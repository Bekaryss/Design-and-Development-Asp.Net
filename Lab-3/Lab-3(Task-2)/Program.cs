using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_3_Task_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPhone("(555) 555-1212"));
            Console.WriteLine(IsZip("01111-1111"));
            Console.WriteLine(IsEmail("bekarys.kuralbai@gmail.com"));
            Console.WriteLine(ReformatPhone("(555)555-1212"));
            Console.ReadKey();
        }
        static bool IsPhone(string s){ return Regex.IsMatch(s, @"^\(?\d{3}\)?[\s\-]?\d{3}\-?\d{4}$"); }
        static string ReformatPhone(string s) { Match m = Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$"); return String.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]); }
        static bool IsZip(string s) { return Regex.IsMatch(s, @"^\d{5}(\-\d{4})?$"); }
        static bool IsEmail(string s) { return Regex.IsMatch(s, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$$"); }  
    }
}
