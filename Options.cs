using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            LoadFromConfig();
        }
        
        private void LoadFromConfig()
        {
            numMapX.Value = Config.MAP_X;
            numMapY.Value = Config.MAP_Y;
            numInitialSize.Value = Config.INITIAL_SNAKE_SIZE;
            cbSpecialFruit.Checked = Config.SPECIAL_FRUIT_AVAILABLE;
            numSpecialFruitPct.Value = Convert.ToDecimal(Config.SPECIAL_FRUIT_PCT);
            numSpecialFruitValue.Value = Config.SPECIAL_FRUIT_VALUE;
            cbMapType.SelectedIndex = (int) Config.MAP_TYPE;
            cbDifficulty.SelectedIndex = (int) Config.DIFFICULTY;
            tbControlsUp.Text = Config.IN_UP.ToString();
            tbControlsDown.Text = Config.IN_DOWN.ToString();
            tbControlsLeft.Text = Config.IN_LEFT.ToString();
            tbControlsRight.Text = Config.IN_RIGHT.ToString();
            tbControlsPause.Text = Config.IN_PAUSE.ToString();
            tbControlsNew.Text = Config.IN_NEW.ToString();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!CheckCorrectControls()) return;
            Config.MAP_TYPE = (MapType) cbMapType.SelectedIndex;
            Config.DIFFICULTY = (Difficulty) cbDifficulty.SelectedIndex;
            Config.MAP_X = Convert.ToInt32(numMapX.Value);
            Config.MAP_Y = Convert.ToInt32(numMapY.Value);
            Config.INITIAL_SNAKE_SIZE = Convert.ToInt32(numInitialSize.Value);
            Config.SPECIAL_FRUIT_AVAILABLE = cbSpecialFruit.Checked;
            Config.SPECIAL_FRUIT_PCT = Convert.ToDouble(numSpecialFruitPct.Value);
            Config.SPECIAL_FRUIT_VALUE = Convert.ToInt32(numSpecialFruitValue.Value);
            Config.IN_UP = (ConsoleKey) tbControlsUp.Text[0];
            Config.IN_DOWN = (ConsoleKey)tbControlsDown.Text[0];
            Config.IN_LEFT = (ConsoleKey)tbControlsLeft.Text[0];
            Config.IN_RIGHT = (ConsoleKey)tbControlsRight.Text[0];
            Config.IN_PAUSE = (ConsoleKey)tbControlsPause.Text[0];
            Config.IN_NEW = (ConsoleKey)tbControlsNew.Text[0];
            Config.SaveConfig();
            MessageBox.Show("Saved changes", "SAVED", MessageBoxButtons.OK);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDefault_Click(object sender, EventArgs e)
        {
            Config.SetToDefault();
            MessageBox.Show("Values set back to default \nChanges will not be saved in memory if SAVE button is not pressed!", "DEFAULT", MessageBoxButtons.OK);
            LoadFromConfig();
        }

        private void ControlsTextsChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "") MessageBox.Show("Please select a valid Key", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ControlsTextsClicked(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = 1;
        }

        private bool CheckCorrectControls()
        {
            bool output = true;
            string[] inputTexts = { tbControlsUp.Text, tbControlsDown.Text, tbControlsLeft.Text, tbControlsRight.Text, tbControlsPause.Text, tbControlsNew.Text};
            foreach(string t in inputTexts)
            {
                if (String.IsNullOrEmpty(t))
                {
                    output = false;
                    MessageBox.Show("There is an empty control value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if(inputTexts.Distinct().Count() != inputTexts.Length)
            {
                output = false;
                MessageBox.Show("There are controls with the same key", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return output;
        }
    }
}
