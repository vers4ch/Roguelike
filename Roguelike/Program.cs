//  main.cs
//  Roguelike
//  Created by Versach on 19.03.2023.
//
using System;
//jjjjjj
namespace Program
{
    public static class Map
    {
        public static void Gener()
        {
            int height = 45; //min = 15
            int width = 170; //min = 50
            
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

            int cordX, cordY, Nroom, hsq, wsq;

            //!!
            Nroom = rnd.Next(height*width/50, height*width/45);
            for (int i = 0; i < Nroom; i++)
            {
                cordX = rnd.Next(1, width-7);
                cordY = rnd.Next(2, height-height/6);
                
                hsq = rnd.Next(height/7, height/6);///!!!!
                wsq = rnd.Next(width/21, width/11);

                for (int j = 0; j < hsq-3; j++)//7, 10
                {
                    for (int f = 0; f < wsq-5; f++)//17, 20
                    {
                        // world[cordY + j, cordX + f] = '▓';
                        world[cordY + j, cordX + f] = '#';
                    }
                }
            }

            //always clean
            int jj = height/8, ff = width/7; 
            for (int j = 0; j < height/6; j++)
            {
                for (int f = 0; f < width/8; f++)
                {
                    //   height  width
                    world[height/2 + j, width/7 + f] = ' ';
                    world[height-jj - 3 + j, width - width/6 + f] = ' ';//bottom right 
                    world[1 + j, 1 + f] = ' ';
                    world[1 + f, width/7] = ' ';
                    world[height/2 + j, width/2+f] = ' ';
                }
            }
            
            //heart
            int item = rnd.Next(height/5, width/10);
            for(int o = 0; o < item; o++)
            {
                cordX = rnd.Next(1, width-1);
                cordY = rnd.Next(1, height-1);
                if (world[cordY, cordX] == '▓' || world[cordY, cordX] == '@')
                    item++;
                else
                    world[cordY, cordX] = '❤';
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

        // public static void Print()
        // {
        //     //printing world
        //     for (int i=0; i<height; i++)
        //     {
        //         for(int t = 0; t < width; t++)
        //         {
        //             Console.Write(world[i, t]);
        //         }
        //         Console.WriteLine();
        //     }
        // }
    }
    class Program
    {
        static void Main()
        {
            Map.Gener();
        }
    }
}
