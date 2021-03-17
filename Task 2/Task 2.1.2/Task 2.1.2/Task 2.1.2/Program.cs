using System;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(0,0,1);
            Ring ring = new Ring(0,0,2,1);
            Triangle tri = new Triangle(2,2,2);

            Console.WriteLine("Площадь треугольника: {0} ", tri.TriangleSquare);
            Console.WriteLine("Периметр треугольника: {0} ", tri.TrianglePerimetr);

            Console.WriteLine("Площадь: {0} ", circle.CircleArea);
            Console.WriteLine("Длина: {0} ", circle.Circumference);

            Console.WriteLine("Площадь кольца: " + ring.RingArea);
            Console.WriteLine("Суммарная длина внешней и внутренней окружностей: " + ring.SummaryLen);
        }
    }

    class Points
    {
        // Стороны
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        // Точки центра
        public double X { get; set; }
        public double Y { get; set; }

        public Points() { }
        public Points (double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    class Circle : Points
    {
     
        public double Radius { get; set; }
        public Circle() { }
        public Circle (double x, double y, double Radius) { this.X = x; this.Y = y; this.Radius = Radius; }

        public double CircleArea => Math.PI * Math.Pow(Radius, 2);
        public double Circumference => ((Math.PI * Radius)*2);
    }

    class Ring : Circle
    {
        public double InnerRadius { get; set; }

        public Ring (double x, double y, double Radius, double InnerRadius) 
        { this.X = x; this.Y = y; this.Radius = Radius; this.InnerRadius = InnerRadius; }


        public double RingArea => Math.PI * ((Radius*Radius) - (InnerRadius*InnerRadius));
        public double SummaryLen => (2 * (Math.PI * Radius)) + (2 * (Math.PI * InnerRadius));

    }

    class Triangle : Points
    {
       
        double P { get; set; }
        
        public Triangle (double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;

            P = (A + B + C) / 2; // полупериметр
        }

        public double TriangleSquare => Math.Sqrt(P* (P - A) * (P - B) * (P - C));
        public double TrianglePerimetr => A + B + C;
    }
    
    class Square : Points
    {
        public Square (double a)
        {
            this.A = a;
        }

        public double SquareArea => A*A;
        public double SquarePerimeter => A * 4;
    }

    class Rectangle : Points
    {
        public Rectangle (double a, double b)
        {
            this.A = a;
            this.B = b;
        }

        public double RectangleArea => A * B;
        public double RectanglePerimeter => (A+B)*2;

    }

    class Line : Points
    {
        public Line (double a)
        {
            this.A = a;
        }
    }
}
