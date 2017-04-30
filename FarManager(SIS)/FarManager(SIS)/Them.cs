using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager_SIS_
{
    public class Them
    {
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor TextColor { get; set; }
        public ConsoleColor ActiveColor { get; set; }
        public ConsoleColor PrivateColor { get; set; }

        public string FolderIcon { get; set; }
        public string FolderIconEmpty { get; set; }
        public string FileIcon { get; set; }
        public enum FFType //Folder or File type
        {
            Active,
            Private,
            Simple
        }

        public Them(ConsoleColor _backColor, ConsoleColor _textColor, ConsoleColor _activeColor, ConsoleColor _privateColor, string _folderIcon, string _folderIconEmpty, string _fileIcon)
        {
            BackgroundColor = _backColor;
            TextColor = _textColor;
            ActiveColor = _activeColor;
            PrivateColor = _privateColor;
            FolderIcon = _folderIcon;
            FileIcon = _fileIcon;
            FolderIconEmpty = _folderIconEmpty;
        }

        public void DrowFolder(int x, int y, string s, FFType type)
        {
            if(type == FFType.Simple)
            {
                Console.ForegroundColor = TextColor;
            }
            else if(type == FFType.Active)
            {
                Console.ForegroundColor = ActiveColor;
            }
            else if(type == FFType.Private)
            {
                Console.ForegroundColor = PrivateColor;
            }
            Console.SetCursorPosition(x, y);
            string space = "";
            if (s.Length < 20)
            {
                space = new string(' ', 20 - s.Length);
            }
            Console.Write(FolderIcon + s + space);
        }

        public void DrowFolderEmpty(int x, int y, string s, FFType type)
        {
            if (type == FFType.Simple)
            {
                Console.ForegroundColor = TextColor;
            }
            else if (type == FFType.Active)
            {
                Console.ForegroundColor = ActiveColor;
            }
            else if (type == FFType.Private)
            {
                Console.ForegroundColor = PrivateColor;
            }
            Console.SetCursorPosition(x, y);
            string space = "";
            if (s.Length < 20)
            {
                space = new string(' ', 20 - s.Length);
            }
            Console.Write(FolderIconEmpty + s + space);
        }

        public void DrowFile(int x, int y, string s, FFType type)
        {
            if (type == FFType.Simple)
            {
                Console.ForegroundColor = TextColor;
            }
            else if (type == FFType.Active)
            {
                Console.ForegroundColor = ActiveColor;
            }
            else if (type == FFType.Private)
            {
                Console.ForegroundColor = PrivateColor;
            }
            Console.SetCursorPosition(x, y);
            string space = "";
            if (s.Length < 20)
            {
                space = new string(' ', 20 - s.Length);
            }
            Console.Write(FileIcon + s + space);
        }

        public void DrowInfo(int x, int y, FileSystemInfo fsi)
        {
            Console.ForegroundColor = TextColor;
            Console.SetCursorPosition(x, y);
            string space = "";
            if (fsi.Name.Length < 30)
            {
                space = new string(' ', 30 - fsi.Name.Length);
            }
            Console.Write("Name: " + fsi.Name.Substring(0, Math.Min(30, fsi.Name.Length)) + space );
            y++;
            Console.SetCursorPosition(x, y);
            if (fsi.FullName.Length < 30)
            {
                space = new string(' ', 30 - fsi.FullName.Length);
            }
            Console.Write("Path: " + fsi.FullName.Substring(0, Math.Min(30, fsi.FullName.Length)) + space);
            y++;
            Console.SetCursorPosition(x, y);
            if (fsi.CreationTime.ToString().Length < 30)
            {
                space = new string(' ', 30 - fsi.CreationTime.ToString().Length);
            }
            Console.Write("Created: " + fsi.CreationTime + space);
            y++;
            Console.SetCursorPosition(x, y);
            if (fsi.LastWriteTime.ToString().Length < 30)
            {
                space = new string(' ', 30 - fsi.LastWriteTime.ToString().Length);
            }
            Console.Write("Last Modified: " + fsi.LastWriteTime + space);
            y++;
            Console.SetCursorPosition(x, y);
            DirectoryInfo d = fsi as DirectoryInfo;
            //Console.Write("Parent: " + d.Parent.FullName);
        }

        public void DrowParent(int x, int y, string s)
        {
            Console.ForegroundColor = TextColor;
            Console.SetCursorPosition(x, y);
            Console.Write("Parent: " + s);
        }

        public void ShowMenu(DrowConsole box)
        {
            Console.ForegroundColor = ActiveColor;
            Console.SetCursorPosition(box.BoxX, box.BoxY);
            Console.WriteLine("F1 - Change Them    F2 - Create Folder or File    F3 - Delete    ESC - Exit");
        }

        

    }
}
