using MidTerm_Hospital_.Models;
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
using System.Xml.Serialization;

namespace MidTerm_Hospital_
{
    public partial class Form1 : Form
    {
        BindingList<Doctor> bl = new BindingList<Doctor>();
        BindingList<Patient> blP = new BindingList<Patient>();

        public Form1()
        {
            InitializeComponent();
            FileStream fs = new FileStream("Doctors.txt", FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(BindingList<Doctor>));
            bl = (BindingList<Doctor>)xs.Deserialize(fs);
            fs.Close();
            DoctorView.DataSource = bl;

            FileStream fs2 = new FileStream("Patient.txt", FileMode.Open);
            XmlSerializer xs2 = new XmlSerializer(typeof(BindingList<Patient>));
            blP = (BindingList<Patient>)xs2.Deserialize(fs2);
            fs2.Close();
            PatientView.DataSource = blP;

            List<Gender> genders = new List<Gender>();
            genders.Add(Gender.Male);
            genders.Add(Gender.Female);
            Genders.DataSource = genders;
            GendersP.DataSource = genders;

            List<Speciality> special = new List<Speciality>();
            foreach(Speciality item in Enum.GetValues(typeof(Speciality)))
            {
                special.Add(item);
            }
            Special.DataSource = special;


            List<string> DoctorName = new List<string>();
            foreach(var i in bl)
            {
                DoctorName.Add(i.FirstName);
            }
            DoctorId.DataSource = DoctorName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctor doc = new Doctor();
            DoctorView.DataSource = bl;
            foreach (Control p in PersonDPanel.Controls)
            {
                if(p.Name == "FirstName")
                {
                    doc.FirstName = p.Text;
                }
                if(p.Name == "SecondName")
                {
                    doc.SecondName = p.Text;
                }
                if(p.Name == "FatherName")
                {
                    doc.FatherName = p.Text;
                }
                if (p.Name == "Age")
                {
                    NumericUpDown n =  p as NumericUpDown;
                    doc.Age = (int)n.Value;
                }
                if (p.Name == "BirthDate")
                {
                    DateTimePicker date = p as DateTimePicker;
                    doc.BirthDate = date.Value;
                }
                if (p.Name == "PhoneNumber")
                {
                    doc.PhoneNumber = p.Text;
                }
                if (p.Name == "Genders")
                {
                    ComboBox comb = p as ComboBox;
                    if(comb.Text == "Male")
                    {
                        doc.Genders = Gender.Male;
                    }
                    else
                    {
                        doc.Genders = Gender.Female;
                    }
                   
                }
                if (p.Name == "Address")
                {
                    doc.Address = p.Text;
                }

            }
            foreach (Control p in DoctorPanel.Controls)
            {
                if(p.Name == "Location")
                {
                    doc.Location = p.Text;
                }
                if(p.Name == "Degree")
                {
                    doc.Degree = p.Text;
                }
                if(p.Name == "Special")
                {
                    ComboBox comb = p as ComboBox;
                    foreach (Speciality item in Enum.GetValues(typeof(Speciality)))
                    {
                        if(comb.Text == item.ToString())
                        {
                            doc.Special = item;
                        }
                    }
                }
            }

            bl.Add(doc);
            DoctorView.Refresh();

        }

        private void SaveDoctor_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Doctors.txt", FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(BindingList<Doctor>));
            xs.Serialize(fs, bl);
            fs.Close();
        }

        private void UploadPacient_Click(object sender, EventArgs e)
        {
            Patient doc = new Patient();
            PatientView.DataSource = blP;
            foreach (Control p in PaciPanel.Controls)
            {
                if (p.Name == "FirstNameP")
                {
                    doc.FirstName = p.Text;
                }
                if (p.Name == "SecondNameP")
                {
                    doc.SecondName = p.Text;
                }
                if (p.Name == "FatherNameP")
                {
                    doc.FatherName = p.Text;
                }
                if (p.Name == "AgeP")
                {
                    NumericUpDown n = p as NumericUpDown;
                    doc.Age = (int)n.Value;
                }
                if (p.Name == "BirthDateP")
                {
                    DateTimePicker date = p as DateTimePicker;
                    doc.BirthDate = date.Value;
                }
                if (p.Name == "PhoneNumberP")
                {
                    doc.PhoneNumber = p.Text;
                }
                if (p.Name == "GendersP")
                {
                    ComboBox comb = p as ComboBox;
                    if (comb.Text == "Male")
                    {
                        doc.Genders = Gender.Male;
                    }
                    else
                    {
                        doc.Genders = Gender.Female;
                    }

                }
                if (p.Name == "AddressP")
                {
                    doc.Address = p.Text;
                }

            }
            foreach (Control p in PacientPanel.Controls)
            {
                if (p.Name == "Special")
                {
                    ComboBox comb = p as ComboBox;
                    foreach (var item in bl)
                    {
                        if (comb.Text == item.FirstName)
                        {
                            doc.DoctorName = item.FirstName;
                        }
                    }
                }
                if (p.Name == "Info")
                {
                    doc.Info = p.Text;
                }              
            }

            blP.Add(doc);
            PatientView.Refresh();
        }

        private void SavePati_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Patient.txt", FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(BindingList<Patient>));
            xs.Serialize(fs, blP);
            fs.Close();
        }
    }
}
