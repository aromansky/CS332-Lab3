using CS332_Lab3;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS332_Lab3
{   
    public class Task3
    {
        /// <summary>
        /// Точка с цветок
        /// </summary>
        public struct ColorPoint
        {
            /// <summary>
            /// Расположение точки
            /// </summary>
            public Point Location { get; set; }

            /// <summary>
            /// Цвет точки
            /// </summary>
            public Color PointColor { get; set; }

            /// <summary>
            /// Конструктор точки
            /// </summary>
            /// <param name="location">Расположение точки</param>
            /// <param name="color">Цвет точки</param>
            public ColorPoint(Point location, Color color)
            {
                Location = location;
                PointColor = color;
            }
        }

        /// <summary>
        /// Градиентное окрашивание произвольного треугольника
        /// </summary>
        /// <param name="point1">Точка A</param>
        /// <param name="point2">точка B</param>
        /// <param name="point3">Точка C</param>
        /// <returns>Изображение с окрашенным градиентом треугольником</returns>
        public static MyImage TriangleRasterization(MyImage image, ColorPoint point1, ColorPoint point2, ColorPoint point3)
        {
            MyImage res = image.Copy();

            res.Lock();

            int minX = Math.Min(point1.Location.X, Math.Min(point2.Location.X, point3.Location.X));
            int minY = Math.Min(point1.Location.Y, Math.Min(point2.Location.Y, point3.Location.Y));
            int maxX = Math.Max(point1.Location.X, Math.Max(point2.Location.X, point3.Location.X));
            int maxY = Math.Max(point1.Location.Y, Math.Max(point2.Location.Y, point3.Location.Y));

            minX = Math.Max(0, minX);
            minY = Math.Max(0, minY);
            maxX = Math.Min(res.Width - 1, maxX);
            maxY = Math.Min(res.Height - 1, maxY);

            Point A = point1.Location;
            Point B = point2.Location;
            Point C = point3.Location;

            float denominator = (B.Y - C.Y) * (A.X - C.X) + (C.X - B.X) * (A.Y - C.Y);

            if (Math.Abs(denominator) < 0.0001f)
            {
                res.Unlock();
                return res;
            }

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    float alpha = ((B.Y - C.Y) * (x - C.X) + (C.X - B.X) * (y - C.Y)) / denominator;
                    float beta = ((C.Y - A.Y) * (x - C.X) + (A.X - C.X) * (y - C.Y)) / denominator;
                    float gamma = 1.0f - alpha - beta;

                    if (alpha >= 0 && beta >= 0 && gamma >= 0)
                    {
                        Color interpolatedColor = InterpolateColor(point1.PointColor, point2.PointColor, point3.PointColor, alpha, beta, gamma);

                        res.SetPixel(x, y, interpolatedColor);
                    }
                }
            }

            res.Unlock();
            return res;
        }

        /// <summary>
        /// Интерполяция цвета с использованием барицентрических координат
        /// </summary>
        private static Color InterpolateColor(Color colorA, Color colorB, Color colorC, float alpha, float beta, float gamma)
        {
            int r = (int)(alpha * colorA.R + beta * colorB.R + gamma * colorC.R);
            int g = (int)(alpha * colorA.G + beta * colorB.G + gamma * colorC.G);
            int b = (int)(alpha * colorA.B + beta * colorB.B + gamma * colorC.B);

            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            return Color.FromArgb(r, g, b);
        }

    }
}
