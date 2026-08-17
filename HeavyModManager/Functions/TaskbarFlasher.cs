using System;
using System.Runtime.InteropServices;

namespace HeavyModManager.Functions
{
    public static class TaskbarFlasher
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        private const uint FLASHW_ALL = 3;
        private const uint FLASHW_TIMERNOFG = 12;

        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        public static void Flash(IntPtr handle)
        {
            var fw = new FLASHWINFO
            {
                cbSize = (uint)Marshal.SizeOf(typeof(FLASHWINFO)),
                hwnd = handle,
                dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG,
                uCount = uint.MaxValue,
                dwTimeout = 0
            };

            FlashWindowEx(ref fw);
        }

        public static void Stop(IntPtr handle)
        {
            var fw = new FLASHWINFO
            {
                cbSize = (uint)Marshal.SizeOf(typeof(FLASHWINFO)),
                hwnd = handle,
                dwFlags = 0,
                uCount = 0,
                dwTimeout = 0
            };

            FlashWindowEx(ref fw);
        }
    }
}
