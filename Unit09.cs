using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Unit09
    {
        private string str;
        private string[] words;
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
                workworkWithWords();
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
            Console.WriteLine("Пользователь вводит с клавитуры строку.\n" +
                              "Программа:\n" +
                              "-Определяет количество слов в строке  \n" +
                              "-Находит самое длинное слово и выводит его на экран; \n" +
                              "-Меняет местами первое и последнее слово в строке, затем выводит текст на экран.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Решение:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Input posutive number
        private void input()
        {
            Console.Write("Введите строку: ");
            str = Console.ReadLine();
            Console.WriteLine($"Введенная строка: {str}");
        }

        //Quantity words in string
        private void searchQuantity()
        {
            //Quantity words in string
            words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Количество слов в строке: {words.Length}");
        }

        //Search long word
        private void searchMostLongWord()
        {
            string longWord = "";
            //Long word
            foreach (string strTemp in words)
                if (strTemp.Length > longWord.Length)
                    longWord = strTemp;
            Console.WriteLine($"Самое большое слово: {longWord}");
        }

        //Swapped words
        private void swappedWords()
        {
            //Swapped words
            string strSwappedTemp;
            Console.Write("Изменненная строка: ");
            strSwappedTemp = words[0];
            words[0] = words[words.Length - 1];
            words[words.Length - 1] = strSwappedTemp;
            foreach (string singleWord in words)
                Console.Write("{0} ", singleWord);
            Console.WriteLine();
        }

        private void workworkWithWords()
        {
            input();
            searchQuantity();
            searchMostLongWord();
            swappedWords();
        }
    }
}
