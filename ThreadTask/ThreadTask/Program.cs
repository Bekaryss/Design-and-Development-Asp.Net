using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTask
{
    class Program
    {
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }
        static void WorkWithParameter(object o)
        {
            ArrayList ar = o as ArrayList;
            int[,] arr = (int[,])ar[0];
            string country = (string)ar[1];
            int n = 0;
            string[,] crush = new string[5, 5];
            for(int x=0; x< 20; x++)
            {
                int a = GetRandomNumber(0, 5);
                int b = GetRandomNumber(0, 5);
                if(arr[a,b] == 1)
                {
                    Console.WriteLine("X");
                    n++;
                    if (n == 12)
                    {
                        Thread.CurrentThread.Abort();
                        Console.WriteLine(country + " Win!!!");
                    }
                    crush[a, b] = "X";
                }
                else
                {
                    Console.WriteLine("O");
                    crush[a, b] = "O";
                }
                Console.WriteLine("{0}: {1} {2}", country, a, b);
                Console.WriteLine();
                Thread.Sleep(100);
            }
            Console.WriteLine(country + " destroy " + n);
            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 5; y++)
                {
                    
                    Console.Write(crush[i, y] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            ArrayList al1 = new ArrayList();
            ArrayList al2 = new ArrayList();
            int[,] matrix = ArrayObject();
            Console.WriteLine();
            int[,] matrix1 = ArrayObject();
            Console.WriteLine();
            al1.Add(matrix);
            al1.Add("Анчуария");
            al2.Add(matrix1);
            al2.Add("Тарантерия");
            ParameterizedThreadStart operation = new ParameterizedThreadStart(WorkWithParameter);
            Thread newThread = new Thread(operation);
            newThread.Start(al1);
            Thread theThread = new Thread(operation);
            theThread.Start(al2);
            Console.ReadKey();

        }
        public static int[,] ArrayObject()
        {
            int row = 5; //rows
            int col = 5; //coloumns

            int[,] matrice = new int[row, col];
            int n = 0;
            for (int i = 0; i < row; i++)
            {
                for (int y = 0; y < col; y++)
                {
                    int rundN = GetRandomNumber(0, 2);
                    if(rundN == 1 && n<12)
                    {
                        matrice[i, y] = rundN;
                        n++;
                    }
                    else if(rundN == 0)
                    {
                        matrice[i, y] = rundN;
                    }
                    Console.Write(matrice[i, y] + " ");
                }
                Console.WriteLine();
            }
            return matrice;
        }
    }
}
