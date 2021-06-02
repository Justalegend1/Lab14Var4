using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14Var4
{
    public class Insurance_Company : Organization, ICloneable
    {
        Insurance_Company next;
        string[] employee = new string[7] { "Петров", "Николаев", "Борисов", "Никитин", "Вяткин", "Уткин", "Отвальный" };
        int[] stage = new int[7] { 5, 3, 9, 4, 17, 9, 13 };
        int rating;
        int year_of_foundation;
        public Insurance_Company() : base()
        {
            year_of_foundation = 0;
            rating = 0;
        }
        public Insurance_Company(string l, int k, int year_of_found, int rating1) : base(l, k)
        {
            Year_of_Foundation = year_of_found;
            rating = rating1;
        }
        public int Rating
        {
            get { return rating; }
            set
            {
                bool o = Int32.TryParse(Convert.ToString(value), out rating);
                while ((!o) | (rating < 0) | (rating > 100))
                {
                    Console.WriteLine("Введите рейтинг от 0 до 100");
                    o = Int32.TryParse(Console.ReadLine(), out rating);
                }
            }
        }
        public int Year_of_Foundation
        {
            get { return year_of_foundation; }
            set
            {
                bool o = Int32.TryParse(Convert.ToString(value), out year_of_foundation);
                while ((!o) | (year_of_foundation < 0) | (year_of_foundation > 2021))
                {
                    Console.WriteLine("Введите целое число");
                    o = Int32.TryParse(Console.ReadLine(), out year_of_foundation);
                }
            }
        }
        //public override void Show()
        //{
        //    base.Show();
        //    Console.WriteLine($"Фирма имеет рейтинг {rating} и организована в {year_of_foundation} году");
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
        //static Random rnd = new Random();
        public override object Init()
        {
            Organization o = (Organization)base.Init();
            Insurance_Company i = new Insurance_Company(o.Name, o.Number_of_employees, Year_of_Foundation = rnd.Next(1800, 2022), Rating = rnd.Next(0, 101));
            return i;
        }
        public override object Clone()
        {
            return new Insurance_Company { Name = this.Name, Number_of_employees = this.Number_of_employees, Year_of_Foundation = this.Year_of_Foundation, Rating = this.Rating };
        }
        public override object ClonePoverx()
        {
            return this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if (obj is Insurance_Company)
                return base.Equals(obj) && this.Rating == ((Insurance_Company)obj).Rating && this.Year_of_Foundation == ((Insurance_Company)obj).Year_of_Foundation;
            else
                return false;
        }
        public override string ToString()
        {
            return base.ToString() + " " + "Рейтинг: " + this.rating.ToString() + "," + "Год основания: " + this.year_of_foundation.ToString();
        }
    }
}
