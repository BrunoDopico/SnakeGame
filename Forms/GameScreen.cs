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

namespace Snake_Game.Forms
{
    public partial class GameScreen : Form, IGameView
    {
        // Timer parameters
        private Timer countdownTimer;
        private int countdownValue;
        private Action pendingGameStart;
        private bool showCountdown = false;

        // Game controller
        GameController _controller;
        Timer gameLoop = new Timer();
        bool inGame = false;

        // UI elements
        private int defaultFormWidth;
        private int cellSize = 32;

        public GameScreen()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
            null, panelGame, new object[] { true });

            gameLoop.Tick += GameLoop;
            _controller = new GameController(this);
            defaultFormWidth = this.Width;
        }

        public void PaintMap()
        {
            panelGame.Invalidate();
        }

        public void UpdateCell(int x, int y)
        {
            Rectangle cellRect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);
            panelGame.Invalidate(cellRect);
        }
        private void StartCountdownThenGameLoop()
        {
            countdownValue = 3;

            showCountdown = true;
            panelGame.Invalidate();

            if (countdownTimer == null)
            {
                countdownTimer = new Timer();
                countdownTimer.Interval = 1000;
                countdownTimer.Tick += CountdownTimer_Tick;
            }
            pendingGameStart = StartGameLoop;
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            countdownValue--;
            if (countdownValue > 0)
            {
                panelGame.Invalidate();
            }
            else
            {
                countdownTimer.Stop();
                showCountdown = false;
                panelGame.Invalidate();
                pendingGameStart?.Invoke();
                pendingGameStart = null;
            }
        }

        private void SetupRandomGame()
        {
            ThemeManager.LoadTheme("Default");
            panelGame.Size = new Size(Config.MAP_X * cellSize, Config.MAP_Y * cellSize);
            int width = Math.Max(defaultFormWidth, panelGame.Right + 32);
            int height = panelGame.Bottom +32;
            this.Size = new Size(width, height);
            this.CenterToScreen();

            _controller.StartRandomGame();
            PaintMap();
            
        }

        private void SetupCustomGame(MapInfo customMap)
        {
            ThemeManager.LoadTheme(customMap.Theme);
            _controller.StartCustomGame(customMap);
            panelGame.Size = new Size(Config.MAP_X * cellSize, Config.MAP_Y * cellSize);
            int width = Math.Max(defaultFormWidth, panelGame.Right + 64);
            int height = panelGame.Bottom + 128;
            this.Size = new Size(width, height);
            this.CenterToScreen();
            PaintMap();
        }

        private void StartGameLoop()
        {
            gameLoop.Interval = Config.TIMER;   // milliseconds
            gameLoop.Start();
            inGame = true;
            SoundManager.PlayBackgroundMusic();
        }

        private void GameLoop(object sender, EventArgs e)  //run this logic each timer tick
        {
            Task.Run(() =>
         {
             _controller.Step();
             if (_controller.Lose)
             {
                 Invoke(new Action(() =>
                 {
                     gameLoop.Stop();
                     inGame = false;
                     SoundManager.StopBackgroundMusic();
                     SoundManager.PlayEffect("death");
                 }));
             }
         });
        }

        private void Pause()
        {
            gameLoop.Stop();
            MessageBox.Show("Game is paused", "PAUSE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gameLoop.Start();
        }

        private void GameScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            ConsoleKey key = (ConsoleKey)Char.ToUpper(e.KeyChar);
            if (key.Equals(Config.IN_PAUSE)) Pause();
            else if (key.Equals(Config.IN_NEW))
            {
                SoundManager.PlayEffect("click");
                SetupRandomGame();
                StartCountdownThenGameLoop();
            }
            else _controller.getInput(key);
        }

        private void bt_Options_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            gameLoop.Stop();
            Form options = new Options();
            options.ShowDialog(this);
            if (inGame) gameLoop.Start();
        }

        private void bt_newGame_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            SetupRandomGame();
            StartCountdownThenGameLoop();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            Application.Exit();
        }

        private void bt_Credits_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            gameLoop.Stop();
            MessageBox.Show("- THE GAME -\n" +
                "\nThis is the snake game." +
                "\nThe objective of this game is to survive for as long as possible while eating fruits to make your snake's body larger." +
                "\nTouching an obstacle or your own body will instantly kill you.\n" +
                "\n- CONTROLS -\n" +
                " · Move Up: " + Config.IN_UP.ToString() +
                "\n · Move Down: " + Config.IN_DOWN.ToString() +
                "\n · Move Left: " + Config.IN_LEFT.ToString() +
                "\n · Move Right: " + Config.IN_RIGHT.ToString() +
                "\n · Pause: " + Config.IN_PAUSE.ToString() +
                "\n · New Random Game: " + Config.IN_NEW.ToString() +
                "\n (Can be changed in options)\n" +
                "\n- CREDITS -\n" +
                "Game made by Bruno (BrunusOP) Dopico\n", "CREDITS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (inGame) gameLoop.Start();
        }

        private void btLoadMap_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            using (var mapSelector = new MapSelector())
            {
                if (mapSelector.ShowDialog() == DialogResult.OK)
                {
                    MapInfo selectedMap = mapSelector.SelectedMap;

                    SetupCustomGame(selectedMap);
                    StartCountdownThenGameLoop();
                }
                else
                {
                    MessageBox.Show("No map was selected.", "Map Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttons_MouseEnter(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("hover");
        }

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            if (_controller?.Map == null) return;
            var g = e.Graphics;
            var clip = e.ClipRectangle;

            // Calculate the range of cell indices that intersect with the clip rectangle
            int minX = Math.Max(0, clip.Left / cellSize);
            int maxX = Math.Min(Config.MAP_X - 1, (clip.Right - 1) / cellSize);
            int minY = Math.Max(0, clip.Top / cellSize);
            int maxY = Math.Min(Config.MAP_Y - 1, (clip.Bottom - 1) / cellSize);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    Rectangle cellRect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);

                    // Draw background
                    Image background = ThemeManager.GetSprite(SpriteType.Background);
                    if (background != null)
                        g.DrawImage(background, cellRect);

                    // Draw cell sprite
                    Cell current = _controller.Map[x, y];
                    Image sprite = ThemeManager.GetSprite(current.Sprite);

                    if (sprite != null)
                        g.DrawImage(sprite, cellRect);
                }
            }

            if (showCountdown && countdownValue > 0)
            {
                string text = countdownValue.ToString();
                using (Font font = new Font("Showcard Gothic", 48, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(180, Color.White))) // semi-transparent white
                {
                    SizeF textSize = g.MeasureString(text, font);
                    float x = (panelGame.Width - textSize.Width) / 2;
                    float y = (panelGame.Height - textSize.Height) / 2;
                    g.DrawString(text, font, brush, x, y);
                }
            }
        }

        public void ChangeTime(int seconds)
        {
            if (lbTime.InvokeRequired)
            {
                lbTime.Invoke(new Action(() => ChangeTime(seconds)));
            }
            else
            {
                lbTime.Text = "Time: " + seconds.ToString();
                lbTime.BringToFront();
            }
        }

        public void ChangeScore(int score)
        {
            if (lbScore.InvokeRequired)
            {
                lbScore.Invoke(new Action(() => ChangeScore(score)));
            }
            else
            {
                lbScore.Text = "Score: " + score;
                lbScore.BringToFront();
            }
        }
    }
}
