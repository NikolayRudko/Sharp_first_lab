using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Unit04
    {
        private int numberN;
        private long factorialN;
        private ConsoleKeyInfo selectedKey;

        //Основная функция метода
        public void TaskSolution()
        {
            var nr = new Menu();
            //вызов информации о задании
            HelpMenu();
            //отработка основного пункта меню
            try
            {
                //вызов метода решения
                printData();
                Console.WriteLine("\nПовторить? (y/n)");
                //чтение нажатой кнопки 
                selectedKey = Console.ReadKey();
                //если это Y тогда прграма выполниться еще раз
                if (selectedKey.Key == ConsoleKey.Y)
                    TaskSolution();
                else
                    nr.SwitchMenu();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ОШИБКА!");
                Console.ReadKey();
                TaskSolution();
            }
        }

        //Меню вывода информации
        private void HelpMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Условие:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Пользователь вводит с клавиатуры число для расчета факториала\n" +
                              "Программа расчитывает факториал.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Решение:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Ввод чисела с клавиатулы:
        private int inputNumber(string str1, string str2)
        {
            int number;
            Console.Write(str1);
            string inputStr = Console.ReadLine();
            if (!Int32.TryParse(inputStr, out number))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА ВВОДА ДАННЫХ!");
                Console.ForegroundColor = ConsoleColor.White;
                return inputNumber(str1, str2);
            }
            else if (number>14)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА! СЛИШКОМ БОЛЬШОЕ ЧИСЛО!");
                Console.ForegroundColor = ConsoleColor.White;
                return inputNumber(str1, str2);
            }
            else
            {
                Console.WriteLine($"{str2} = {number}\n");
            }
            return number;
        }

        //расчет факториала
        private long fact(int N)
        {
            if (N < 0)                      // если пользователь ввел отрицательное число
                return 0;                   // возвращаем ноль
            if (N == 0)                     // если пользователь ввел ноль,
                return 1;                   // возвращаем факториал от нуля - не удивляетесь, но это 1 =)
            else                            // Во всех остальных случаях
                return N * fact(N - 1);     // делаем рекурсию.
        }

        //вывод результата
        private void printData()
        {
            numberN = inputNumber("Ведите число для расчета факториала: ", "Число для расчета");
            factorialN = fact(numberN);
            Console.WriteLine($"Факториал числа {numberN}, равен {factorialN}");
        }
    }
}
