using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion(200, "Simba");
            Tiger tiger = new Tiger(180, "Shere Khan");

            lion.Show();
            tiger.Show();
        }
    }
}



