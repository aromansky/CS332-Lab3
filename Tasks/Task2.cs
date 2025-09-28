using CS332_Lab3;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS332_Lab2.Tasks
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
        public MyImage DrawLine(MyImage image, LineAlgorithm algo, Point start, Point end, Color color)
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
        private MyImage DrawLineBresenham(MyImage image, Point start, Point end, Color color)
        {
            MyImage res = image.Copy();

            // TODO

            return res;
        }


        /// <summary>
        /// Реализация рисования отрезка алгоритмом Брезенхейма
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="start">Начальная точка</param>
        /// <param name="end">Конечная точка</param>
        /// <param name="color">Цвет отрезка</param>
        /// <returns>Изображение с нанесённым отрезком указаного цвета</returns>
        private MyImage DrawLineWu(MyImage image, Point start, Point end, Color color)
        {
            MyImage res = image.Copy();

            // TODO

            return res;
        }
    }
}
