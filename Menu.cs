using CS332_Lab2.Tasks;
using CS332_Lab3;
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
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CS332_Lab2
{
    public partial class Menu : Form
    {
        private MyImage source = null;
        private MyImage result = null;

        private Point lastPoint, penultimatePoint, beforePenultimatePoint;
        private Color lastColor, penultimateColor, beforePenultimateColor;

        private bool task1 = false;
        private bool task2 = false;
        private bool task3 = false;

        private bool draw = false;

        public Menu()
        {
            InitializeComponent();
        }

        private bool CheckImage()
        {
            if (source == null)
            {
                if (!draw)
                {
                    MessageBox.Show("Сначала загрузите изображение!");
                }
                else
                {
                    MessageBox.Show("Сначала сохраните изображение, а после загрузите его!");
                }
                return false;
            }
            return true;
        }

        private void ChangeEnabledTask1(bool active)
        {
            button_color.Enabled = active;
            button_color.Visible = active;

            button_image.Enabled = active;
            button_image.Visible = active;

            button_bolder.Enabled = active;
            button_bolder.Visible = active;

            label1.Visible = active;
            label2.Visible = active;

            pictureBox_oldcolor.Visible = active;

            pictureBox_newcolor.Visible = active;
            pictureBox_newcolor.Enabled = active;

            pictureBox.Enabled = active;

            task1 = active;
        }

        private void ChangeEnabledTask2(bool active)
        {
            button_bresenham.Enabled = active;
            button_bresenham.Visible = active;

            button_wu.Enabled = active;
            button_wu.Visible = active;

            pictureBox.Enabled = active;

            task2 = active;
        }

        private void ChangeEnabledTask3(bool active)
        {
            button_select_color.Enabled = active;
            button_select_color.Visible = active;

            label1.Visible = active;
            pictureBox_oldcolor.Visible = active;

            button_triangle.Visible = active;
            button_triangle.Enabled = active;

            pictureBox.Enabled = active;

            task3 = active;
        }

        private void UpdateDisplay()
        {
            if (result != null)
            {
                pictureBox.Image = result.Img;
                pictureBox.Refresh();
            }
            else
            {
                pictureBox.Image = null;
                pictureBox.Refresh();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void task1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;

            ChangeEnabledTask2(false);
            ChangeEnabledTask3(false);

            ChangeEnabledTask1(true);

            MessageBox.Show("Выберите исходный цвет и точку для заливки кликом по картинке.");
            MessageBox.Show(@"Выберите новый цвет для заливки кликом по окошку с цветом ""Новый цвет"".");
        }

        private void task2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;

            ChangeEnabledTask1(false);
            ChangeEnabledTask3(false);

            ChangeEnabledTask2(true);
        }

        private void task3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            source = MyImage.CreateWhiteImage(pictureBox.Width, pictureBox.Height);
            result = source.Copy();
            UpdateDisplay();

            ChangeEnabledTask1(false);
            ChangeEnabledTask2(false);

            ChangeEnabledTask3(true);
        }

        private void button_image_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif|All files|*.*";
            openFileDialog.Title = "Выберите изображение";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MyImage pattern = new MyImage(openFileDialog.FileName);
                    result = Task1.Fill(result, lastPoint, Task1.FillType.FillImage, pattern: pattern, oldColor: pictureBox_oldcolor.BackColor);

                    UpdateDisplay();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_bolder_Click(object sender, EventArgs e)
        {
            List<Point> points = Task1.GetBorder(result, penultimatePoint, pictureBox_oldcolor.BackColor);
            result = Task1.DrawPixels(result, pictureBox_newcolor.BackColor, points);
            UpdateDisplay();
        }

        private void button_color_Click(object sender, EventArgs e)
        {
            result = Task1.Fill(result, lastPoint, Task1.FillType.FillColor, oldColor: pictureBox_oldcolor.BackColor, newColor: pictureBox_newcolor.BackColor);
            UpdateDisplay();
        }

        private void button_bresenham_Click(object sender, EventArgs e)
        {
            result = Task2.DrawLine(result, Task2.LineAlgorithm.Bresenham, lastPoint, penultimatePoint, Color.Black);
            UpdateDisplay();
        }

        private void button_wu_Click(object sender, EventArgs e)
        {
            result = Task2.DrawLine(result, Task2.LineAlgorithm.Wu, lastPoint, penultimatePoint, Color.Black);
            UpdateDisplay();
        }

        private void button_select_color_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_oldcolor.BackColor = colorDialog.Color;

                beforePenultimateColor = penultimateColor;
                penultimateColor = lastColor;
                lastColor = colorDialog.Color;
            }
            
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeEnabledTask1(false);
            ChangeEnabledTask1(false);
            ChangeEnabledTask1(false);

            draw = false;
            pictureBox.Enabled = false;

            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif|All files|*.*";
            openFileDialog.Title = "Выберите изображение";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    source = new MyImage(openFileDialog.FileName);
                    result = source.Copy();

                    UpdateDisplay();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeEnabledTask1(false);
            ChangeEnabledTask1(false);
            ChangeEnabledTask1(false);

            if (result == null)
            {
                MessageBox.Show("Сначала нарисуйте или загрузите изображение!");
                return;
            }

            draw = false;
            pictureBox.Enabled = false;

            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp|All files|*.*";
            saveFileDialog.Title = "Сохранить изображение";
            saveFileDialog.DefaultExt = "png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    result.Save(saveFileDialog.FileName);
                    MessageBox.Show("Изображение успешно сохранено", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении изображения: {ex.Message}", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw = false;
            pictureBox.Enabled = false;

            ChangeEnabledTask1(false);
            ChangeEnabledTask2(false);
            ChangeEnabledTask3(false);

            if (!CheckImage()) return;

            result = source.Copy();
            UpdateDisplay();
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (draw || !CheckImage()) return;

            Point imageCoord = GetCoordinates(e.Location);

            beforePenultimatePoint = penultimatePoint;
            penultimatePoint = lastPoint;
            lastPoint = imageCoord;

            if (task1) 
            {
                if (!draw)
                {
                    pictureBox_oldcolor.BackColor = result.Img.GetPixel(imageCoord.X, imageCoord.Y);
                }
            }
            if (task2)
            {
                result.Img.SetPixel(imageCoord.X, imageCoord.Y, Color.Black);
                UpdateDisplay();
            }
            if (task3)
            {
                result.Img.SetPixel(imageCoord.X, imageCoord.Y, pictureBox_newcolor.BackColor);
                UpdateDisplay();
            }
        }

        private void button_triangle_Click(object sender, EventArgs e)
        {
            Task3.ColorPoint colPoint1 = new Task3.ColorPoint(lastPoint, lastColor);
            Task3.ColorPoint colPoint2 = new Task3.ColorPoint(penultimatePoint, penultimateColor);
            Task3.ColorPoint colPoint3 = new Task3.ColorPoint(beforePenultimatePoint, beforePenultimateColor);

            result = Task3.TriangleRasterization(result, colPoint1, colPoint2, colPoint3);
            UpdateDisplay();
        }

        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeEnabledTask1(false);
            ChangeEnabledTask1(false);
            ChangeEnabledTask1(false);

            pictureBox.Enabled = true;

            result = MyImage.CreateWhiteImage(pictureBox.Width, pictureBox.Height);
            UpdateDisplay();
            draw = true;
        }


        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point loc = e.Location;
                    if (loc.X < pictureBox.Width && loc.X > 0 && loc.Y < pictureBox.Height && loc.Y > 0)
                    {
                        result.Img.SetPixel(loc.X, loc.Y, Color.Black);
                        UpdateDisplay();
                    }
                }
            }
        }

        private Point GetCoordinates(Point mousePos)
        {
            if (draw)
            {
                return new Point(0, 0);
            }
            float imageAspect = (float)source.Width / source.Height;
            float boxAspect = (float)pictureBox.Width / pictureBox.Height;

            int imageWidth, imageHeight;
            int offsetX, offsetY;

            if (imageAspect > boxAspect)
            {
                imageWidth = pictureBox.Width;
                imageHeight = (int)(pictureBox.Width / imageAspect);
                offsetX = 0;
                offsetY = (pictureBox.Height - imageHeight) / 2;
            }
            else
            {
                imageHeight = pictureBox.Height;
                imageWidth = (int)(pictureBox.Height * imageAspect);
                offsetX = (pictureBox.Width - imageWidth) / 2;
                offsetY = 0;
            }

            if (mousePos.X < offsetX || mousePos.X >= offsetX + imageWidth ||
                mousePos.Y < offsetY || mousePos.Y >= offsetY + imageHeight)
            {
                return Point.Empty;
            }

            double scaleX = (double)source.Width / imageWidth;
            double scaleY = (double)source.Height / imageHeight;

            return new Point(
                (int)((mousePos.X - offsetX) * scaleX),
                (int)((mousePos.Y - offsetY) * scaleY)
            );
        }

        private void pictureBox_newcolor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_newcolor.BackColor = colorDialog.Color;
            }
        }
    }
}
