using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager_SIS_
{
    public class Session
    {
        public static Stack<FileSystemInfo[]> flsi = new Stack<FileSystemInfo[]>();
        public static Stack<int> Index = new Stack<int>();
        public static Stack<DirectoryInfo> cur = new Stack<DirectoryInfo>();
        public static void Push(FileSystemInfo[] f, int i, DirectoryInfo dir)
        {
            flsi.Push(f);
            Index.Push(i);
            cur.Push(dir);
        }
        public static FileSystemInfo[] PopFlsi()
        {
            return flsi.Pop();
        }
        public static int PopIndex()
        {
            return Index.Pop();
        }
        public static DirectoryInfo PopDir()
        {
            return cur.Pop();
        }
        public static DirectoryInfo PeekDir()
        {
            return cur.Peek();
        }
        public static FileSystemInfo[] PeekFlsi()
        {
            return flsi.Peek();
        }
        public static int PeekIndex()
        {
            return Index.Peek();
        }
    }
}
