
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
            this.tbControlsUp = new System.Windows.Forms.TextBox();
            this.lbControlsUp = new System.Windows.Forms.Label();
            this.lbControlsDown = new System.Windows.Forms.Label();
            this.tbControlsDown = new System.Windows.Forms.TextBox();
            this.lbControlsPause = new System.Windows.Forms.Label();
            this.tbControlsPause = new System.Windows.Forms.TextBox();
            this.lbControlsNewGame = new System.Windows.Forms.Label();
            this.tbControlsNew = new System.Windows.Forms.TextBox();
            this.lbControlsRight = new System.Windows.Forms.Label();
            this.tbControlsRight = new System.Windows.Forms.TextBox();
            this.lbControlsLeft = new System.Windows.Forms.Label();
            this.tbControlsLeft = new System.Windows.Forms.TextBox();
            this.lbControls = new System.Windows.Forms.Label();
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
            this.cbDifficulty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDifficulty.ForeColor = System.Drawing.SystemColors.WindowText;
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
            this.cbMapType.BackColor = System.Drawing.Color.LimeGreen;
            this.cbMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btDefault.Location = new System.Drawing.Point(18, 310);
            this.btDefault.Name = "btDefault";
            this.btDefault.Size = new System.Drawing.Size(75, 23);
            this.btDefault.TabIndex = 13;
            this.btDefault.Text = "DEFAULT";
            this.btDefault.UseVisualStyleBackColor = true;
            this.btDefault.Click += new System.EventHandler(this.btDefault_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(135, 310);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 14;
            this.btSave.Text = "SAVE";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // numMapX
            // 
            this.numMapX.BackColor = System.Drawing.Color.LimeGreen;
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
            this.numMapY.BackColor = System.Drawing.Color.LimeGreen;
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
            this.numInitialSize.BackColor = System.Drawing.Color.LimeGreen;
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
            this.btCancel.Location = new System.Drawing.Point(246, 310);
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
            this.numSpecialFruitPct.BackColor = System.Drawing.Color.LimeGreen;
            this.numSpecialFruitPct.DecimalPlaces = 2;
            this.numSpecialFruitPct.ForeColor = System.Drawing.SystemColors.WindowText;
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
            this.numSpecialFruitValue.BackColor = System.Drawing.Color.LimeGreen;
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
            // tbControlsUp
            // 
            this.tbControlsUp.BackColor = System.Drawing.Color.LimeGreen;
            this.tbControlsUp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbControlsUp.Location = new System.Drawing.Point(63, 227);
            this.tbControlsUp.MaxLength = 1;
            this.tbControlsUp.Name = "tbControlsUp";
            this.tbControlsUp.Size = new System.Drawing.Size(63, 20);
            this.tbControlsUp.TabIndex = 23;
            this.tbControlsUp.Click += new System.EventHandler(this.ControlsTextsClicked);
            this.tbControlsUp.TextChanged += new System.EventHandler(this.ControlsTextsChanged);
            // 
            // lbControlsUp
            // 
            this.lbControlsUp.AutoSize = true;
            this.lbControlsUp.Location = new System.Drawing.Point(15, 230);
            this.lbControlsUp.Name = "lbControlsUp";
            this.lbControlsUp.Size = new System.Drawing.Size(22, 13);
            this.lbControlsUp.TabIndex = 24;
            this.lbControlsUp.Text = "UP";
            // 
            // lbControlsDown
            // 
            this.lbControlsDown.AutoSize = true;
            this.lbControlsDown.Location = new System.Drawing.Point(15, 256);
            this.lbControlsDown.Name = "lbControlsDown";
            this.lbControlsDown.Size = new System.Drawing.Size(42, 13);
            this.lbControlsDown.TabIndex = 26;
            this.lbControlsDown.Text = "DOWN";
            // 
            // tbControlsDown
            // 
            this.tbControlsDown.BackColor = System.Drawing.Color.LimeGreen;
            this.tbControlsDown.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbControlsDown.Location = new System.Drawing.Point(63, 253);
            this.tbControlsDown.MaxLength = 1;
            this.tbControlsDown.Name = "tbControlsDown";
            this.tbControlsDown.Size = new System.Drawing.Size(63, 20);
            this.tbControlsDown.TabIndex = 25;
            this.tbControlsDown.Click += new System.EventHandler(this.ControlsTextsClicked);
            this.tbControlsDown.TextChanged += new System.EventHandler(this.ControlsTextsChanged);
            // 
            // lbControlsPause
            // 
            this.lbControlsPause.AutoSize = true;
            this.lbControlsPause.Location = new System.Drawing.Point(15, 282);
            this.lbControlsPause.Name = "lbControlsPause";
            this.lbControlsPause.Size = new System.Drawing.Size(43, 13);
            this.lbControlsPause.TabIndex = 28;
            this.lbControlsPause.Text = "PAUSE";
            // 
            // tbControlsPause
            // 
            this.tbControlsPause.BackColor = System.Drawing.Color.LimeGreen;
            this.tbControlsPause.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbControlsPause.Location = new System.Drawing.Point(63, 279);
            this.tbControlsPause.MaxLength = 1;
            this.tbControlsPause.Name = "tbControlsPause";
            this.tbControlsPause.Size = new System.Drawing.Size(63, 20);
            this.tbControlsPause.TabIndex = 27;
            this.tbControlsPause.Click += new System.EventHandler(this.ControlsTextsClicked);
            this.tbControlsPause.TextChanged += new System.EventHandler(this.ControlsTextsChanged);
            // 
            // lbControlsNewGame
            // 
            this.lbControlsNewGame.AutoSize = true;
            this.lbControlsNewGame.Location = new System.Drawing.Point(191, 282);
            this.lbControlsNewGame.Name = "lbControlsNewGame";
            this.lbControlsNewGame.Size = new System.Drawing.Size(67, 13);
            this.lbControlsNewGame.TabIndex = 34;
            this.lbControlsNewGame.Text = "NEW GAME";
            // 
            // tbControlsNew
            // 
            this.tbControlsNew.BackColor = System.Drawing.Color.LimeGreen;
            this.tbControlsNew.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbControlsNew.Location = new System.Drawing.Point(258, 279);
            this.tbControlsNew.MaxLength = 1;
            this.tbControlsNew.Name = "tbControlsNew";
            this.tbControlsNew.Size = new System.Drawing.Size(63, 20);
            this.tbControlsNew.TabIndex = 33;
            this.tbControlsNew.Click += new System.EventHandler(this.ControlsTextsClicked);
            this.tbControlsNew.TextChanged += new System.EventHandler(this.ControlsTextsChanged);
            // 
            // lbControlsRight
            // 
            this.lbControlsRight.AutoSize = true;
            this.lbControlsRight.Location = new System.Drawing.Point(191, 256);
            this.lbControlsRight.Name = "lbControlsRight";
            this.lbControlsRight.Size = new System.Drawing.Size(41, 13);
            this.lbControlsRight.TabIndex = 32;
            this.lbControlsRight.Text = "RIGHT";
            // 
            // tbControlsRight
            // 
            this.tbControlsRight.BackColor = System.Drawing.Color.LimeGreen;
            this.tbControlsRight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbControlsRight.Location = new System.Drawing.Point(258, 253);
            this.tbControlsRight.MaxLength = 1;
            this.tbControlsRight.Name = "tbControlsRight";
            this.tbControlsRight.Size = new System.Drawing.Size(63, 20);
            this.tbControlsRight.TabIndex = 31;
            this.tbControlsRight.Click += new System.EventHandler(this.ControlsTextsClicked);
            this.tbControlsRight.TextChanged += new System.EventHandler(this.ControlsTextsChanged);
            // 
            // lbControlsLeft
            // 
            this.lbControlsLeft.AutoSize = true;
            this.lbControlsLeft.Location = new System.Drawing.Point(191, 230);
            this.lbControlsLeft.Name = "lbControlsLeft";
            this.lbControlsLeft.Size = new System.Drawing.Size(33, 13);
            this.lbControlsLeft.TabIndex = 30;
            this.lbControlsLeft.Text = "LEFT";
            // 
            // tbControlsLeft
            // 
            this.tbControlsLeft.AcceptsTab = true;
            this.tbControlsLeft.BackColor = System.Drawing.Color.LimeGreen;
            this.tbControlsLeft.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbControlsLeft.Location = new System.Drawing.Point(258, 227);
            this.tbControlsLeft.MaxLength = 1;
            this.tbControlsLeft.Name = "tbControlsLeft";
            this.tbControlsLeft.Size = new System.Drawing.Size(63, 20);
            this.tbControlsLeft.TabIndex = 29;
            this.tbControlsLeft.Click += new System.EventHandler(this.ControlsTextsClicked);
            this.tbControlsLeft.TextChanged += new System.EventHandler(this.ControlsTextsChanged);
            // 
            // lbControls
            // 
            this.lbControls.AutoSize = true;
            this.lbControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbControls.Location = new System.Drawing.Point(14, 199);
            this.lbControls.Name = "lbControls";
            this.lbControls.Size = new System.Drawing.Size(104, 20);
            this.lbControls.TabIndex = 35;
            this.lbControls.Text = "CONTROLS";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(338, 343);
            this.Controls.Add(this.lbControls);
            this.Controls.Add(this.lbControlsNewGame);
            this.Controls.Add(this.tbControlsNew);
            this.Controls.Add(this.lbControlsRight);
            this.Controls.Add(this.tbControlsRight);
            this.Controls.Add(this.lbControlsLeft);
            this.Controls.Add(this.tbControlsLeft);
            this.Controls.Add(this.lbControlsPause);
            this.Controls.Add(this.tbControlsPause);
            this.Controls.Add(this.lbControlsDown);
            this.Controls.Add(this.tbControlsDown);
            this.Controls.Add(this.lbControlsUp);
            this.Controls.Add(this.tbControlsUp);
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
        private System.Windows.Forms.TextBox tbControlsUp;
        private System.Windows.Forms.Label lbControlsUp;
        private System.Windows.Forms.Label lbControlsDown;
        private System.Windows.Forms.TextBox tbControlsDown;
        private System.Windows.Forms.Label lbControlsPause;
        private System.Windows.Forms.TextBox tbControlsPause;
        private System.Windows.Forms.Label lbControlsNewGame;
        private System.Windows.Forms.TextBox tbControlsNew;
        private System.Windows.Forms.Label lbControlsRight;
        private System.Windows.Forms.TextBox tbControlsRight;
        private System.Windows.Forms.Label lbControlsLeft;
        private System.Windows.Forms.TextBox tbControlsLeft;
        private System.Windows.Forms.Label lbControls;
    }
}