using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using bsn.CashCtrl;

using CashCtrl.PathHandlers;

namespace CashCtrl {
	[CmdletProvider("CashCtrl", ProviderCapabilities.Credentials)]
	public class CashCtrlProvider: NavigationCmdletProvider {
		protected override ProviderInfo Start(ProviderInfo providerInfo) {
			#warning Implement initialisation, such as registering FormatViewDefinitions
			return base.Start(providerInfo);
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

		protected override bool IsValidPath(string path) {
			return this.TryParsePath(path, out _);
		}

		private bool TryParsePath(string pathString, out CashCtrlPath path) {
			return new CashCtrlRootHandler(this.PSDriveInfo.Root).TryParsePath(pathString, out path);
		}

		private CashCtrlPath ParsePath(string pathString) {
			if (this.TryParsePath(pathString, out var path)) {
				return path;
			}
			throw new ArgumentException("The path is not valid for CashCtrl: " + pathString, nameof(pathString));
		}

		private CashCtrlClient Client => (this.PSDriveInfo as CashCtrlPSDriveInfo)?.Client ?? throw new InvalidOperationException("No CashCtrl client associated to drive");

		protected override void GetItem(string pathString) {
			var path = this.ParsePath(pathString);
			this.WriteItemObject(path.Handler.GetItemValue(this.Client), path.ToString(), path.Handler.IsContainer);
		}

		protected override void SetItem(string pathString, object value) {
			var path = this.ParsePath(pathString);
			var setter = path.Handler.GetItemSetter(this.Client, value);
			if (this.ShouldProcess(pathString, nameof(this.SetItem))) {
				setter();
			}
		}

		protected override bool ItemExists(string pathString) {
			return this.TryParsePath(pathString, out var path) && path.Handler.Exists(this.Client);
		}

		protected override void GetChildItems(string pathString, bool recurse) {
			var path = this.ParsePath(pathString);
			var queue = new Queue<(CashCtrlPath Path, CashCtrlPathHandler Handler)>(path.Handler.GetAllChildHandlers(this.Client).Select(h => (path, h)));
			while (queue.Count > 0) {
				var child = queue.Dequeue();
				this.WriteItemObject(child.Handler.GetItemValue(this.Client), child.Path.ToString(), child.Handler.IsContainer);
				if (recurse) {
					foreach (var childHandler in child.Handler.GetAllChildHandlers(this.Client)) {
						queue.Enqueue((child.Path.Append(child.Handler), childHandler));
					}
				}
			}
		}

		protected override void GetChildNames(string pathString, ReturnContainers returnContainers) {
			var path = this.ParsePath(pathString);
			foreach (var childHandler in path.Handler.GetAllChildHandlers(this.Client)) {
				this.WriteItemObject(childHandler.Name, path.ToString(), childHandler.IsContainer);
			}
		}

		protected override bool HasChildItems(string pathString) {
			return this.ParsePath(pathString).Handler.GetAllChildHandlers(this.Client).Any();
		}

		protected override void NewItem(string pathString, string itemTypeName, object newItemValue) {
			var path = this.ParsePath(pathString);
			var creator = path.Handler.GetChildItemCreator(this.Client, newItemValue);
			if (this.ShouldProcess(path.ToString(), nameof(this.NewItem))) {
				creator();
			}
		}

		protected override void RemoveItem(string pathString, bool recurse) {
			if (recurse) {
				throw new NotSupportedException();
			}
			var path = this.ParsePath(pathString);
			var remover = path.Handler.GetItemRemover(this.Client);
			if (this.ShouldProcess(path.ToString(), nameof(this.RemoveItem))) {
				remover();
			}
		}

		protected override bool IsItemContainer(string pathString) {
			var path = this.ParsePath(pathString);
			return path.Handler.IsContainer;
		}
/*
		protected override string GetChildName(string pathString) {
			if (pathString.StartsWith(this.PSDriveInfo.Root, StringComparison.OrdinalIgnoreCase)) {
				pathString = pathString.Substring(this.PSDriveInfo.Root.Length);
			}
			return pathString.Split(CashCtrlPathHandler.PathSeparators, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
		}

		protected override string GetParentPath(string pathString, string root) {
			var path = this.ParsePath(pathString);
			if (!string.IsNullOrEmpty(root)) {
				var rootPath = this.ParsePath(root);
				if (rootPath.Count > path.Count) {
					return null;
				}
				if (!rootPath.Names.SequenceEqual(path.Names.Take(rootPath.Count), StringComparer.OrdinalIgnoreCase)) {
					return null;
				}
			}
			return path.Parent().ToString();
		}

		protected override string MakePath(string parent, string child) {
			if (string.IsNullOrEmpty(parent)) {
				return string.Empty;
			}
			return string.IsNullOrEmpty(child) ? parent : parent + CashCtrlPathHandler.PathSeparator + child;
		}

		protected override string NormalizeRelativePath(string path, string basePath) {
			return this.ParsePath(string.IsNullOrEmpty(basePath) ? path : this.MakePath(basePath, path)).ToString();
		}
*/
	}
}
