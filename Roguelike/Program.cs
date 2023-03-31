//  main.cs
//  Roguelike
//  Created by Versach on 19.03.2023.
//
using System;
using System.ComponentModel.Design;
using System.Threading;

namespace Program
{
    public static class Map
    {
        public static void Rand(char[,] world)
        {
            Console.CursorVisible = false;
            int height = world.GetLength(0); //min = 15
            int width = world.GetLength(1); //min = 50
            Random rnd = new Random();

            //draw WORLD with
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //border
                    if (x == 0 && y > 0 && y < height - 1 || x == width - 1 && y > 0 && y < height - 1)
                        world[y, x] = '┃';
                    else if (y == 0 && x > 0 && x < width - 1 || y == height - 1 && x > 0 && x < width - 1)
                        world[y, x] = '━';
                    else if (x == 0 && y == 0)
                        world[y, x] = '┏';
                    else if (x == width - 1 && y == height - 1)
                        world[y, x] = '┛';
                    else if (x == 0 && y == height - 1)
                        world[y, x] = '┗';
                    else if (x == width - 1 && y == 0)
                        world[y, x] = '┓';
                    //bg
                    else
                    {
                        world[y, x] = ' ';
                    }
                }
            }

            int cordX, cordY, Nroom, hsq, wsq;

            //sq
            Nroom = rnd.Next(height * width / 50, height * width / 45);
            for (int i = 0; i < Nroom; i++)
            {
                cordX = rnd.Next(1, width - 8);
                cordY = rnd.Next(2, height - height / 6 + 2);

                hsq = rnd.Next(height / 7, height / 6);///!!!!
                wsq = rnd.Next(width / 21, width / 11);

                for (int j = 0; j < hsq - 3; j++)//7, 10
                {
                    for (int f = 0; f < wsq - 5; f++)//17, 20
                    {
                        world[cordY + j, cordX + f] = '#';
                    }
                }
            }

            //always clean
            int jj = height / 8, ff = width / 7;
            for (int j = 0; j < height / 6; j++)
            {
                for (int f = 0; f < width / 8; f++)
                {
                    //   height  width
                    world[height / 2 + j, width / 7 + f] = ' ';
                    world[height - jj - 3 + j, width - width / 6 + f] = ' ';//bottom right 
                    world[1 + j, 1 + f] = ' ';
                    world[1 + f, width / 7] = ' ';
                    world[height / 2 + j, width / 2 + f] = ' ';
                    world[height-1, width-4] = '+';
                }
            }

            //heart
            int item = rnd.Next(height / 5, width / 10);
            for (int o = 0; o < item; o++)
            {
                cordX = rnd.Next(1, width - 1);
                cordY = rnd.Next(1, height - 1);
                if (world[cordY, cordX] == '@' || world[cordY, cordX] == '#')
                    item++;
                else
                    world[cordY, cordX] = '❤';
            }
            //enemy
            int pp = rnd.Next(height / 3, width / 5);
            for (int o = 0; o < pp; o++)
            {
                cordX = rnd.Next(1, width - 1);
                cordY = rnd.Next(1, height - 1);
                if (world[cordY, cordX] == '@' || world[cordY, cordX] == '❤' || world[cordY, cordX] == '#')
                    pp++;
                else
                {
                    world[cordY, cordX] = '@';
                }
            }
            int money = rnd.Next(7, 12);
            for (int o = 0; o < money; o++)
            {
                cordX = rnd.Next(1, width - 1);
                cordY = rnd.Next(1, height - 1);
                if (world[cordY, cordX] == '@' || world[cordY, cordX] == '#' || world[cordY, cordX] == '@' || world[cordY, cordX] == '$')
                    item++;
                else
                    world[cordY, cordX] = '$';
            }
            
        }
    }
    public static class startGame
    {
        public static void start()
        {
            Console.Clear();
            Console.WriteLine("\nChoice:\n1.Play\n2.Exit");
            int number;
            number = Convert.ToInt32(Console.ReadLine());
            if (number == 1)
            {
                Console.Clear();
            }
            if (number == 2)
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }
    }

    public class Igor
    {
        public string name;
        public static int _Health = 100;
        public static int _Gold = 0;

        public Igor(string name, int Health)
        {
            this.name = name;
            _Health = Health;
        }

        public  void PrintPerson()
        {
            Console.WriteLine($"{name} , {_Health}HP");
        }
        public static class ChoicePerson
        {
            public static void Person()
            {
                Igor a1 = new Igor("1 - Игорь", 100);
                a1.PrintPerson();
                Igor a2 = new Igor("2 - Рома", 100);
                a2.PrintPerson();
                int choice = 0;

                while (choice != 1 && choice != 2)
                {
                    Console.Write("\nChoice your person: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }

                if (choice == 1)
                {
                    Console.WriteLine("\nYou choice is Person number 1\n");
                }

                if (choice == 2)
                {
                    Console.WriteLine("\nYour choice is Person number 2\n");
                }

                Thread.Sleep(500);
                int number1 = 0;
                while (number1 != 3)
                {
                    Console.WriteLine("If you are ready push number 3\n");
                    number1 = Convert.ToInt32(Console.ReadLine());
                }

                if (number1 == 3)
                {
                    Console.Clear();
                    char[] load = new char[52] { '[', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', ']' };
                    for (int i = 0; i < 50; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                        if (i % 2 == 0)
                            Console.WriteLine("\t\t\t\t\t\t                       Loading..\n");
                        else
                            Console.WriteLine("\t\t\t\t\t\t                       Loading...\n");
                        Console.WriteLine($"\t\t\t\t\t\t                         {i * 2 + 2}%");
                        load[i + 1] = '#';
                        Console.Write("\t\t\t\t\t\t");
                        for (int o = 0; o < 52; o++)
                        {
                            Console.Write(load[o]);
                        }

                        Thread.Sleep(75);
                    }
                    Console.Clear();
                }
            }
        }

        public static class Move
        {
            public static void Moves(char[,] world)
            {
                char[,] worldNew = new char[world.GetLength(0), world.GetLength(1)];
                // string smile = "♕";
                char smile = '♕';
                char hearts = '❤';
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                int userX = 8;
                int userY = 5;
                char[] heart = new char[1];
                ///writing NEW_SECOND_ARRAY
                for (int o = 0; o < world.GetLength(0); o++)
                {
                    for (int h = 0; h < world.GetLength(1); h++)
                    {
                        worldNew[o, h] = 'l';
                    }
                }

                while (true)
                {
                    if (_Health < 1)
                    {
                        //Console.Clear();
                        Console.WriteLine("\n\n\n\t\t\tYou die!! \n\n\n\t\t\ta)Exit         b)Restart");
                        string ex = Console.ReadLine();

                        switch (ex)
                        {
                            case "a":
                                return;
                            case "b":
                                Console.Clear();
                                Map.Rand(world);
                                _Health = 100;
                                _Gold = 0;
                                break;
                        }
                    }
                    
                    for (int i = 0; i < world.GetLength(0); i++)
                    {
                        for (int j = 0; j < world.GetLength(1); j++)
                        {
                            
                            Console.SetCursorPosition(j, i);
                            
                            if (world[i, j] == '❤' && world[i, j] != worldNew[i, j])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] == '$'&& world[i, j] != worldNew[i, j])
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] == '@'&& world[i, j] != worldNew[i, j])
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] == '#'&& world[i, j] != worldNew[i, j])
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if(world[i, j] != worldNew[i, j])
                            {
                                Console.Write(world[i, j]);
                            }
                            else if(worldNew[i, j] == smile)
                                Console.Write(' ');
                        }

                        Console.WriteLine();
                    }
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"HP: {_Health}     ");
                    Console.ResetColor();
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Gold: {_Gold}");
                    Console.ResetColor();

                    Console.SetCursorPosition(1, 1);
                    for (int k = 0; k < heart.Length; k++)
                    {
                        Console.Write(heart[k] + " ");
                    }

                    Console.SetCursorPosition(userX, userY);
                    world[userY, userX] = smile;
                    Console.Write(smile);
                    ConsoleKeyInfo moveKey = Console.ReadKey();
                    switch (moveKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (world[userY - 1, userX] != '#' && world[userY - 1, userX] != '┃' &&
                                world[userY - 1, userX] != '━' && world[userY - 1, userX] != '┏' &&
                                world[userY - 1, userX] != '┛' && world[userY - 1, userX] != '┗' &&
                                world[userY - 1, userX] != '┓')
                            {
                                userY--;
                            }

                            break;
                        case ConsoleKey.DownArrow:
                            if (world[userY + 1, userX] != '#' && world[userY + 1, userX] != '┃' &&
                                world[userY + 1, userX] != '━' && world[userY + 1, userX] != '┏' &&
                                world[userY + 1, userX] != '┛' && world[userY + 1, userX] != '┗' &&
                                world[userY + 1, userX] != '┓')
                            {
                                userY++;
                            }

                            break;
                        case ConsoleKey.LeftArrow:
                            if (world[userY, userX - 1] != '#' && world[userY, userX - 1] != '┃' &&
                                world[userY, userX - 1] != '━' && world[userY, userX - 1] != '┏' &&
                                world[userY, userX - 1] != '┛' && world[userY, userX - 1] != '┗' &&
                                world[userY, userX - 1] != '┓')
                            {
                                userX--;
                            }

                            break;
                        case ConsoleKey.RightArrow:
                            if (world[userY, userX + 1] != '#' && world[userY, userX + 1] != '┃' &&
                                world[userY, userX + 1] != '━' && world[userY, userX + 1] != '┏' &&
                                world[userY, userX + 1] != '┛' && world[userY, userX + 1] != '┗' &&
                                world[userY, userX + 1] != '┓')
                            {
                                userX++;
                            }

                            break;
                    }

                    if (world[userY, userX] == '$')
                    {
                        _Gold++;
                        world[userY, userX] = ' ';
                    }

                    if (world[userY, userX] == '@')
                    {
                        world[userY, userX] = ' ';
                        Guess.Gener(world, userY, userX);
                        // Console.Clear();
                    }
                    if (world[userY+1, userX] == '+')
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n\t\t\t\tУРОВЕНЬ ПРОЙДЕН!");
                        return;
                    }
                    
                    if (world[userY, userX] == hearts)
                    {
                        world[userY, userX] = ' ';
                        _Health += 25;
                    }
                    ///writing NEW_SECOND_ARRAY
                    for (int o = 0; o < world.GetLength(0); o++)
                    {
                        for (int h = 0; h < world.GetLength(1); h++)
                        {
                            worldNew[o, h] = world[o, h];
                        }
                    }
                }
            }
            public static class Guess
            {
                public static void Gener(char[,] world, int cordY, int cordX)
                {
                    Console.Clear();
                    int height = 22; //min = 15
                    int width = 80; //min = 50
                    string[,] gues = new string[height, width];
                    //draw
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            string text1 = "You have met the enemy";
                            string text2 = "Choose an action";
                            string text3 = "a) 'Ударить'";
                            string text4 = "b) 'Убить'";
                            string text5 = "c) 'Отступить'";

                            if (y == 3 && x == width / 2 - text1.Length / 2)
                                gues[y, x] = text1;
                            else if (y == 10 && x == width / 2 - text2.Length / 2)
                                gues[y, x] = text2;
                            else if (y == 15 && x == 10)
                                gues[y, x] = text3;
                            else if (y == 15 && x == 20)
                                gues[y, x] = text4;
                            else if (y == 15 && x == 30)
                                gues[y, x] = text5;
                            else if (x == width - 1 && y > 0 && y < height - 1 && y == 3)
                                gues[y, x - text1.Length + 1] = "┃";
                            else if (x == width - 1 && y > 0 && y < height - 1 && y == 10)
                                gues[y, x - text2.Length + 1] = "┃";
                            else if (x == width - 1 && y > 0 && y < height - 1 && y == 15)
                                gues[y, x - (text3.Length + text4.Length + text5.Length - 3)] = "┃";
                            else if (x == 0 && y > 0 && y < height - 1 || x == width - 1 && y > 0 && y < height - 1 && y != 3 && y != 10 && y != 15)
                                gues[y, x] = "┃";
                            else if (y == 0 && x > 0 && x < width - 1 || y == height - 1 && x > 0 && x < width - 1)
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
                    
                    _Health -= 25;

                    //printing
                    for (int i = 0; i < height; i++)
                    {
                        for (int t = 0; t < width; t++)
                        {
                            Console.Write(gues[i, t]);
                        }
                        Console.WriteLine();
                    } 
                    
                    string press = Console.ReadLine();
                    
                    if (press == "c" || press == "C")
                    {
                        world[cordY, cordX] = '@';
                    }
                    
                    Console.Clear();
                    
                    for (int i = 0; i < world.GetLength(0); i++)
                    {
                        for (int j = 0; j < world.GetLength(1); j++)
                        {
                            
                            Console.SetCursorPosition(j, i);
                            
                            if (world[i, j] == '❤')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] == '$')
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] == '@')
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] == '#')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(world[i, j]);
                            }
                        }

                        Console.WriteLine();
                    }
                }

            }
            internal class Program
            {
                public static void Main(string[] args)
                {
                    while (true)
                    {
                        char[,] world = new char[45, 170];
                        startGame.start();
                        ChoicePerson.Person();
                        Map.Rand(world);
                        Moves(world);
                        Console.WriteLine("\n\n\n\t\tНажмите <ENTER>, чтобы продолжить. <Q>, чтобы выйти.");
                        ConsoleKeyInfo exit = Console.ReadKey();
                        switch (exit.Key)
                        {
                            case ConsoleKey.Q:
                                Console.Clear();
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}