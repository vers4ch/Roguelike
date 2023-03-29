using System;
using System.Text;
using System.Threading;

namespace Program
{
    public static class Map
    {
        public static void Rand(char[,] world)
        {
            
            int height = 45; //min = 15
            int width = 170; //min = 50
            Random rnd = new Random();

            //draw WORLD with
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //border
                    if (x == 0 && y > 0 && y < height - 1 || x == width - 1 && y > 0 && y < height - 1)
                        world[y, x] = (char)179;
                    else if (y == 0 && x > 0 && x < width - 1 || y == height - 1 && x > 0 && x < width - 1)
                        world[y, x] = '━';
                    else if (x == 0 && y == 0)
                        world[y, x] = '┏';
                    else if (x == width - 1 && y == height - 1)
                        world[y, x] = (char)223;
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

            //!!
            Nroom = rnd.Next(height * width / 50, height * width / 45);
            for (int i = 0; i < Nroom; i++)
            {
                cordX = rnd.Next(1, width - 7);
                cordY = rnd.Next(2, height - height / 6);

                hsq = rnd.Next(height / 7, height / 6);///!!!!
                wsq = rnd.Next(width / 21, width / 11);

                for (int j = 0; j < hsq - 3; j++)//7, 10
                {
                    for (int f = 0; f < wsq - 5; f++)//17, 20
                    {
                        // world[cordY + j, cordX + f] = '▓';
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
                    world[cordY, cordX] =(char)003;
            }
        }
    }
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
    

    public class Igor
    {
        public string name;
        public string skills;

        public Igor(string name, string skills)
        {
            this.name = name;
            this.skills = skills;
        }

        public void PrintIgor()
        {
            Console.WriteLine($"{name},{skills}");
        }
        
        public static class ChoicePerson
        {
            public static void Person()
            {
                Igor a1 = new Igor("                                            1 - Игорь", "смертельный вопрос\n");
                a1.PrintIgor();
                Igor a2 = new Igor("                                            2 - Рома", "супер броня\n");
                a2.PrintIgor();
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
                    char[] load = new char[52] {                                   '[', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', ']' };
                    for (int i = 0; i < 50; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("                                         now we can start the game...\n");
                        Console.WriteLine($"                        {i * 2 + 2}%");
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
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                string smile = "♕";
                char hearts = (char)003;
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                int userX = 10;
                int userY = 5;
                char[] heart = new char[1];
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

                    Console.SetCursorPosition(0, 12);
                    Console.Write("Heart:");
                    Console.Write((char)003);
                    for (int k = 0; k < heart.Length; k++)
                    {
                        Console.Write(heart[k] + " ");
                    }

                    Console.SetCursorPosition(userX, userY);
                    Console.Write(smile);
                    ConsoleKeyInfo moveKey = Console.ReadKey();
                    switch (moveKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (world[userY - 1, userX] != '#')
                            {
                                userY--;
                            }

                            break;

                        case ConsoleKey.DownArrow:
                            if (world[userY + 1, userX] != '#')
                            {
                                userY++;
                            }

                            break;

                        case ConsoleKey.LeftArrow:
                            if (world[userY, userX - 1] != '#')
                            {
                                userX--;
                            }

                            break;

                        case ConsoleKey.RightArrow:
                            if (world[userY, userX + 1] != '#')
                            {
                                userX++;
                            }

                            break;
                    }

                    if (world[userY, userX] == (char)003)
                    {
                        world[userY, userX] = ' ';

                        char[] listHeart = new char[heart.Length + 1];
                        for (int i = 0; i < heart.Length; i++)
                        {
                            listHeart[i] = heart[i];
                        }

                        listHeart[listHeart.Length - 1] = (char)003;
                        heart = listHeart;
                    }
                    Console.Clear();
                }
            }

            class Program
            {
                static void Main()
                {
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    char[,] world = new char[45, 170];
                    startGame.start();
                    ChoicePerson.Person();
                    Console.ReadKey();
                    Map.Rand(world);
                    Move.Moves(world);
                }
            }
        }
    }
}