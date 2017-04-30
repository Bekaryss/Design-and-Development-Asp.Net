using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcher
{
    public partial class Form1 : Form
    {
        int TogMove;
        int MValX;
        int MVAlY;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MVAlY = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MVAlY);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimieButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void Search_Click(object sender, EventArgs e)
        {
            Searcher ser = new Searcher();
            string Searchfile = textBox1.Text.ToString();
            Regex regex = new Regex(@"^\[([0-9 a-z .?!A - Z а-я А - Я]+)\]$");
            var result = regex.Match(Searchfile);
            bool name = true;

            if (result.Success)
            {
                Searchfile = Searchfile.Replace("[", "").Replace("]", "");
                name = false;
            }
            List<string> FileList = new List<string>();
            FileList = await ser.SearchFile(FileList, @"C:\Users\Bekarys\Documents", Searchfile, name);
            listBox1.DataSource = null;
            if(FileList.Count == 0)
            {
                FileList.Add("No result");
            }
            listBox1.DataSource = FileList;
            listBox1.Visible = true;
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Searcher ser = new Searcher();
                string Searchfile = textBox1.Text.ToString();
                Regex regex = new Regex(@"^\[([0-9 a-z .?!A - Z а-я А - Я]+)\]$");
                var result = regex.Match(Searchfile);
                bool name = true;

                if (result.Success)
                {
                    Searchfile = Searchfile.Replace("[", "").Replace("]", "");
                    name = false;
                }
                List<string> FileList = new List<string>();
                FileList = await ser.SearchFile(FileList, @"C:\Users\Bekarys\Documents", Searchfile, name);
                listBox1.DataSource = null;
                if (FileList.Count == 0)
                {
                    FileList.Add("No result");
                }
                listBox1.DataSource = FileList;
                listBox1.Visible = true;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
