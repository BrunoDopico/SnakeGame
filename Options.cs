using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            cbMapType.SelectedIndex = Config.MAP_TYPE;
            cbDifficulty.SelectedIndex = Config.DIFFICULTY;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Config.MAP_TYPE = cbMapType.SelectedIndex;
            Config.DIFFICULTY = cbDifficulty.SelectedIndex;
            Config.MAP_X = Convert.ToInt32(numMapX.Value);
            Config.MAP_Y = Convert.ToInt32(numMapY.Value);
            Config.INITIAL_SNAKE_SIZE = Convert.ToInt32(numInitialSize.Value);
            Config.SPECIAL_FRUIT_AVAILABLE = cbSpecialFruit.Checked;
            Config.SPECIAL_FRUIT_PCT = Convert.ToDouble(numSpecialFruitPct.Value);
            Config.SPECIAL_FRUIT_VALUE = Convert.ToInt32(numSpecialFruitValue.Value);
            MessageBox.Show("Saved changes", "SAVED", MessageBoxButtons.OK);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
