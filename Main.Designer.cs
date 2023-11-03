
namespace Snake_Game
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
            this.lbInfo = new System.Windows.Forms.Label();
            this.bt_newGame = new System.Windows.Forms.Button();
            this.bt_Options = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_Credits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("Star Guard", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfo.Location = new System.Drawing.Point(180, 2);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(49, 22);
            this.lbInfo.TabIndex = 1;
            this.lbInfo.Text = "INFO";
            // 
            // bt_newGame
            // 
            this.bt_newGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_newGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_newGame.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_newGame.Location = new System.Drawing.Point(12, 1);
            this.bt_newGame.Name = "bt_newGame";
            this.bt_newGame.Size = new System.Drawing.Size(78, 23);
            this.bt_newGame.TabIndex = 2;
            this.bt_newGame.Text = "NEW GAME";
            this.bt_newGame.UseVisualStyleBackColor = true;
            this.bt_newGame.Click += new System.EventHandler(this.bt_newGame_Click);
            // 
            // bt_Options
            // 
            this.bt_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Options.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Options.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_Options.Location = new System.Drawing.Point(96, 1);
            this.bt_Options.Name = "bt_Options";
            this.bt_Options.Size = new System.Drawing.Size(78, 23);
            this.bt_Options.TabIndex = 3;
            this.bt_Options.Text = "OPTIONS";
            this.bt_Options.UseVisualStyleBackColor = true;
            this.bt_Options.Click += new System.EventHandler(this.bt_Options_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_exit.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_exit.Location = new System.Drawing.Point(375, 1);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(78, 23);
            this.bt_exit.TabIndex = 4;
            this.bt_exit.Text = "EXIT";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_Credits
            // 
            this.bt_Credits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Credits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_Credits.ForeColor = System.Drawing.Color.DarkGreen;
            this.bt_Credits.Location = new System.Drawing.Point(291, 1);
            this.bt_Credits.Name = "bt_Credits";
            this.bt_Credits.Size = new System.Drawing.Size(78, 23);
            this.bt_Credits.TabIndex = 5;
            this.bt_Credits.Text = "ABOUT";
            this.bt_Credits.UseVisualStyleBackColor = true;
            this.bt_Credits.Click += new System.EventHandler(this.bt_Credits_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ClientSize = new System.Drawing.Size(464, 327);
            this.Controls.Add(this.bt_Credits);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_Options);
            this.Controls.Add(this.bt_newGame);
            this.Controls.Add(this.lbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake Game";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button bt_newGame;
        private System.Windows.Forms.Button bt_Options;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_Credits;
    }
}

