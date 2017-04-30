using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher
{
    public class Searcher
    {
        public async Task<List<string>> SearchFile(List<string> getlist, string directory, string search, bool type)
        {
            DirectoryInfo dir = new DirectoryInfo(directory);
            if (getlist.Count > 4)
            {
                return getlist;
            }
            foreach (var file in dir.GetFiles())
            {
                if (type == true)
                {
                    if (Path.GetFileNameWithoutExtension(file.Name.ToLower()).Contains(search.ToLower()))
                    {
                        getlist.Add(file.Name);
                    }
                }
                else
                {
                    string[] lines = File.ReadAllLines(file.FullName);
                    foreach (string s in lines.ToList())
                    {
                        if (s.ToLower().Contains(search))
                        {
                            getlist.Add(file.Name);
                            break;
                        }
                    }
                }
            }
            try
            {
                foreach (var direct in dir.GetDirectories())
                {
                    
                    await SearchFile(getlist, direct.FullName, search, type);
                }
            }
            catch { }
            
            return getlist;

        }
    }
}
