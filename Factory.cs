using System;

namespace Lab14Var4
{
    public class Factory : Organization, ICloneable
    {
        private string[] employee = new string[7] { "Кузнецов", "Иванов", "Петров", "Ветров", "Подбельский", "Блок", "Понасенков" };
        private int[] stage = new int[7] { 3, 4, 5, 6, 5, 9, 2 };
        private int AgeObj;
        private string city_of_object;
        Factory next;
        Factory pred;
        public Factory() : base()
        {
            AgeObj = 0;
            city_of_object = default;
        }

        public Factory(string name, int number, int AgeObj1, string city_of_obj) : base(name, number)
        {
            AgeObj = AgeObj1;
            City_of_Object = city_of_obj;
        }

        public int AgeObJ
        {
            get { return AgeObj; }
            set
            {
                bool o = Int32.TryParse(Convert.ToString(value), out AgeObj);
                while (!o)
                {
                    Console.WriteLine("Введите целое число");
                    o = Int32.TryParse(Console.ReadLine(), out AgeObj);
                }
            }
        }

        public string City_of_Object
        {
            get { return city_of_object; }
            set
            {
                city_of_object = Convert.ToString(value);
            }
        }
        public Organization BaseFactory
        {
            get { return new Organization(name, number_of_employees); }
        }
        //public override void Show()
        //{
        //    base.Show();
        //    Console.WriteLine($"Возраст объекта: {AgeObj}, Город расположения объекта: {city_of_object}");
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
            string[] City_Object = new string[] { "Пермь", "Москва", "Лондон", "Париж", "Венеция", "Прага", "Амстердам", "Барнаул", "Каир", "Стамбул", "Ничанг", "Далат", "Барселона" };
            Factory f = new Factory(o.Name, o.Number_of_employees, AgeObJ = rnd.Next(1, 50), City_of_Object = City_Object[rnd.Next(0, City_Object.Length - 1)]);
            return f;
        }

        public override object Clone()
        {
            return new Factory { Name = this.Name, Number_of_employees = this.Number_of_employees, City_of_Object = this.City_of_Object, AgeObj = this.AgeObj };
        }

        public override object ClonePoverx()
        {
            return this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if (obj is Organization)
                return base.Equals(obj) && this.AgeObJ == ((Factory)obj).AgeObj && this.City_of_Object == ((Factory)obj).City_of_Object;
            else
                return false;

        }
        public override string ToString()
        {
            return (base.ToString() + " " + "Возраст объекта: " + this.AgeObj.ToString() + "," + "Город расположения объекта: " + this.city_of_object);
        }
        public Organization BaseOrganization
        {
            get
            {
                string[] name1 = new string[7] { "Техкомфорт", "Газпром", "Ваше право", "Рука Фемиды", "Кодекс чести", "Гармония здоровья", "Apple" };
                return new Organization(name1[rnd.Next(0, name1.Length - 1)], rnd.Next(1, 501));
            }
        }
    }
}
