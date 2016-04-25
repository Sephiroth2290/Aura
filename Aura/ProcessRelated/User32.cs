using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Aura.ProcessRelated
{
    internal static class User32
    {
        [DllImport("user32.dll")]
        internal static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowRect(IntPtr hWnd, ref User32.RECT lpRect);

        internal static string GetWindowText(IntPtr hWnd)
        {
            StringBuilder lpString = new StringBuilder(User32.GetWindowTextLength(hWnd) + 1);
            User32.GetWindowText(hWnd, lpString, lpString.Capacity);
            return lpString.ToString();
        }

        [DllImport("user32.dll")]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern int SetWindowText(IntPtr hWnd, string text);

        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
