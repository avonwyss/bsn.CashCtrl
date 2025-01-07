using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Text.RegularExpressions;

using bsn.CashCtrl;

using CashCtrl.PathHandlers;

namespace CashCtrl {
	[CmdletProvider("CashCtrl", ProviderCapabilities.Credentials | ProviderCapabilities.ShouldProcess)]
	public class CashCtrlProvider: NavigationCmdletProvider {
		private CashCtrlClient Client => (this.PSDriveInfo as CashCtrlPSDriveInfo)?.Client ?? throw new InvalidOperationException("No CashCtrl client associated to drive");

		protected override void GetChildItems(string pathString, bool recurse) {
			var path = this.ParsePath(pathString);
			var queue = new Queue<(CashCtrlPath Path, CashCtrlPathHandler Handler)>(path.Handler.GetChildHandlers(this.Client, this.DynamicParameters).Select(h => (path, h)));
			while (queue.Count > 0) {
				var child = queue.Dequeue();
				this.WriteItemObject(child.Handler.GetItemValue(this.Client), child.Path.ToString(), child.Handler.IsContainer);
				if (recurse) {
					foreach (var childHandler in child.Handler.GetChildHandlers(this.Client, null)) {
						queue.Enqueue((child.Path.Append(child.Handler), childHandler));
					}
				}
			}
		}

		protected override object GetChildItemsDynamicParameters(string pathString, bool recurse) {
			return this.TryParsePath(pathString, out var path) ? path.Handler.GetChildHandlersDynamicParameters() : null;
		}

		protected override void GetChildNames(string pathString, ReturnContainers returnContainers) {
			var path = this.ParsePath(pathString);
			foreach (var childHandler in path.Handler.GetChildHandlers(this.Client, this.DynamicParameters)) {
				this.WriteItemObject(childHandler.Name, path.ToString(), childHandler.IsContainer);
			}
		}

		protected override object GetChildNamesDynamicParameters(string pathString) {
			return this.TryParsePath(pathString, out var path) ? path.Handler.GetChildHandlersDynamicParameters() : null;
		}

		protected override void GetItem(string pathString) {
			var path = this.ParsePath(pathString);
			this.WriteItemObject(path.Handler.GetItemValue(this.Client), path.ToString(), path.Handler.IsContainer);
		}

		protected override bool HasChildItems(string pathString) {
			return this.ParsePath(pathString).Handler.GetChildHandlers(this.Client, null).Any();
		}

		protected override bool IsItemContainer(string pathString) {
			var path = this.ParsePath(pathString);
			return path.Handler.IsContainer;
		}

		protected override bool IsValidPath(string path) {
			return this.TryParsePath(path, out _);
		}

		protected override bool ItemExists(string pathString) {
			return this.TryParsePath(pathString, out var path) && path.Handler.Exists(this.Client);
		}

		protected override PSDriveInfo NewDrive(PSDriveInfo drive) {
			if (drive == null) {
				this.WriteError(new(
						new ArgumentNullException("drive"),
						"NullDrive",
						ErrorCategory.InvalidArgument,
						null)
				);
				return null;
			}
			if (string.IsNullOrEmpty(drive.Root) || !Regex.IsMatch(drive.Root, @"^[a-z]+$")) {
				this.WriteError(new(
						new ArgumentException("drive.Root"),
						"NoRoot",
						ErrorCategory.InvalidArgument,
						drive)
				);
				return null;
			}
			if (string.IsNullOrEmpty(drive.Credential?.UserName)) {
				this.WriteError(new(
						new ArgumentException("drive.Credential.UserName"),
						"NoCredential",
						ErrorCategory.InvalidArgument,
						drive)
				);
				return null;
			}
			var cashCtrlClient = new CashCtrlClient(drive.Root, drive.Credential.UserName);
			return new CashCtrlPSDriveInfo(drive, cashCtrlClient);
		}

		protected override void NewItem(string pathString, string itemTypeName, object newItemValue) {
			var path = this.ParsePath(pathString);
			var creator = path.Handler.GetChildItemCreator(this.Client, newItemValue, this.DynamicParameters);
			if (this.ShouldProcess(path.ToString(), nameof(this.NewItem))) {
				creator();
			}
		}

		protected override object NewItemDynamicParameters(string pathString, string itemTypeName, object newItemValue) {
			return this.TryParsePath(pathString, out var path) ? path.Handler.GetItemCreateDynamicParameters() : null;
		}

		private CashCtrlPath ParsePath(string pathString) {
			if (this.TryParsePath(pathString, out var path)) {
				return path;
			}
			throw new ArgumentException("The path is not valid for CashCtrl: " + pathString, nameof(pathString));
		}

		protected override PSDriveInfo RemoveDrive(PSDriveInfo drive) {
			if (drive == null) {
				this.WriteError(new(
						new ArgumentNullException("drive"),
						"NullDrive",
						ErrorCategory.InvalidArgument,
						null)
				);
				return null;
			}
			if (!(drive is CashCtrlPSDriveInfo cashCtrlDrive)) {
				return null;
			}
			cashCtrlDrive.Client.Dispose();
			return cashCtrlDrive;
		}

		protected override void RemoveItem(string pathString, bool recurse) {
			if (recurse) {
				throw new NotSupportedException();
			}
			var path = this.ParsePath(pathString);
			var remover = path.Handler.GetItemRemover(this.Client, this.DynamicParameters);
			if (this.ShouldProcess(path.ToString(), nameof(this.RemoveItem))) {
				remover();
			}
		}

		protected override object RemoveItemDynamicParameters(string pathString, bool recurse) {
			return this.TryParsePath(pathString, out var path) ? path.Handler.GetItemRemoveDynamicParameters() : null;
		}

		protected override void SetItem(string pathString, object value) {
			var path = this.ParsePath(pathString);
			var setter = path.Handler.GetItemSetter(this.Client, value, this.DynamicParameters);
			if (this.ShouldProcess(pathString, nameof(this.SetItem))) {
				setter();
			}
		}

		protected override object SetItemDynamicParameters(string pathString, object value) {
			return this.TryParsePath(pathString, out var path) ? path.Handler.GetItemSetDynamicParameters() : null;
		}

		protected override ProviderInfo Start(ProviderInfo providerInfo) {
#warning Implement initialisation, such as registering FormatViewDefinitions
			return base.Start(providerInfo);
		}

		private bool TryParsePath(string pathString, out CashCtrlPath path) {
			return new CashCtrlRootHandler(this.PSDriveInfo.Root).TryParsePath(pathString, out path);
		}
	}
}
