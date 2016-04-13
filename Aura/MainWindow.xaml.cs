using System;
using Aura;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace Aura
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region DLLImports


        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
   UInt32 dwDesiredAccess,
   Int32 bInheritHandle,
   Int32 dwProcessId
   );

        [DllImport("kernel32")]
        public static extern IntPtr CreateRemoteThread(
 IntPtr hProcess,
 IntPtr lpThreadAttributes,
 uint dwStackSize,
 UIntPtr lpStartAddress, // raw Pointer into remote process
 IntPtr lpParameter,
 uint dwCreationFlags,
 out IntPtr lpThreadId
);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(
       IntPtr hObject
       );

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool VirtualFreeEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            UIntPtr dwSize,
            uint dwFreeType
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern UIntPtr GetProcAddress(
            IntPtr hModule,
            string procName
            );

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            uint dwSize,
            uint flAllocationType,
            uint flProtect
            );

        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            string lpBuffer,
            UIntPtr nSize,
            out IntPtr lpNumberOfBytesWritten
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(
            string lpModuleName
            );

        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        internal static extern Int32 WaitForSingleObject(
            IntPtr handle,
            Int32 milliseconds
            );

        #endregion

        private WindowSettings settingsWindow;
        public MainWindow()
        {
            InitializeComponent();
            Settings.Load();
            Settings.Save();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            DragMove();  //Allows you to drag the window from anywhere.
        }

        private void btnLaunch_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(Settings.DarkAgesPath))
            {
                int num = (int)MessageBox.Show(Settings.DarkAgesPath + " could not be located.", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                StartupInfo structure = new StartupInfo();
                StartupInfo startupInfo = new StartupInfo()
                {
                    Size = Marshal.SizeOf(structure)
                };
                ProcessInformation processInfo;
                Kernel32.CreateProcess(Settings.DarkAgesPath, null, IntPtr.Zero, IntPtr.Zero, false, ProcessCreationFlags.Suspended, IntPtr.Zero, null, ref startupInfo, out processInfo);

                //get process id from pinfo
                //Process processById = Process.GetProcessById(processInfo.ProcessId);
                //open that process at this memory location
                //IntPtr hProcess = OpenProcess(0x1F0FFF, 1, processById.Id);
                //inject dawnd
                //InjectDLL(hProcess, Settings.DarkAgesDirectory + "\\dawnd.dll");


                using (ProcessMemoryStream processMemoryStream = new ProcessMemoryStream(processInfo.ProcessId, ProcessAccess.VmOperation | ProcessAccess.VmRead | ProcessAccess.VmWrite))
                {
                    //skip intro
                    processMemoryStream.Seek(0x0042E625, SeekOrigin.Begin);
                    processMemoryStream.WriteByte(0x90);
                    processMemoryStream.WriteByte(0x90);
                    processMemoryStream.WriteByte(0x90);
                    processMemoryStream.WriteByte(0x90);
                    processMemoryStream.WriteByte(0x90);
                    processMemoryStream.WriteByte(0x90);

                    //force "socket" - call for direct ip
                    processMemoryStream.Position = 0x004333A2;
                    processMemoryStream.WriteByte(0xEB);

                    //change direct ip to 127.0.0.1
                    processMemoryStream.Position = 0x004333C2;
                    processMemoryStream.WriteByte(106);
                    processMemoryStream.WriteByte(1);
                    processMemoryStream.WriteByte(106);
                    processMemoryStream.WriteByte(0);
                    processMemoryStream.WriteByte(106);
                    processMemoryStream.WriteByte(0);
                    processMemoryStream.WriteByte(106);
                    processMemoryStream.WriteByte(127);

                    processMemoryStream.Position = 0x0057A7D9;  //Multiple Instance
                    processMemoryStream.WriteByte(235);

                    //resume suspended process
                    Kernel32.ResumeThread(processInfo.ThreadHandle);
                }
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {

            if (settingsWindow == null)
            {
                settingsWindow = new WindowSettings();
                settingsWindow.Closed += (a, b) => settingsWindow = null;
                settingsWindow.Show();
            }
            else
            {

                settingsWindow.Show();
            }
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();  //Closes the bot.
        }
    }
}
