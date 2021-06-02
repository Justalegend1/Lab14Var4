using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab14Var4
{
    public class Library : Organization, ICloneable, IComparer
    {
        Library next;
        int working_hours;
        int number_of_books;
        string[] employee = new string[7] { "Улыбкина", "Кардашьян", "Барбариков", "Бобров", "Крылов", "Чесноков", "Паров" };
        int[] stage = new int[7] { 3, 15, 11, 4, 4, 2, 22 };
        public Library() : base()
        {
            number_of_books = 0;
            working_hours = 0;
        }
        public Library(string name, int number, int work, int number1) : base(name, number)
        {
            Working_Hours = work;
            Number_of_Books = number1;
        }
        public int Working_Hours
        {
            get { return working_hours; }
            set
            {
                bool o = Int32.TryParse(Convert.ToString(value), out working_hours);
                while ((!o) | (working_hours < 0) | (working_hours > 9))
                {
                    Console.WriteLine("Не может столько библиотека работать, введите время работы заново");
                    o = Int32.TryParse(Console.ReadLine(), out working_hours);
                }
            }
        }
        public int Number_of_Books
        {
            get { return number_of_books; }
            set
            {
                bool o = Int32.TryParse(Convert.ToString(value), out number_of_books);
                while ((!o) | (number_of_books < 0))
                {
                    Console.WriteLine("Такого количества книг не может быть, осуществите ввод заново");
                    o = Int32.TryParse(Console.ReadLine(), out number_of_books);
                }
            }
        }
        //public override void Show()
        //{
        //    base.Show();
        //    Console.WriteLine($"Библиотека работает {working_hours} часов и имеет {number_of_books} книг"); ;
        //}
        public override void Show()
        {
            //Console.WriteLine($"Кол-во сотрудников: {number_of_employees}, название организации: {name} ");
            Console.WriteLine(this.ToString());
        }
        public void ShowStage(int po)
        {
            int count = 0;
            for (int y = 0; y < stage.Length; y++)
            {
                Console.WriteLine($"{employee[y]} - работает {stage[y]} лет ");
            }
            Console.WriteLine($"Эти люди работают в {name} не менее шести лет");
            for (int t = 0; t < stage.Length; t++)
            {
                if (stage[t] >= po)
                {
                    Console.WriteLine(employee[t]);
                }
            }
            if (count == 0)
                Console.WriteLine("Такого работника нет");
        }
        public override object Init()
        {
            //Random rnd = new Random();
            Organization o = (Organization)base.Init();
            Library l = new Library(Name = o.Name, Number_of_employees = o.Number_of_employees, Working_Hours = rnd.Next(1, 10), Number_of_Books = rnd.Next(50, 1001));
            //Console.WriteLine(ReferenceEquals(this, l));
            return l;
        }
        public override object Clone()
        {
            return new Library { Name = this.Name, Number_of_employees = this.Number_of_employees, Number_of_Books = this.Number_of_Books, Working_Hours = this.Working_Hours };
        }
        public override object ClonePoverx()
        {
            return this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if (obj is Library)
                return base.Equals(obj) && this.Working_Hours == ((Library)obj).Working_Hours && this.Number_of_Books == ((Library)obj).Number_of_Books;
            else
                return false;
        }
        public override string ToString()
        {
            return base.ToString() + " " + "Часы работы: " + this.working_hours.ToString() + "," + "Количество книг: " + this.number_of_books.ToString();
        }
        public int Compare(object x, object y)
        {
            if (((Organization)x).Number_of_employees > ((Organization)y).Number_of_employees) { return 1; }
            else if (((Organization)x).Number_of_employees < ((Organization)y).Number_of_employees) { return -1; }
            else { return 0; }
        }
    }
}
