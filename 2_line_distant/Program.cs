using System;

namespace _line_distant
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---\tРасстояние между двумя прямыми\t---\n\n");
            Console.WriteLine("Введите координаты точек, расположенных на прямых через пробел");
            Console.Write("Для прямой L1\nM1 (x;y;z):");
            string[] a = Console.ReadLine().Replace('.',',').Split(' ');
            Point m1 = new Point()
            {
                X = double.Parse(a[0]),
                Y = double.Parse(a[1]),
                Z = double.Parse(a[2])
            };
            Console.Write("Для прямой L2\nM2 (x;y;z):");
            a = Console.ReadLine().Replace('.', ',').Split(' ');
            Point m2 = new Point()
            {
                X = double.Parse(a[0]),
                Y = double.Parse(a[1]),
                Z = double.Parse(a[2])
            };
            Console.WriteLine("Введите координаты направляющего вектора прямой");
            Console.Write("Для прямой L1\nP1 (x;y;z):");
            a = Console.ReadLine().Replace('.', ',').Split(' ');
            Point p1 = new Point
            {
                X = double.Parse(a[0]),
                Y = double.Parse(a[1]),
                Z = double.Parse(a[2])
            };
            Console.WriteLine("Введите координаты направляющего вектора прямой");
            Console.Write("Для прямой L2\nP2 (x;y;z):");
            a = Console.ReadLine().Replace('.', ',').Split(' ');
            Point p2 = new Point
            {
                X = double.Parse(a[0]),
                Y = double.Parse(a[1]),
                Z = double.Parse(a[2])
            };
            Console.Write("Проверка направляющих векторов на коллинеарность...\t");
            if (Collinear(p1, p2))
            {
                Console.Write("Успешно!\n");
                Point m1m2 = m2.Diff(m1);
                double s = VectLenght(VectorMulti(m1m2, p1));
                double q1 = VectLenght(p1);
                double res = s / q1;
                Console.WriteLine($"Расстояние между векторами: {res}");
            }
            else
            {
                Console.Write("Неудача!\n");
            }
        }


        /// <summary>
        /// Вычисление длины вектора
        /// </summary>
        /// <param name="point">Вектор</param>
        /// <returns></returns>
        public static double VectLenght(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X, 2d) + Math.Pow(point.Y, 2d) + Math.Pow(point.Z, 2));
        }
        /// <summary>
        /// Проверка коллинеарности направляющих векторов
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool Collinear(Point p1, Point p2)
        {
            double l1 = p2.X / p1.X, l2 = p2.Y / p1.Y, l3 = p2.Z / p1.Z;
            if (l1 == l2 && l1 == l3 && l2 == l3)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Вычисление векторного произведения при помощи определителя 3-го порядка
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point VectorMulti(Point a, Point b)
        {
            return new Point()
            {
                X = a.Y * b.Z - a.Z * b.Y,
                Y = (a.X * b.Z - a.Z * b.X)*(-1),
                Z = a.X * b.Y - a.Y * b.X
            };
        }
    }

    struct Point
    {
        public double X, Y, Z;
        public Point Diff(Point p)
        {
            return new Point() { X = this.X - p.X, Y = this.Y - p.Y, Z = this.Z - p.Z };
        }
        
    };
}