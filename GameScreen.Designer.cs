
namespace Snake_Game
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
            this.lbInfo = new System.Windows.Forms.Label();
            this.bt_Credits = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_Options = new System.Windows.Forms.Button();
            this.bt_newGame = new System.Windows.Forms.Button();
            this.pbMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.BackColor = System.Drawing.Color.Transparent;
            this.lbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Image = global::Snake_Game.Properties.Resources.stats_border;
            this.lbInfo.Location = new System.Drawing.Point(27, 54);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(63, 25);
            this.lbInfo.TabIndex = 13;
            this.lbInfo.Text = "INFO";
            // 
            // bt_Credits
            // 
            this.bt_Credits.BackColor = System.Drawing.Color.Tan;
            this.bt_Credits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Credits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Credits.ForeColor = System.Drawing.Color.Black;
            this.bt_Credits.Location = new System.Drawing.Point(247, 22);
            this.bt_Credits.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Credits.Name = "bt_Credits";
            this.bt_Credits.Size = new System.Drawing.Size(104, 28);
            this.bt_Credits.TabIndex = 10;
            this.bt_Credits.Text = "ABOUT";
            this.bt_Credits.UseVisualStyleBackColor = false;
            this.bt_Credits.Click += new System.EventHandler(this.bt_Credits_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.BackColor = System.Drawing.Color.Tan;
            this.bt_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_exit.ForeColor = System.Drawing.Color.Black;
            this.bt_exit.Location = new System.Drawing.Point(359, 22);
            this.bt_exit.Margin = new System.Windows.Forms.Padding(4);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(104, 28);
            this.bt_exit.TabIndex = 9;
            this.bt_exit.Text = "EXIT";
            this.bt_exit.UseVisualStyleBackColor = false;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_Options
            // 
            this.bt_Options.BackColor = System.Drawing.Color.Tan;
            this.bt_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Options.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Options.ForeColor = System.Drawing.Color.Black;
            this.bt_Options.Location = new System.Drawing.Point(135, 22);
            this.bt_Options.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Options.Name = "bt_Options";
            this.bt_Options.Size = new System.Drawing.Size(104, 28);
            this.bt_Options.TabIndex = 8;
            this.bt_Options.Text = "OPTIONS";
            this.bt_Options.UseVisualStyleBackColor = false;
            this.bt_Options.Click += new System.EventHandler(this.bt_Options_Click);
            // 
            // bt_newGame
            // 
            this.bt_newGame.BackColor = System.Drawing.Color.Tan;
            this.bt_newGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_newGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_newGame.ForeColor = System.Drawing.Color.Black;
            this.bt_newGame.Location = new System.Drawing.Point(23, 22);
            this.bt_newGame.Margin = new System.Windows.Forms.Padding(4);
            this.bt_newGame.Name = "bt_newGame";
            this.bt_newGame.Size = new System.Drawing.Size(104, 28);
            this.bt_newGame.TabIndex = 7;
            this.bt_newGame.Text = "NEW GAME";
            this.bt_newGame.UseVisualStyleBackColor = false;
            this.bt_newGame.Click += new System.EventHandler(this.bt_newGame_Click);
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
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_Options);
            this.Controls.Add(this.bt_Credits);
            this.Controls.Add(this.bt_newGame);
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
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button bt_Credits;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_Options;
        private System.Windows.Forms.Button bt_newGame;
        private System.Windows.Forms.PictureBox pbMenu;
    }
}