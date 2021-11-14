using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace NFS.Commons.WindowClose
{
    public class CloseWindow
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr GetParent(IntPtr hWnd);

        //I'd double check this constant, just in case
        static uint WM_CLOSE = 0x10;

        public void CloseContainingWindow(Visual visual)
        {
            // Find the containing HWND for the Visual in question
            HwndSource wpfHandle = PresentationSource.FromVisual(visual) as HwndSource;
            if (wpfHandle == null)
            {
                throw new Exception("Could not find Window handle");
            }

            // Trace up the window chain, to find the ultimate parent
            IntPtr hWindow = wpfHandle.Handle;
            while (true)
            {
                IntPtr parentHWindow = GetParent(hWindow);
                if (parentHWindow == (IntPtr)0) break;
                hWindow = parentHWindow;
            }

            // Now send the containing window a close message
            SendMessage(hWindow, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
