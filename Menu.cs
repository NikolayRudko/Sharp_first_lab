using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Menu
    {
        private int MenuNumber;             //количество элементов меню
        private int NIterm = 0;             //текущий выбраный пункт 
        private ConsoleKeyInfo NN;          //информация о нажатой клавише

        //header и footer для главного меню
        private string Hearder = "Выберите номер задачи, для решения:";
        private string Footer = "Для выхода из программы нажмите 'Esc'";

        //массив пунктов меню
        string[] MenuItem = new string[]
        {
            "Поиск большего числа из 3-х" ,
            "Определение типа треугольника" ,
            "Расчет покупки со скидкой",
            "Расчет факториала" ,
            "Остаток от деления функции f(x) на функцию g(x)" ,
            "Изменяет все отрицательные элементы одномерного массива на индекс" ,
            "Генерирует матрицу и поворачивает ее на 90 градусов",
            "Определяет количество особых элементов массива",
            "Пользователь вводит с клавитуры строку",
            "Шрифт цезаря"
        };

        //управление меню 
        public void SwitchMenu()
        {
            MenuNumber = MenuItem.Length;       //запоминаем кол-во эл-тов
            PrintMenu();                        //печатаем меню
            NN = Console.ReadKey();             //сохраняем инф-ю о нажатой клавише
            switch (NN.Key)
            {
                case ConsoleKey.Escape:
                    return;
                case ConsoleKey.UpArrow:
                    if (NIterm > 0)
                        NIterm--;
                    else
                        NIterm = --MenuNumber;
                    SwitchMenu();
                    break;
                case ConsoleKey.DownArrow:
                    if (NIterm < MenuNumber - 1)
                        NIterm++;
                    else
                        NIterm = 0;
                    SwitchMenu();
                    break;
                case ConsoleKey.Enter:
                    SwitchTask();
                    break;
                default:
                    SwitchMenu();
                    break;
            }
        }

        //печать меню
        private void PrintMenu()
        {
            Console.Clear();        //очистка консоли
            //печать зеленым цветом
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Hearder}\n");
            //печать серым цветом
            Console.ForegroundColor = ConsoleColor.Gray;
            //перебераем массив пунктов меню
            for (int i = 0; i < MenuNumber; i++)
            {
                if (i == NIterm)
                    Console.ForegroundColor = ConsoleColor.White;   //печать белым цветом
                Console.WriteLine($"{(i + 1).ToString("00")}. {MenuItem[i]}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{Footer}\n");
        }

        //выбор задания для отработки
        private void SwitchTask()
        {
            switch (NIterm)
            {
                case 0:
                    Unit01 unit1 = new Unit01();
                    unit1.TaskSolution();
                    break;
                case 1:
                    Unit02 unit2 = new Unit02();
                    unit2.TaskSolution();
                    break;
                case 2:
                    Unit03 unit3 = new Unit03();
                    unit3.TaskSolution();
                    break;
                case 3:
                    Unit04 unit4 = new Unit04();
                    unit4.TaskSolution();
                    break;
                case 4:
                    Unit05 unit5 = new Unit05();
                    unit5.TaskSolution();
                    break;
                case 5:
                    Unit06 unit6 = new Unit06();
                    unit6.TaskSolution();
                    break;
                case 6:
                    Unit07 unit7 = new Unit07();
                    unit7.TaskSolution();
                    break;
                case 7:
                    Unit08 unit8 = new Unit08();
                    unit8.TaskSolution();
                    break;
                case 8:
                    Unit09 unit9 = new Unit09();
                    unit9.TaskSolution();
                    break;
                case 9:
                    Unit10 unit10 = new Unit10();
                    unit10.TaskSolution();
                    break;
                default:
                    break;
            }
        }
    }
}

