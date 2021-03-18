using System;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Triangle tri = new Triangle();
            //tri.MakeTriangle();

            Square sq = new Square();
            sq.MakeSquare();

            //Circle circle = new Circle(0, 0, 1);
            //Ring ring = new Ring(0, 0, 2, 1);
            //Console.WriteLine("Площадь: {0} ", circle.CircleArea);
            //Console.WriteLine("Длина: {0} ", circle.Circumference);

            //Console.WriteLine("Площадь кольца: " + ring.RingArea);
            //Console.WriteLine("Суммарная длина внешней и внутренней окружностей: " + ring.SummaryLen);
        }
    }

    class Figure
    {
        protected double a,b,c,d;
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }

        public Figure() { }
        public Figure (double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double GetX()
        {
            return X;
        }
        public double GetY()
        {
            return Y;
        }
    }

    class Circle : Figure
    {
        public Circle(double x, double y, double Radius) { this.X = x; this.Y = y; this.Radius = Radius; }

        public double CircleArea => Math.PI * Math.Pow(Radius, 2);
        public double Circumference => ((Math.PI * Radius) * 2);
    }

    class Ring : Figure
    {
        public double InnerRadius { get; set; }

        public Ring(double x, double y, double Radius, double InnerRadius)
        { this.X = x; this.Y = y; this.Radius = Radius; this.InnerRadius = InnerRadius; }

        public double RingArea => Math.PI * ((Radius * Radius) - (InnerRadius * InnerRadius));
        public double SummaryLen => (2 * (Math.PI * Radius)) + (2 * (Math.PI * InnerRadius));

    }

    class Triangle : Figure
    {
        double P { get; set; } 
        public Triangle (Figure a, Figure b, Figure c)
        {
            double x1 = a.GetX(), y1 = a.GetY();
            double x2 = b.GetX(), y2 = b.GetY();
            double x3 = c.GetX(), y3 = c.GetY();

            this.a = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            this.b = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            this.c = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
        }

        public Triangle() { }

        public void MakeTriangle()
        {
            double x;
            double y;
            P = (a + b + c) / 2;

            Console.WriteLine("Координата x1: ");
            double.TryParse(Console.ReadLine(), out x);

            Console.WriteLine("Координата y1: ");
            double.TryParse(Console.ReadLine(), out y);

            Figure SideA = new Figure(x, y);

            Console.WriteLine("Координата x2: ");
            double.TryParse(Console.ReadLine(), out x);

            Console.WriteLine("Координата y2: ");
            double.TryParse(Console.ReadLine(), out y);

            Figure SideB = new Figure(x, y);

            Console.WriteLine("Координата x3: ");
            double.TryParse(Console.ReadLine(), out x);

            Console.WriteLine("Координата y3: ");
            double.TryParse(Console.ReadLine(), out y);

            Figure SideC = new Figure(x, y);

            Triangle tri = new Triangle(SideA, SideB, SideC);

            Console.WriteLine(tri.ToString());
            Console.WriteLine(Environment.NewLine + "Площадь треугольника: " + tri.TriangleSquare);
            Console.WriteLine("Периметр треугольника: " +tri.TrianglePerimetr);

            Console.ReadKey();
        }
        public override string ToString()
        {
            P = (a + b + c) / 2;
            return string.Format(Environment.NewLine + "Треугольник со сторонами: a = {0}, b = {1}, c = {2}", a, b, c);
        }
        public double TriangleSquare => Math.Sqrt(P * (P - a) * (P - b) * (P - c));
        public double TrianglePerimetr => a + b + c; 
        }

    class Square : Figure
    {
        public Square (Figure a, Figure b, Figure c, Figure d)
        {
            double x1 = a.GetX(), y1 = a.GetY();
            double x2 = b.GetX(), y2 = b.GetY();
            double x3 = c.GetX(), y3 = c.GetY();
            double x4 = d.GetX(), y4 = d.GetY();

            this.a = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            this.b = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            this.c = Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2));
            this.d = Math.Sqrt(Math.Pow(x4 - x1, 2) + Math.Pow(y4 - y1, 2));
        }

        public Square () { }

        public void MakeSquare()
        {
            double x;
            double y;

            Console.WriteLine("Координата x1: ");
            double.TryParse(Console.ReadLine(), out x);

            Console.WriteLine("Координата y1: ");
            double.TryParse(Console.ReadLine(), out y);

            Figure SideA = new Figure(x, y);

            Console.WriteLine("Координата x2: ");
            double.TryParse(Console.ReadLine(), out x);

            Console.WriteLine("Координата y2: ");
            double.TryParse(Console.ReadLine(), out y);

            Figure SideB = new Figure(x, y);

            Console.WriteLine("Координата x3: ");
            double.TryParse(Console.ReadLine(), out x);

            Console.WriteLine("Координата y3: ");
            double.TryParse(Console.ReadLine(), out y);

            Figure SideC = new Figure(x, y);

            Console.WriteLine("Координата x4: ");
            double.TryParse(Console.ReadLine(), out x);

            Console.WriteLine("Координата y4: ");
            double.TryParse(Console.ReadLine(), out y);

            Figure SideD = new Figure(x, y);

            Square sq = new Square (SideA, SideB, SideC, SideD);

            Console.WriteLine(sq.ToString());
            Console.WriteLine(Environment.NewLine + "Площадь квадрата: " + sq.SquareArea);
            Console.WriteLine("Периметр квадрата: " + sq.SquarePerimeter);

            Console.ReadKey();
        }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + "Квадрат со сторонами: a = {0}, b = {1}, c = {2}, d = {3}", a, b, c, d);
        }

        public double SquareArea => a * a;
        public double SquarePerimeter => a * 4;
    }

    //class Rectangle : Figure
    //{
    //    public Rectangle(double a, double b)
    //    {
    //        this.A = a;
    //        this.B = b;
    //    }

    //    public double RectangleArea => A * B;
    //    public double RectanglePerimeter => (A + B) * 2;

    //}

    //class Line : Figure
    //{
    //    public Line(double a)
    //    {
    //        this.A = a;
    //    }
    //}
}
