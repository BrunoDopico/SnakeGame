namespace Snake_Game.Forms
{
    partial class MapSelector
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
            this.lbMaps = new System.Windows.Forms.ListBox();
            this.tbPreview = new System.Windows.Forms.TextBox();
            this.lbMapList = new System.Windows.Forms.Label();
            this.lbPreview = new System.Windows.Forms.Label();
            this.lbDifficulty = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbTheme = new System.Windows.Forms.Label();
            this.bt_LoadMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMaps
            // 
            this.lbMaps.BackColor = System.Drawing.Color.Tan;
            this.lbMaps.FormattingEnabled = true;
            this.lbMaps.ItemHeight = 16;
            this.lbMaps.Location = new System.Drawing.Point(13, 35);
            this.lbMaps.Margin = new System.Windows.Forms.Padding(4);
            this.lbMaps.Name = "lbMaps";
            this.lbMaps.Size = new System.Drawing.Size(241, 148);
            this.lbMaps.TabIndex = 0;
            this.lbMaps.SelectedIndexChanged += new System.EventHandler(this.lbMaps_SelectedIndexChanged);
            // 
            // tbPreview
            // 
            this.tbPreview.BackColor = System.Drawing.Color.Tan;
            this.tbPreview.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPreview.Location = new System.Drawing.Point(13, 213);
            this.tbPreview.Margin = new System.Windows.Forms.Padding(4);
            this.tbPreview.Multiline = true;
            this.tbPreview.Name = "tbPreview";
            this.tbPreview.Size = new System.Drawing.Size(491, 331);
            this.tbPreview.TabIndex = 1;
            this.tbPreview.WordWrap = false;
            // 
            // lbMapList
            // 
            this.lbMapList.AutoSize = true;
            this.lbMapList.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMapList.Location = new System.Drawing.Point(14, 9);
            this.lbMapList.Name = "lbMapList";
            this.lbMapList.Size = new System.Drawing.Size(93, 20);
            this.lbMapList.TabIndex = 2;
            this.lbMapList.Text = "MAP LIST";
            // 
            // lbPreview
            // 
            this.lbPreview.AutoSize = true;
            this.lbPreview.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPreview.Location = new System.Drawing.Point(14, 187);
            this.lbPreview.Name = "lbPreview";
            this.lbPreview.Size = new System.Drawing.Size(90, 20);
            this.lbPreview.TabIndex = 3;
            this.lbPreview.Text = "PREVIEW";
            // 
            // lbDifficulty
            // 
            this.lbDifficulty.AutoSize = true;
            this.lbDifficulty.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDifficulty.Location = new System.Drawing.Point(261, 123);
            this.lbDifficulty.Name = "lbDifficulty";
            this.lbDifficulty.Size = new System.Drawing.Size(100, 20);
            this.lbDifficulty.TabIndex = 4;
            this.lbDifficulty.Text = "Difficulty: ";
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWidth.Location = new System.Drawing.Point(261, 79);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(70, 20);
            this.lbWidth.TabIndex = 5;
            this.lbWidth.Text = "Width: ";
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeight.Location = new System.Drawing.Point(261, 101);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(76, 20);
            this.lbHeight.TabIndex = 6;
            this.lbHeight.Text = "Height: ";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(261, 35);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(69, 20);
            this.lbName.TabIndex = 7;
            this.lbName.Text = "Name: ";
            // 
            // lbTheme
            // 
            this.lbTheme.AutoSize = true;
            this.lbTheme.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTheme.Location = new System.Drawing.Point(261, 57);
            this.lbTheme.Name = "lbTheme";
            this.lbTheme.Size = new System.Drawing.Size(79, 20);
            this.lbTheme.TabIndex = 8;
            this.lbTheme.Text = "Theme: ";
            // 
            // bt_LoadMap
            // 
            this.bt_LoadMap.BackColor = System.Drawing.Color.Tan;
            this.bt_LoadMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_LoadMap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_LoadMap.ForeColor = System.Drawing.Color.Black;
            this.bt_LoadMap.Location = new System.Drawing.Point(262, 147);
            this.bt_LoadMap.Margin = new System.Windows.Forms.Padding(4);
            this.bt_LoadMap.Name = "bt_LoadMap";
            this.bt_LoadMap.Size = new System.Drawing.Size(115, 28);
            this.bt_LoadMap.TabIndex = 9;
            this.bt_LoadMap.Text = "LOAD MAP";
            this.bt_LoadMap.UseVisualStyleBackColor = false;
            this.bt_LoadMap.Click += new System.EventHandler(this.bt_LoadMap_Click);
            // 
            // MapSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.ClientSize = new System.Drawing.Size(517, 557);
            this.Controls.Add(this.bt_LoadMap);
            this.Controls.Add(this.lbTheme);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbHeight);
            this.Controls.Add(this.lbWidth);
            this.Controls.Add(this.lbDifficulty);
            this.Controls.Add(this.lbPreview);
            this.Controls.Add(this.lbMapList);
            this.Controls.Add(this.tbPreview);
            this.Controls.Add(this.lbMaps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MAP SELECTOR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMaps;
        private System.Windows.Forms.TextBox tbPreview;
        private System.Windows.Forms.Label lbMapList;
        private System.Windows.Forms.Label lbPreview;
        private System.Windows.Forms.Label lbDifficulty;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbTheme;
        private System.Windows.Forms.Button bt_LoadMap;
    }
}