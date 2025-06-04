using Snake_Game.Entities;
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
            panelPreview.Paint += panelPreview_Paint;
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

            panelPreview.Invalidate();

            lbName.Text = $"Name: {SelectedMap.Name}";
            lbTheme.Text = $"Theme: {SelectedMap.Theme}";
            lbWidth.Text = $"Width: {SelectedMap.Width}";
            lbHeight.Text = $"Height: {SelectedMap.Height}";
            lbDifficulty.Text = $"Difficulty: {SelectedMap.Difficulty}";
            UpdateDifficultyLabel(SelectedMap.Difficulty);
        }

        private void bt_LoadMap_Click(object sender, EventArgs e)
        {
            if (lbMaps.SelectedItem == null)
            {
                MessageBox.Show("Please select a map first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string selectedMapName = lbMaps.SelectedItem.ToString();
            SelectedMap = availableMaps.FirstOrDefault(map => Path.GetFileNameWithoutExtension(map.FilePath) == selectedMapName);

            this.DialogResult = DialogResult.OK; // Indicate success
            this.Close();
        }

        private void panelPreview_Paint(object sender, PaintEventArgs e)
        {
            if (SelectedMap == null || SelectedMap.MapLines == null)
                return;

            int cellSize = 20; // Size of each square cell in pixels
            var g = e.Graphics;

            for (int y = 0; y < SelectedMap.MapLines.Count; y++)
            {
                string line = SelectedMap.MapLines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    char c = line[x];
                    Rectangle cellRect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);

                    switch (c)
                    {
                        case '#': // Wall
                            g.FillRectangle(Brushes.DimGray, cellRect);
                            break;
                        case '<':
                        case '^':
                        case '>':
                        case 'v': // Snake head
                            g.FillEllipse(Brushes.Green, cellRect);
                            using (var font = new Font("Consolas", 16, FontStyle.Bold))
                            {
                                var text = c.ToString();
                                SizeF textSize = g.MeasureString(text, font);
                                float textX = cellRect.X + (cellRect.Width - textSize.Width) / 2;
                                float textY = cellRect.Y + (cellRect.Height - textSize.Height) / 2;
                                g.DrawString(text, font, Brushes.White, textX, textY);
                            }
                            break;
                        case 'O': // Snake body
                            g.FillRectangle(Brushes.LightGreen, cellRect);
                            break;
                        case 'F': // Fruit
                            g.FillEllipse(Brushes.Red, cellRect);
                            break;
                        case 'S': // Special Fruit
                            g.FillEllipse(Brushes.Gold, cellRect);
                            break;
                        case 'D': // Disappear Fruit
                            g.FillEllipse(Brushes.LightSalmon, cellRect);
                            break;
                        default: // Empty
                            break;
                    }

                    // Optional: draw grid lines
                    g.DrawRectangle(Pens.DarkGray, cellRect);
                }
            }
            panelPreview.Size = new Size(SelectedMap.Width * cellSize, SelectedMap.Height * cellSize);
        }
        // Add this method to MapSelector
        private void UpdateDifficultyLabel(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    lbDifficulty.ForeColor = Color.Green;
                    break;
                case Difficulty.Medium:
                    lbDifficulty.ForeColor = Color.Orange;
                    break;
                case Difficulty.Hard:
                    lbDifficulty.ForeColor = Color.Red;
                    break;
                case Difficulty.Hardcore:
                    lbDifficulty.ForeColor = Color.Purple;
                    break;
                default:
                    lbDifficulty.ForeColor = SystemColors.ControlText;
                    break;
            }
        }
    }
}
