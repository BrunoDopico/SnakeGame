﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game.Forms
{
    public partial class Main : Form
    {
        
        public Main()
        {
            Config.LoadConfig();
            SoundManager.Init();
            ThemeManager.Init(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..","..", "Resources"));
            SoundManager.StopBackgroundMusic();
            InitializeComponent();
        }

        private void bt_newGame_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            GameScreen game = new GameScreen();
            game.FormClosed += (s, args) => this.Show(); // Show Main form when GameScreen is closed  
            this.Hide();
            game.Show();
        }

        private void bt_Options_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            Form options = new Options();
            options.ShowDialog(this);
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            Application.Exit();
        }

        private void bt_Credits_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            MessageBox.Show("- THE GAME -\n" +
                "\nThis is the snake game." +
                "\nThe objective of this game is to survive for as long as possible while eating fruits to make your snake's body larger." +
                "\nTouching an obstacle or your own body will instantly kill you.\n" +
                "\n- CONTROLS -\n" +
                " · Move Up: " + Config.IN_UP.ToString() +
                "\n · Move Down: " + Config.IN_DOWN.ToString() +
                "\n · Move Left: " + Config.IN_LEFT.ToString() +
                "\n · Move Right: " + Config.IN_RIGHT.ToString() +
                "\n · Pause: " + Config.IN_PAUSE.ToString() +
                "\n · New Random Game: " + Config.IN_NEW.ToString() +
                "\n (Can be changed in options)\n" +
                "\n- CREDITS -\n" +
                "Game made by Bruno (BrunusOP) Dopico\n", "CREDITS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttons_MouseEnter(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("hover");
        }
    }
}
