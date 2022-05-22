using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarOdev
{
    internal class Program
    {
        public static int counter = 0;
        static void Main(string[] args)
        {
            Console.Write("İsminiz: ");
            string name = Console.ReadLine();
            Console.Write("Soy isminiz: ");
            string surname = Console.ReadLine();
            Console.Write("Doğduğunuz ay: ");
            int month = int.Parse(Console.ReadLine());

            Dice zar = new Dice(name,surname,month); 

            zar.roll();
            zar.showNumbers();
            zar.calculatePoints();


            Console.ReadKey();
        }

        class Dice
        {
            private string numbers = "";
            private int point = 0;
            private string name;
            private string surname;
            private int dateMonth;
            Random random = new Random();

            public Dice(string name, string surname, int date)
            {
                this.name = name;
                this.surname = surname;
                this.dateMonth = date;
            }
            public void roll()
            {
                int rolled;
                int i = 0;

                while (i < 10)
                {
                    rolled = random.Next(1, 7);
                    numbers = numbers  + rolled.ToString() + ' ';
                    if (rolled == 1)
                    {
                        point = point + 100;
                        i++;
                    }
                    else if (rolled == 6)
                    {
                        point = point - 75;
                        i++;
                    }
                }
            }

            public void showNumbers()
            {
                numbers = numbers.Trim();
                var numbersAll = numbers.Split(' ').Select(Int32.Parse).ToArray();
                for(int i = 0; i< numbersAll.Length; i++)
                {
                    Console.WriteLine("{0}. atışta gelen sayı: {1}",(i+1), (numbersAll[i]));
                }
            }

            public void calculatePoints()
            {
                if (name.Length > surname.Length)
                {
                    point= point + 50;
                }
                else if (name.Length == surname.Length)
                {
                    point = point + 25;
                }
                else if (name.Length< surname.Length)
                {
                    point = point - 10;
                }

                if (dateMonth <= 6)
                {
                    point = point + 30;
                }
                else
                {
                    point = point - 20;
                }

                if (point >= 500)
                {
                    Console.WriteLine("KAZANDINIZ! --- Puanınız: {0}",point);
                }
                else
                {
                    Console.WriteLine("KAYBETTİNİZ!--- Puanınız: {0}", point);
                }
            }
        }
    }
}
