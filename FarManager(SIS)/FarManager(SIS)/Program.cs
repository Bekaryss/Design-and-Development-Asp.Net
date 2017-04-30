using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager_SIS_
{
    public class Program
    {
        static void Main(string[] args)
        {
            Them th = new Them(ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Red, "{+} ", "[0] ", "   ");
            Console.BackgroundColor = th.BackgroundColor;
            Console.SetWindowSize(82, 59);
            Console.SetBufferSize(82, 59);
            MainFunction mf = new MainFunction();
            DrowConsole box = new DrowConsole(4, 5, 30, 41);
            box.Start = 0;
            box.Finish = box.Height;
            DirectoryInfo currentDir;
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

            mf.Init(th);

            string[] drives = Environment.GetLogicalDrives();
            FileSystemInfo[] flsi = new FileSystemInfo[drives.Length];
            for (int i = 0; i < drives.Length; i++)
            {
                flsi[i] = new DirectoryInfo(drives[i]);
            }
            int index = 0;
            mf.ShowDirectory(th, box, flsi, index);
            ConsoleKeyInfo keyInfo;
            bool Process = true;
            while (Process == true)
            {
                Console.CursorVisible = false;
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        {
                            index++;
                            if (flsi.Length - 1 < index)
                            {
                                index = 0;
                            }
                            mf.ShowDirectory(th, box, flsi, index);
                            Console.CursorVisible = false;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            index--;
                            if (0 > index)
                            {
                                index = flsi.Length - 1;
                            }
                            mf.ShowDirectory(th, box, flsi, index);
                            Console.CursorVisible = false;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            try
                            {
                                if (flsi[index] is DirectoryInfo)
                                {
                                    currentDir = flsi[index] as DirectoryInfo;
                                    Session.Push(flsi, index, currentDir);
                                    flsi = currentDir.GetFileSystemInfos();
                                    mf.ClearBox(box);
                                    if (flsi.Length != 0)
                                    {
                                        index = 0;
                                        mf.ShowDirectory(th, box, flsi, index);


                                    }
                                    Console.CursorVisible = false;
                                }
                                else
                                {
                                    if (ImageExtensions.Contains(Path.GetExtension(flsi[index].FullName).ToUpperInvariant()))
                                    {
                                        Console.Clear();
                                        ShowImage si = new ShowImage();
                                        si.ShowImages(flsi[index].FullName.ToString());
                                        bool imgTrue = true;
                                        while (imgTrue)
                                        {
                                            keyInfo = Console.ReadKey();
                                            if (keyInfo.Key == ConsoleKey.Escape)
                                            {
                                                imgTrue = false;
                                                Console.Clear();
                                                mf.Init(th);
                                                mf.ShowDirectory(th, box, flsi, index);
                                            }
                                        }

                                    }
                                    else
                                    {
                                        System.Diagnostics.Process.Start(flsi[index].FullName);
                                    }

                                }

                            }
                            catch
                            {
                                if (flsi.Length != 0)
                                {
                                    Session.PopDir();
                                    Session.PopFlsi();
                                    Session.PopIndex();
                                }

                            }

                            break;
                        }

                    case ConsoleKey.LeftArrow:
                        {
                            if (Session.flsi.Count != 0)
                            {
                                flsi = Session.PopFlsi();
                                index = Session.PopIndex();
                                currentDir = Session.PopDir();
                                mf.ClearBox(box);
                                mf.ShowDirectory(th, box, flsi, index);
                                Console.CursorVisible = false;
                            }
                            break;
                        }
                    case ConsoleKey.F1:
                        {
                            bool CThem = true;
                            Console.Clear();
                            Console.SetCursorPosition(5, 5);
                            Console.WriteLine("Dark - 1");
                            Console.SetCursorPosition(5, 7);
                            Console.WriteLine("Light - 2");
                            Console.SetCursorPosition(5, 9);
                            Console.WriteLine("Sun - 3");
                            while (CThem)
                            {
                                keyInfo = Console.ReadKey();
                                if (keyInfo.Key == ConsoleKey.NumPad1)
                                {
                                    th = new Them(ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Red, "{+} ", "[0] ", "   ");
                                    Console.BackgroundColor = th.BackgroundColor;
                                    Console.Clear();
                                    mf.Init(th);
                                    CThem = false;
                                    mf.ShowDirectory(th, box, flsi, index);
                                }
                                else
                                if (keyInfo.Key == ConsoleKey.NumPad2)
                                {
                                    th = new Them(ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.DarkMagenta, "{*} ", "[0] ", "   ");
                                    Console.BackgroundColor = th.BackgroundColor;
                                    Console.Clear();
                                    mf.Init(th);
                                    CThem = false;
                                    mf.ShowDirectory(th, box, flsi, index);
                                }
                                else
                                if (keyInfo.Key == ConsoleKey.NumPad3)
                                {
                                    th = new Them(ConsoleColor.Yellow, ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta, ConsoleColor.Black, "{/} ", "[-] ", "-- ");
                                    Console.BackgroundColor = th.BackgroundColor;
                                    Console.Clear();
                                    mf.Init(th);
                                    CThem = false;
                                    mf.ShowDirectory(th, box, flsi, index);
                                }
                                else
                                if (keyInfo.Key == ConsoleKey.Escape)
                                {
                                    CThem = false;
                                }
                            }
                            break;
                        }
                    case ConsoleKey.F2:
                        {
                            if (Session.cur.Count != 0)
                            {
                                currentDir = Session.PeekDir();
                                mf.CreateFolder(currentDir);
                                flsi = currentDir.GetFileSystemInfos();
                                index = 0;
                                mf.ClearBox(box);
                                mf.ShowDirectory(th, box, flsi, index);
                            }

                            break;
                        }
                    case ConsoleKey.F3:
                        {
                            if (Session.cur.Count != 0)
                            {
                                mf.DeleteFolder(flsi, index);
                                mf.ClearBox(box);
                                flsi = Session.PopFlsi();
                                index = Session.PopIndex();
                                currentDir = Session.PopDir();
                                Session.Push(flsi, index, currentDir);
                                flsi = currentDir.GetFileSystemInfos();
                                index = 0;
                                mf.ClearBox(box);
                                if (flsi.Length != 0)
                                {
                                    mf.ShowDirectory(th, box, flsi, index);
                                }
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Process = false;
                            break;
                        }
                }

            }
        }
    }
}
