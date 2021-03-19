using System;
using System.Collections.Generic;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager.start();
        }
    }
    abstract class Shape
    {
        protected Point[] points { get; set; }
        public abstract double Area();
    }
    sealed class Point
    {
        public double X { get; }
        public double Y { get; }
        public Point(double x, double y) { this.X = x; this.Y = y; }
        public override string ToString()
        {
            return string.Format(Environment.NewLine + "({0}, {1})", X,Y);
        }
        public static Point CreatePointFromConsole(string name)
        {
            Console.WriteLine("Введите координаты точки " + name);
            string[] coords = Console.ReadLine().Split(" ");
            double X = double.Parse(coords[0]);
            double Y = double.Parse(coords[1]);
            return new Point(X, Y);
        }
    }
    class Line : Shape
    {
        public override string ToString()
        {
            return string.Format(Environment.NewLine + "Точки: A({0}), B = ({1})" +
                "\nДлина: {2}", points[0].ToString(), points[1].ToString(), Len());
        }
        public override double Area() { return 0.0; }
        public double Len() { return Math.Sqrt(Math.Pow(points[0].X - points[1].X, 2) + Math.Pow(points[0].Y - points[1].Y, 2)); }
        public Line(double x1, double y1, double x2, double y2)
        {
            this.points = new Point[2] { new Point(x1, y1), new Point(x2, y2) };
        }
        public Line(Point a, Point b)
        {
            this.points = new Point[2] { new Point(a.X, a.Y), new Point(b.X, b.Y) };
        }

        public static double GetCos(Line A, Line B)
        {
            double XA = A.points[0].X - A.points[1].X;
            double YA = A.points[0].Y - A.points[1].Y;

            double XB = B.points[0].X - B.points[1].X;
            double YB = B.points[0].Y - B.points[1].Y;

            return (XA * YA + XB * YB) / A.Len() * B.Len();
        }
    }
    class Circle : Shape
    {
        public double Radius { get; set; }
        public Point Center { get { return points[0]; } }
        public override double Area() { return Math.PI * Math.Pow(Radius, 2); }
        public virtual double Circumference => Math.PI * Radius * 2;
        public Circle(double x, double y, double Radius)
        {
            points = new Point[1] { new Point(x, y) };
            this.Radius = Radius;
        }
    }
    class Ring : Circle
    {
        public double InnerRadius { get; set; }
        public override double Area() { return Math.PI * ((Radius * Radius) - (InnerRadius * InnerRadius)); }
        public override double Circumference => (2 * (Math.PI * Radius)) + (2 * (Math.PI * InnerRadius));
        public Ring(double x, double y, double Radius, double InnerRadius)
            : base(x, y, Radius)
        {
            this.InnerRadius = InnerRadius;
        }
    }

    class Triangle : Shape
    {
        double HalfP { get; } // полупериметр
        double Perimeter { get { return HalfP * 2; } }
        public override double Area()
        {
            return Math.Sqrt(HalfP * (HalfP - new Line(points[0], points[1]).Len()) * (HalfP - new Line(points[1], points[2]).Len() * (HalfP - new Line(points[2], points[0]).Len())));
        }
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Point A = new Point(x1, y1);
            Point B = new Point(x2, y2);
            Point C = new Point(x3, y3);
            Line AB = new Line(A, B);
            Line BC = new Line(B, C);
            Line CA = new Line(C, A);

            HalfP = (AB.Len() + BC.Len() + CA.Len()) / 2;

            if ((AB.Len() + BC.Len() < CA.Len()) || (BC.Len() + CA.Len() < AB.Len()) || (CA.Len() + AB.Len() < BC.Len()))
                throw new Exception("Неправильный треугольник");

            points = new Point[3] { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "Стороны: AB: {0}\n BC: {1}\n CA: {2}\n" + "Площадь: {3}" +
                "\nПериметр: {4}", new Line(points[0], points[1]).ToString(), new Line(points[1], points[2]).ToString(),
                new Line(points[2], points[0]).ToString(), Area(), Perimeter);
        }
    }

    class Rectangle : Shape
    {
        public Rectangle(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            Point A = new Point(x1, y1);
            Point B = new Point(x2, y2);
            Point C = new Point(x3, y3);
            Point D = new Point(x4, y4);

            Line AB = new Line(A, B);
            Line BC = new Line(B, C);
            Line CD = new Line(C, D);
            Line AD = new Line(A, D);

            if (Line.GetCos(AB, BC) != 0 || Line.GetCos(BC, CD) != 0 || Line.GetCos(CD, AD) != 0)
                throw new Exception("Неправильный прямоугольник");

            points = new Point[4] { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3), new Point(x4, y4) };

        }
        public override double Area() { return new Line(points[0], points[1]).Len() * new Line(points[1], points[2]).Len(); }
        public double Perimeter => (new Line(points[0], points[1]).Len() + new Line(points[1], points[2]).Len()) * 2;
        public override string ToString()
        {
            return string.Format(Environment.NewLine + "Стороны: AB: {0}\n BC: {1}\n CD: {2}\n DA: {5}" + "Площадь: {3}" +
                "\nПериметр: {4}", new Line(points[0], points[1]).ToString(), new Line(points[1], points[2]).ToString(),
                new Line(points[2], points[3]).ToString(), Area(), Perimeter, new Line(points[3], points[0]).ToString());
        }
    }
    class Square : Rectangle
    {
        public Square(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4) 
            : base (x1, y1, x2, y2, x3,  y3, x4, y4)
        {
            if (new Line(points[0], points[1]).Len() != new Line(points[1], points[2]).Len())
                throw new Exception("У данного квадрата стороны не равны. Значит это не квадрат");
        }
    }
    class Desktop
    {
        List<Shape> shapes;

        public Desktop() { shapes = new List<Shape>(); }
        public void Menu()
        {
            bool swBool = true;
            bool swUser = false;
            do
            {
                Console.WriteLine(Environment.NewLine + "Выберите действие: \n1. Добавить фигуру \n2. Вывести фигуры \n3. Очистить холст \n4. Сменить пользователя \n5. Выход ");
                string enter = Console.ReadLine();
                switch (enter)
                {
                    case "1":
                        AddShape();
                        break;
                    case "2":
                        ShowShapes();
                        break;
                    case "3":
                        shapes = new List<Shape>();
                        break;
                    case "4":
                        Console.WriteLine("Введите имя пользователя: ");
                        Manager.SwitchUser(Console.ReadLine());
                        swUser = true;
                        swBool = false;
                        break;
                    case "5":
                        Console.WriteLine("Конец программы");
                        swBool = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверное значение"); 
                        break;
                }
            }
            while (swBool);

            if (swUser) { Manager.GetCurrent(); }
        }
        public void AddShape()
        {
            Console.WriteLine("Выберите тип фигуры: \n1. Линия \n2. Круг \n 3. Кольцо \n4. Треугольник \n5. Прямоугольник \n6. Квадрат ");
            string enter = Console.ReadLine();
            switch (enter)
            {
                case "1":
                    var A=Point.CreatePointFromConsole("A");
                    var B = Point.CreatePointFromConsole("B");
                    var line = new Line(A,B);
                    shapes.Add(line);
                    Console.WriteLine("Линия создана");
                    break;
                case "2":
                    var Center = Point.CreatePointFromConsole("Center Circle");
                    Console.WriteLine("Введите радиус: ");
                    var Rad = double.Parse(Console.ReadLine());
                    var circle = new Circle(Center.X, Center.Y, Rad);
                    shapes.Add(circle);
                    Console.WriteLine("Круг создан");
                    break;
                case "3":
                    var Center2 = Point.CreatePointFromConsole("Center Ring");
                    Console.WriteLine("Введите внешний радиус: ");
                    var Rad2 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите внутренний радиус: ");
                    var InnRad = double.Parse(Console.ReadLine());
                    var ring = new Ring(Center2.X, Center2.Y, Rad2, InnRad);
                    shapes.Add(ring);
                    Console.WriteLine("Кольцо создано");
                    break;
                case "4":
                    var A_Tri = Point.CreatePointFromConsole("A");
                    var B_Tri = Point.CreatePointFromConsole("B");
                    var C_Tri = Point.CreatePointFromConsole("C");
                    var tri = new Triangle(A_Tri.X, A_Tri.Y, B_Tri.X, B_Tri.Y, C_Tri.X, C_Tri.Y);
                    shapes.Add(tri);
                    Console.WriteLine("Треугольник создан");
                    break;
                case "5":
                    var A_Rec = Point.CreatePointFromConsole("A");
                    var B_Rec = Point.CreatePointFromConsole("B");
                    var C_Rec = Point.CreatePointFromConsole("C");
                    var D_Rec = Point.CreatePointFromConsole("D");
                    var rec = new Rectangle(A_Rec.X, A_Rec.Y, B_Rec.X, B_Rec.Y, C_Rec.X, C_Rec.Y, D_Rec.X, D_Rec.Y);
                    shapes.Add(rec);
                    Console.WriteLine("Прямоугольник создан");
                    break;
                case "6":
                    var A_Sq = Point.CreatePointFromConsole("A");
                    var B_Sq = Point.CreatePointFromConsole("B");
                    var C_Sq = Point.CreatePointFromConsole("C");
                    var D_Sq = Point.CreatePointFromConsole("D");
                    var sq = new Rectangle(A_Sq.X, A_Sq.Y, B_Sq.X, B_Sq.Y, C_Sq.X, C_Sq.Y, D_Sq.X, D_Sq.Y);
                    shapes.Add(sq);
                    Console.WriteLine("Квадрат создан");
                    break;
                default:
                    Console.WriteLine("Вы ввели неверное значение");
                    break;
            }
        }
        public void ShowShapes()
        {
            if(shapes.Count==0)
                Console.WriteLine("У вас нет фигур");

            foreach (var sas in shapes)
            {
                Console.WriteLine(sas.ToString());
            }
        }
    }

    public class Manager
    {
        static Dictionary<string, Desktop> users = new Dictionary<string, Desktop>();
        static string currentUser;

        public static void AddUser()
        {
            Console.WriteLine("Введите ваше имя: ");
            string name = Console.ReadLine();
            if (users.ContainsKey(name))
                Console.WriteLine("Такой пользователь уже существует");
            else
            {
                users[name] = new Desktop();
                currentUser = name;
            }
        }

        public static void AddUser(string name)
        {
            if (users.ContainsKey(name))
                throw new Exception ("Такой пользовател уже существует");
            else
            {
                users[name] = new Desktop();
                currentUser = name;
            }
        }
        public static void SwitchUser(string name)
        {
            if (!users.ContainsKey(name))
                AddUser(name);

            currentUser = name;
        }

        public static void start()
        {
            Manager.AddUser();
            users[currentUser].Menu();
        }

        public static void GetCurrent()
        {
            users[currentUser].Menu();
        }
    }
}
