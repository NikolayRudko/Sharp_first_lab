using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Unit06
    {
        private int sizeArray;                      //массива
        private int[] numbersArray;                 //массив положительных символов
        private ConsoleKeyInfo selectedKey;         //кнопка повтора выполнения
        private ConsoleKeyInfo typeCreate;          //информация о нажатой клавише

        private int MenuNumber;                     //количество элементов меню
        private int NIterm = 0;                     //текущий выбраный пункт 
        string[] MenuItem = new string[]
            {
              "Создание случайного массива" ,
              "Заполнение массива вручную" ,
            };

        //Основная функция метода
        public void TaskSolution()
        {
            var nr = new Menu();
            //отработка основного пункта меню
            try
            {
                //вызов метода решения
                createMenu();
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Пользователь вводит с клавитары размер массива.\n" +
                              "Элементы массива вводятся с клавиатуры, или задаются случайным образом\n" +
                              "Программа изменяет все отрицательные элементы одномерного массива на индекс,\n " +
                              "занимаемый данным элементом");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            //перебераем массив пунктов меню
            for (int i = 0; i < MenuNumber; i++)
            {
                if (i == NIterm)
                    Console.ForegroundColor = ConsoleColor.White;   //печать белым цветом
                Console.WriteLine($"{i + 1}. {MenuItem[i]}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Решение:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Упавление подменю
        public void createMenu()
        {
            MenuNumber = MenuItem.Length;                   //запоминаем кол-во эл-тов
            HelpMenu();                                     //печатаем меню
            typeCreate = Console.ReadKey();                 //сохраняем инф-ю о нажатой клавише
            //навигагия при помощи клавишь
            switch (typeCreate.Key)
            {
                case ConsoleKey.Escape:
                    TaskSolution();
                    break;
                case ConsoleKey.UpArrow:
                    if (NIterm > 0)
                        NIterm--;
                    else
                        NIterm = --MenuNumber;
                    createMenu();
                    break;
                case ConsoleKey.DownArrow:
                    if (NIterm < MenuNumber - 1)
                        NIterm++;
                    else
                        NIterm = 0;
                    createMenu();
                    break;
                case ConsoleKey.Enter:
                    replacingNegativeItems();
                    break;
                default:
                    createMenu();
                    break;
            }
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
            else
            {
                Console.WriteLine($"{str2} = {number}\n");
            }
            return number;
        }

        //перегрузка
        private int inputNumber(string str1)
        {
            int number;
            Console.WriteLine(str1);
            string inputStr = Console.ReadLine();
            if (!Int32.TryParse(inputStr, out number))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА ВВОДА ДАННЫХ!");
                Console.ForegroundColor = ConsoleColor.White;
                return inputNumber(str1);
            }
            else if (number <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОШИБКА ВВОДА ДАННЫХ!\n ВВОДИТЕ ТОЛЬКО ЧИСЛО БОЛЬШЕ 0");
                Console.ForegroundColor = ConsoleColor.White;
                return inputNumber(str1);
            }
            return number;
        }

        //создание массива
        private void generateArray()
        {
            Console.WriteLine("Сгенерированный массив: ");
            // Создание обьекта генерации случайных чисел
            Random rnd = new Random();
            //Создание массива случайных чисел 
            for (int i = 0; i < sizeArray; i++)
            {
                numbersArray[i] = rnd.Next(-100, 100);
                Console.Write($"[{i}]= {numbersArray[i]}\t");
            }
            Console.WriteLine();
        }

        //создание массива вручную
        private void inputArray()
        {
            Console.WriteLine("ВВодимый массив: ");
            //Ввод массива вчучную
            for (int i = 0; i < sizeArray; i++)
            {
                numbersArray[i] = inputNumber($"[{i}] = ");
                Console.Write($"[{i}]= {numbersArray[i]}\t");
            }
            Console.WriteLine();
        }

        //Replacing negative items
        private void replacingNegativeItems()
        {
            sizeArray = inputNumber("Введите размер массива: ", "размер массива");
            numbersArray = new int[sizeArray];
            switch (NIterm)
            {
                case 0:
                    generateArray();
                    break;
                case 1:
                    inputArray();
                    break;
                default:
                    break;
            }
            Console.WriteLine("Измененный массив: ");
            for (int i = 0; i < sizeArray; i++)
            {
                //Замена отрицательных элемнтов
                if (numbersArray[i] < 0)
                    numbersArray[i] = i;
                Console.Write($"[{i}]= {numbersArray[i]}\t");
            }
        }
    }
}
