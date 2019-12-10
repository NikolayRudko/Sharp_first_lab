using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Unit07
    {
        private int sizeMatrix;
        private int[,] originMatrix;
        private int[,] rotateMatrix;
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
                rotateOriginMatrix();
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
            Console.WriteLine("Пользователь вводит с клавитары размер массива.\n" +
                              "Программа генерирует матрицу и поворачивает ее на 90 градусов.\n");
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

        //Создание оригинальной матрицы
        private void generateMatrix()
        {
            sizeMatrix = inputNumber("Введите размер маматрицы: ", "размер маматрицы");
            originMatrix = new int[sizeMatrix, sizeMatrix];
            Console.WriteLine("Созданая матрица: ");
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    originMatrix[i, j] = (i + 1) * 10 + j + 1;
                    Console.Write(originMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        //Поворот матрицы
        private void rotateOriginMatrix()
        {
            generateMatrix();
            rotateMatrix = new int[sizeMatrix, sizeMatrix];
            Console.WriteLine("Повернутая матрица: ");
            int k;
            for (int i = 0; i < sizeMatrix; i++)
            {
                //Создание повернутой матрицы
                for (int j = 0; j < sizeMatrix; j++)
                {
                    k = (sizeMatrix - 1) - j;
                    rotateMatrix[i, j] = originMatrix[k, i];
                }
            }
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                    Console.Write(rotateMatrix[i, j] + "\t");
                Console.WriteLine();
            }
        }
    }
}
