using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;


namespace NijnCoach.View.Avatar
{
    class AvatarPanel: Panel
    {
        /*
         * With help of:
         * http://stackoverflow.com/questions/12653418/why-cant-i-embed-these-applications-in-my-form
         */

        private const String eCoachPath = "C:\\ecoach\\ecoach-bart.exe";
        private Process Task = null;
        private IntPtr AvatarHandle = new IntPtr();
        private System.Windows.Forms.Timer t;
        private int borderWidth = 120;
        private int borderHeight = 80;


        public AvatarPanel()
        {
            killProcess();
            Task = Process.Start(eCoachPath);
            Task.WaitForInputIdle();
            IntPtr Handle = IntPtr.Zero;
            for (int i = 0; Handle == IntPtr.Zero && i < 10; i++) { Handle = Task.MainWindowHandle; Thread.Sleep(100); }
            ShowWindowAsync(Handle, 0);
            AvatarHandle = FindCoachWindow();
            Thread.Sleep(500);
            SetParent(AvatarHandle, this.Handle);
            SetWindowLong(AvatarHandle, GWL_STYLE, (int)(~WS_VISIBLE & ((WS_MAXIMIZE | WS_BORDER) | WS_CHILD)));
            MoveWindow(AvatarHandle, -borderWidth, -borderHeight, this.Width + 2 * borderWidth, this.Height + 2 * borderHeight, true);
            this.Disposed += new EventHandler(closeAvatarPanel);
            t = new System.Windows.Forms.Timer();
            t.Interval = 6000;
            t.Tick += new EventHandler(avatarReady);
            t.Enabled = true;
            //this.Paint += avatarPaint;
        }

        private void avatarReady(object sender, EventArgs e)
        {
            t.Enabled = false;
            captureAvatarInPanel();
        }

        

        private void captureAvatarInPanel()
        {
            const int VK_F2 = 0x71;
            const int WM_KEYDOWN = 0x100;
            SendMessage(AvatarHandle, WM_KEYDOWN, VK_F2, 0);
            Thread.Sleep(500);
            SetParent(AvatarHandle, this.Handle);
            SetWindowLong(AvatarHandle, GWL_STYLE, (int)(WS_VISIBLE | WS_CHILD));
            MoveWindow(AvatarHandle, -borderWidth, -borderHeight, this.Width + 2 * borderWidth, this.Height + 2 * borderHeight, true);

            this.Resize += new EventHandler(delegate(object sender2, EventArgs e2) { MoveWindow(AvatarHandle, -borderWidth, -borderHeight, this.Width + 2 * borderWidth, this.Height + 2 * borderHeight, true); });
            ShowWindowAsync(AvatarHandle, 1);
        }

        private void avatarPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath buttonPath =
       new System.Drawing.Drawing2D.GraphicsPath();
            // Set a new rectangle to the same size as the button's 
            // ClientRectangle property.
            System.Drawing.Rectangle newRectangle = this.ClientRectangle;

            // Decrease the size of the rectangle.
            //newRectangle.Inflate(-borderWidth, -borderHeight);


            // Create a circle within the new rectangle.
            buttonPath.AddRectangle(newRectangle);

            // Set the button's Region property to the newly created 
            // circle region.
            this.Region = new System.Drawing.Region(buttonPath);
            
        }

        private void closeAvatarPanel(object sender, EventArgs e)
        {
            SendMessage(AvatarHandle, 83, 0, 0);
            Thread.Sleep(100);
            AvatarHandle = IntPtr.Zero;
            Task.Close();
            killProcess();
        }

        /// <summary>
        /// Provides a handle to the ecoach window
        /// Will wait indefinitely until the window exists
        /// </summary>
        /// <returns>a handle to the ecoach window</returns>
        private IntPtr FindCoachWindow()
        {
            IntPtr id = new IntPtr();
            while (id.Equals(new IntPtr()))
            {
                EnumWindows(delegate(IntPtr hwnd, IntPtr data1)
                {
                    int pid = GetProcessId(hwnd);
                    StringBuilder sb1 = new StringBuilder(1024);
                    GetClassName(hwnd, sb1, sb1.Capacity);
                    Debug.WriteLine(sb1.ToString());
                    if (sb1.ToString().StartsWith("winviz"))
                    {
                        id = hwnd;
                        return false;
                    }
                    return true;
                }, id);
            }
            return id;
        }

        /// <summary>
        /// Kill the processes that are created to display the avatar
        /// </summary>
        private void killProcess()
        {
            string NameECoach = Path.GetFileName(Path.GetDirectoryName(eCoachPath));
            string winviz = "winviz";
            foreach (Process Task in Process.GetProcesses())
            {
                String task = Path.GetFileName(Path.GetDirectoryName((Task.ProcessName)));
                if (task.Contains(NameECoach) || task.Contains(winviz))
                {
                    try { Task.Kill(); }
                    catch (Exception e) { }
                }
            }
        }

        #region
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr data);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr data);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int GetProcessId(IntPtr hWnd);
        
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr Handle, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr Handle, int x, int y, int w, int h, bool repaint);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        const int GWL_STYLE = -16;
        const long WS_VISIBLE = 0x10000000,
                    WS_MAXIMIZE = 0x01000000,
                    WS_BORDER = 0x00800000,
                    WS_CHILD = 0x40000000,
                    WS_MINIMIZE = 0x20000000,
                    WS_CAPTION = 0x00C0000;
        #endregion
    }
}
