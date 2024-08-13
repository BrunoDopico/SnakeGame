
namespace Snake_Game
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.cbDifficulty = new System.Windows.Forms.ComboBox();
            this.lbDifficulty = new System.Windows.Forms.Label();
            this.lbDificultyExplanation = new System.Windows.Forms.Label();
            this.cbMapType = new System.Windows.Forms.ComboBox();
            this.lbMapType = new System.Windows.Forms.Label();
            this.lbMapTypeExplanation = new System.Windows.Forms.Label();
            this.lbMapX = new System.Windows.Forms.Label();
            this.lbMapY = new System.Windows.Forms.Label();
            this.cbSpecialFruit = new System.Windows.Forms.CheckBox();
            this.lbSnakeSize = new System.Windows.Forms.Label();
            this.btDefault = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.numMapX = new System.Windows.Forms.NumericUpDown();
            this.numMapY = new System.Windows.Forms.NumericUpDown();
            this.numInitialSize = new System.Windows.Forms.NumericUpDown();
            this.btCancel = new System.Windows.Forms.Button();
            this.lbSpecialFruitPct = new System.Windows.Forms.Label();
            this.lbSpecialFruitValue = new System.Windows.Forms.Label();
            this.numSpecialFruitPct = new System.Windows.Forms.NumericUpDown();
            this.numSpecialFruitValue = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numMapX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecialFruitPct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecialFruitValue)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDifficulty
            // 
            this.cbDifficulty.BackColor = System.Drawing.Color.LimeGreen;
            this.cbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDifficulty.FormattingEnabled = true;
            this.cbDifficulty.Items.AddRange(new object[] {
            "EASY",
            "MEDIUM",
            "DIFFICULT",
            "HARDCORE"});
            this.cbDifficulty.Location = new System.Drawing.Point(12, 26);
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(158, 21);
            this.cbDifficulty.TabIndex = 0;
            // 
            // lbDifficulty
            // 
            this.lbDifficulty.AutoSize = true;
            this.lbDifficulty.Location = new System.Drawing.Point(15, 10);
            this.lbDifficulty.Name = "lbDifficulty";
            this.lbDifficulty.Size = new System.Drawing.Size(94, 13);
            this.lbDifficulty.TabIndex = 1;
            this.lbDifficulty.Text = "Difficulty Selection";
            // 
            // lbDificultyExplanation
            // 
            this.lbDificultyExplanation.AutoSize = true;
            this.lbDificultyExplanation.Location = new System.Drawing.Point(192, 21);
            this.lbDificultyExplanation.Name = "lbDificultyExplanation";
            this.lbDificultyExplanation.Size = new System.Drawing.Size(131, 26);
            this.lbDificultyExplanation.TabIndex = 2;
            this.lbDificultyExplanation.Text = "Changes game speed and\r\nnum of Fruits on the game";
            // 
            // cbMapType
            // 
            this.cbMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapType.FormattingEnabled = true;
            this.cbMapType.Items.AddRange(new object[] {
            "STANDARD",
            "BORDERLESS",
            "HOLES ON THE WALL",
            "EXTRA WALLS",
            "HOLES AND WALLS"});
            this.cbMapType.Location = new System.Drawing.Point(12, 78);
            this.cbMapType.Name = "cbMapType";
            this.cbMapType.Size = new System.Drawing.Size(158, 21);
            this.cbMapType.TabIndex = 3;
            // 
            // lbMapType
            // 
            this.lbMapType.AutoSize = true;
            this.lbMapType.Location = new System.Drawing.Point(15, 62);
            this.lbMapType.Name = "lbMapType";
            this.lbMapType.Size = new System.Drawing.Size(75, 13);
            this.lbMapType.TabIndex = 4;
            this.lbMapType.Text = "Map Selection";
            // 
            // lbMapTypeExplanation
            // 
            this.lbMapTypeExplanation.AutoSize = true;
            this.lbMapTypeExplanation.Location = new System.Drawing.Point(192, 73);
            this.lbMapTypeExplanation.Name = "lbMapTypeExplanation";
            this.lbMapTypeExplanation.Size = new System.Drawing.Size(110, 26);
            this.lbMapTypeExplanation.TabIndex = 5;
            this.lbMapTypeExplanation.Text = "Changes the way that\r\nthe map is generated";
            // 
            // lbMapX
            // 
            this.lbMapX.AutoSize = true;
            this.lbMapX.Location = new System.Drawing.Point(15, 122);
            this.lbMapX.Name = "lbMapX";
            this.lbMapX.Size = new System.Drawing.Size(64, 13);
            this.lbMapX.TabIndex = 7;
            this.lbMapX.Text = "Map Length";
            // 
            // lbMapY
            // 
            this.lbMapY.AutoSize = true;
            this.lbMapY.Location = new System.Drawing.Point(15, 152);
            this.lbMapY.Name = "lbMapY";
            this.lbMapY.Size = new System.Drawing.Size(62, 13);
            this.lbMapY.TabIndex = 8;
            this.lbMapY.Text = "Map Height";
            // 
            // cbSpecialFruit
            // 
            this.cbSpecialFruit.AutoSize = true;
            this.cbSpecialFruit.Checked = true;
            this.cbSpecialFruit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSpecialFruit.Location = new System.Drawing.Point(195, 121);
            this.cbSpecialFruit.Name = "cbSpecialFruit";
            this.cbSpecialFruit.Size = new System.Drawing.Size(126, 17);
            this.cbSpecialFruit.TabIndex = 10;
            this.cbSpecialFruit.Text = "Special Fruit Enabled";
            this.cbSpecialFruit.UseVisualStyleBackColor = true;
            // 
            // lbSnakeSize
            // 
            this.lbSnakeSize.AutoSize = true;
            this.lbSnakeSize.Location = new System.Drawing.Point(15, 183);
            this.lbSnakeSize.Name = "lbSnakeSize";
            this.lbSnakeSize.Size = new System.Drawing.Size(54, 13);
            this.lbSnakeSize.TabIndex = 11;
            this.lbSnakeSize.Text = "Initial Size";
            // 
            // btDefault
            // 
            this.btDefault.Location = new System.Drawing.Point(34, 208);
            this.btDefault.Name = "btDefault";
            this.btDefault.Size = new System.Drawing.Size(75, 23);
            this.btDefault.TabIndex = 13;
            this.btDefault.Text = "DEFAULT";
            this.btDefault.UseVisualStyleBackColor = true;
            this.btDefault.Click += new System.EventHandler(this.btDefault_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(134, 208);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 14;
            this.btSave.Text = "SAVE";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // numMapX
            // 
            this.numMapX.Location = new System.Drawing.Point(85, 120);
            this.numMapX.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMapX.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numMapX.Name = "numMapX";
            this.numMapX.Size = new System.Drawing.Size(85, 20);
            this.numMapX.TabIndex = 15;
            this.numMapX.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numMapY
            // 
            this.numMapY.Location = new System.Drawing.Point(85, 150);
            this.numMapY.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numMapY.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numMapY.Name = "numMapY";
            this.numMapY.Size = new System.Drawing.Size(85, 20);
            this.numMapY.TabIndex = 16;
            this.numMapY.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numInitialSize
            // 
            this.numInitialSize.Location = new System.Drawing.Point(85, 176);
            this.numInitialSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numInitialSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numInitialSize.Name = "numInitialSize";
            this.numInitialSize.Size = new System.Drawing.Size(85, 20);
            this.numInitialSize.TabIndex = 17;
            this.numInitialSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // btCancel
            // 
            this.btCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btCancel.Location = new System.Drawing.Point(236, 208);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 18;
            this.btCancel.Text = "EXIT";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbSpecialFruitPct
            // 
            this.lbSpecialFruitPct.AutoSize = true;
            this.lbSpecialFruitPct.Location = new System.Drawing.Point(192, 152);
            this.lbSpecialFruitPct.Name = "lbSpecialFruitPct";
            this.lbSpecialFruitPct.Size = new System.Drawing.Size(76, 13);
            this.lbSpecialFruitPct.TabIndex = 19;
            this.lbSpecialFruitPct.Text = "Special Fruit %";
            // 
            // lbSpecialFruitValue
            // 
            this.lbSpecialFruitValue.AutoSize = true;
            this.lbSpecialFruitValue.Location = new System.Drawing.Point(192, 178);
            this.lbSpecialFruitValue.Name = "lbSpecialFruitValue";
            this.lbSpecialFruitValue.Size = new System.Drawing.Size(95, 13);
            this.lbSpecialFruitValue.TabIndex = 20;
            this.lbSpecialFruitValue.Text = "Special Fruit Value";
            // 
            // numSpecialFruitPct
            // 
            this.numSpecialFruitPct.DecimalPlaces = 2;
            this.numSpecialFruitPct.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numSpecialFruitPct.Location = new System.Drawing.Point(274, 150);
            this.numSpecialFruitPct.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpecialFruitPct.Name = "numSpecialFruitPct";
            this.numSpecialFruitPct.Size = new System.Drawing.Size(52, 20);
            this.numSpecialFruitPct.TabIndex = 21;
            this.numSpecialFruitPct.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // numSpecialFruitValue
            // 
            this.numSpecialFruitValue.Location = new System.Drawing.Point(294, 176);
            this.numSpecialFruitValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSpecialFruitValue.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            -2147483648});
            this.numSpecialFruitValue.Name = "numSpecialFruitValue";
            this.numSpecialFruitValue.Size = new System.Drawing.Size(32, 20);
            this.numSpecialFruitValue.TabIndex = 22;
            this.numSpecialFruitValue.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(338, 243);
            this.Controls.Add(this.numSpecialFruitValue);
            this.Controls.Add(this.numSpecialFruitPct);
            this.Controls.Add(this.lbSpecialFruitValue);
            this.Controls.Add(this.lbSpecialFruitPct);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.numInitialSize);
            this.Controls.Add(this.numMapY);
            this.Controls.Add(this.numMapX);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btDefault);
            this.Controls.Add(this.lbSnakeSize);
            this.Controls.Add(this.cbSpecialFruit);
            this.Controls.Add(this.lbMapY);
            this.Controls.Add(this.lbMapX);
            this.Controls.Add(this.lbMapTypeExplanation);
            this.Controls.Add(this.lbMapType);
            this.Controls.Add(this.cbMapType);
            this.Controls.Add(this.lbDificultyExplanation);
            this.Controls.Add(this.lbDifficulty);
            this.Controls.Add(this.cbDifficulty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OPTIONS";
            ((System.ComponentModel.ISupportInitialize)(this.numMapX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMapY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecialFruitPct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpecialFruitValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDifficulty;
        private System.Windows.Forms.Label lbDifficulty;
        private System.Windows.Forms.Label lbDificultyExplanation;
        private System.Windows.Forms.ComboBox cbMapType;
        private System.Windows.Forms.Label lbMapType;
        private System.Windows.Forms.Label lbMapTypeExplanation;
        private System.Windows.Forms.Label lbMapX;
        private System.Windows.Forms.Label lbMapY;
        private System.Windows.Forms.CheckBox cbSpecialFruit;
        private System.Windows.Forms.Label lbSnakeSize;
        private System.Windows.Forms.Button btDefault;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.NumericUpDown numMapX;
        private System.Windows.Forms.NumericUpDown numMapY;
        private System.Windows.Forms.NumericUpDown numInitialSize;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lbSpecialFruitPct;
        private System.Windows.Forms.Label lbSpecialFruitValue;
        private System.Windows.Forms.NumericUpDown numSpecialFruitPct;
        private System.Windows.Forms.NumericUpDown numSpecialFruitValue;
    }
}