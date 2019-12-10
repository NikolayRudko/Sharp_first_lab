using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Unit10
    {
        //private int selectEncryption;       //Choice of encryption or decryption
        private string text;                //Введенная строка
        private string encryptionText;      //Шифрованная строка
        private int shift = 3;              //Смешение

        //Массив из русского алфавита 
        private char[] books = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й',
                                 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
                                 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я',
                                 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
                                 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
                                 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'};
        private char spase = ' ';

        #region Menu Out
        private ConsoleKeyInfo typeCreate;          //информация о нажатой клавише
        private ConsoleKeyInfo selectedKey;         //кнопка повтора выполнения
        private int MenuNumber;                     //количество элементов меню
        private int NIterm = 0;                     //текущий выбраный пункт 
        string[] MenuItem = new string[]
            {
              "получить шифровку" ,
              "получить источник" ,
            };
        #endregion
        
        //Оснвная функция
        public void TaskSolution()
        {
            var nr = new Menu();
            HelpMenu();
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
            Console.WriteLine("Пользователь вводит с клавитары строку.\n" +
                              "Программа выдает либо исходный либо шифрованый текст.\n " );
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Решение:");
            Console.ForegroundColor = ConsoleColor.White;
            inputText();
        }

        private void printMenu()
        { //перебераем массив пунктов меню
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < MenuNumber; i++)
            {
                if (i == NIterm)
                    Console.ForegroundColor = ConsoleColor.White;   //печать белым цветом
                Console.WriteLine($"{i + 1}. {MenuItem[i]}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Решение:");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void createMenu()
        {
            MenuNumber = MenuItem.Length;       //запоминаем кол-во эл-тов
            printMenu();
            typeCreate = Console.ReadKey();             //сохраняем инф-ю о нажатой клавише
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
                    workText();
                    break;
                default:
                    createMenu();
                    break;
            }
        }

        //enter text
        private void inputText()
        {
            //индикатор наличия неправильного символа
            bool triger = true;
            //зацикленный ввод строки пока не булет введена правильная строка 
            //содержащая только русские буквы или пробел
            do
            {
                //индикатор наличия неправильного символа имеет начальное значение положительное
                triger = true;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Ввелите текст, используйте только символы:\n" +
                                  "А-Я, а-я или \"пробел\"\n");
                Console.ForegroundColor = ConsoleColor.White;
                //считывание строки из консоли
                text = Console.ReadLine();
                //проверка введенного текста на помтороние символы:
                //в первом цикле мы проверяем каждый символ ввеленной строки 
                for (int i = 0; i < text.Length; i++)
                {
                    //если индикатор наличия неправильного символа false тогда цикл прекращается
                    //как следствие будет цикл while будет повторен
                    if (!triger)
                    {
                        //вывод сообщения об ошибке
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неизвестный символ - ввелите символ заново!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else
                    {
                        //проверка каждого символа из строки с символом из массива разрешенных символов
                        foreach (char symbol in books)
                        {
                            //как только символ совпалает с символом из массива разрешенных символов
                            //индикатор наличия неправильного символа приобретает значение true 
                            //начинается проверка следующего символа
                            if (text[i] == symbol || text[i] == spase)
                            {
                                triger = true;
                                break;
                            }
                            //если за весь цикл индикатор наличия неправильного символа остался false 
                            //тогда как следствие  цикл while будет будет повторен
                            else
                            {
                                triger = false;
                            }
                        }
                    }
                }
            } while (!triger);
        }

        private void encryption()
        {
            
            //проход по каждому символу исходной строки
            for (int i = 0; i < text.Length; i++)
            {
                //сравниваем с кажым символом из массива разрешенных символов
                for (int j = 0; j < books.Length; j++)
                {
                    //если знак пробел
                    if (text[i] == spase)
                    {
                        encryptionText = encryptionText + spase;
                        break;
                    }
                    //для маленьких букв
                    if (j < books.Length / 2)
                    {
                        if (text[i] == books[j] && j < books.Length / 2 - shift)
                        {
                            encryptionText = encryptionText + books[j + shift];
                            break;
                        }
                        if (text[i] == books[j] && j >= books.Length / 2 - shift)
                        {
                            encryptionText = encryptionText + books[(j % (books.Length / 2 - shift))];
                            break;
                        }
                    }
                    else
                    {
                        if (text[i] == books[j] && j < (books.Length - shift))
                        {
                            encryptionText = encryptionText + books[j + shift];
                            break;
                        }

                        if (text[i] == books[j] && j >= (books.Length - shift))
                        {
                            encryptionText = encryptionText + books[(j % (books.Length - 1 - shift)) + (books.Length - 1) / 2];
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"Зашифрованый текст = {encryptionText}");
        }


        private void workText() {
            //ввод текста 
        
            switch (NIterm)
            {
                case 0:
                    encryption();
                    break;
                case 1:
                    Console.WriteLine(text);
                    break;
                default:
                    break;
            }
        }
    }
}
