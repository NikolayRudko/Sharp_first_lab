using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Unit03
    {
        private double price;
        private double discountedPrice;
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
                discounted();
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
            Console.WriteLine("Пользователь вводит с клавитары cумму покупки\n" +
                              "Программа выводит сумvу с 3% скидкой, если сумма покупки больше 500 руб., \n" +
                              "выводит сумvу с 3% скидкой,если сумма больше 1000 руб. ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Решение:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Ввод чисела с клавиатулы:
        private double inputNumber(string str1, string str2)
        {
            double number;
            Console.Write(str1);
            string inputStr = Console.ReadLine();
            if (!Double.TryParse(inputStr, out number))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА ВВОДА ДАННЫХ!");
                Console.ForegroundColor = ConsoleColor.White;
                return inputNumber(str1, str2);
            }
            else if (number < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА ВВОДА ДАННЫХ!\n ВВОДИТЕ ТОЛЬКО ПОЛОЖИТЕЛЬНОЕ ЧИСЛО");
                Console.ForegroundColor = ConsoleColor.White;
                return inputNumber(str1, str2);
            }
            else
            {
                Console.WriteLine($"{str2} = {number}\n");
            }
            return number;
        }

        //Расчет цены со скидкой
        private void discounted()
        {
            price = inputNumber("Введите сумму покупки: ", "Сумма покупки");
            if (price < 500)
                discountedPrice = price;                        //Без скидки
            else if (price >= 500 && price < 1000)
                discountedPrice = price * 0.97;                 //3% Скидка
            else
                discountedPrice = price * 0.95;                 //5% Скидка
            Console.WriteLine($"Цена покупки со скидкой = {discountedPrice}");
        }
    }
}
