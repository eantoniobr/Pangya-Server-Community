using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Security.Permissions;
using System.IO;

namespace PangyaAPI.PAK
{
    // The CharSet must match the CharSet of the corresponding PInvoke signature
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WIN32_FIND_DATA
    {
        public FileAttributes dwFileAttributes;
        public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public uint dwReserved0;
        public uint dwReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;
    }

    [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
    public static class Win32
    {
       public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        // http://www.pinvoke.net/default.aspx/kernel32.findfirstfile
        public static IntPtr FindFirstFile(string path, out WIN32_FIND_DATA findData)
        {
            return NativeMethods.FindFirstFile(path, out findData);
        }

        public static bool FindNextFile(IntPtr findHandle, out WIN32_FIND_DATA findData)
        {
            return NativeMethods.FindNextFile(findHandle, out findData);        
        }
        public static bool FindClose(IntPtr close)
        { 
        return NativeMethods.FindClose(close);
        }
        private static class NativeMethods
        {
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool FindClose(IntPtr hFindFile);

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);
        }
    }
}