using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1_Person_
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(Person.Gender.Male);
            p = new Person("Bekarys", "Kuralbay" , 20);
            Manager m = new Manager("87754464696", "Almaty");
            Console.WriteLine(p .ToString());
            Console.WriteLine(m.ToString());
            Console.ReadKey();
        }
        public class Person
        {
            public string FirstName;
            public string LastName;
            public int Age;
            public Gender gen;
            public enum Gender
            {
                Male,
                Female
            };
            public Person(string fn, string ln, int a, Gender _gen) : this(fn, ln, a)
            {
                gen = _gen;   
            }
            public Person(string fn, string ln, int a)
            {
                FirstName = fn;
                LastName = ln;
                Age = a;
            }
            public int GetAge() { return Age; }
            public void SEtAge(int _age)
            {
                Age = _age;
            }
            public override string ToString()
            {
                return FirstName + " " + LastName + " " + Age + " " + gen;  
            }
        }

        public class Manager : Person
        {
            public string PhoneNumber;
            public string OfficeLocation;
            public Manager(string fn, string ln, int a, Gender _gen, string pn, string ol) : base(fn, ln, a, _gen)
            {
                PhoneNumber = pn;
                OfficeLocation = ol;
            }
            public override string ToString()
            {
                return base.ToString() + PhoneNumber + " " + OfficeLocation;
            }
        }
    }
}
