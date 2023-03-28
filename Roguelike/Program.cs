//  main.cs
//  Roguelike
//  Created by Versach on 19.03.2023.
//
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    public static class startGame
    {
        public static void start()
        {
            Console.WriteLine(
                "                                             1.Play\n\n                                             2.Exit");
            int number = 0;
            Console.WriteLine("                                             choice number");
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

    public class Person
    {
        public string name;

        public Person(string name)
        {
            this.name = name;
        }

        public virtual void PrintPerson()
        {
            Console.WriteLine(this.name);
        }

        public class Igor : Person
        {
            public string skills;

            public Igor(string name, string skills) : base(name)
            {
                this.skills = skills;
            }

            public override void PrintPerson()
            {
                Console.WriteLine($"{name},{skills}");
            }
        }

        public static class ChoicePerson
        {
            public static void Person()
            {
                Igor a1 = new Igor("                                            1 - Игорь", "смертельный вопрос\n");
                a1.PrintPerson();
                Igor a2 = new Igor("                                            2 - Игорь", "супер броня\n");
                a2.PrintPerson();
                int choice = 0;

                while (choice != 1 && choice != 2)
                {
                    Console.WriteLine("                                             choice your person");
                    choice = Convert.ToInt32(Console.ReadLine());
                }

                if (choice == 1)
                {
                    Console.WriteLine("                                         you choice is Person number 1\n");
                }

                if (choice == 2)
                {
                    Console.WriteLine("                                             your choice is Person number 2\n");
                }

                Thread.Sleep(500);
                int number1 = 0;
                while (number1 != 3)
                {
                    Console.WriteLine("                                             If you are ready push number 3\n");
                    number1 = Convert.ToInt32(Console.ReadLine());
                }

                if (number1 == 3)
                {
                    Console.Clear();
                    char[] load = new char[52]{'[','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.',']'};
                    for (int i = 0; i < 50; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("                                         now we can start the game...\n");
                        Console.WriteLine($"                        {i*2+2}%");
                        load[i+1] = '#';
                        for (int o = 0; o < 52; o++)
                        {
                            Console.Write(load[o]);
                        }

                        Thread.Sleep(150);
                    }
                    Console.Clear();
                }
            }
        }

        public static class Move
        {
            public static void Moves()
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                char[,] world = new char[45, 170];
                int userX = 10;
                int userY = 5;
                while (true)
                {
                    for (int i = 0; i < world.GetLength(0); i++)
                    {
                        for (int j = 0; j < world.GetLength(1); j++)
                        {
                            Console.Write(world[i, j]);
                        }

                        Console.WriteLine();
                    }

                    Console.SetCursorPosition(userX, userY);
                    Console.Write('@');
                    ConsoleKeyInfo moveKey = Console.ReadKey();
                    switch (moveKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (world[userY-1, userX] != '#')
                            {
                                userY--;
                            }

                            break;
                        case ConsoleKey.DownArrow:
                            if (world[userY+1, userX] != '#')
                            {
                                userY++;
                            }

                            break;
                        case ConsoleKey.LeftArrow:
                            if (world[userY, userX-1] != '#')
                            {
                                userX--;
                            }

                            break;
                        case ConsoleKey.RightArrow:
                            if (world[userY, userX+1] != '#')
                            {
                                userX++;
                            }

                            break;

                    }

                    Console.Clear();
                }
            }

            class Program
            {
                static void Main()
                {
                    startGame.start();
                    ChoicePerson.Person();
                    Move.Moves();
                }
            }
        }
    }
}
