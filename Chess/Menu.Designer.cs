namespace Chess
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.label1 = new System.Windows.Forms.Label();
            this.perCent = new System.Windows.Forms.Label();
            this.subText = new System.Windows.Forms.Label();
            this.botPro = new secureyourshit2022.FlatProgress();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chess++";
            // 
            // perCent
            // 
            this.perCent.AutoSize = true;
            this.perCent.BackColor = System.Drawing.Color.Transparent;
            this.perCent.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perCent.ForeColor = System.Drawing.Color.White;
            this.perCent.Location = new System.Drawing.Point(583, 280);
            this.perCent.Name = "perCent";
            this.perCent.Size = new System.Drawing.Size(25, 28);
            this.perCent.TabIndex = 1;
            this.perCent.Text = "0";
            // 
            // subText
            // 
            this.subText.AutoSize = true;
            this.subText.BackColor = System.Drawing.Color.Transparent;
            this.subText.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subText.ForeColor = System.Drawing.Color.White;
            this.subText.Location = new System.Drawing.Point(12, 285);
            this.subText.Name = "subText";
            this.subText.Size = new System.Drawing.Size(74, 22);
            this.subText.TabIndex = 2;
            this.subText.Text = "subText";
            this.subText.TextChanged += new System.EventHandler(this.subText_TextChanged);
            // 
            // botPro
            // 
            this.botPro.ChannelColor = System.Drawing.Color.White;
            this.botPro.ChannelHeight = 6;
            this.botPro.ForeBackColor = System.Drawing.Color.LightSkyBlue;
            this.botPro.ForeColor = System.Drawing.Color.White;
            this.botPro.Location = new System.Drawing.Point(-3, 329);
            this.botPro.Maximum = 99;
            this.botPro.Name = "botPro";
            this.botPro.ShowMaximun = false;
            this.botPro.ShowValue = secureyourshit2022.TextPosition.None;
            this.botPro.Size = new System.Drawing.Size(638, 6);
            this.botPro.SliderColor = System.Drawing.Color.LightSkyBlue;
            this.botPro.SliderHeight = 6;
            this.botPro.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.botPro.SymbolAfter = "";
            this.botPro.SymbolBefore = "";
            this.botPro.TabIndex = 3;
            this.botPro.Click += new System.EventHandler(this.botPro_Click);
            this.botPro.Validated += new System.EventHandler(this.botPro_Validated);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(634, 335);
            this.Controls.Add(this.botPro);
            this.Controls.Add(this.subText);
            this.Controls.Add(this.perCent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess++";
            this.TransparencyKey = System.Drawing.Color.DarkSalmon;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label perCent;
        private System.Windows.Forms.Label subText;
        private secureyourshit2022.FlatProgress botPro;
    }
}