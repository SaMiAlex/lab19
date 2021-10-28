using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab19
{
    class Comp
    {
        public int id { get; set; }
        public string name { get; set; }
        public string proc { get; set; }
        public int procrate { get; set; }
        public int ram { get; set; }
        public int hard { get; set; }
        public int graphics { get; set; }
        public double cost { get; set; }
        public int count { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Comp> listcomp = new List<Comp>()
            {
            new Comp() { id = 1, name = "Noob", proc = "Baikal", procrate = 600, ram = 4, hard = 100, graphics = 512, cost = 100, count = 10 },
            new Comp() { id = 2, name = "Basic", proc = "Elbrus", procrate = 1000, ram = 4, hard = 200, graphics = 1024, cost = 200, count = 10 },
            new Comp() { id = 3, name = "Student", proc = "Xeon", procrate = 1400, ram = 8, hard = 500, graphics = 1024, cost = 400, count = 20 },
            new Comp() { id = 4, name = "Business", proc = "AMD", procrate = 1600, ram = 8, hard = 1000, graphics = 2048, cost = 800, count = 30 },
            new Comp() { id = 5, name = "Premium", proc = "Intel", procrate = 2000, ram = 16, hard = 2000, graphics = 4096, cost = 1200, count = 5 },
            new Comp() { id = 6, name = "Elite", proc = "AMD", procrate = 3000, ram = 32, hard = 2000, graphics = 8192, cost = 2000, count = 1 }
            };

            #region //выборка по процессору
            Console.WriteLine("Введите название процессора");
            string proctype = Console.ReadLine();
            List<Comp> comps1 = listcomp
           .Where(d => d.proc == proctype)
           .ToList();
            Console.WriteLine($"Процессор {proctype} есть в моделях");
            foreach (Comp d in comps1)
            {
                Console.WriteLine($"{d.id} {d.name}");
            }
            if (comps1.Count == 0)
            {
                Console.WriteLine("Некорректное название процессора");
            }
            #endregion
            Console.WriteLine();
            #region //выборка по объему ОЗУ
            Console.WriteLine("Объем ОЗУ не меньше");
            int ramuse = Convert.ToInt32(Console.ReadLine());
            List<Comp> comps2 = listcomp
           .Where(d => d.ram >= ramuse)
           .ToList();
            Console.WriteLine($"Список компьютеров с ОЗУ не менее {ramuse}");
            foreach (Comp d in comps2)
            {
                Console.WriteLine($"{d.id} {d.name}");
            }
            if (comps2.Count == 0)
            {
                Console.WriteLine("Некорректное значение");
            }
            #endregion
            Console.WriteLine();
            #region //сортировка по стоимости
            var comps3 = listcomp
           .OrderBy(d => d.cost);

            Console.WriteLine("Сортировка по увеличению стоимости");
            foreach (Comp d in comps3)
            {
                Console.WriteLine($"{d.id} {d.name}");
            }
            #endregion
            Console.WriteLine();
            #region //группировка по типу процессора
            var GroupByProc = listcomp.GroupBy(p => p.proc);
            foreach (var group in GroupByProc)
            {
                Console.WriteLine($"Типов компьютеров с процессором {group.Key} - {group.Count()} шт.");
                foreach (var Comp in group)
                {                    
                    Console.WriteLine($"номер - {Comp.id}, название компьютера - {Comp.name}");
                }
                Console.WriteLine("=======================================");
            }
            #endregion
            Console.WriteLine();
            #region //поиск самого дорогого и самого бюджетного компьютера
            var comps5 = listcomp
                .OrderBy(d => d.cost);
            var mincost = comps5.First();
            var maxcost = comps5.Last();
            Console.WriteLine($"Самый дешевый компьютер - {mincost.name} стоимостью {mincost.cost}у.е.\nСамый дорогой компьютер - {maxcost.name} стоимостью {maxcost.cost}у.е.");
            #endregion
            Console.WriteLine();
            #region //поиск компа в наличии более 30шт
            var num = listcomp
                .Where(n => n.count >= 30)
                .Count();
            if (num > 0)
            {
                Console.WriteLine("Есть позиции с количеством не менее 30шт");
            }
            else
            {
                Console.WriteLine("Нет позиций с количеством не менее 30шт");
            }
            #endregion

            Console.ReadKey();
        }
    }

}

