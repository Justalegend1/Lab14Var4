using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14Var4
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаем элементы иерархии классов
            List<object> CollWithOtherColl = new List<object>();
            Organization Org = new Organization();
            Org = (Organization)Org.Init();
            Org.Name = "Организация";
            Organization SecondOrg = new Organization();
            SecondOrg = (Organization)SecondOrg.Init();
            SecondOrg.Name = "Организация 1";
            Factory Fac = new Factory();
            Factory SecFac = new Factory();
            Fac = (Factory)SecFac.Init();
            SecFac = (Factory)SecFac.Init();
            Fac.Name = "Фабрика";
            SecFac.Name = "Фабрика 1";
            Library Lib = new Library();
            Lib = (Library)Lib.Init();
            Lib.Name = "Библиотека";
            Shipbuilding_company Ship = new Shipbuilding_company();
            Ship = (Shipbuilding_company)Ship.Init();
            Ship.Name = "Кораблестроительная фирма";
            Insurance_Company Ins = new Insurance_Company();
            Ins = (Insurance_Company)Ins.Init();
            Ins.Name = "Страховая компания";
            SortedDictionary<string, Organization> FirstColl = new SortedDictionary<string, Organization>();
            //добавляем элементы в коллекции
            FirstColl.Add(Org.Name, Org);
            FirstColl.Add(SecondOrg.Name, SecondOrg);
            FirstColl.Add(Fac.Name, Fac);
            FirstColl.Add(SecFac.Name, SecFac);
            FirstColl.Add(Lib.Name, Lib);
            FirstColl.Add(Ship.Name, Ship);
            FirstColl.Add(Ins.Name, Ins);
            Queue<Organization> SecondColl = new Queue<Organization>();
            SecondColl.Enqueue(Org);
            SecondColl.Enqueue(SecondOrg);
            SecondColl.Enqueue(Fac);
            SecondColl.Enqueue(SecFac);
            SecondColl.Enqueue(Lib);
            SecondColl.Enqueue(Ship);
            SecondColl.Enqueue(Ins);
            foreach (Organization current in SecondColl)
                current.Show();
            Console.ReadKey();
            //добавляем ссылки на коллекции в коллекцию с коллекциями
            CollWithOtherColl.Add(FirstColl);
            CollWithOtherColl.Add(SecondColl);
            //осуществляем LINQ запросы
            int Max = 300;
            var MaxEmployee = from temp in SecondColl where temp.Number_of_employees > Max select temp.Name;
            foreach (var tepm in MaxEmployee)
                Console.WriteLine($"Больше 300 сотрудников в {tepm}");
            Console.ReadKey();
            //методы расширения
            var MaxEmployee1 = SecondColl.Where(employee => employee.Number_of_employees > Max).Select(employee => employee.Name);
            foreach (var tepm in MaxEmployee1)
                Console.WriteLine($"Больше 300 сотрудников в {tepm}");
            Console.ReadKey();
            //количество объектов, где кол-во сотрудников четное
            var chetn = (from item in SecondColl where (item.Number_of_employees % 2 == 0) select item.Name).Count();
            Console.WriteLine($"Четное кол-во сотрудников в {chetn} организациях");
            Console.ReadKey();
            var chetn1 = SecondColl.Where(employee => employee.Number_of_employees % 2 == 0);
            Console.WriteLine($"Четное кол-во сотрудников в {chetn1.Count()} организациях");
            Console.ReadKey();
            //вторая коллекция
            Console.Clear();
            var Keys = FirstColl.Keys;
            var MaxEmploye = from temp in Keys where FirstColl[temp].Number_of_employees > Max select FirstColl[temp].Name;
            foreach (var tepm in MaxEmployee)
                Console.WriteLine($"Больше 300 сотрудников в {tepm}");
            Console.ReadKey();
            //методы расширения
            var MaxEmploye1 = FirstColl.Where(employee => FirstColl[employee.ToString()].Number_of_employees > Max).Select(employee => FirstColl[employee.ToString()].Name);
            foreach (var tepm in MaxEmployee1)
                Console.WriteLine($"Больше 300 сотрудников в {tepm}");
            Console.ReadKey();
            //количество объектов, где кол-во сотрудников четное
            var Сhetn = (from item in Keys where (FirstColl[item.ToString()].Number_of_employees % 2 == 0) select FirstColl[item.ToString()].Name).Count();
            Console.WriteLine($"Четное кол-во сотрудников в {chetn} организациях");
            Console.ReadKey();
            var Сhetn1 = FirstColl.Where(employee => FirstColl[employee.ToString()].Number_of_employees % 2 == 0);
            Console.WriteLine($"Четное кол-во сотрудников в {chetn1.Count()} организациях");
            Console.ReadKey();
            // агрегирование данных
            var Average = (from item in SecondColl select item.Number_of_employees).Average();
            Console.WriteLine($"Среднее количество сотрудников во всех фирмах {Average}");
            var Average1 = SecondColl.Average(employee => employee.Number_of_employees);
            Console.WriteLine($"Среднее количество сотрудников во всех фирмах {Average1}");
            Console.ReadKey();
            //группировка данных 
            Org.Number_of_employees = 300;
            Fac.Number_of_employees = 300;
            SecFac.Number_of_employees = 300;
            SecondOrg.Number_of_employees = 250;
            Ship.Number_of_employees = 250;
            var GroupByEmpl = from temp in SecondColl group temp by temp.Number_of_employees into g select new { Name = g.Key, Count = g.Count() };
            foreach (var gr in GroupByEmpl)
                Console.WriteLine($"Группировка по кол-ву сотрудников:\n{gr.Name} : {gr.Count}");
            var GroupByEmpl1 = SecondColl.GroupBy(p => p.Number_of_employees).Select(g => new { Name = g.Key, Count = g.Count() });
            foreach (var gr in GroupByEmpl1)
                Console.WriteLine($"Группировка по кол-ву сотрудников:\n{gr.Name} : {gr.Count}");
            var GroupByEmpl2 = from temp in Keys group temp by FirstColl[temp].Number_of_employees into g select new { Name = g.Key, Count = g.Count() };
            foreach (var gr in GroupByEmpl)
                Console.WriteLine($"Группировка по кол-ву сотрудников:\n{gr.Name} : {gr.Count}");
            var GroupByEmpl3 = FirstColl.GroupBy(p =>FirstColl[p.ToString()].Number_of_employees).Select(g => new { Name = g.Key, Count = g.Count() });
            foreach (var gr in GroupByEmpl1)
                Console.WriteLine($"Группировка по кол-ву сотрудников:\n{gr.Name} : {gr.Count}");
            Console.ReadKey();
        }
    }
}
