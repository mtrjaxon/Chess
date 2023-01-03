using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Hash : Form
    {
        public Hash()
        {
            InitializeComponent();
        }

        public void Hash_Load(object sender, EventArgs e)
        {
            Hash mainForm = new Hash();
            this.Location = new Point(0,0);
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[16];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            label1.Text = "Session ID:"+ " " + finalString;
        }
    }
}
