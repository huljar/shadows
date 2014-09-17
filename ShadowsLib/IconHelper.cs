using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;

using ShadowsLib;

namespace Etier.IconHelper {
    /// <summary>
    /// Provides static methods to read system icons for both folders and files.
    /// </summary>
    /// <example>
    /// <code>IconReader.GetFileIcon("c:\\general.xls");</code>
    /// </example>
    public class IconReader {
        /// <summary>
        /// Options to specify the size of icons to return.
        /// </summary>
        public enum IconSize {
            /// <summary>
            /// Specify large icon - 32 pixels by 32 pixels.
            /// </summary>
            Large = 0,
            /// <summary>
            /// Specify small icon - 16 pixels by 16 pixels.
            /// </summary>
            Small = 1
        }

        /// <summary>
        /// Options to specify whether folders should be in the open or closed state.
        /// </summary>
        public enum FolderType {
            /// <summary>
            /// Specify open folder.
            /// </summary>
            Open = 0,
            /// <summary>
            /// Specify closed folder.
            /// </summary>
            Closed = 1
        }

        /// <summary>
        /// Returns an icon for a given file - indicated by the name parameter.
        /// </summary>
        /// <param name="name">Pathname for file.</param>
        /// <param name="size">Large or small</param>
        /// <param name="linkOverlay">Whether to include the link icon</param>
        /// <returns>System.Drawing.Icon</returns>
        public static System.Drawing.Icon GetFileIcon(string name, IconSize size, bool linkOverlay) {
            NativeMethods.Shell32.SHFILEINFO shfi;
            uint flags = NativeMethods.Shell32.SHGFI_ICON | NativeMethods.Shell32.SHGFI_USEFILEATTRIBUTES;

            if(true == linkOverlay) flags += NativeMethods.Shell32.SHGFI_LINKOVERLAY;

            /* Check the size specified for return. */
            if(IconSize.Small == size) {
                flags += NativeMethods.Shell32.SHGFI_SMALLICON;
            }
            else {
                flags += NativeMethods.Shell32.SHGFI_LARGEICON;
            }

            NativeMethods.Shell32.SHGetFileInfo(
                name,
                NativeMethods.Shell32.FILE_ATTRIBUTE_NORMAL,
                out shfi,
                (uint)Marshal.SizeOf(typeof(NativeMethods.Shell32.SHFILEINFO)),
                flags
            );

            // Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
            System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
            NativeMethods.User32.DestroyIcon(shfi.hIcon); // Cleanup
            return icon;
        }

        /// <summary>
        /// Used to access system folder icons.
        /// </summary>
        /// <param name="size">Specify large or small icons.</param>
        /// <param name="folderType">Specify open or closed FolderType.</param>
        /// <returns>System.Drawing.Icon</returns>
        public static System.Drawing.Icon GetFolderIcon(IconSize size, FolderType folderType) {
            // Need to add size check, although errors generated at present!
            uint flags = NativeMethods.Shell32.SHGFI_ICON | NativeMethods.Shell32.SHGFI_USEFILEATTRIBUTES;

            if(FolderType.Open == folderType) {
                flags += NativeMethods.Shell32.SHGFI_OPENICON;
            }

            if(IconSize.Small == size) {
                flags += NativeMethods.Shell32.SHGFI_SMALLICON;
            }
            else {
                flags += NativeMethods.Shell32.SHGFI_LARGEICON;
            }

            // Get the folder icon
            NativeMethods.Shell32.SHFILEINFO shfi;
            NativeMethods.Shell32.SHGetFileInfo(
                "AnyNonEmptyStringWillDo",
                NativeMethods.Shell32.FILE_ATTRIBUTE_DIRECTORY,
                out shfi,
                (uint)Marshal.SizeOf(typeof(NativeMethods.Shell32.SHFILEINFO)),
                flags
            );

            System.Drawing.Icon.FromHandle(shfi.hIcon);	// Load the icon from an HICON handle

            // Now clone the icon, so that it can be successfully stored in an ImageList
            System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();

            NativeMethods.User32.DestroyIcon(shfi.hIcon); // Cleanup
            return icon;
        }
    }

}

