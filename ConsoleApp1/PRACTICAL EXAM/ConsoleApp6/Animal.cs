using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Animal
    {
        protected double weight;
        protected string name;

        public void SetMe(double weight, string name)
        {
            this.weight = weight;
            this.name = name;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Name: {name}, Weight: {weight}kg");
        }
    }

    class Lion : Animal
    {
        public Lion(double weight, string name)
        {
            SetMe(weight, name); 
        }

        public override void Show()
        {
            Console.WriteLine($"Lion - Name: {name}, Weight: {weight}kg");
        }
    }

    class Tiger : Animal
    {
        public Tiger(double weight, string name)
        {
            SetMe(weight, name); 
        }

        public override void Show()
        {
            Console.WriteLine($"Tiger - Name: {name}, Weight: {weight}kg");
        }
    }
}