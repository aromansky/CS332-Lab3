using CS332_Lab3;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS332_Lab2.Tasks
{
    public static class Task1
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
        /// <param name="point">Точка заливки</param>
        /// <param name="type">Тип заливки</param>
        /// <param name="oldColor">Старый цвет</param>
        /// <param name="newColor">Новый цвет</param>
        /// <param name="pattern">Рисунок, которым заливать область</param>
        /// <returns>Изображение, результат работы заливки.</returns>
        /// <exception cref="ArgumentException">Возникает при передаче неизвествного типа заливки</exception>
        public static MyImage Fill(MyImage image, Point point, FillType type, Color oldColor = default, Color newColor = default, MyImage pattern = null)
        {
            switch (type) 
            { 
                case FillType.FillColor: return FillWithColor(image, point, oldColor, newColor);
                case FillType.FillImage: return FillWithImage(image, point, pattern);
                default:
                    throw new ArgumentException($"Неизвестный тип заливки: {type}");
            }

        }


        /// <summary>
        /// Заливка области рисунка указанным цветом
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="point">Точка заливки</param>
        /// <param name="oldColor">Цвет заливки</param>
        /// <returns>Изображение, результат работы заливки</returns>
        private static MyImage FillWithColor(MyImage image, Point point, Color oldColor = default, Color newColor = default)
        {
            MyImage res = image.Copy();

            // TODO

            return res;
        }


        /// <summary>
        /// Заливка области рисунка другим рисунком
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="point">Точка заливки</param>
        /// <param name="pattern">Рисунок, которым заливать область</param>
        /// <returns>Изображение, результат работы заливки</returns>
        private static MyImage FillWithImage(MyImage image, Point point, MyImage pattern)
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
        public static MyImage DrawBorder(MyImage image, Point startPoint, Color color)
        {
            MyImage res = image.Copy();

            return res;
        }

    }
}
