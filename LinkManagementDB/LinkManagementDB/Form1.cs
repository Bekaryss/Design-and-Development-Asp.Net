using LinkManagementDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkManagementDB
{
    public partial class Form1 : Form
    {
        List<Link> links = new List<Link>();
        Link curLink;

        bool edit = false;
        bool delete = false;
        public Form1()
        {
            InitializeComponent();
            GetList();
        }

        private SqlConnection connect = null;

        public void OpenConnection()
        {
            connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Beka\Documents\Visual Studio 2017\Projects\Design and Development\LinkManagementDB\LinkManagementDB\AddData\Database1.mdf';Integrated Security=True");
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            string s = tb_create.Text;
            string sql = string.Format("Insert Into Link" + "(Id, Name) Values(@Id, @Name)");
            OpenConnection();
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.Parameters.AddWithValue("@Id", LinkList.RowCount + 1);
                cmd.Parameters.AddWithValue("@Name", s);
                cmd.ExecuteNonQuery();
            }
            tb_create.Text = "";
            CloseConnection();
            GetList();
        }

        private void GetList()
        {
            OpenConnection();
            string strSQL = "SELECT * FROM Link";
            SqlCommand myCommand = new SqlCommand(strSQL, this.connect);
            SqlDataReader dr = myCommand.ExecuteReader();
            links.Clear();
            while (dr.Read())
                links.Add(new Link((int)dr[0], (string)dr[1]));
            LinkList.DataSource = null;
            LinkList.DataSource = links;
            LinkList.Refresh();
            CloseConnection();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
                curLink.Name = tb_edit.Text;
                string sql = string.Format("Update Link Set Name = '{0}' Where Id = '{1}'", curLink.Name, curLink.Id);
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sql, this.connect))
                {
                    cmd.ExecuteNonQuery();
                }
                tb_edit.Text = "";
                CloseConnection();
                GetList();
        }

        private void btn_upd_Click(object sender, EventArgs e)
        {
            if(LinkList.SelectedRows != null)
            {
                foreach (DataGridViewRow item in LinkList.SelectedRows)
                {
                    curLink = new Link((int)item.Cells[0].Value, item.Cells[1].Value.ToString());
                }
                tb_edit.Text = curLink.Name;
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
                foreach (DataGridViewRow item in LinkList.SelectedRows)
                {
                    curLink = new Link((int)item.Cells[0].Value, item.Cells[1].Value.ToString());
                }
                int id = curLink.Id;
                string sql = string.Format("Delete from Link where Id = '{0}'", id);
                 OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sql, this.connect))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("К сожалению, эта машина заказана!", ex);
                        throw error;
                    }
                }
                CloseConnection();
                GetList();
        }
    }
}
