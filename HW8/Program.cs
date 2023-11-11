using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task2();
        }

        public static void Task2()
        {
            Console.WriteLine("Площадь:");
            double square = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Кол-во людей:");
            int numberOfResidents = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Какой сезон:");
            string season = Console.ReadLine();

            Console.WriteLine("Есть ли льготы (да/нет):");
            string discountInput = Console.ReadLine();
            bool hasDiscount = discountInput.ToLower() == "да";

            KOMMUNALKA calculator = new KOMMUNALKA(square, numberOfResidents, season, hasDiscount);
            calculator.CalculatePayments();
        }

        public static void Task1()
        {
            Indexator array = new Indexator(10);

            for (int i = 0; i < array.arrayLength; i++)
            {
                array[i] = i;
            }

            for (int i = 0; i < array.arrayLength; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        public class Indexator
        {
            private int[] array;
            public int arrayLength { get; set; }

            public Indexator(int length)
            {
                array = new int[length];
                arrayLength = length;
            }

            public int this[int index]
            {
                get
                {
                    if (index < 0 || index >= arrayLength)
                        throw new Exception();
                    return array[index];
                }
                set
                {
                    if (index < 0 || index >= arrayLength)
                        throw new Exception();
                    array[index] = value * value;
                }
            }

        }

        public class KOMMUNALKA
        {
            private double square;
            private int numberOfResidents;
            private string season;
            private bool hasDiscount;

            public KOMMUNALKA(double square, int numberOfResidents, string season, bool hasDiscount)
            {
                this.square = square;
                this.numberOfResidents = numberOfResidents;
                this.season = season;
                this.hasDiscount = hasDiscount;
            }

            public void CalculatePayments()
            {
                double heatingRate = 10.0; 
                double waterRate = 5.0; 
                double gasRate = 15.0; 
                double repairRate = 2.0; 

                double heatingPayment = square * heatingRate;
                double waterPayment = numberOfResidents * waterRate;
                double gasPayment = numberOfResidents * gasRate;
                double repairPayment = square * repairRate;

                if (season.ToLower() == "зима")
                {
                    heatingPayment *= 1.2;
                }

                double totalPayment = heatingPayment + waterPayment + gasPayment + repairPayment;

                double discount = 0.0;
                if (hasDiscount)
                {
                    discount = totalPayment * 0.3;
                }

                Console.WriteLine("Вид платежа\tНачислено\tЛьготная скидка\tИтого");
                Console.WriteLine("Отопление\t" + heatingPayment + "\t" + discount + "\t" + (heatingPayment - discount));
                Console.WriteLine("Вода\t" + waterPayment + "\t0\t" + waterPayment);
                Console.WriteLine("Газ\t" + gasPayment + "\t0\t" + gasPayment);
                Console.WriteLine("Ремонт\t" + repairPayment + "\t0\t" + repairPayment);
                Console.WriteLine("Итог\t" + totalPayment + "\t" + discount + "\t" + (totalPayment - discount));
            }

        }
    }
    
}
