
namespace Snake_Game.Forms
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.bt_newGame = new System.Windows.Forms.Button();
            this.bt_Options = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_Credits = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_newGame
            // 
            this.bt_newGame.BackColor = System.Drawing.Color.Gold;
            this.bt_newGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_newGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_newGame.ForeColor = System.Drawing.Color.Black;
            this.bt_newGame.Location = new System.Drawing.Point(161, 134);
            this.bt_newGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_newGame.Name = "bt_newGame";
            this.bt_newGame.Size = new System.Drawing.Size(104, 28);
            this.bt_newGame.TabIndex = 2;
            this.bt_newGame.Text = "START";
            this.bt_newGame.UseVisualStyleBackColor = false;
            this.bt_newGame.Click += new System.EventHandler(this.bt_newGame_Click);
            // 
            // bt_Options
            // 
            this.bt_Options.BackColor = System.Drawing.Color.Gold;
            this.bt_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Options.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Options.ForeColor = System.Drawing.Color.Black;
            this.bt_Options.Location = new System.Drawing.Point(161, 170);
            this.bt_Options.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_Options.Name = "bt_Options";
            this.bt_Options.Size = new System.Drawing.Size(104, 28);
            this.bt_Options.TabIndex = 3;
            this.bt_Options.Text = "OPTIONS";
            this.bt_Options.UseVisualStyleBackColor = false;
            this.bt_Options.Click += new System.EventHandler(this.bt_Options_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.BackColor = System.Drawing.Color.Gold;
            this.bt_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_exit.ForeColor = System.Drawing.Color.Black;
            this.bt_exit.Location = new System.Drawing.Point(161, 241);
            this.bt_exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(104, 28);
            this.bt_exit.TabIndex = 4;
            this.bt_exit.Text = "EXIT";
            this.bt_exit.UseVisualStyleBackColor = false;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_Credits
            // 
            this.bt_Credits.BackColor = System.Drawing.Color.Gold;
            this.bt_Credits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Credits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Credits.ForeColor = System.Drawing.Color.Black;
            this.bt_Credits.Location = new System.Drawing.Point(161, 206);
            this.bt_Credits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_Credits.Name = "bt_Credits";
            this.bt_Credits.Size = new System.Drawing.Size(104, 28);
            this.bt_Credits.TabIndex = 5;
            this.bt_Credits.Text = "ABOUT";
            this.bt_Credits.UseVisualStyleBackColor = false;
            this.bt_Credits.Click += new System.EventHandler(this.bt_Credits_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Snake_Game.Properties.Resources.title;
            this.pictureBox1.Location = new System.Drawing.Point(17, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(408, 103);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.BackgroundImage = global::Snake_Game.Properties.Resources.back;
            this.ClientSize = new System.Drawing.Size(443, 290);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_Credits);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_Options);
            this.Controls.Add(this.bt_newGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_newGame;
        private System.Windows.Forms.Button bt_Options;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_Credits;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

