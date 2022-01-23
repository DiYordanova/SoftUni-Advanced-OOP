using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Height of a rectangle:");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("Width of a rectangle:");
            double width = double.Parse(Console.ReadLine());

            Console.WriteLine("Radius of circle:");
            double radius = double.Parse(Console.ReadLine());

            Shape rectangle = new Rectangle(height, width);
            Shape circle = new Circle(radius);

            Console.WriteLine($"The perimeter of rectangle is: {rectangle.CalculatePerimeter()}.");
            Console.WriteLine($"The perimeter of circle is: {circle.CalculatePerimeter()}.");
            Console.WriteLine($"The area of rectangle is: {rectangle.CalculateArea()}.");
            Console.WriteLine($"The area of circle is: {circle.CalculateArea()}.");
            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(circle.Draw());
                       
        }        
    }            
}
