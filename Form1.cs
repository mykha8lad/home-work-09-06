using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            DrawWater(graphics);
            DrawBackground(graphics);
            DrawShip(graphics);
        }

        private void DrawWater(Graphics g)
        {            
            Rectangle waterRect = new Rectangle(0, ClientSize.Height / 2 + 10, ClientSize.Width, ClientSize.Height / 2);
            using (LinearGradientBrush waterBrush = new LinearGradientBrush(waterRect, Color.DarkBlue, Color.LightBlue, LinearGradientMode.Vertical))
            {
                g.FillRectangle(waterBrush, waterRect);
            }
        }

        private void DrawBackground(Graphics g)
        {            
            Rectangle skyRect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height / 2 + 11);
            using (LinearGradientBrush skyBrush = new LinearGradientBrush(skyRect, ColorTranslator.FromHtml("#300A57"), ColorTranslator.FromHtml("#0D104B"), LinearGradientMode.Vertical))
            {
                g.FillRectangle(skyBrush, skyRect);
            }
            
            int moonSize = 80;
            int moonX = ClientSize.Width - moonSize - 20;
            int moonY = 20;
            Rectangle moonRect = new Rectangle(moonX, moonY, moonSize, moonSize);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            using (SolidBrush moonBrush = new SolidBrush(ColorTranslator.FromHtml("#EBB514")))
            {
                g.FillEllipse(moonBrush, moonRect);
            }
        }

        private void DrawShip(Graphics g)
        {
            Color shipColor = Color.DarkGray;
            Color chimneyColor = Color.Gray;
            Color windowColor = Color.Yellow;
            Color outlineColor = Color.Black;

            int shipWidth = 400;
            int shipHeight = 80;
            int shipX = (ClientSize.Width - shipWidth + 200) / 2;
            int shipY = (ClientSize.Height - shipHeight) / 2;

            using (SolidBrush shipBrush = new SolidBrush(shipColor))
            using (Pen shipPen = new Pen(outlineColor))
            {
                g.FillRectangle(shipBrush, shipX, shipY, shipWidth, shipHeight);

                int triangleWidth = 50;
                int triangleHeight = 60;
                int triangleX = 250;
                int triangleY = (ClientSize.Height - triangleHeight + 20) / 2;

                Point[] trianglePoints1 = new Point[]
            {
                new Point(triangleX + triangleWidth + 1, triangleY),
                new Point(triangleX, triangleY),
                new Point(triangleX + triangleWidth + 1, triangleY + triangleHeight)
            };
                using (SolidBrush fillBrush = new SolidBrush(shipColor))
                using (Pen outlinePen = new Pen(outlineColor))
                {
                    g.FillPolygon(fillBrush, trianglePoints1);
                }

                Point[] trianglePoints2 = new Point[]
            {
                new Point(triangleX + 449, triangleY - 10),
                new Point(triangleX + triangleWidth + 430, triangleY - 10),
                new Point(triangleX + 449, triangleY + triangleHeight)
            };

                using (SolidBrush fillBrush = new SolidBrush(shipColor))
                using (Pen outlinePen = new Pen(outlineColor))
                {
                    g.FillPolygon(fillBrush, trianglePoints2);
                }
            }

            int chimneyWidth = 30;
            int chimneyHeight = 50;
            int chimneyX1 = shipX + 90;
            int chimneyY1 = shipY - chimneyHeight;
            int chimneyX2 = shipX + shipWidth - chimneyWidth - 210;
            int chimneyY2 = shipY - chimneyHeight;
            int chimneyX3 = shipX + shipWidth - chimneyWidth - 140;
            int chimneyY3 = shipY - chimneyHeight;
            int chimneyX4 = shipX + shipWidth - chimneyWidth - 70;
            int chimneyY4 = shipY - chimneyHeight;

            using (SolidBrush chimneyBrush = new SolidBrush(chimneyColor))
            using (Pen chimneyPen = new Pen(outlineColor))
            {
                g.FillRectangle(chimneyBrush, chimneyX1, chimneyY1, chimneyWidth, chimneyHeight);
                g.FillRectangle(chimneyBrush, chimneyX2, chimneyY2, chimneyWidth, chimneyHeight);
                g.FillRectangle(chimneyBrush, chimneyX3, chimneyY3, chimneyWidth, chimneyHeight);
                g.FillRectangle(chimneyBrush, chimneyX4, chimneyY4, chimneyWidth, chimneyHeight);
            }

            int windowSize = 10;
            int windowSpacing = 5;
            int numWindows = (shipWidth - 2 * windowSpacing) / (windowSize + windowSpacing);
            int windowsY = shipY + (shipHeight - windowSize) / 2;

            using (SolidBrush windowBrush = new SolidBrush(windowColor))
            using (Pen windowPen = new Pen(outlineColor))
            {
                for (int i = 0; i < numWindows; i++)
                {
                    int windowX = shipX + windowSpacing + i * (windowSize + windowSpacing);
                    g.FillRectangle(windowBrush, windowX, windowsY, windowSize, windowSize);
                }
            }
        }
    }
}