using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;
using NDde.Client;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using UIAutomationClient;
using TreeScope = UIAutomationClient.TreeScope;
using System.Windows.Automation;
using System.Runtime.CompilerServices;

namespace Chess
{
    public partial class Form1 : Form
    {

        [DllImport("kernel32.dll",
        EntryPoint = "GetStdHandle",
        SetLastError = true,
        CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll",
        EntryPoint = "AllocConsole",
        SetLastError = true,
        CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();
        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;

        public ChromiumWebBrowser chromeBrowser;
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings
            {
                PersistSessionCookies = true,
                CachePath = @"C:\ChessCache\"
            };
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("http://chess.com");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }
        private readonly CUIAutomation _automation;
        public Form1()
        {
            InitializeComponent();
        }
        private Thread checkThread;
        public static string[] openSites =
        {
                "Test",
        };
        public List<string> siteList = new List<string>(openSites.ToList());
        public void startCheck()
        {
            Hash mainForm = new Hash();
            mainForm.Show();
            checkThread = new Thread(new ThreadStart(check));
            checkThread.Start();
        }
        public void check()
        {
            while (true)
            {
                scanApplications();
                PrintBrowserTabName();
                wait(5000);
            }

        }
        public static void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        public int det = 0;




        List<string> bannedSites = new List<string>();
        public void generateBanSites()
        {
            string nextCMove = "Next Chess";
            string cNextMove = "Chess Next";
            string engine = "Engine";
            string calc = "Chess Calculator";
            bannedSites.Add(nextCMove);
            bannedSites.Add(cNextMove);
            bannedSites.Add(engine);
            bannedSites.Add(calc);
        }


        /*public class FocusChangeHandler : IUIAutomationFocusChangedEventHandler
        {


            private readonly Form1 _listener;

            public FocusChangeHandler(Form1 listener)
            {
                _listener = listener;
            }

            public void HandleFocusChangedEvent(IUIAutomationElement element)
            {
                if (element != null)
                {
                    using (Process process = Process.GetProcessById(element.CurrentProcessId))
                    {
                        try
                        {
                            IUIAutomationElement elm = this._listener._automation.ElementFromHandle(process.MainWindowHandle);
                            IUIAutomationCondition Cond = this._listener._automation.CreatePropertyCondition(30003, 50004);
                            IUIAutomationElementArray elm2 = elm.FindAll(TreeScope.TreeScope_Descendants, Cond);
                            for (int i = 0; i < elm2.Length; i++)
                            {
                                IUIAutomationElement elm3 = elm2.GetElement(i);
                                IUIAutomationValuePattern val = (IUIAutomationValuePattern)elm3.GetCurrentPattern(10002);
                                if(val == null) continue;
                                    openSites.ToList().Add(val.CurrentValue);
                                    foreach(string item in openSites.ToList())
                                    {
                                        if (item.Contains("https://nextchessmove.com/"))
                                        {
                                            MessageBox.Show("Cheating detected.");


                                        }
                                        else
                                        {
                                            Application.DoEvents();
                                        }
                                    }


                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                }
            }
        }*/
        [DllImport("user32.dll")]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public void PrintBrowserTabName()
        {
            var browsersList = new List<string>
            {
                "chrome",
                "firefox",
                "iexplore",
                "safari",
                "opera",
                "edge"
            };
            var bannedSites = new List<String>
            {
                "Next Chess",
                "Chess Next",
                "Engine",
                "Chess Calculator"
            };

            foreach (var singleBrowser in browsersList)
            {
                var process = Process.GetProcessesByName(singleBrowser);
                if(process == null || process.Length == 0)
                {
                    continue;
                }
                if (process.Length > 0)
                {
                    foreach (Process singleProcess in process)
                    {
                        IntPtr hWnd = singleProcess.MainWindowHandle;
                        if (hWnd == IntPtr.Zero)
                        {
                            continue;
                        }
                        int length = GetWindowTextLength(hWnd);

                        StringBuilder text = new StringBuilder(length + 1);
                        GetWindowText(hWnd, text, text.Capacity);
                        foreach(string site in bannedSites)
                        {
                            if (text.ToString().Contains(site))
                            {
                                MessageBox.Show("Cheat Detected");
                                this.Close();
                            }
                        }

                    }
                }
            }
        }

        public void closeOnDetect()
        {
            this.Close();
        }
        public bool scanApplications()
        {

            /*data.Add("ChessBot");
            data.Add("Bot");
            data.Add("Stockfish");*/


            Process[] pname = Process.GetProcessesByName("ChessBot");
            if (pname.Length == 1)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ChessPP");
                if (key == null)
                {
                    key.SetValue("Strikes", 0);
                    key.SetValue("Status", "ACTIVE");
                }
                object strikesKey = key.GetValue("Strikes");
                if (strikesKey != null)
                {
                    int value = Convert.ToInt32(strikesKey);
                    if(value >= 6)
                    {
                        key.SetValue("Status", "BANNED");
                    }
                    else
                    {
                        value = value + 1;
                        key.SetValue("Strikes", value);
                    }

                }
                key.Close();
                Hash mainForm = new Hash();
                mainForm.Show();

                Cef.Shutdown();
                this.Close();
                MessageBox.Show("Cheat detected");
                return true;
            }
            else
            {
                return false;
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Form1 mainform = new Form1();
            mainform.Hide();
            Menu load = new Menu();
            load.Show();
            do
            {

                Application.DoEvents();
            }
            while (load.updateProg().Result < 100);
            load.Close();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;




            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ChessPP");
            if (key == null)
            {
                key.SetValue("Strikes", 0);
                key.SetValue("Status", "ACTIVE");
            }
            else
            {
                object statusKey = key.GetValue("Status");
                if (statusKey != null)
                {
                    string value = Convert.ToString(statusKey);
                    if (value == "BANNED")
                    {
                        MessageBox.Show("You are currently banned from Chess++");
                        this.Close();
                    }
                }
            }
            key.Close();
            InitializeChromium();
            check();


            /*var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            Form1 mainForm = new Form1();
            mainForm.Text = mainForm.Text + " " + finalString;*/

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

    }
}
