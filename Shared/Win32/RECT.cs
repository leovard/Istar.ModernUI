using System.Runtime.InteropServices;

namespace Istar.ModernUI.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Rect
    {
        public int left, top, right, bottom;
    }
}
