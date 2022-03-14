using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ImageFilter_Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap currImage;
        int imWidth, imHeight;       
        bool isOpen = false; //флаг наличия открытого изображения
        int curBright = 5;
        int curContrast = 5;

        /// <summary>
        /// Загрузка изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadImage_Click(object sender, EventArgs e)
        {
            openFileDialogImage.RestoreDirectory = true;
            isOpen = false; // если изображение не было выбрано

            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialogImage.FileName;
                pictureBox1.Image = Image.FromFile(imagePath);
                currImage = new Bitmap(pictureBox1.Image);
                imWidth = pictureBox1.Image.Width;
                imHeight = pictureBox1.Image.Height;
                isOpen = true;
            }
        }

        /// <summary>
        /// Равномерный фильтр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Perform_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                _ = MessageBox.Show("Нет изображения", "Предупреждение", MessageBoxButtons.OK);
                return;
            }
            double[] filter = new double[] {
                1.0f/9, 1.0f/9, 1.0f/9,
                1.0f/9, 1.0f/9, 1.0f/9,
                1.0f/9, 1.0f/9, 1.0f/9
            };
            PerformFilter(filter);

        }

        /// <summary>
        /// Медианный фильтр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Median_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                _ = MessageBox.Show("Нет изображения", "Предупреждение", MessageBoxButtons.OK);
                return;
            }
            int appertSize = 3;
            Bitmap image1 = new Bitmap(imWidth + 2 * (appertSize / 2), imHeight + 2 * (appertSize / 2));
            Bitmap image2 = new Bitmap(imWidth, imHeight);

            Color color;
            for (int i = 0; i < imWidth; i++)
                for (int j = 0; j < imHeight; j++)
                {
                    color = currImage.GetPixel(i, j);
                    image1.SetPixel(i + (appertSize / 2), j + (appertSize / 2), color);
                }

            //fix up
            for (int i = appertSize / 2; i < imWidth + appertSize / 2; i++)
                for (int j = 0; j < appertSize / 2; j++)
                {
                    color = currImage.GetPixel(i - appertSize / 2, j + appertSize);
                    image1.SetPixel(i, j, color);
                }

            //fix down
            for (int i = appertSize / 2; i < imWidth + appertSize / 2; i++)
                for (int j = imHeight + appertSize / 2; j < imHeight + appertSize - 1; j++)
                {
                    color = currImage.GetPixel(i - appertSize / 2, j - appertSize);
                    image1.SetPixel(i, j, color);
                }

            //fix left
            for (int i = 0; i < appertSize / 2; i++)
                for (int j = 0; j < imHeight + appertSize - 1; j++)
                {
                    color = image1.GetPixel(i + appertSize / 2, j);
                    image1.SetPixel(i, j, color);
                }

            //fix right
            for (int i = imWidth + appertSize / 2; i < imWidth + appertSize - 1; i++)
                for (int j = 0; j < imHeight + appertSize - 1; j++)
                {
                    color = image1.GetPixel(i - appertSize / 2 - 1, j);
                    image1.SetPixel(i, j, color);
                }


            int index = 0;
            //последовательность которая подвергается сортировке
            Color[] mas = new Color[appertSize * appertSize];

            //перебор всех пикселей
            for (int i = appertSize / 2; i < imWidth + appertSize / 2; i++)
            {
                for (int j = appertSize / 2; j < imHeight + appertSize / 2; j++)
                {
                    //вычисление аппертуры для каждого из них
                    index = 0;
                    for (int x = -appertSize / 2; x < appertSize / 2 + 1; x++)
                        for (int y = -appertSize / 2; y < appertSize / 2 + 1; y++)
                            mas[index++] = image1.GetPixel(i + x, j + y);

                    //перекрашиваем пиксель в цвет среднего эл-та последовательности
                    image1.SetPixel(i, j, GetMiddle(mas));
                }
            }


            //возвращение изображения к старым координатам - обрезание апертуры на краях
            for (int i = 0; i < imWidth; i++)
                for (int j = 0; j < imHeight; j++)
                {
                    color = image1.GetPixel(i + (appertSize / 2), j + (appertSize / 2));
                    image2.SetPixel(i, j, color);
                }

            Graphics g = pictureBox1.CreateGraphics();
            currImage = image2;
            pictureBox1.Image = (Image)currImage;
        }

        /// <summary>
        /// Добавить резкости
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSharpness_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                _ = MessageBox.Show("Нет изображения", "Предупреждение", MessageBoxButtons.OK);
                return;
            }
            double[] filter = new double[] {
                -1.0f/4, -1.0f/4, -1.0f/4,
                -1.0f/4, 3.0f, -1.0f/4,
                -1.0f/4, -1.0f/4, -1.0f/4
            };
            PerformFilter(filter);
        }

        /// <summary>
        /// Добавить шумы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNoise_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                _ = MessageBox.Show("Нет изображения", "Предупреждение", MessageBoxButtons.OK);
                return;
            }
            Graphics g = pictureBox1.CreateGraphics();
            g = Graphics.FromImage(currImage);
            //выбираем кисть для шума
            Pen noisePen = new Pen(Color.White, 1);
            Random rand = new Random();


            //количество шума в изображении
            int amountNoise = (imWidth * imHeight) / 100;

            Pen pen = new Pen(Color.White, 1);
            for (var i = 0; i < amountNoise; i++)
            {
                g.DrawEllipse(pen, rand.Next(currImage.Width), rand.Next(currImage.Height), 1, 1);
            }

            //вывод изображения
            g = pictureBox1.CreateGraphics();
            pictureBox1.Image = (Image)currImage;
        }

        /// <summary>
        /// Акварелизация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Acvarel_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                _ = MessageBox.Show("Нет изображения", "Предупреждение", MessageBoxButtons.OK);
                return;
            }
            Median_Click(sender, e);
            Median_Click(sender, e);
            AddSharpness_Click(sender, e);
        }

        /// <summary>
        /// Черно-белое изображение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlackWhiteColor_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                _ = MessageBox.Show("Нет изображения", "Предупреждение", MessageBoxButtons.OK);
                return;
            }
            for (int i = 0; i < imHeight; i++)
            {
                for (int j = 0; j < imWidth; j++)
                {
                    int brightness_px = Convert.ToInt32(Math.Round(0.299f * currImage.GetPixel(j, i).R + 0.5876f * currImage.GetPixel(j, i).G + 0.114f * currImage.GetPixel(j, i).B));
                    if (brightness_px < 128)
                        currImage.SetPixel(j, i, Color.Black);
                    else
                        currImage.SetPixel(j, i, Color.White);
                }
            }
            pictureBox1.Image = (Image)currImage;
        }

        /// <summary>
        /// Оттенки серого
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrayColor_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                _ = MessageBox.Show("Нет изображения", "Предупреждение", MessageBoxButtons.OK);
                return;
            }

            for (int i = 0; i < imHeight; i++)
            {
                for (int j = 0; j < imWidth; j++)
                {
                    int brightPx = Convert.ToInt32(Math.Round(0.299f * currImage.GetPixel(j, i).R + 0.5876f * currImage.GetPixel(j, i).G + 0.114f * currImage.GetPixel(j, i).B));
                    currImage.SetPixel(j, i, Color.FromArgb(brightPx, brightPx, brightPx));
                }
            }
            pictureBox1.Image = (Image)currImage;
        }


        private void Negative_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                _ = MessageBox.Show("Нет изображения", "Предупреждение", MessageBoxButtons.OK);
                return;
            }
            for (int i = 0; i < imHeight; i++)
            {
                for (int j = 0; j < imWidth; j++)
                {
                    int r = currImage.GetPixel(j, i).R;
                    int g = currImage.GetPixel(j, i).G;
                    int b = currImage.GetPixel(j, i).B;
                    currImage.SetPixel(j, i, Color.FromArgb(255 - r, 255 - g, 255 - b));
                }
            }
            pictureBox1.Image = (Image)currImage;

        }

        /// <summary>
        /// Корректировка яркости
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorrectBrightTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                _ = MessageBox.Show("Нет изображения", "Предупреждение", MessageBoxButtons.OK);
                return;
            }
            float bright = (correctBrightTrackBar.Value - curBright) * 10;
            for (int i = 0; i < imHeight; i++)
            {
                for (int j = 0; j < imWidth; j++)
                {
                    int r = currImage.GetPixel(j, i).R + Convert.ToInt32(Math.Round(bright));
                    if (r < 0) r = 0;
                    if (r > 255) r = 255;
                    int g = currImage.GetPixel(j, i).G + Convert.ToInt32(Math.Round(bright));
                    if (g < 0) g = 0;
                    if (g > 255) g = 255;
                    int b = currImage.GetPixel(j, i).B + Convert.ToInt32(Math.Round(bright));
                    if (b < 0) b = 0;
                    if (b > 255) b = 255;

                    currImage.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
            }
            pictureBox1.Image = (Image)currImage;
            curBright = correctBrightTrackBar.Value;
        }

        /// <summary>
        /// Корректировка контрастности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorrectContrastTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                _ = MessageBox.Show("Нет изображения", "Предупреждение", MessageBoxButtons.OK);
                return;
            }
            int r_avg = 0;
            int g_avg = 0;
            int b_avg = 0;
            for (int i = 0; i < imHeight; i++)
            {
                for (int j = 0; j < imWidth; j++)
                {
                    r_avg += currImage.GetPixel(j, i).R;
                    g_avg += currImage.GetPixel(j, i).G;
                    b_avg += currImage.GetPixel(j, i).B;
                }
            }
            r_avg /= imWidth * imHeight;
            g_avg /= imWidth * imHeight;
            b_avg /= imWidth * imHeight;

            float contrast = Convert.ToSingle(1.0 + (correctContrastTrackBar.Value - curContrast) / 5f);

            for (int i = 0; i < imHeight; i++)
            {
                for (int j = 0; j < imWidth; j++)
                {
                    var oldColor = currImage.GetPixel(j, i);
                    var red = contrast * (oldColor.R - r_avg) + r_avg;
                    var green = contrast * (oldColor.G - g_avg) + g_avg;
                    var blue = contrast * (oldColor.B - b_avg) + b_avg;

                    if (red > 255) red = 255;
                    if (red < 0) red = 0;
                    if (green > 255) green = 255;
                    if (green < 0) green = 0;
                    if (blue > 255) blue = 255;
                    if (blue < 0) blue = 0;

                    var newColor = Color.FromArgb((int)red, (int)green, (int)blue);
                    currImage.SetPixel(j, i, newColor);
                }
            }
            pictureBox1.Image = (Image)currImage;
            curContrast = correctContrastTrackBar.Value;
        }

        //------------------------
        // Вспомогательные функции
        //------------------------

        /// <summary>
        /// Получение среднего цвета
        /// </summary>
        /// <param name="e"> массив цветов </param>
        /// <returns> средний цвет </returns>
        private Color GetMiddle(Color[] e)
        {
            int size = e.Length;
            double[] brightness = new double[size];
            for (int i = 0; i < size; i++)
                brightness[i] = (0.299 * e[i].R + 0.5876 * e[i].G + 0.114 * e[i].B);
            Array.Sort(brightness, e);
            return e[size / 2];
        }

        /// <summary>
        /// Равномерный фильтр
        /// </summary>
        /// <param name="filter"> матрица специального вида </param>
        private void PerformFilter(double[] filter)
        {
            int appertSize = (int)Math.Sqrt(filter.Length);
            Bitmap image1 = new Bitmap(imWidth + 2 * (appertSize / 2), imHeight + 2 * (appertSize / 2));
            Bitmap image2 = new Bitmap(imWidth, imHeight);

            Color color;
            for (int i = 0; i < imWidth; i++)
                for (int j = 0; j < imHeight; j++)
                {
                    color = currImage.GetPixel(i, j);
                    image1.SetPixel(i + (appertSize / 2), j + (appertSize / 2), color);
                }

            //fix up
            for (int i = appertSize / 2; i < imWidth + appertSize / 2; i++)
                for (int j = 0; j < appertSize / 2; j++)
                {
                    color = currImage.GetPixel(i - appertSize / 2, j + appertSize);
                    image1.SetPixel(i, j, color);
                }

            //fix down
            for (int i = appertSize / 2; i < imWidth + appertSize / 2; i++)
                for (int j = imHeight + appertSize / 2; j < imHeight + appertSize - 1; j++)
                {
                    color = currImage.GetPixel(i - appertSize / 2, j - appertSize);
                    image1.SetPixel(i, j, color);
                }

            //fix left
            for (int i = 0; i < appertSize / 2; i++)
                for (int j = 0; j < imHeight + appertSize - 1; j++)
                {
                    color = image1.GetPixel(i + appertSize / 2, j);
                    image1.SetPixel(i, j, color);
                }

            //fix right
            for (int i = imWidth + appertSize / 2; i < imWidth + appertSize - 1; i++)
                for (int j = 0; j < imHeight + appertSize - 1; j++)
                {
                    color = image1.GetPixel(i - appertSize / 2 - 1, j);
                    image1.SetPixel(i, j, color);
                }

            double red, green, blue;
            double currAppert;

            //перебор всех пикселей
            for (int i = appertSize / 2; i < imWidth + appertSize / 2; i++)
            {
                for (int j = appertSize / 2; j < imHeight + appertSize / 2; j++)
                {
                    red = 0; green = 0; blue = 0;
                    //вычисление цвета для каждого из них
                    int index = 0;
                    for (int x = -appertSize / 2; x < appertSize / 2 + 1; x++)
                        for (int y = -appertSize / 2; y < appertSize / 2 + 1; y++)
                        {
                            currAppert = filter[index++];
                            color = image1.GetPixel(i + x, j + y);
                            red += currAppert * color.R;
                            green += currAppert * color.G;
                            blue += currAppert * color.B;
                        }
                    if (red > 255) red = 255;
                    if (red < 0) red = 0;
                    if (green > 255) green = 255;
                    if (green < 0) green = 0;
                    if (blue > 255) blue = 255;
                    if (blue < 0) blue = 0;
                    //перекрашиваем пиксель в цвет среднего эл-та последовательности
                    image2.SetPixel(i - appertSize / 2, j - appertSize / 2, Color.FromArgb((int)red, (int)green, (int)blue));
                }
            }
            currImage = image2;
            pictureBox1.Image = (Image)currImage;
        }
    }
}
