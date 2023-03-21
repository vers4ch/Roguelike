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
            int height = 25;
            int width = 100;
            char[,] world = new char[height, width];
            Random rnd = new Random();

            //draw WORLD with
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //border
                    if (x == 0 && y>0 && y < height-1|| x == width-1 && y > 0 && y < height-1)
                        world[y, x] = '┃';
                    else if (y == 0 && x > 0 && x < width-1 || y == height-1 && x > 0 && x < width-1)
                        world[y, x] = '━';
                    else if(x == 0 && y == 0)
                        world[y, x] = '┏';
                    else if (x == width-1 && y == height-1)
                        world[y, x] = '┛';
                    else if (x == 0 && y == height-1)
                        world[y, x] = '┗';
                    else if (x == width-1 && y == 0)
                        world[y, x] = '┓';
                    //bg
                    else
                    {
                        world[y, x] = ' ';
                    }
                }
            }

            int cordX, cordY, Nroom;

            Nroom = rnd.Next(height*width/50, height*width/45);
            for (int i = 0; i < Nroom; i++)
            {
                cordX = rnd.Next(1, 94);
                cordY = rnd.Next(1, 21);

                for (int j = 0; j < 4; j++)
                {
                    for (int f = 0; f < 6; f++)
                    {
                        world[cordY + j, cordX + f] = '▓';
                    }
                }
            }

            int item = rnd.Next(5, 10);
            for(int o = 0; o < item; o++)
            {
                cordX = rnd.Next(1, width-1);
                cordY = rnd.Next(1, height-1);
                if (world[cordY, cordX] == '#' || world[cordY, cordX] == '@')
                    item++;
                else
                    world[cordY, cordX] = '❤';
            }
            
            //always clean
            int jj = height/8, ff = width/7; 
            for (int j = 0; j < 3; j++)
            {
                for (int f = 0; f < 15; f++)
                {
                    //   height  width
                    world[height/2 + j, 15 + f] = ' ';
                    world[height-jj - 1 + j, 84 + f] = ' ';
                    world[1 + j, 1 + f] = ' ';
                    world[1 + f, 15] = ' ';
                    world[height/2 + j, width/2+f] = ' ';
                    // world[8 + f, 30] = ' ';
                    // world[20, 30+f] = ' ';
                    // world[20-f, 45] = ' ';
                    // world[18, 45+f] = ' ';
                    // world[18-f, 60] = ' ';
                    // world[7, 60+f] = ' ';
                    // world[7 - j, 75 + f] = ' ';
                    // world[15 + j, 84 + f] = ' ';
                    // world[7+f, 87] = ' ';
                }
            }

            //printing world
            for (int i=0; i<height; i++)
            {
                for(int t = 0; t < width; t++)
                {
                    Console.Write(world[i, t]);
                }
                Console.WriteLine();
            }
        }
    }
}
