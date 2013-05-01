using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace NijnCoach.Avatar
{
    public partial class VizardBox : UserControl
    {
        public String VizardAdditionalStartupArguments
        {
            get { return (String)GetValue(VizardAdditionalStartupArgumentsProperty); }
            set { SetValue(VizardAdditionalStartupArgumentsProperty, value); }
        }
        public bool VizardConsole
        {
            get { return (bool)GetValue(VizardConsoleProperty); }
            set { SetValue(VizardConsoleProperty, value); }
        }
        public String VizardScript
        {
            get { return (String)GetValue(VizardScriptProperty); }
            set { SetValue(VizardScriptProperty, value); }
        }
        public String VizardInstallation
        {
            get { return (String)GetValue(VizardInstallationProperty); }
            set { SetValue(VizardInstallationProperty, value); }
        }
        public static readonly DependencyProperty VizardAdditionalStartupArgumentsProperty = DependencyProperty.Register("VizardAdditionalStartupArguments", typeof(String), typeof(VizardBox), new UIPropertyMetadata(""));
        public static readonly DependencyProperty VizardConsoleProperty = DependencyProperty.Register("VizardConsole", typeof(bool), typeof(VizardBox), new UIPropertyMetadata(false));
        public static readonly DependencyProperty VizardScriptProperty = DependencyProperty.Register("VizardScript", typeof(String), typeof(VizardBox), new UIPropertyMetadata(""));
        public static readonly DependencyProperty VizardInstallationProperty = DependencyProperty.Register("VizardInstallation", typeof(String), typeof(VizardBox), new UIPropertyMetadata("C:\\Program Files (x86)\\WorldViz\\Vizard30\\bin\\winviz.exe"));


        avatarHwndHost vh;
        public VizardBox()
        {
            InitializeComponent();
        }
        public void Go()
        {
            vh = new avatarHwndHost();
            _hostborder.Child = vh;
            vh.go(VizardScript, VizardInstallation, VizardAdditionalStartupArguments, VizardConsole);
        }

        public void Stop()
        {
            _hostborder.Child = null;
            vh.stop();
        }
    }

    class avatarHwndHost : HwndHost
    {
        IntPtr hwndVizardHandle;
        Process vizardProc;
        ~avatarHwndHost()
        {
            stop();
            DestroyWindow(hwndVizardHandle);
        }
        public void stop()
        {
            if (vizardProc != null)
                if(!vizardProc.HasExited)
                    vizardProc.Kill();
        }
        public void go(string script, string vizardLocation, string additionalStartupArguments, bool console)
        {
            vizardProc = new Process();
            vizardProc.StartInfo.FileName = vizardLocation;
            vizardProc.StartInfo.Arguments = (console? "-console" : "") + " \"" + script + "\" " + hwndVizardHandle.ToString() + " " + additionalStartupArguments;
            vizardProc.Start();
        }
        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            hwndVizardHandle = IntPtr.Zero;
            hwndVizardHandle = CreateWindowEx(0, "static", "",
                                      WS_CHILD | WS_VISIBLE,
                                      0, 0,
                                      0, 0,
                                      hwndParent.Handle,
                                      (IntPtr)HOST_ID,
                                      IntPtr.Zero,
                                      0);
            return new HandleRef(this, hwndVizardHandle);
        }
        protected override IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            handled = false;
            return IntPtr.Zero;
        }
        public void setFocus()
        {
            SetFocus(hwndVizardHandle);
        }
        protected override void DestroyWindowCore(HandleRef hwnd)
        {
            DestroyWindow(hwnd.Handle);
        }
        //PInvoke declarations
        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateWindowEx(int dwExStyle,
                                                      string lpszClassName,
                                                      string lpszWindowName,
                                                      int style,
                                                      int x, int y,
                                                      int width, int height,
                                                      IntPtr hwndParent,
                                                      IntPtr hMenu,
                                                      IntPtr hInst,
                                                      [MarshalAs(UnmanagedType.AsAny)] object pvParam);
        [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Unicode)]
        internal static extern bool DestroyWindow(IntPtr hwnd);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        static extern IntPtr SetFocus(IntPtr hWnd);
        internal const int
          WS_CHILD =       0x40000000,
          WS_VISIBLE =     0x10000000,
          LBS_NOTIFY =     0x00000001,
          HOST_ID =        0x00000002;
    }
}
