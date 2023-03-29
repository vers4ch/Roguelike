//  main.cs
//  Roguelike
//  Created by Versach on 19.03.2023.
//
using System;
using System.ComponentModel.Design;

namespace Program
{
    public static class guess1
    {
        public static void Gener()
        {
            int height = 22; //min = 15
            int width = 80; //min = 50

            string[,] gues = new string[height, width];

            //draw 
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    if (y == 3 && x == 30)
                        gues[y, x] = "You have met the enemy";
                    else if (y == 10 && x == 30)
                        gues[y, x] = "Choose an action";
                    else if (y == 15 && x == 10)
                        gues[y, x] = "a) 'УДАРИТЬ' "; // ИЗМЕНИТЬ НА ПОДХОДЯЩЕЕ
                    else if (y == 15 && x == 20)
                        gues[y, x] = "b) 'УДАРИТЬ' "; // ИЗМЕНИТЬ НА ПОДХОДЯЩЕЕ
                    else if (y == 15 && x == 30)
                        gues[y, x] = "c) 'УДАРИТЬ' "; // ИЗМЕНИТЬ НА ПОДХОДЯЩЕЕ
                    else if ((x == 0 && y > 0 && y < height - 1 || x == width - 1 && y > 0 && y < height - 1))
                        gues[y, x] = "┃";
                    else if ((y == 0 && x > 0 && x < width - 1 || y == height - 1 && x > 0 && x < width - 1))
                        gues[y, x] = "━";
                    else if (x == 0 && y == 0)
                        gues[y, x] = "┏";
                    else if (x == width - 1 && y == height - 1)
                        gues[y, x] = "┛";
                    else if (x == 0 && y == height - 1)
                        gues[y, x] = "┗";
                    else if (x == width - 1 && y == 0)
                        gues[y, x] = "┓";
                    //bg

                    else
                    {
                        gues[y, x] = " ";

                    }
                }
            }
            


            //printing 
            for (int i = 0; i < height; i++)
            {
                for (int t = 0; t < width; t++)
                {
                    Console.Write(gues[i, t]);
                }
                Console.WriteLine();
            }
            string one = Console.ReadLine();    // ДАЛЬШЕ ЕСЛИ ИГРОК ВЫБРАЛ А или Б или С , то сносится столько-то урона
                                                // НАВЕРНО НЕ СТОИТ ИСПОЛЬЗОВАТЬ ReadKey, чтоб игрок случайно не ошибся с выбором
        }

    }
    class Program
    {
        static void Main()
        {
            guess1.Gener();
        }
    }
}