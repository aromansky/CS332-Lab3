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
                case FillType.FillImage: return FillWithImage(image, point, oldColor, pattern);
                default:
                    throw new ArgumentException($"Неизвестный тип заливки: {type}");
            }

        }


        /// <summary>
        /// Заливка области рисунка указанным цветом
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="point">Точка заливки</param>
        /// <param name="oldColor">Исходный цвет заливки</param>
        /// <param name="newColor">Новый цвет заливки</param>
        /// <returns>Изображение, результат работы заливки</returns>
        private static MyImage FillWithColor(MyImage image, Point point, Color oldColor = default, Color newColor = default)
        {
            MyImage res = image.Copy();

            res.Lock();

            FillLine(res, (point.X, point.Y), oldColor, newColor);

            res.Unlock();

            return res;
        }

        /// <summary>
        /// Рекурсивный алгоритм заливки на основе серий пикселов.
        /// </summary>
        private static void FillLine(MyImage image, (int x, int y) point, Color oldColor, Color newColor)
        {
            if (point.y < 0 || point.y == image.Height - 1 || 
                image.GetRGB(point.x, point.y) == newColor || image.GetRGB(point.x, point.y) != oldColor)
            {
                return;
            }

            int leftBorder = point.x;
            int rightBorder = point.x;
            int y = point.y;

            while (leftBorder >= 0 && image.GetRGB(leftBorder, y) == oldColor) leftBorder--;
            while (rightBorder <= image.Width && image.GetRGB(rightBorder, y) == oldColor) rightBorder++;

            leftBorder++; rightBorder--;

            for (int i = leftBorder; i <= rightBorder; i++) image.SetPixel(i, y, newColor);

            for (int i = leftBorder; i <= rightBorder; i++) FillLine(image, (i, y + 1), oldColor, newColor);
            for (int i = leftBorder; i <= rightBorder; i++) FillLine(image, (i, y - 1), oldColor, newColor);
        }


        /// <summary>
        /// Заливка области рисунка другим рисунком
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="point">Точка заливки</param>
        /// <param name="pattern">Рисунок, которым заливать область</param>
        /// /// <param name="oldColor">Исходный цвет заливки</param>
        /// <returns>Изображение, результат работы заливки</returns>
        private static MyImage FillWithImage(MyImage image, Point point, Color oldColor, MyImage pattern)
        {
            MyImage res = image.Copy();

            res.Lock();
            pattern.Lock();

            FillImage(res, (point.X, point.Y), oldColor, pattern);

            res.Unlock();
            pattern.Unlock();

            return res;
        }

        /// <summary>
        /// Заливка области рисунка другим рисунком
        /// </summary>
        private static void FillImage(MyImage image, (int x, int y) point, Color oldColor, MyImage pattern)
        {
            if (point.y < 0 || point.y == image.Height - 1 ||
                image.GetRGB(point.x, point.y) == pattern.GetRGB(point.x % pattern.Width, point.y % (pattern.Height - 1)))
            {
                return;
            }

            int leftBorder = point.x;
            int rightBorder = point.x;
            int y = point.y;

            while (leftBorder >= 0 && image.GetRGB(leftBorder, y) == oldColor) leftBorder--;
            while (rightBorder <= image.Width && image.GetRGB(rightBorder, y) == oldColor) rightBorder++;

            leftBorder++; rightBorder--;

            for (int i = leftBorder; i <= rightBorder; i++) image.SetPixel(i, y, pattern.GetRGB(i % pattern.Width, y % (pattern.Height - 1)));

            for (int i = leftBorder; i <= rightBorder; i++) FillImage(image, (i, y + 1), oldColor, pattern);
            for (int i = leftBorder; i <= rightBorder; i++) FillImage(image, (i, y - 1), oldColor, pattern);
        }


        /// <summary>
        /// Выделяет границу связной области. Граница связной области задаётся одним цветом
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="startPoint">Начальная точка границы</param>
        /// <param name="color">Цвет границы</param>
        /// <returns>Изображение, результат выделения границы области</returns>
        public static List<Point> GetBorder(MyImage image, Point startPoint, Color color)
        {
            List<Point> res = new List<Point>();

            image.Lock();

            Point curPoint = new Point(startPoint.X, startPoint.Y);
            Point next = Point.Empty;

            List<Point> predRightPoints = new List<Point>();
            do
            {
                bool flag = false;
                (int x, int y) current = (curPoint.X, curPoint.Y);
                List<(int X, int Y)> neighbours = GetClockwiseNeighbors(image, current);

                foreach ((int X, int Y) neighbour in neighbours)
                {
                    if (image.GetRGB(neighbour.X, neighbour.Y) != image.GetRGB(current.x, current.y)) continue;
                    List<Point> rightPoints = GetRightPixel(current, neighbour);
                    if (rightPoints.Count == 2)
                    {
                        var (x1, y1) = (rightPoints[0].X, rightPoints[0].Y);
                        var (x2, y2) = (rightPoints[1].X, rightPoints[1].Y);
                        if (image.GetRGB(x1, y1) != image.GetRGB(x2, y2) || image.GetRGB(x1, y1) != color) continue;                       
                    }
                    Point rightPoint = rightPoints[0];
                    next = new Point(neighbour.X, neighbour.Y);
                    
                    if (image.GetRGB(rightPoint.X, rightPoint.Y) == color && !res.Contains(next))
                    {
                        
                        //image.SetPixel(rightPoint.X, rightPoint.Y, Color.Blue);
                        
                        if (predRightPoints.Count == 0)
                        {
                            res.Add(next);
                            curPoint = next;
                            flag = true;
                            predRightPoints = rightPoints;
                            break;
                        }
                        else
                        {
                            if (CheckConnect(predRightPoints, rightPoints, color))
                            {
                                res.Add(next);
                                curPoint = next;
                                flag = true;
                                predRightPoints = rightPoints;
                                //image.SetPixel(rightPoint.X, rightPoint.Y, Color.Blue);
                                break;
                            }
                        }
                                
                    }
                    
                    
                }
                if (flag) continue;
                image.Unlock();
                return new List<Point>();

            }
            while (curPoint != startPoint);

            image.Unlock();

            return res;
        }

        private static bool CheckConnect(List<Point> l1, List<Point> l2, Color color)
        {
            foreach (Point p1 in l1)
            {
                foreach (Point p2 in l2)
                {
                    if (Math.Abs(p1.X - p2.X) <= 1 && Math.Abs(p1.Y - p2.Y) <= 1) return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Возвращает соседние точки, добавленные по часовой стрелке
        /// </summary>
        /// <param name="image">Изображение</param>
        /// <param name="point">Точка</param>
        /// <returns>Соседи точки</returns>
        private static List<(int X, int Y)> GetClockwiseNeighbors(MyImage image, (int X, int Y) point)
        {
            List<(int X, int Y)> neighbours = new List<(int X, int Y)> ();
            var (x, y) = (point.X, point.Y);

            (int X, int Y)[] possibleNeighbours = new (int X, int Y)[]
            {
                (x + 1, y - 1),
                (x + 1, y),
                (x + 1, y + 1),
                (x, y + 1),     
                (x - 1, y + 1), 
                (x - 1, y),  
                (x - 1, y - 1),
                (x, y - 1)    
            };

            foreach ((int X, int Y) neighbour in possibleNeighbours)
            {
                if (CheckPixel(image, neighbour))
                {
                    neighbours.Add(neighbour);
                }
            }

            return neighbours;
        }

        /// <summary>
        /// Закрашивает выбранные точки указанным цветом
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="color">Цвет заливки</param>
        /// <param name="points">Набор точек для заливки</param>
        /// <returns>Изображение с закрашенными точками</returns>
        public static MyImage DrawPixels(MyImage image, Color color, List<Point> points)
        {
            MyImage res = image.Copy();

            res.Lock();

            foreach (Point p in points) res.SetPixel(p.X, p.Y, color);

            res.Unlock();

            return res;
        }

        /// <summary>
        /// Получает координаты правого пикселя относительно направления движения. Работает только с 4-х смежными пикселями
        /// </summary>
        /// <param name="current">Текущий пиксель</param>
        /// <param name="target">Следующий пиксель</param>
        /// <returns>Координаты правого пикселя</returns>
        private static List<Point> GetRightPixel((int X, int Y) current, (int X, int Y) target)
        {
            if (current == target)
                throw new ArgumentException("Точки не могут совпадать");

            int dx = Math.Abs(current.X - target.X);
            int dy = Math.Abs(current.Y - target.Y);
            if (dx > 1 || dy > 1)
                throw new ArgumentException("Точки должны быть 8-смежными соседями");

            List<Point> res = new List<Point>();

            if (current.Y == target.Y)
            {
                if (current.X > target.X)
                {
                    res.Add(new Point(current.X, current.Y - 1));
                    res.Add(new Point(target.X, current.Y - 1));
                }
                else
                {
                    res.Add(new Point(current.X, current.Y + 1));
                    res.Add(new Point(target.X, current.Y + 1));
                }
            }
            else if (current.X == target.X)
            {
                if (current.Y < target.Y)
                {
                    res.Add(new Point(current.X - 1, current.Y));
                    res.Add(new Point(current.X - 1, target.Y));
                }
                else
                {
                    res.Add(new Point(current.X + 1, current.Y));
                    res.Add(new Point(current.X + 1, target.Y));
                }
            }
            else if (current.X < target.X)
            {
                if (current.Y < target.Y) res.Add(new Point(current.X, current.Y + 1));
                else res.Add(new Point(current.X + 1, current.Y));
            }
            else
            {
                if (current.Y > target.Y) res.Add(new Point(current.X, current.Y - 1));
                else res.Add(new Point(current.X - 1, current.Y));
            }

            return res;
        }

        /// <summary>
        /// Получает координаты правого пикселя относительно направления движения. Работает только с 4-х смежными пикселями
        /// </summary>
        /// <param name="current">Текущий пиксель</param>
        /// <param name="target">Следующий пиксель</param>
        /// <returns>Координаты правого пикселя</returns>
        private static Point GetRightPixel(Point current, Point target)
        {
            if (current == target)
                throw new ArgumentException("Точки не могут совпадать");

            int dx = Math.Abs(current.X - target.X);
            int dy = Math.Abs(current.Y - target.Y);
            if (dx > 1 || dy > 1)
                throw new ArgumentException("Точки должны быть 8-смежными соседями");

            if (current.Y == target.Y)
            {
                if (current.X > target.X) return new Point(current.X, current.Y - 1);
                else return new Point(current.X, current.Y + 1);
            }
            else if (current.X == target.X)
            {
                if (current.Y < target.Y) return new Point(current.X - 1, current.Y);
                else return new Point(current.X + 1, current.Y);
            }
            else if (current.X < target.X)
            {
                if (current.Y < target.Y) return new Point(current.X, current.Y + 1);
                else return new Point(current.X, current.Y - 1);
            }
            else
            {
                if (current.Y > target.Y) return new Point(current.X, current.Y - 1);
                else return new Point(current.X - 1, current.Y);
            }
        }

        /// <summary>
        /// Проверяет, принадлежит ли точка изображению
        /// </summary>
        /// <param name="image">Изображение</param>
        /// <param name="point">Точка</param>
        /// <returns>True - если принадлежит, иначе False</returns>
        private static bool CheckPixel(MyImage image, Point point)
        {
            var (x, y) = (point.X, point.Y);

            return (x >= 0) && (x < image.Width) && (y >= 0) && (y  < image.Height);
        }

        /// <summary>
        /// Проверяет, принадлежит ли точка изображению
        /// </summary>
        /// <param name="image">Изображение</param>
        /// <param name="point">Точка</param>
        /// <returns>True - если принадлежит, иначе False</returns>
        private static bool CheckPixel(MyImage image, (int X, int Y) point)
        {
            var (x, y) = (point.X, point.Y);

            return (x >= 0) && (x < image.Width) && (y >= 0) && (y < image.Height);
        }

    }
}
