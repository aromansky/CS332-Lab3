using CS332_Lab3;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS332_Lab2.Tasks
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

            // TODO

            return res;
        }
        
    }
}
