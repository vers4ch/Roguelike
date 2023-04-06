using System;
using System.Threading;

namespace Program
{
    public static class Map
    {
        public static void Rand(char[,] world)
        {
            Console.CursorVisible = false;
            int height = world.GetLength(0) - 1; //min = 15
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
                    world[height - 1, width - 4] = '+';
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
            
            //mana
            int _mana = rnd.Next(5,8);
            for (int o = 0; o < _mana; o++)
            {
                cordX = rnd.Next(1, width - 1);
                cordY = rnd.Next(1, height - 1);
                if (world[cordY, cordX] == '@' || world[cordY, cordX] == '❤' || world[cordY, cordX] == '#' || world[cordY, cordX] == '$')
                    _mana++;
                else
                {
                    world[cordY, cordX] = 'Ⰷ';
                }
            }
            
            //money
            int money = rnd.Next(9, 12);
            for (int o = 0; o < money; o++)
            {
                cordX = rnd.Next(1, width - 1);
                cordY = rnd.Next(1, height - 1);
                if (world[cordY, cordX] == '@' || world[cordY, cordX] == '#' || world[cordY, cordX] == '@' || world[cordY, cordX] == '$')
                    item++;
                else
                    world[cordY, cordX] = '$';
            }
            //boss
            int boss = world[43, 166];
            if (world[43, 166] == '@' || world[43, 166] == '#' || world[43, 166] == '@' || world[43, 166] == '$')
                item++;
            else
                world[43, 166] = '☠';
        }
    }
    public static class startGame
    {
        public static void start()
        {
            Console.Clear();
            string ch = "Choice:";
            string ch1 = "1.Play";
            string ch2 = "2.Exit";
            Console.SetCursorPosition((Console.WindowWidth - ch.Length) / 1/2, Console.CursorTop);
            Console.WriteLine(ch);
            Console.SetCursorPosition((Console.WindowWidth - ch1.Length) / 1/2, Console.CursorTop);
            Console.WriteLine(ch1);
            Console.SetCursorPosition((Console.WindowWidth - ch2.Length) / 1/2, Console.CursorTop);
            Console.WriteLine(ch2);

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
        public static int _Health;
        public static int _Mana;
        public static int _Gold = 1500;

        public Person(string name, int Health, int mana)
        {
            this.name = name;
            _Health = Health;
            _Mana = mana;
        }
        public virtual void PrintPerson()
        {
            string ss = $"{name} , {_Health}HP , {_Mana}%";
            Console.SetCursorPosition((Console.WindowWidth - ss.Length) / 2, Console.CursorTop);
            Console.WriteLine(ss);
        }
        public class Igor : Person
        {
            public Igor(string name, int Health, int mana) : base(name, Health, mana)
            {
                _Health = Health;
                _Mana = mana;
            }
            public override void PrintPerson()
            {
                string ss = $"{name} , {_Health}HP , {_Mana}%";
                Console.SetCursorPosition((Console.WindowWidth - ss.Length) / 2, Console.CursorTop);
                Console.WriteLine(ss);
            }
        }
        public class Roma : Person
        {
            public Roma(string name, int Health, int mana) : base(name, Health, mana)
            {
                _Health = Health;
                _Mana = mana;
            }
            public override void PrintPerson()
            {
                string ss = $"{name} , {_Health}HP , {_Mana}%";
                Console.SetCursorPosition((Console.WindowWidth - ss.Length) / 2, Console.CursorTop);
                Console.WriteLine(ss);
            }
        }
    
        public static class ChoicePerson
        {
            public static void Person()
            {

                Igor Igor = new Igor("1 - Игорь", 50 , 200 );
                Igor.PrintPerson();
                Roma Roma = new Roma("2 - Рома", 250, 50);
                Roma.PrintPerson();
                int choice = 0;
                string s1 = "Choice your person";
                string s2 = "You choice is Person number 1\n";
                string choice1 = "Your choice is Person number 2\n";

                while (choice != 1 && choice != 2)
                {
                    Console.SetCursorPosition((Console.WindowWidth - s1.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s1);
                    choice = Convert.ToInt32(Console.ReadLine());
                }

                if (choice == 1)
                {
                    Igor = new Igor("1 - Игорь", 50, 200);
                    Console.SetCursorPosition((Console.WindowWidth - s2.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s2);
                }

                if (choice == 2)
                {
                    Roma = new Roma("2 - Рома", 250, 50);
                    Console.SetCursorPosition((Console.WindowWidth - choice1.Length) / 2, Console.CursorTop);
                    Console.WriteLine(choice1);

                }

                Thread.Sleep(500);
                int number1 = 0;
                string s = "If you are ready push number 3";
                while (number1 != 3)
                {
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    number1 = Convert.ToInt32(Console.ReadLine());
                }

                if (number1 == 3)
                {
                    Console.Clear();
                    char[] load = new char[52] {                         '[', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', ']' };

                    for (int i = 0; i < 50; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                        if (i % 2 == 0)
                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t                       Loading..\n");
                        else
                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t                       Loading...\n");
                        Console.WriteLine($"\t\t\t\t\t\t                                                          {i * 2 + 2}%");
                        load[i + 1] = '#';
                        Console.Write("\t\t\t\t\t\t\t\t\t\t");
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
                char smile = '♕';
                char hearts = '❤';
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                int userX = 8;
                int userY = 5;
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
                        Console.Clear();
                        string ss = "You die!!";
                        string sss = "a)Exit";
                        string ssss = "b)Restart";
                        Console.SetCursorPosition((Console.WindowWidth - ss.Length) / 2, Console.CursorTop);
                        Console.WriteLine(ss);
                        Console.SetCursorPosition((Console.WindowWidth - sss.Length) / 2, Console.CursorTop);
                        Console.WriteLine(sss);
                        Console.SetCursorPosition((Console.WindowWidth - ssss.Length) / 2, Console.CursorTop);
                        Console.WriteLine(ssss);
                        string ex = Console.ReadLine();

                        switch (ex)
                        {
                            case "a":
                                Environment.Exit(0);
                                break;
                            case "b":
                                while (true)
                                {
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
                            else if (world[i, j] == '$' && world[i, j] != worldNew[i, j])
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] == 'Ⰷ' && world[i, j] != worldNew[i, j])
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] == '@' && world[i, j] != worldNew[i, j])
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] == '#' && world[i, j] != worldNew[i, j])
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] == '☠' && world[i, j] != worldNew[i, j])
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(world[i, j]);
                                Console.ResetColor();
                            }
                            else if (world[i, j] != worldNew[i, j])
                            {
                                Console.Write(world[i, j]);
                            }
                            else if (worldNew[i, j] == smile)
                                Console.Write(' ');
                        }

                        Console.WriteLine();
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"HP: {_Health}     ");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Gold: {_Gold}     ");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"Mana: {_Mana}");
                    Console.ResetColor();


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
                        _Gold += 100;
                        world[userY, userX] = ' ';
                    }

                    if (world[userY, userX] == 'Ⰷ')
                    {
                        world[userY, userX] = ' ';
                        _Mana += 50;
                    }

                    if (world[userY - 1, userX] == '@')
                    {
                        world[userY - 1, userX] = ' ';
                        Guess.Gener(world, userY, userX);
                    }

                    if (world[userY, userX] == '@')
                    {
                        world[userY, userX] = ' ';
                        Guess.Gener(world, userY, userX);
                    }

                    if (world[userY, userX - 1] == '@')
                    {
                        world[userY, userX - 1] = ' ';
                        Guess.Gener(world, userY, userX);
                    }
                   
                    if (world[userY, userX + 1] == '@')
                    {
                        world[userY, userX + 1] = ' ';
                        Guess.Gener(world, userY, userX);
                    }

                    if (world[userY + 1, userX] == '@')
                    {
                        world[userY + 1, userX] = ' ';
                        Guess.Gener(world, userY, userX);
                    }

                    if (world[userY - 1, userX] == '☠')
                    {
                        world[userY - 1, userX] = ' ';
                        Guess1.Gener(world, userY, userX);
                    }

                    if (world[userY, userX - 1] == '☠')
                    {
                        world[userY, userX - 1] = ' ';
                        Guess1.Gener(world, userY, userX);
                    }

                    if (world[userY, userX + 1] == '☠')
                    {
                        world[userY, userX + 1] = ' ';
                        Guess1.Gener(world, userY, userX);
                    }

                    if (world[userY + 1, userX] == '☠')
                    {
                        world[userY + 1, userX] = ' ';
                        Guess1.Gener(world, userY, userX);
                    }


                    if (world[userY, userX] == '+')
                    {
                        Console.Clear();
                        string ss = "УРОВЕНЬ ПРОЙДЕН!";
                        Console.SetCursorPosition((Console.WindowWidth - ss.Length) / 2, Console.CursorTop);
                        Console.WriteLine(ss);
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
                    if (_Mana > 25)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                string text1 = "You have met the enemy";
                                string text2 = "Choose an action";
                                string text3 = "          a) 'Ударить'";
                                string text4 = "            b) 'Убить'";

                                if (y == 3 && x == width / 2 - text1.Length / 2)
                                    gues[y, x] = text1;
                                else if (y == 10 && x == width / 2 - text2.Length / 2)
                                    gues[y, x] = text2;
                                else if (y == 15 && x == 10)
                                    gues[y, x] = text3;
                                else if (y == 15 && x == 20)
                                    gues[y, x] = text4;
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 3)
                                    gues[y, x - text1.Length + 1] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 10)
                                    gues[y, x - text2.Length + 1] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 15)
                                    gues[y, x - (text3.Length + text4.Length - 2)] = "┃";
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
                    }
                    else if (_Mana < 1)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                string nexttext = "you have met the enemy";
                                string nexttext1 = "choose an action";
                                string nexttext2 = "not enough mana to fight the enemy";
                                string nexttext3 = "            с) 'Отступить'";

                                if (y == 3 && x == width / 2 - nexttext.Length / 2)
                                    gues[y, x] = nexttext;
                                else if (y == 5 && x == width / 2 - nexttext1.Length / 2)
                                    gues[y, x] = nexttext1;
                                else if (y == 10 && x == width / 2 - nexttext2.Length / 2)
                                    gues[y, x] = nexttext2;
                                else if (y == 15 && x == 20)
                                    gues[y, x] = nexttext3;
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 3)
                                    gues[y, x - nexttext.Length + 1] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 5)
                                    gues[y, x - nexttext.Length + 7] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 10)
                                    gues[y, x - nexttext1.Length - 17] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 15)
                                    gues[y, x - (nexttext3.Length - 1)] = "┃";
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

                                else
                                {
                                    gues[y, x] = " ";
                                }
                            }
                        }
                    }
                    else if (_Mana <= 25 && _Mana > 1)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                string nexttext = "you have met the enemy";
                                string nexttext1 = "choose an action";
                                string nexttext2 = "You only have enough mana to hit";
                                string nexttext3 = "                    a) 'Ударить'";

                                if (y == 3 && x == width / 2 - nexttext.Length / 2)
                                    gues[y, x] = nexttext;
                                else if (y == 5 && x == width / 2 - nexttext1.Length / 2)
                                    gues[y, x] = nexttext1;
                                else if (y == 10 && x == width / 2 - nexttext2.Length / 2)
                                    gues[y, x] = nexttext2;
                                else if (y == 15 && x == 20)
                                    gues[y, x] = nexttext3;
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 3)
                                    gues[y, x - nexttext.Length + 1] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 5)
                                    gues[y, x - nexttext.Length + 7] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 10)
                                    gues[y, x - nexttext1.Length - 15] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 15)
                                    gues[y, x - (nexttext3.Length - 1)] = "┃";
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

                                else
                                {
                                    gues[y, x] = " ";
                                }
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

                    string press = Console.ReadLine();

                    if (press == "c" || press == "C")
                    {
                        world[cordY - 1, cordX] = '@';
                        _Health -= 25;
                    }
                    else if(press == "b" || press == "B")
                    {
                        _Mana -= 50;
                        _Gold += 50;
                    }
                    else if (press == "a" || press == "A")
                    {
                        _Health -= 10;
                        _Mana -= 25;
                        _Gold += 10;
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
                            else if (world[i,j] == 'Ⰷ')
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
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
            public static class Guess1
            {
                public static void Gener(char[,] world, int cordY, int cordX)
                {
                    Console.Clear();
                    int height = 22; //min = 15
                    int width = 80; //min = 50
                    string[,] gues = new string[height, width];
                    //draw
                    
                    if (_Gold < 1500)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                string text = "This is the Keeper of the Gate";
                                string text2 = "You don't have enough gold";
                                string text3 = "to go further";
                                string text4 = "h) 'идти собирать золото'";

                                if (y == 3 && x == width / 2 - text.Length / 2)
                                    gues[y, x] = text;
                                else if (y == 5 && x == width / 2 - text2.Length / 2)
                                    gues[y, x] = text2;
                                else if (y == 10 && x == width / 2 - text3.Length / 2)
                                    gues[y, x] = text3;
                                else if (y == 15 && x == 20)
                                    gues[y, x] = text4;
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 3)
                                    gues[y, x - text.Length + 1] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 5)
                                    gues[y, x - text.Length + 5] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 10)
                                    gues[y, x - text2.Length + 14] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 15)
                                    gues[y, x - text3.Length - 11] = "┃";
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

                                else
                                {
                                    gues[y, x] = " ";
                                }
                            }
                        }
                    }
                    if(_Gold >= 1500)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                string text = "This is the Keeper of the Gate";
                                string text2 = "You have enough gold";
                                string text3 = "you need pay 1500";
                                string text4 = "u) 'заплатить'";

                                if (y == 3 && x == width / 2 - text.Length / 2)
                                    gues[y, x] = text;
                                else if (y == 5 && x == width / 2 - text2.Length / 2)
                                    gues[y, x] = text2;
                                else if (y == 10 && x == width / 2 - text3.Length / 2)
                                    gues[y, x] = text3;
                                else if (y == 15 && x == 20)
                                    gues[y, x] = text4;
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 3)
                                    gues[y, x - text.Length + 1] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 5)
                                    gues[y, x - text.Length + 11] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 10)
                                    gues[y, x - text2.Length + 4] = "┃";
                                else if (x == width - 1 && y > 0 && y < height - 1 && y == 15)
                                    gues[y, x - (text3.Length -4)] = "┃";
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

                                else
                                {
                                    gues[y, x] = " ";
                                }
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

                    string press = Console.ReadLine();

                    if (press == "h" || press == "H")
                    {
                        world[43, 166] = '☠';
                    }

                    if(press == "u" || press == "U")
                    {
                        world[43, 166] = ' ';
                        _Gold -= 1500;
                    }

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
                            else if (world[i, j] == 'Ⰷ')
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
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
                        char[,] world = new char[46, 170];
                        startGame.start();
                        ChoicePerson.Person();
                        Map.Rand(world);
                        Moves(world);
                        string s = "Нажмите <ENTER>, чтобы продолжить. <Q>, чтобы выйти.";
                        Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                        Console.WriteLine(s);
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