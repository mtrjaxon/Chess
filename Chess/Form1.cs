using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;

namespace Chess
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.PersistSessionCookies = true;
            settings.CachePath = @"C:\TEST\";
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("http://chess.com");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }
        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Hash mainForm = new Hash();
            mainForm.Show();
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
