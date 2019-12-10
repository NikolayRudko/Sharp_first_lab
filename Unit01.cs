using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Unit01
    {
        private int numberA;
        private int numberB;
        private int numberC;
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
                maxNumber();
                Console.WriteLine("\nПовторить? (y/n)");
                //чтение нажатой кнопки 
                selectedKey = Console.ReadKey();
                //если была нажата Y тогда прграма выполниться еще раз иначе возвращается в основное меню
                if (selectedKey.Key == ConsoleKey.Y)
                    TaskSolution();
                else
                    nr.SwitchMenu();
            }
            catch
            {
                //отработа не предвиденной ошибки
                Console.ForegroundColor = ConsoleColor.Red;     //красный шрифт
                Console.Write("ОШИБКА!");
                Console.ReadKey();
                TaskSolution();                                 //повторный вызов основной функции
            }
        }

        //Меню вывода информации
        private void HelpMenu()
        {
            Console.Clear();                                    
            Console.ForegroundColor = ConsoleColor.Green;                               //Зеленый шрифт
            Console.WriteLine("Условие:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;                               //белый шрифт
            Console.WriteLine("Пользователь вводит с клавиатуры 3 числа A,B,C.\n" +
                              "Программа отпределяет наибольшее из них");
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
            else
            {
                Console.WriteLine($"{str2} = {number}\n");
            }
            return number;
        }

        //Поиск большего числа
        private void maxNumber()
        {
            //Ввод и присваивание значений перменным
            numberA = inputNumber("Введите число А: ", "A");
            numberB = inputNumber("Введите число B: ", "B");
            numberC = inputNumber("Введите число C: ", "C");

            //определение большего числа
            if (numberA > numberB && numberA > numberC)
                Console.WriteLine($"Максимальное число A = {numberA}");
            else if (numberB > numberA && numberB > numberC)
                Console.WriteLine($"Максимальное число B = {numberB}");
            else
                Console.WriteLine($"Максимальное число C = {numberC}");
        }
    }
}
