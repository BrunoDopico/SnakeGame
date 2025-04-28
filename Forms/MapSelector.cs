using Snake_Game.Entities;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Snake_Game.Forms
{
    public partial class MapSelector: Form
    {
        private List<MapInfo> availableMaps = new List<MapInfo>();
        public MapInfo SelectedMap { get; private set; }


        public MapSelector()
        {
            InitializeComponent();
            InitializeMapList();
        }

        private void InitializeMapList()
        {
            availableMaps = MapLoader.GetAvailableMaps(Config.MAP_PATH);
            availableMaps.ForEach(map => lbMaps.Items.Add(Path.GetFileNameWithoutExtension(map.FilePath)));
        }

        private void lbMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMapName = lbMaps.SelectedItem.ToString();

            SelectedMap = availableMaps.FirstOrDefault(map => Path.GetFileNameWithoutExtension(map.FilePath) == selectedMapName);
            tbPreview.Clear();
            SelectedMap.MapLines.ForEach(line => tbPreview.AppendText(line + Environment.NewLine));

            using (Graphics g = tbPreview.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(string.Join(Environment.NewLine, SelectedMap.MapLines), tbPreview.Font);
                tbPreview.Size = new Size((int)Math.Ceiling(textSize.Width) + 15, (int)Math.Ceiling(textSize.Height) + 40);
            }

            lbName.Text = $"Name: {SelectedMap.Name}";
            lbTheme.Text = $"Theme: {SelectedMap.Theme}";
            lbWidth.Text = $"Width: {SelectedMap.Width}";
            lbHeight.Text = $"Height: {SelectedMap.Height}";
            lbDifficulty.Text = $"Difficulty: {SelectedMap.Difficulty.ToString()}";
        }

        private void bt_LoadMap_Click(object sender, EventArgs e)
        {
            string selectedMapName = lbMaps.SelectedItem.ToString();
            SelectedMap = availableMaps.FirstOrDefault(map => Path.GetFileNameWithoutExtension(map.FilePath) == selectedMapName);

            this.DialogResult = DialogResult.OK; // Indicate success
            this.Close();
        }
    }
}
