using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Unit08
    {
        private int rows;
        private int colums;
        private int[,] matrix;
        private int[] summRows;
        private int specialElements = 0;
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
                searchSpecialElements();
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
            Console.WriteLine("Пользователь вводит с клавитары размеры матрицы.\n" +
                              "Программа определяет количество особых элементов массива, \n" +
                              "считая его элемент особым, если он больше суммы остальных элементов его столбца.\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Решение:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Ввод целого положительного чисела с клавиатулы:
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

        //Input numbers
        private void inputNumber()
        {
            rows = inputNumber("Ведите количесто строк: ", "количесто строк");
            colums = inputNumber("Ведите количесто столбцов: ", "количесто столбцов");
        }

        //Input posutive number
        private int inputInt(string str)
        {
            int number;
            do
            {
                Console.WriteLine(str);
                number = Convert.ToInt32(Console.ReadLine());
            } while (number < 0);
            return number;
        }

        //generate array
        private void generateMatrix()
        {
            inputNumber();
            matrix = new int[rows, colums];
            Console.WriteLine("Создание матрицы: ");
            // Create an object to generate numbers
            Random rnd = new Random();
            //generate random array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    matrix[i, j] = rnd.Next(0, 10);               // Get a random number (ranging from 0 to 10)
                    Console.Write($"[{i},{j}]= {matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        //Search special elements
        private void searchSpecialElements()
        {
            generateMatrix();
            summRows = new int[rows];
            //line sum calculation
            for (int i = 0; i < rows; i++)
            {
                summRows[i] = 0;
                for (int j = 0; j < colums; j++)
                    summRows[i] += matrix[i, j];
            }
            //Search special elements
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < colums; j++)
                    if (matrix[i, j] > (summRows[i] - matrix[i, j]))
                        specialElements++;
            Console.WriteLine($"Количество специальных элементов: {specialElements}");
        }
    }
}
