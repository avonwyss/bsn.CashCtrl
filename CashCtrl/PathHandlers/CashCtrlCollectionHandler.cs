using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;

using bsn.CashCtrl;
using bsn.CashCtrl.Entities;
using bsn.CashCtrl.Query;

using OneOf;

namespace CashCtrl.PathHandlers {
	internal abstract class CashCtrlCollectionHandler<TEntity>: CashCtrlCollectionHandler<TEntity, QueryBase> where TEntity: EntityBase {
		protected CashCtrlCollectionHandler(string name, params CashCtrlPathHandler[] nestedHandlers): base(name, nestedHandlers) { }
	}

	internal abstract class CashCtrlCollectionHandler<TEntity, TQuery>: CashCtrlContainerHandler where TEntity: EntityBase
	                                                                                             where TQuery: QueryBase, new() {
		private const string FullParameterName = "Full";
		private static readonly Regex RxQueryNonFiltering = new(@"^(start|limit|sort|dir)$", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

		private static readonly PropertyInfo[] QueryProperties = typeof(TQuery)
				.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				.Where(p => p.IsDefined(typeof(DescriptionAttribute), true))
				.ToArray();

		public static bool TryParseId(string name, out int id) {
			return int.TryParse(name, NumberStyles.None, CultureInfo.InvariantCulture, out id) && id > 0;
		}

		protected CashCtrlCollectionHandler(string name, params CashCtrlPathHandler[] nestedHandlers): base(name, nestedHandlers) { }

		public override IEnumerable<CashCtrlPathHandler> GetChildHandlers(CashCtrlClient client, object parameters) {
			var query = default(TQuery);
			var full = false;
			if (parameters != null) {
				query = this.ParametersToQuery(parameters, out full);
			}
			if (query == null || !query.ToParameters().Any(static p => !RxQueryNonFiltering.IsMatch(p.Key) && p.Value != null)) {
				// Only return static handlers when the query is not filtering the results
				foreach (var childHandler in base.GetChildHandlers(client, parameters)) {
					yield return childHandler;
				}
			}
			foreach (var entity in this.ListEntities(client, query)) {
				yield return this.GetEntityHandler(full && entity.Partial ? OneOf<int, TEntity>.FromT0(entity.Id) : OneOf<int, TEntity>.FromT1(entity));
			}
		}

		public override object GetChildHandlersDynamicParameters() {
			var runtimeDefinedParametersDictionary = new RuntimeDefinedParameterDictionary();
			if (typeof(TQuery) != typeof(QueryBase)) {
				// Add the dynamic parameter to a dictionary
				foreach (var property in QueryProperties) {
					runtimeDefinedParametersDictionary.Add(property.Name, new(property.Name, property.PropertyType, new() {
							new ParameterAttribute {
									Mandatory = false,
									HelpMessage = property.GetCustomAttribute<DescriptionAttribute>().Description
							}
					}));
				}
			}
			runtimeDefinedParametersDictionary.Add(FullParameterName, new(FullParameterName, typeof(SwitchParameter), new() {
					new ParameterAttribute {
							Mandatory = false
					}
			}));
			return runtimeDefinedParametersDictionary;
		}

		public override Action GetChildItemCreator(CashCtrlClient client, object value, object parameters) {
			return this.GetEntityHandler(0).GetItemSetter(client, value, parameters);
		}

		protected abstract CashCtrlEntityHandler<TEntity> GetEntityHandler(OneOf<int, TEntity> idOrEntity);

		protected abstract IEnumerable<TEntity> ListEntities(CashCtrlClient client, TQuery query);

		private TQuery ParametersToQuery(object parameters, out bool full) {
			if (parameters is not RuntimeDefinedParameterDictionary parameterDictionary) {
				full = false;
				return null;
			}
			var result = new TQuery();
			foreach (var property in QueryProperties) {
				if (parameterDictionary.TryGetValue(property.Name, out var parameter) && parameter.IsSet) {
					property.SetValue(result, parameter.Value);
				}
			}
			full = parameterDictionary.TryGetValue(FullParameterName, out var fullParameter) && fullParameter.IsSet && Equals(fullParameter.Value, true);
			return result;
		}

		public override bool TryGetChildHandler(string name, out CashCtrlPathHandler handler) {
			if (base.TryGetChildHandler(name, out handler)) {
				return true;
			}
			if (TryParseId(name, out var id)) {
				handler = this.GetEntityHandler(id);
				return true;
			}
			return false;
		}
	}
}
