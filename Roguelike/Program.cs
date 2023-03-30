//  main.cs
//  Roguelike
//  Created by Versach on 19.03.2023.
//
using System;
using System.Threading;
using static Program.Person;

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
                }
            }

            //heart
            int item = rnd.Next(height / 5, width / 10);
            for (int o = 0; o < item; o++)
            {
                cordX = rnd.Next(1, width - 1);
                cordY = rnd.Next(1, height - 1);
                if (world[cordY, cordX] == '▓' || world[cordY, cordX] == '@')
                    item++;
                else
                    world[cordY, cordX] = '❤';
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
                Igor a1 = new Igor("1 - Игорь", "смертельный вопрос\n");
                a1.PrintPerson();
                Igor a2 = new Igor("2 - Игорь", "супер броня\n");
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
                        Console.WriteLine();
                        if (i % 2 == 0)
                            Console.WriteLine("                       Loading..\n");
                        else
                            Console.WriteLine("                       Loading...\n");
                        Console.WriteLine($"                         {i * 2 + 2}%");
                        load[i + 1] = '#';
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
            public static void Moves(char[,] world)
            {
                Console.SetCursorPosition(0, 0);
                int userX = 8;
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
                            if (world[userY - 1, userX] != '#' && world[userY - 1, userX] != '┃' && world[userY - 1, userX] != '━' && world[userY - 1, userX] != '┏' && world[userY - 1, userX] != '┛' && world[userY - 1, userX] != '┗' && world[userY - 1, userX] != '┓')
                            {
                                userY--;
                            }

                            break;
                        case ConsoleKey.DownArrow:
                            if (world[userY + 1, userX] != '#' && world[userY + 1, userX] != '┃' && world[userY + 1, userX] != '━' && world[userY + 1, userX] != '┏' && world[userY + 1, userX] != '┛' && world[userY + 1, userX] != '┗' && world[userY + 1, userX] != '┓')
                            {
                                userY++;
                            }

                            break;
                        case ConsoleKey.LeftArrow:
                            if (world[userY, userX - 1] != '#' && world[userY, userX - 1] != '┃' && world[userY, userX - 1] != '━' && world[userY, userX - 1] != '┏' && world[userY, userX - 1] != '┛' && world[userY, userX - 1] != '┗' && world[userY, userX - 1] != '┓')
                            {
                                userX--;
                            }

                            break;
                        case ConsoleKey.RightArrow:
                            if (world[userY, userX + 1] != '#' && world[userY, userX + 1] != '┃' && world[userY, userX + 1] != '━' && world[userY, userX + 1] != '┏' && world[userY, userX + 1] != '┛' && world[userY, userX + 1] != '┗' && world[userY, userX + 1] != '┓')
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
                public static void Main(string[] args)
                {
                    char[,] world = new char[45, 170];
                    startGame.start();
                    ChoicePerson.Person();
                    Map.Rand(world);
                    Moves(world);

                    Igor Igor = new Igor();
                    enemy enemy = new enemy();

                    enemy.SetDamage(Igor, 25);
                    Igor.SetDamage(enemy, 100);

                    Console.ReadKey();
                }
            }
            public abstract class Character
            {
                public int Health { get; private set; }

                public Character()
                {
                    Health = 100;
                }

                public virtual void GetDamage(int damage)
                {
                    Health -= damage;
                    if (Health < 1)
                    {

                    }
                }
                public void SetDamage(Character character, int damage)
                {
                    character.GetDamage(damage);
                }
            }

            public class Igor : Character
            {
                public override void GetDamage(int damage)
                {

                    base.GetDamage(damage);
                }
            }

            public class enemy : Character
            {
                public override void GetDamage(int damage)
                {

                    base.GetDamage(damage);
                }
            }
        }
    }
}
