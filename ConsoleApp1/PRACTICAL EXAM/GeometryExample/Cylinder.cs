using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryExample
{
    class Cylinder
    {
        public double radius;
        public double height;
        public double baseArea;
        public double lateralArea;
        public double totalArea;
        public double volume;
        public Cylinder(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
        }
        public void Process()
        {
            baseArea = radius * radius * Math.PI;
            lateralArea = 2 * Math.PI * radius * height;
            totalArea = 2 * Math.PI * radius * (height + radius);
            volume = Math.PI * radius * radius * height;
        }
        public void Result  ()
        {
            Console.WriteLine($"Radius: {radius}, Height: {height}");
            Console.Write($"Base Area: {baseArea:F2} ! ");
            Console.Write($"Lateral Area: {lateralArea:F2} ! ");
            Console.Write($"Total Area: {totalArea:F2}  ! ");
            Console.Write($"Volume: {volume:F2} ! ");
        }
    }
}
