using System;

namespace Task_2._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(0,0,1);
            Ring ring = new Ring(0,0,2,1);

            Console.WriteLine("Площадь: {0} ", circle.Square);
            Console.WriteLine("Длина: {0} ", circle.Circumference);

            Console.WriteLine("Площадь кольца: " + ring.RingSquare);
            Console.WriteLine("Суммарная длина внешней и внутренней окружностей: " + ring.SummaryLen);
        }
    }

    public class Circle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public Circle() { }
        public Circle (double x, double y, double Radius) { this.X = x; this.Y = y; this.Radius = Radius; }

        public double Square => Math.PI * Math.Pow(Radius, 2);
        public double Circumference => ((Math.PI * Radius)*2);
    }

    public class Ring : Circle
    {
        public double InnerRadius { get; set; }

        public Ring (double x, double y, double Radius, double InnerRadius) 
        { this.X = x; this.Y = y; this.Radius = Radius; this.InnerRadius = InnerRadius; }


        public double RingSquare => Math.PI * ((Radius*Radius) - (InnerRadius*InnerRadius));
        public double SummaryLen => (2 * (Math.PI * Radius)) + (2 * (Math.PI * InnerRadius));

    }
    
}
