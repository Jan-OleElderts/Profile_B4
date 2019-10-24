using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rechteckigProfil
{
    class v
    {
            double l;
            double  w;
          
            public void Acceptdetail()
            {
              l = 4.5;
              w = 3.5;
            }
            public double GetArea()
            {
              return l *w  ;
            }
            public void Display()
        {
            Console.WriteLine("   Querschnittsflache:   " + l);
            Console.WriteLine("   volumen:              " + w);
            Console.ReadKey();
        }


       }
    class b
    {
        static void Main(string[] args)
        {
            v r = new v();
            r.Acceptdetail();
            r.Display();
            Console.ReadLine();
        }
    }
}


