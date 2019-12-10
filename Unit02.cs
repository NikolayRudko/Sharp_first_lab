using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Unit02
    {
        private int sideA;
        private int sideB;
        private int sideC;
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
                triangleType();
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
            Console.WriteLine("Пользователь вводит с клавиатуры являющиеся длинами сторон треугольника A,B,C\n" +
                              "Программа отпределяет тип получегоного треугольника");
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
            else if (number <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА ВВОДА ДАННЫХ!\n ВВОДИТЕ ТОЛЬКО ЧИСЛО БОЛЬШЕ 0");
                Console.ForegroundColor = ConsoleColor.White;
                return inputNumber(str1, str2);
            }

            else
            {
                Console.WriteLine($"{str2} = {number}\n");
            }
            return number;
        }

        //Ввод теугольника
        private void inputTriangle()
        {
            //Ввод и присваивание значений перменным
            sideA = inputNumber("Введите значение стороны A: ", "Сторона A");
            sideB = inputNumber("Введите значение стороны B: ", "Сторона B");
            sideC = inputNumber("Введите значение стороны C: ", "Сторона C");
            if (sideA + sideB < sideC || sideB + sideC < sideA || sideC + sideA < sideB)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА ВВОДА ДАННЫХ!\n СУММА 2-Х СТОРОН ТРЕУГОЛЬНИКАНЕ ДОЛЖНА БЫТЬ БОЛЬШЕ 3-Й");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                inputTriangle();
            }
        }

        //Определение типа теругольника
        private void triangleType()
        {
            inputTriangle();
            //Определение типа треугольника
            if (sideA == sideB && sideA == sideC)
                Console.WriteLine("Этот теугольник равтостороний!");
            else
            {
                if (sideA == sideB || sideB == sideC || sideC == sideA)
                    Console.WriteLine("Этот теугольник равнобеденый!");
                else
                    Console.WriteLine("Этот теугольник разностороний!");
            }
        }
    }
}
