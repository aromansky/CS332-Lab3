using CS332_Lab3;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS332_Lab3
{
    public class Task2
    {
        /// <summary>
        /// Алгоритмы рисования отрезка
        /// </summary>
        public enum LineAlgorithm
        {
            Bresenham,
            Wu
        }


        /// <summary>
        /// Рисует отрезок в соотвествии с выбранным алгоритмом
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="algo">Алгоритм рисования отрезка</param>
        /// <param name="start">Начальная точка отрезка</param>
        /// <param name="end">Конечная точка отрезка</param>
        /// <param name="color">Цвет отрезка</param>
        /// <returns>Изображение с нанесённым отрезком указаного цвета</returns>
        /// <exception cref="ArgumentException">Возникает при передаче несуществующего алгоритма</exception>
        public static MyImage DrawLine(MyImage image, LineAlgorithm algo, Point start, Point end, Color color)
        {
            switch (algo)
            {
                case LineAlgorithm.Bresenham: return DrawLineBresenham(image, start, end, color);
                case LineAlgorithm.Wu: return DrawLineWu(image, start, end, color);
                default:
                    throw new ArgumentException($"Неизвестный алгоритм: {algo}");
            }
        }


        /// <summary>
        /// Реализация рисования отрезка алгоритмом Брезенхейма
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="start">Начальная точка</param>
        /// <param name="end">Конечная точка</param>
        /// <param name="color">Цвет отрезка</param>
        /// <returns>Изображение с нанесённым отрезком указаного цвета</returns>
        private static MyImage DrawLineBresenham(MyImage image, Point start, Point end, Color color)
        {
            MyImage res = image.Copy();

            res.Lock();

            int x0 = start.X;
            int y0 = start.Y;
            int x1 = end.X;
            int y1 = end.Y;

            // Если линия вертикальная или горизонтальная, используем простой алгоритм
            if (x0 == x1)
            {
                // Вертикальная линия
                int minY = Math.Min(y0, y1);
                int maxY = Math.Max(y0, y1);
                for (int i = minY; i <= maxY; i++)
                {
                    res.SetPixel(x0, i, color);
                }
                res.Unlock();
                return res;
            }

            if (y0 == y1)
            {
                // Горизонтальная линия
                int minX = Math.Min(x0, x1);
                int maxX = Math.Max(x0, x1);
                for (int x = minX; x <= maxX; x++)
                {
                    res.SetPixel(x, y0, color);
                }
                res.Unlock();
                return res;
            }

            // Определяем, в каком октанте находится линия и нормализуем координаты
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if (steep)
            {
                // Если линия крутая, меняем x и y местами
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }

            if (x0 > x1)
            {
                // Обеспечиваем рисование слева направо
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            int deltax = x1 - x0;
            int deltay = Math.Abs(y1 - y0);
            int error = 0;
            int deltaerr = deltay;
            int y = y0;
            int diry = y1 - y0;

            if (diry > 0)
                diry = 1;
            else
                diry = -1;

            // Основной цикл алгоритма Брезенхейма
            for (int x = x0; x <= x1; x++)
            {
                if (steep)
                {
                    // Если меняли местами, восстанавливаем координаты
                    res.SetPixel(y, x, color);
                }
                else
                {
                    res.SetPixel(x, y, color);
                }

                error += deltaerr;
                if (error >= (deltax + 1))
                {
                    y += diry;
                    error -= (deltax + 1);
                }
            }

            res.Unlock();

            return res;
        }

        /// <summary>
        /// Вспомогательная функция для обмена значений двух переменных
        /// </summary>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }


        /// <summary>
        /// Реализация рисования отрезка алгоритмом Ву
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="start">Начальная точка</param>
        /// <param name="end">Конечная точка</param>
        /// <param name="color">Цвет отрезка</param>
        /// <returns>Изображение с нанесённым отрезком указаного цвета</returns>
        private static MyImage DrawLineWu(MyImage image, Point start, Point end, Color color)
        {
            MyImage res = image.Copy();

            res.Lock();

            int x0 = start.X;
            int y0 = start.Y;
            int x1 = end.X;
            int y1 = end.Y;

            // Если точки совпадают, рисуем одну точку
            if (x0 == x1 && y0 == y1)
            {
                DrawPointWu(res, x0, y0, 1.0f, color);
                res.Unlock();
                return res;
            }

            // Обеспечиваем рисование слева направо
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if (steep)
            {
                // Транспонируем координаты если угол наклона больше 45 градусов
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }

            if (x0 > x1)
            {
                // Обеспечиваем рисование слева направо
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = dx == 0 ? 1 : dy / dx;

            // Первая конечная точка
            float y = y0 + gradient;

            // Рисуем начальную точку
            if (steep)
            {
                DrawPointWu(res, y0, x0, 1.0f, color);
            }
            else
            {
                DrawPointWu(res, x0, y0, 1.0f, color);
            }

            // Основной цикл рисования
            for (var x = x0 + 1; x <= x1 - 1; x++)
            {
                if (steep)
                {
                    // Транспонируем обратно
                    DrawPointWu(res, (int)y, x, 1 - (y - (int)y), color);
                    DrawPointWu(res, (int)y + 1, x, y - (int)y, color);
                }
                else
                {
                    DrawPointWu(res, x, (int)y, 1 - (y - (int)y), color);
                    DrawPointWu(res, x, (int)y + 1, y - (int)y, color);
                }
                y += gradient;
            }

            // Рисуем конечную точку
            if (steep)
            {
                DrawPointWu(res, y1, x1, 1.0f, color);
            }
            else
            {
                DrawPointWu(res, x1, y1, 1.0f, color);
            }

            res.Unlock();
            return res;
        }

        /// <summary>
        /// Рисует точку с заданной интенсивностью для алгоритма Ву
        /// </summary>
        /// <param name="image">Изображение</param>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="intensity">Интенсивность в долях единицы (0-1)</param>
        /// <param name="color">Цвет</param>
        private static void DrawPointWu(MyImage image, int x, int y, float intensity, Color color)
        {
            // Проверяем границы изображения
            if (x < 0 || x >= image.Width || y < 0 || y >= image.Height)
                return;

            // Получаем текущий цвет пикселя
            Color originalColor = image.GetRGB(x, y);

            // Смешиваем цвета с учетом интенсивности
            float r = originalColor.R * (1 - intensity) + color.R * intensity;
            float g = originalColor.G * (1 - intensity) + color.G * intensity;
            float b = originalColor.B * (1 - intensity) + color.B * intensity;

            // Обеспечиваем корректные значения цветов
            int red = Math.Max(0, Math.Min(255, (int)Math.Round(r)));
            int green = Math.Max(0, Math.Min(255, (int)Math.Round(g)));
            int blue = Math.Max(0, Math.Min(255, (int)Math.Round(b)));

            Color blendedColor = Color.FromArgb(red, green, blue);
            image.SetPixel(x, y, blendedColor);
        }
    }
}
