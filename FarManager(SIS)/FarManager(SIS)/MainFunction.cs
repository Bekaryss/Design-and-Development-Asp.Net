using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FarManager_SIS_
{
    public class MainFunction
    {
        public void Init(Them th)
        {
            Console.BackgroundColor = th.BackgroundColor;
            Console.ForegroundColor = th.TextColor;
            for (int i = 0; i < 81; i++)
            {
                for(int j = 1; j< 59; j++)
                {
                    
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                    if (i == 2 && j != 59 && j!=0)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("#");
                    }
                    if (i == 80  && j != 59 && j != 0)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("#");
                    }
                    if(j==1 && i>2 && i < 80)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("#");
                    }

                    if (j == 58 && i > 2 && i < 80)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("#");
                    }

                    if (j == 3 && i > 2 && i < 80)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("-");
                    }
                    if (j == 46 && i > 2 && i < 80)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("-");
                    }
                    if (j == 53 && i > 2 && i < 80)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("-");
                    }
                }

            }
            th.ShowMenu(new DrowConsole(4, 2, 30, 1));
        }
        public void ReShowDirectory(Them th, DrowConsole box, FileSystemInfo[] fsi, int index)
        {
            int number = 0; //FileSystemCount
            int x = box.BoxX;
            int y = 0;
            foreach (FileSystemInfo item in fsi)
            {
                if (number > box.Height)
                {
                    break;
                }
                y = box.BoxY + number;
                if (number == index)
                {
                    
                    if (item is DirectoryInfo)
                    {
                        DirectoryInfo di = item as DirectoryInfo;
                        try
                        {
                            if (di.GetFileSystemInfos().Length == 0)
                            {
                                th.DrowFolderEmpty(x, y, di.Name.Substring(0, Math.Min(20, di.Name.Length)), Them.FFType.Active);
                            }
                            else
                            {
                                th.DrowFolder(x, y, di.Name.Substring(0, Math.Min(20, di.Name.Length)), Them.FFType.Active);
                            }
                        }
                        catch
                        {
                            th.DrowFolder(x, y, di.Name.Substring(0, Math.Min(20, di.Name.Length)), Them.FFType.Private);
                        }
                        
                    }
                    else
                    {
                        th.DrowFile(x, y, item.Name.Substring(0, Math.Min(20, item.Name.Length)), Them.FFType.Active);
                    }
                    
                }               
                number++;
            }
        }
        public void DeleteFolder(FileSystemInfo[] fsi, int index)
        {
            if(fsi[index] is DirectoryInfo)
            {
                ClearFolder(fsi[index].FullName);
                foreach(var fs in fsi)
                {
                    fs.Refresh();
                }
                fsi[index].Delete();
            }
            else
            {
                FileInfo f = fsi[index] as FileInfo;
                f.Delete();
                foreach (var fs in fsi)
                {
                    fs.Refresh();
                }
            }
        }
        private void ClearFolder(string FolderName)
        {           
            DirectoryInfo dir = new DirectoryInfo(FolderName);
            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
        }
        public void ShowDirectory(Them th, DrowConsole box, FileSystemInfo[] fsi, int index)
        {
            Console.BackgroundColor = th.BackgroundColor;
            th.DrowInfo(4, 48, fsi[index]);
            
            int number = 0; //FileSystemCount
            int x = box.BoxX;
            int y = 0;
            int start = 0;
            int finish = box.Height;
            if (index + 2 > box.Height)
            {
                start = index + 2 - box.Height;
                finish = box.Height + index + 2 - box.Height;
            }           
            
            int count = 0;       
            foreach (FileSystemInfo item in fsi)
            {                
                if (count >= start && count + 1 < finish)
                {
                    if(number > box.Height)
                    {
                        number = 0;
                    }
                    y = box.BoxY + number;
                    if (item is DirectoryInfo)
                    {
                        DirectoryInfo di = item as DirectoryInfo;
                        try
                        {
                            if (di.GetFileSystemInfos().Length == 0)
                            { 
                                if (count == index)
                                {
                                    th.DrowFolderEmpty(x, y, di.Name.Substring(0, Math.Min(20, di.Name.Length)), Them.FFType.Active);
                                }
                                else
                                {
                                    th.DrowFolderEmpty(x, y, di.Name.Substring(0, Math.Min(20, di.Name.Length)), Them.FFType.Simple);
                                }
                            }
                            else
                            {
                                if (count == index)
                                {
                                    th.DrowFolder(x, y, di.Name.Substring(0, Math.Min(20, di.Name.Length)), Them.FFType.Active);
                                }
                                else
                                {
                                    th.DrowFolder(x, y, di.Name.Substring(0, Math.Min(20, di.Name.Length)), Them.FFType.Simple);
                                }
                            }

                        }
                        catch
                        {
                            if (count == index)
                            {
                                
                                th.DrowFolder(x, y, di.Name.Substring(0, Math.Min(20, di.Name.Length)), Them.FFType.Active);
                            }
                            else
                            {
                                th.DrowFolder(x, y, di.Name.Substring(0, Math.Min(20, di.Name.Length)), Them.FFType.Private);
                            }
                        }

                        number++;
                    }
                    else
                    {
                        FileInfo fl = item as FileInfo;
                        if (fl.Attributes.ToString().Contains("Hidden"))
                        {
                            if (number == index)
                            {
                                th.DrowFile(x, y, fl.Name.Substring(0, Math.Min(20, fl.Name.Length)), Them.FFType.Active);
                            }
                            else
                            {
                                th.DrowFile(x, y, fl.Name.Substring(0, Math.Min(20, fl.Name.Length)), Them.FFType.Private);
                            }

                        }
                        else
                        {
                            if (number == index)
                            {
                                th.DrowFile(x, y, fl.Name.Substring(0, Math.Min(20, fl.Name.Length)), Them.FFType.Active);
                            }
                            else
                            {
                                th.DrowFile(x, y, fl.Name.Substring(0, Math.Min(20, fl.Name.Length)), Them.FFType.Simple);
                            }
                        }
                        number++;
                    }
                }
                count++;
            }
        }

        public void ClearBox(DrowConsole box)
        {
            for(int i = box.BoxX; i< box.BoxX + box.Width; i++)
            {
                Thread.Sleep(1);
                for (int j=box.BoxY; j< box.BoxY + box.Height; j++)
                {                   
                    box.ClBox(i, j);
                }
            }
        }

        public void CreateFolder(DirectoryInfo flsi)
        {
            ClearBox(new DrowConsole(4, 54, 50, 4));
            Console.SetCursorPosition(4, 54);
            Console.Write("Pleas enter folder or file name: ");
            Console.SetCursorPosition(4, 56);
            Console.Write("> ");
            Console.SetCursorPosition(6, 56);
            string name = Console.ReadLine();
            if (name.Contains('.'))
            {
                FileInfo di = new FileInfo((flsi.FullName).ToString() + @"\" + name);
                if (!di.Exists)
                {
                    di.Create().Close();
                    ClearBox(new DrowConsole(4, 54, 40, 4));
                }
                else
                {
                    ClearBox(new DrowConsole(4, 54, 50, 4));
                    Console.SetCursorPosition(5, 54);
                    Console.WriteLine("File with such name already exists press F2");
                }
                
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo((flsi.FullName).ToString() + @"\" + name);
                if (!di.Exists)
                {
                    di.Create();
                    ClearBox(new DrowConsole(4, 54, 50, 4));
                }
                else
                {
                    ClearBox(new DrowConsole(4, 54, 50, 4));
                    Console.SetCursorPosition(5, 55);
                    Console.WriteLine("Folder with such name already exists press F2");
                }
            }        
            
        }
    }
}
