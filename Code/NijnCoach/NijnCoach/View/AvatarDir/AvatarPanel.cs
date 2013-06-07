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


namespace NijnCoach.View.AvatarDir
{
    public class AvatarPanel: Panel
    {
        /*
         * With help of:
         * http://stackoverflow.com/questions/12653418/why-cant-i-embed-these-applications-in-my-form
         */
        private static int avatarCount = 0;
        private static Process Task = null;
        private static IntPtr desktopHandle = new IntPtr();
        private static IntPtr AvatarHandle = new IntPtr();
        private static System.Windows.Forms.Timer t;
        private static Boolean isFullScreen = true;
        private const String eCoachPath = "C:\\ecoach\\ecoach-bart.exe";

        private int borderWidth;
        private int borderHeight;
        private Boolean _fullyLoaded = false;

        /// <summary>
        /// Make a new panel for an avatar. If the avatar has not been displayed before,
        /// a new avatarprocess is started, otherwise, the already started process is used
        /// </summary>
        /// <param name="width">the width of the view rectangle</param>
        /// <param name="height">the height of the view rectangle (may be useless with scaling)</param>
        public AvatarPanel(int width = 200, int height = 100)
        {
            borderWidth = (int)(System.Windows.SystemParameters.PrimaryScreenWidth - width) / 2;
            borderHeight = (int)(System.Windows.SystemParameters.PrimaryScreenHeight - height) / 2;
            if (Task == null)
            {
                initECoachProcess();
            }
            else
            {
                captureAvatarInPanel();
            }
        }

        /// <summary>
        /// Start the eCoach-process and make it invissible
        /// </summary>
        private void initECoachProcess()
        {
            killProcess();
            try
            {
                Task = Process.Start(eCoachPath);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while trying to start the avatar\nDoes the file C:\\ecoach\\ecoach-bart.exe exists?", "Error loading the avatar");
                NijnCoach.View.Main.MainForm._loadAvatar = false;
                return;
            }
            Task.WaitForInputIdle();
            IntPtr Handle = IntPtr.Zero;
            for (int i = 0; Handle == IntPtr.Zero && i < 10; i++) { Handle = Task.MainWindowHandle; Thread.Sleep(100); }
            SetParent(Handle, this.Handle);
            ShowWindow(Handle, 11);
            AvatarHandle = FindCoachWindow();
            Thread.Sleep(500);
            ShowWindow(AvatarHandle, 11);
            Thread.Sleep(500);

            desktopHandle = SetParent(AvatarHandle, this.Handle);
            SetWindowLong(AvatarHandle, GWL_STYLE, (int)(~WS_VISIBLE & ((WS_MAXIMIZE | WS_BORDER) | WS_CHILD)));

            t = new System.Windows.Forms.Timer();
            t.Interval = 20000;
            t.Tick += new EventHandler(avatarReady);
            t.Enabled = true;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(closeECoachProcess);
        }

        /// <summary>
        /// Timer eventhandler, executed when the avatarprocess is fully loaded
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void avatarReady(object sender, EventArgs e)
        {
            t.Enabled = false;
            captureAvatarInPanel();
        }

        /// <summary>
        /// Close the avatar process
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void closeECoachProcess(object sender, EventArgs e)
        {
            SendMessage(AvatarHandle, 83, 0, 0);
            Thread.Sleep(100);
            AvatarHandle = IntPtr.Zero;
            Task.Close();
            killProcess();
        }

        /// <summary>
        /// Replace the avatar window in this panel
        /// </summary>
        private void captureAvatarInPanel()
        {
            if (isFullScreen)
            {
                const int VK_F2 = 0x71;
                const int WM_KEYDOWN = 0x100;
                SendMessage(AvatarHandle, WM_KEYDOWN, VK_F2, 0);
                Thread.Sleep(500);
                isFullScreen = false;
            }
            SetParent(AvatarHandle, this.Handle);
            SetWindowLong(AvatarHandle, GWL_STYLE, (int)(WS_VISIBLE | WS_CHILD));
            MoveWindow(AvatarHandle, -borderWidth, -borderHeight, this.Width + 2 * borderWidth, this.Height + 2 * borderHeight, true);

            this.Resize += new EventHandler(delegate(object sender2, EventArgs e2) { MoveWindow(AvatarHandle, -borderWidth, -borderHeight, this.Width + 2 * borderWidth, this.Height + 2 * borderHeight, true); });
            ShowWindow(AvatarHandle, 9);
            _fullyLoaded = true;
            avatarCount++;
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
                String task = Task.ProcessName;
                if (task.Contains(NameECoach) || task.Contains(winviz))
                {
                    try { Task.Kill(); }
                    catch (Exception e) { }
                }
            }
        }

        public Boolean fullyLoaded
        {
            get { return _fullyLoaded; }
        }

        public static void unParentAvatar()
        {
            avatarCount--;
            if (avatarCount <= 0)
            {
                ShowWindow(AvatarHandle, 11);
                SetWindowLong(AvatarHandle, GWL_STYLE, (int)(~WS_VISIBLE & ((WS_MAXIMIZE | WS_BORDER) & ~WS_CHILD)));
                SetParent(AvatarHandle, desktopHandle);
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

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

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
