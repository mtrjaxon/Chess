using CefSharp.DevTools.CSS;
using CefSharp.DevTools.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        delegate void updateProgress(int value2);

        private async void Menu_Load(object sender, EventArgs e)
        {



            updateUI();



            /*while (updateProg().Result <= 100)
            {
                wait(75);
                await System.Threading.Tasks.Task.Run(() => updateProg());
                botPro.Value = updateProg().Result;
                Application.DoEvents();

            }
            while (updateProg().Result <= 100)
            {
                wait(1500);
                var random = new Random();
                int index = random.Next(subList.Count());
                subText.Text = subList[index];
                Application.DoEvents();
            }*/





        }

        public async void updateUI()
        {
            var progressTask = updateProgressBar();
            var labelTask = updateLabel();
            await Task.WhenAll(progressTask, labelTask);

        }

        private async Task updateProgressBar()
        {
            Form1 mainform = new Form1();
            do
            {
                await System.Threading.Tasks.Task.Run(() => updateProg());
                botPro.Value = updateProg().Result;
                perCent.Text = updateProg().Result.ToString();
                await System.Threading.Tasks.Task.Delay(65);
            }
            while (updateProg().Result <= 83);
            if (mainform.scanApplications())
            {
                this.Close();
            }
            else
            {
                Application.DoEvents();
            }
            await System.Threading.Tasks.Task.Delay(550);
            do
            {
                await System.Threading.Tasks.Task.Run(() => updateProg());
                botPro.Value = updateProg().Result;
                perCent.Text = updateProg().Result.ToString();
                await System.Threading.Tasks.Task.Delay(65);
                
            }
            while (updateProg().Result >= 83);
            Menu load = new Menu();
            if (updateProg().Result == 100)
            {


                this.Close();

            }

        }

        private async Task updateLabel()
        {
            string[] subList;
            subList = new string[]
            {
                "Performing queen sacrifice...",
                "Playing better than stockfish...",
                "If takes then takes then takes then...",
                "Calculating why you're stuck at 800 rated...",
                "Outsmarting anticheat...",
                "Knight C6 played...",
                "But GothamChess said...",
                "Statistically, you've never blundered a piece against Magnus Carlsen...",
                "Calculating first 4 moves of the Vienna...",
                "E4, C6, takes, takes then...",
                "Another day, another 100 ELO lost...",
                "Man. I didn't even see that move...",
                "Wait.. this is mate in 1 right?",
                "It wasn't mate in 1..."
            };
            do
            {
                {
                    var random = new Random();
                    int index = random.Next(subList.Count());
                    subText.Text = subList[index];
                    await System.Threading.Tasks.Task.Delay(1250);
                }
            }
            while (updateProg().Result <= 100);

        }
        private async void BotPro_Load(object sender, EventArgs e)
        {

        }

        private async System.Threading.Tasks.Task<int> updateSubText()
        {
            int value = this.botPro.Value;

            value++;



            return value;
        }
        public async System.Threading.Tasks.Task<int> updateProg()
        {
            int value = this.botPro.Value;


            value++;
            return value;
        }



        private void lolUpdate()
        {

        }

        public async void wait(int milliseconds)
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

        private void botPro_Click(object sender, EventArgs e)
        {

        }

        private void botPro_Validated(object sender, EventArgs e)
        {

        }

        private void subText_TextChanged(object sender, EventArgs e)
        {

            


        }
    }
}
