using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Unit05
    {
        private double numberX;
        private double remainderDivisionFunctions;
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
                division();
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
            Console.WriteLine("Пользователь вводит с клавитары число\n" +
                              "Программа остаток от деления функции f(x) на функцию g(x).\n" +
                              "f(x) = ln x/(1/cos x+2,7x)\n" +
                              "g(x)=arcsin x + arccos x +(x2)^1/2.");
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
            else if (number <= 0 || number > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА ВВОДА ДАННЫХ!\n ВВОДИТЕ ТОЛЬКО ЧИСЛА В ДИАТАЗОНЕ (0;1]");
                Console.ForegroundColor = ConsoleColor.White;
                return inputNumber(str1, str2);
            }
            else
            {
                Console.WriteLine($"{str2} = {number}\n");
            }
            return number;
        }

        //Расчитывает остатток от деления одной фунции на другую
        private void division()
        {
            numberX = inputNumber("Введите число х для растчета функции: ", "x");
            double resultFunctionF;
            double resultFunctionG;
            resultFunctionF = Math.Log(numberX / (1 / Math.Cos((numberX + 2.7 * numberX) * Math.PI / 180)));    //result g(x)
            Console.WriteLine($"f(x)= {resultFunctionF}");
            resultFunctionG = Math.Asin(numberX) + Math.Acos(numberX) + Math.Sqrt(2 * numberX);                 //result f(x)
            Console.WriteLine($"g(x)= {resultFunctionG}");
            remainderDivisionFunctions = resultFunctionF % resultFunctionG;
            Console.WriteLine($"Остаток от деления f(x)/g(x) = {remainderDivisionFunctions}");
        }
    }
}
