//  main.cs
//  Roguelike
//  Created by Versach on 19.03.2023.
//
using System;

namespace Program
{
    class Program
    {
        static void Main()
        {
            char c1 = '\u0001';
            char[,] world = new char[25, 100];
            Random rnd = new Random();

            //draw WORLD with
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    //border
                    if (x == 0 && y>0 && y < 24|| x == 99 && y > 0 && y < 24)
                        world[y, x] = '┃';
                    else if (y == 0 && x > 0 && x < 99 || y == 24 && x > 0 && x < 99)
                        world[y, x] = '━';
                    else if(x == 0 && y == 0)
                        world[y, x] = '┏';
                    else if (x == 99 && y == 24)
                        world[y, x] = '┛';
                    else if (x == 0 && y == 24)
                        world[y, x] = '┗';
                    else if (x == 99 && y == 0)
                        world[y, x] = '┓';
                    //bg
                    else
                    {
                        world[y, x] = ' ';
                    }
                }
            }

            int cordX, cordY, Nroom;

            Nroom = rnd.Next(50, 55);
            for (int i = 0; i < Nroom; i++)
            {
                cordX = rnd.Next(1, 94);
                cordY = rnd.Next(1, 21);

                for (int j = 0; j < 4; j++)
                {
                    for (int f = 0; f < 6; f++)
                    {
                        world[cordY + j, cordX + f] = '#';
                    }
                }
            }

            int item = rnd.Next(15, 25);
            for(int o = 0; o < item; o++)
            {
                cordX = rnd.Next(1, 99);
                cordY = rnd.Next(1, 24);
                if (world[cordY, cordX] == '#' || world[cordY, cordX] == '@')
                    item++;
                else
                    world[cordY, cordX] = '❤';
            }



            //always clean
            for (int j = 0; j < 6; j++)
            {
                for (int f = 0; f < 30; f++)
                {
                    world[11 + j, 20 + f] = ' ';
                    world[14 + j, 69 + f] = ' ';
                    world[13, 43 + f] = ' ';
                    world[1 + j, 1 + f] = ' ';
                    world[3 + j, 25] = ' ';
                }
            }

            //printing world
            for (int i=0; i<25; i++)
            {
                for(int t = 0; t < 100; t++)
                {
                    Console.Write(world[i, t]);
                }
                Console.WriteLine();
            }
        }
    }
}
