﻿
namespace Snake_Game.Forms
{
    partial class GameScreen
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
            this.lbScore = new System.Windows.Forms.Label();
            this.bt_Credits = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_Options = new System.Windows.Forms.Button();
            this.bt_randomMap = new System.Windows.Forms.Button();
            this.pbMenu = new System.Windows.Forms.PictureBox();
            this.btLoadMap = new System.Windows.Forms.Button();
            this.panelGame = new Snake_Game.CustomComponents.DoubleBufferedPanel();
            this.lbTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.BackColor = System.Drawing.Color.Transparent;
            this.lbScore.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore.Image = global::Snake_Game.Properties.Resources.stats_border;
            this.lbScore.Location = new System.Drawing.Point(27, 54);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(64, 22);
            this.lbScore.TabIndex = 13;
            this.lbScore.Text = "Score:";
            // 
            // bt_Credits
            // 
            this.bt_Credits.BackColor = System.Drawing.Color.Tan;
            this.bt_Credits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Credits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Credits.ForeColor = System.Drawing.Color.Black;
            this.bt_Credits.Location = new System.Drawing.Point(370, 22);
            this.bt_Credits.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Credits.Name = "bt_Credits";
            this.bt_Credits.Size = new System.Drawing.Size(104, 28);
            this.bt_Credits.TabIndex = 10;
            this.bt_Credits.Text = "ABOUT";
            this.bt_Credits.UseVisualStyleBackColor = false;
            this.bt_Credits.Click += new System.EventHandler(this.bt_Credits_Click);
            this.bt_Credits.MouseEnter += new System.EventHandler(this.buttons_MouseEnter);
            // 
            // bt_exit
            // 
            this.bt_exit.BackColor = System.Drawing.Color.Tan;
            this.bt_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_exit.ForeColor = System.Drawing.Color.Black;
            this.bt_exit.Location = new System.Drawing.Point(482, 22);
            this.bt_exit.Margin = new System.Windows.Forms.Padding(4);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(104, 28);
            this.bt_exit.TabIndex = 9;
            this.bt_exit.Text = "EXIT";
            this.bt_exit.UseVisualStyleBackColor = false;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            this.bt_exit.MouseEnter += new System.EventHandler(this.buttons_MouseEnter);
            // 
            // bt_Options
            // 
            this.bt_Options.BackColor = System.Drawing.Color.Tan;
            this.bt_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Options.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Options.ForeColor = System.Drawing.Color.Black;
            this.bt_Options.Location = new System.Drawing.Point(258, 22);
            this.bt_Options.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Options.Name = "bt_Options";
            this.bt_Options.Size = new System.Drawing.Size(104, 28);
            this.bt_Options.TabIndex = 8;
            this.bt_Options.Text = "OPTIONS";
            this.bt_Options.UseVisualStyleBackColor = false;
            this.bt_Options.Click += new System.EventHandler(this.bt_Options_Click);
            this.bt_Options.MouseEnter += new System.EventHandler(this.buttons_MouseEnter);
            // 
            // bt_randomMap
            // 
            this.bt_randomMap.BackColor = System.Drawing.Color.Tan;
            this.bt_randomMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_randomMap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_randomMap.ForeColor = System.Drawing.Color.Black;
            this.bt_randomMap.Location = new System.Drawing.Point(135, 22);
            this.bt_randomMap.Margin = new System.Windows.Forms.Padding(4);
            this.bt_randomMap.Name = "bt_randomMap";
            this.bt_randomMap.Size = new System.Drawing.Size(115, 28);
            this.bt_randomMap.TabIndex = 7;
            this.bt_randomMap.Text = "RANDOM MAP";
            this.bt_randomMap.UseVisualStyleBackColor = false;
            this.bt_randomMap.Click += new System.EventHandler(this.bt_newGame_Click);
            this.bt_randomMap.MouseEnter += new System.EventHandler(this.buttons_MouseEnter);
            // 
            // pbMenu
            // 
            this.pbMenu.BackColor = System.Drawing.Color.Transparent;
            this.pbMenu.Image = global::Snake_Game.Properties.Resources.stats_border;
            this.pbMenu.Location = new System.Drawing.Point(0, 0);
            this.pbMenu.MaximumSize = new System.Drawing.Size(800, 100);
            this.pbMenu.MinimumSize = new System.Drawing.Size(800, 100);
            this.pbMenu.Name = "pbMenu";
            this.pbMenu.Size = new System.Drawing.Size(800, 100);
            this.pbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenu.TabIndex = 14;
            this.pbMenu.TabStop = false;
            // 
            // btLoadMap
            // 
            this.btLoadMap.BackColor = System.Drawing.Color.Tan;
            this.btLoadMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btLoadMap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btLoadMap.ForeColor = System.Drawing.Color.Black;
            this.btLoadMap.Location = new System.Drawing.Point(23, 22);
            this.btLoadMap.Margin = new System.Windows.Forms.Padding(4);
            this.btLoadMap.Name = "btLoadMap";
            this.btLoadMap.Size = new System.Drawing.Size(104, 28);
            this.btLoadMap.TabIndex = 15;
            this.btLoadMap.Text = "LOAD MAP";
            this.btLoadMap.UseVisualStyleBackColor = false;
            this.btLoadMap.Click += new System.EventHandler(this.btLoadMap_Click);
            this.btLoadMap.MouseEnter += new System.EventHandler(this.buttons_MouseEnter);
            // 
            // panelGame
            // 
            this.panelGame.Location = new System.Drawing.Point(13, 107);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(200, 100);
            this.panelGame.TabIndex = 16;
            this.panelGame.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Image = global::Snake_Game.Properties.Resources.stats_border;
            this.lbTime.Location = new System.Drawing.Point(149, 54);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(62, 22);
            this.lbTime.TabIndex = 17;
            this.lbTime.Text = "Time:";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.btLoadMap);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_Options);
            this.Controls.Add(this.bt_Credits);
            this.Controls.Add(this.bt_randomMap);
            this.Controls.Add(this.pbMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAME";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameScreen_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Button bt_Credits;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_Options;
        private System.Windows.Forms.Button bt_randomMap;
        private System.Windows.Forms.PictureBox pbMenu;
        private System.Windows.Forms.Button btLoadMap;
        private CustomComponents.DoubleBufferedPanel panelGame;
        private System.Windows.Forms.Label lbTime;
    }
}