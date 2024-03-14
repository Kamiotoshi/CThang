using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the radius of the cylinder: ");
            double radius = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the height of the cylinder: ");
            double height = double.Parse(Console.ReadLine());

            Cylinder cylinder = new Cylinder(radius, height);
            cylinder.Process();
            Console.WriteLine("\nCyclinder Characteristics:");
            cylinder.Result();
        }

    }
}
