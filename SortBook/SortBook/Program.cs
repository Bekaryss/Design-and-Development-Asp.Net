using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Bekarys/Downloads/assets";
            string pathOfsource = "C:/Users/Bekarys/Downloads/assets/chapters.txt";
            string[] ls = { };
            List<string> corValue = new List<string>();
            using (StreamReader sr = new StreamReader(pathOfsource))
            {
                string  s = sr.ReadToEnd();
                ls = s.Split();
                foreach (var a in ls)
                {
                    if (a.Length >= 39)
                    {
                        corValue.Add(a.Substring(0, 40));
                    }

                }
            }
            DirectoryInfo di = new DirectoryInfo(path);
            foreach(var a in corValue)
            {               
                foreach (FileInfo item in di.GetFiles())
                {
                    if (a.ToString() == item.Name)
                    {
                        string s = "";
                        if (!File.Exists("C:/Users/Bekarys/Downloads/assets/All.txt"))
                        {
                            File.Create("C:/Users/Bekarys/Downloads/assets/All.txt").Close();
                        }
                        using (StreamReader sr = new StreamReader(item.FullName))
                        {
                            s = sr.ReadToEnd().ToString();
                            sr.Dispose();
                        }

                        using (StreamWriter sw = File.AppendText("C:/Users/Bekarys/Downloads/assets/All.txt"))
                        {
                            sw.WriteLine();
                            sw.WriteLine();
                            sw.WriteLine(s);
                        }
                    }

                }
            }
            
        }
    }
}
