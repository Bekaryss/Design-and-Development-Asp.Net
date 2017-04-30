using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_1_SpellCorrector_
{
   
    public partial class Form1 : Form
    {
        public static MyParam mp = new MyParam();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = InBox.Text;
            string word = "";
            int selectStart = InBox.SelectionStart;
            if(s != "" && selectStart != 0)
            {
                if (!Char.IsLetterOrDigit(s[selectStart - 1]))
                {
                    progressBar1.Value = 0; 
                    mp.StrF = "";
                    mp.StrL = "";
                    progressBar1.Value = 45;
                    word = GetWord(s, selectStart);
                    progressBar1.Value = 80;
                    dListBox.DataSource = null;
                    dListBox.Items.Clear();
                    dListBox.DataSource = FindWords(word);
                    progressBar1.Value = 100;
                    if(dListBox.SelectedItem != null && dListBox.SelectedItem.ToString() != "No result")
                    {
                        string chanW = dListBox.SelectedItem.ToString();
                        string cc = mp.StrF + chanW + ' ';
                        if(mp.StrL != "")
                        {
                            InBox.Text = mp.StrF + chanW + mp.StrL + ' ';
                        }
                        else
                        {
                            InBox.Text = mp.StrF + chanW + mp.StrL + ' ';
                        }
                        
                        InBox.SelectionStart = cc.Length;                        
                    }
                    
                }
            }            
        }

        public static List<string> FindWords(string _word)
        {
            using (StreamReader sr = new StreamReader("TestFile.txt"))
            {
                string line = sr.ReadToEnd();
                string[] s = line.Split();
                List<string> sw = new List<string>();
                Dictionary<string, int> d = new Dictionary<string, int>();
                d.Clear();
                foreach (string i in s)
                {
                    if (i != "" && _word != "")
                    {
                        if (_word[0] == i[0])
                        {
                            if(i != "")
                            {
                                int f = Compute(_word, i);
                                d.Remove(i);
                                d.Add(i, f);
                            }
                                   
                        }
                    }
                }
                if (d.Count == 0)
                {
                    foreach (string i in s)
                    {
                        if (i != "" && _word != "")
                        {
                            if (_word[0] != i[0])
                            {
                                if (i != "")
                                {
                                    int f = Compute(_word, i);
                                    d.Remove(i);
                                    d.Add(i, f);
                                }
                            }
                        }
                    }
                }
                sw.Clear();
                sw = d.OrderBy(x => x.Value).Take(5).ToDictionary(x => x.Key, x => x.Value).Keys.ToList();
                if (sw.Count == 0)
                {
                    sw.Add("No result");
                }
                return sw;
            }
        }

        public static string GetWord(string text, int n)
        {
            for (int i=n-2; i>=0; i--)
            {                
                if (!Char.IsLetterOrDigit(text[i]))
                {
                    mp.StrF = text.Substring(0, n - (n - i - 1));
                    mp.StrL = text.Substring(n - 1, text.Length - n);
                    return text.Substring(i + 1, n - i - 2);               
                }
            }
            mp.StrF = "";
            mp.StrL = text.Substring(n - 1, text.Length - n);
            return text.Substring(0, n-1);
        }

        

        private void change_Click(object sender, EventArgs e)
        {
            if(dListBox.SelectedItem != null)
            {
                string chanW = dListBox.SelectedItem.ToString();
                InBox.Text = mp.StrF + chanW + mp.StrL + ' ';
                InBox.SelectionStart = (mp.StrF + chanW).Length + 1;
                InBox.Select();
            }        
        }

        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        private void add_Click(object sender, EventArgs e)
        {
            bool success = false;
            if(InBox.SelectedText != "")
            {
                string line = "";
                string word = InBox.SelectedText;
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    bool bad = false;
                    line = sr.ReadToEnd();
                    string[] s = line.Split();
                    foreach(string i in s)
                    {
                        if(i==word)
                        {
                            bad = true;
                        }
                    }
                    if(bad != true)
                    {
                        line = line + "\r" + word;
                        success = true;
                    }
                   
                }
                using (StreamWriter sw = new StreamWriter("TestFile.txt", true))
                {
                    if(success == true)
                    {
                        sw.WriteLine(line);
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("Dictionary have this word");
                    }
                    
                }
            }       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dListBox.SelectedItem != null)
            {
                string chanW = dListBox.SelectedItem.ToString();
                InBox.Text = chanW;
            }
        }

    }
    public class MyParam
    {
        public string StrF { get; set; }
        public string StrL { get; set; }

    }
}
