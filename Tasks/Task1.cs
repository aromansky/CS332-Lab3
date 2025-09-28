using CS332_Lab3;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS332_Lab2.Tasks
{
    public class Task1
    {
        /// <summary>
        /// Тип заливки изображения
        /// </summary>
        public enum FillType
        {
            FillColor,
            FillImage
        }

        /// <summary>
        /// Заливает область изображение выбранной заливкой
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="type">Тип заливки</param>
        /// <param name="color">Цвет заливки</param>
        /// <param name="pattern">Рисунок, которым заливать область</param>
        /// <returns>Изображение, результат работы заливки.</returns>
        /// <exception cref="ArgumentException">Возникает при передаче неизвествного типа заливки</exception>
        public MyImage Fill(MyImage image, FillType type, Color color = default, MyImage pattern = null)
        {
            switch (type) 
            { 
                case FillType.FillColor: return FillWithColor(image, color);
                case FillType.FillImage: return FillWithImage(image, pattern);
                default:
                    throw new ArgumentException($"Неизвестный тип заливки: {type}");
            }

        }


        /// <summary>
        /// Заливка области рисунка указанным цветом
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="color">Цвет заливки</param>
        /// <returns>Изображение, результат работы заливки</returns>
        private MyImage FillWithColor(MyImage image, Color color)
        {
            MyImage res = image.Copy();

            // TODO

            return res;
        }


        /// <summary>
        /// Заливка области рисунка другим рисунком
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="pattern">Рисунок, которым заливать область</param>
        /// <returns>Изображение, результат работы заливки</returns>
        private MyImage FillWithImage(MyImage image, MyImage pattern)
        {
            MyImage res = image.Copy();

            // TODO

            return res;
        }


        /// <summary>
        /// Выделяет границу связной области. Граница связной области задаётся одним цветом
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="startPoint">Начальная точка границы</param>
        /// <param name="color">Цвет границы</param>
        /// <returns>Изображение, результат выделения границы области</returns>
        public MyImage DrawBorder(MyImage image, Point startPoint, Color color)
        {
            MyImage res = image.Copy();

            return res;
        }

    }
}
