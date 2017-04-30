using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_SortString_
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Create a new console application project. Name the project SortString.";
            string[] a = s.Split(' ');
            Array.Sort(a);
            s = String.Join(" ", a);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
