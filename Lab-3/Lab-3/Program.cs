using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable HashT = new Hashtable();
            ListDictionary ListD = new ListDictionary();
            HybridDictionary HibrD = new HybridDictionary();
            OneH(HashT, ListD, HibrD);
            OneS(HashT, ListD, HibrD);
            Tens(HashT, ListD, HibrD);
            Console.ReadKey();
        }
        static void OneH(Hashtable HashT, ListDictionary ListD, HybridDictionary HibrD)
        {
            HashT.Clear();
            ListD.Clear();
            HibrD.Clear();
            Console.WriteLine("100");
            for (int i = 0; i < 100; i++)
            {
                HashT.Add(i, DateTime.Now);
                ListD.Add(i, DateTime.Now);
                HibrD.Add(i, DateTime.Now);
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in HashT.Values)
            {
                
            }
            Console.WriteLine("HashTable " + sw.Elapsed);
            Console.WriteLine();
            sw.Restart();
            foreach (var item in ListD.Values)
            {
            }
            Console.WriteLine("ListDictionary " + sw.Elapsed);
            Console.WriteLine();
            sw.Restart();
            foreach (var item in HibrD.Values)
            {
            }
            Console.WriteLine("HybridDictionary " + sw.Elapsed);
            Console.WriteLine();
        }

        static void OneS(Hashtable HashT, ListDictionary ListD, HybridDictionary HibrD)
        {
            HashT.Clear();
            ListD.Clear();
            HibrD.Clear();
            Console.WriteLine("1000");
            Random r = new Random();
            for (int i = 0; i < 100000; i++)
            {
                DateTime dt = new DateTime((long)r.NextDouble());
                HashT.Add(Guid.NewGuid().ToByteArray(), i );
                ListD.Add(Guid.NewGuid().ToByteArray(), i);
                HibrD.Add(Guid.NewGuid().ToByteArray(), i);
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in HashT.Values)
            {

            }
            Console.WriteLine("HashTable " + sw.Elapsed);
            Console.WriteLine();
            sw.Restart();
            foreach (var item in ListD.Values)
            {
            }
            Console.WriteLine("ListDictionary " + sw.Elapsed);
            Console.WriteLine();
            sw.Restart();
            foreach (var item in HibrD.Values)
            {
            }
            Console.WriteLine("HybridDictionary " + sw.Elapsed);
            Console.WriteLine();
        }
        static void Tens(Hashtable HashT, ListDictionary ListD, HybridDictionary HibrD)
        {
            HashT.Clear();
            ListD.Clear();
            HibrD.Clear();
            Console.WriteLine("10000");
            for (int i = 0; i < 10000; i++)
            {
                HashT.Add(i, DateTime.Now);
                ListD.Add(i, DateTime.Now);
                HibrD.Add(i, DateTime.Now);
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in HashT.Values)
            {

            }
            Console.WriteLine("HashTable " + sw.Elapsed);
            Console.WriteLine();
            sw.Restart();
            foreach (var item in ListD.Values)
            {
            }
            Console.WriteLine("ListDictionary " + sw.Elapsed);
            Console.WriteLine();
            sw.Restart();
            foreach (var item in HibrD.Values)
            {
            }
            Console.WriteLine("HybridDictionary " + sw.Elapsed);
            Console.WriteLine();
        }
    }
}
