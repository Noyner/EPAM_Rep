using System;
using System.Threading;
using System.Linq;

namespace GameDev
{
    class Program
    {
        public static void Main(string[] args)
        {
            inputManager im = new inputManager();
            Player p = new Player();
            Field f = new Field();
            im.ListenAsync();
            im.player = p;
            im.field = f;

            im.ListenAsync();

            f.fillField();
            f.SetBonuses();
            f.SetObstruction();
            f.SetHero(0, 9, p);

            DrawEngine.player = p;
            DrawEngine.drawFieldSync(f);
        }
    }
    class Options
    {
        public const int DRAW_LATENCY = 50;
        public const string HERO_SYMBOL = "T";
        public const string EMPTY_CELL = "_";
        public const string BONUS = "B";
        public const string OBSTRUCTION = "O";
    }
    class Player
    {
        public int X;
        public int Y;
        public static int heart = 3;
        string hero = Options.HERO_SYMBOL;
        public override string ToString()
        {
            return hero;
        }
    }
    class DrawEngine
    {
        public static Player player;
        public static void drawFieldSync(Field f)
        {
            Console.Clear();
            string fieldPrint = "";
            for (int i = 0; i < f.GetStats()[0]; i++)
            {
                for (int j = 0; j < f.GetStats()[1]; j++)
                {
                    fieldPrint += f.GetSymbolIn(i, j);
                }
                fieldPrint += "\n";
            }
            Console.WriteLine(fieldPrint);

            Console.WriteLine("Y: " + player.X + "\n" + "X: " + player.Y);
            Console.WriteLine("Bonuses: " + Bonuses.collected);
            Console.WriteLine("Heart: " + Player.heart);
        }
    }
    class Field
    {
        readonly int Width = 10;
        readonly int Height = 15;
        readonly string fieldSymbol = Options.EMPTY_CELL;
        public string[,] field;
        public void SetEmptyCell(int x, int y)
        {
            field[x, y] = Options.EMPTY_CELL;
        }
        public string GetSymbolIn(int x, int y)
        {
            return field[x, y];
        }
        public int[] GetStats()
        {
            return new int[2] { Width, Height };
        }
        public void SetHero(int x, int y, Player p)
        {
            if (field[x, y] == Options.BONUS)
            {
                Bonuses.collected++;
            }

            if (field[x,y] == Options.OBSTRUCTION)
            {
                Player.heart--; 
            }

            if (Player.heart <= 0)
            {
                Console.WriteLine(Environment.NewLine + "ТЫ МЁРТВ");
                Console.ReadKey();
            }
            field[x, y] = Options.HERO_SYMBOL;
            field[p.X, p.Y] = Options.EMPTY_CELL;
            p.X = x;
            p.Y = y;
        }
        public void fillField()
        {
            field = new string[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int k = 0; k < Height; k++)
                {
                    Console.Write(fieldSymbol);
                    field[i, k] = fieldSymbol; ;
                }
                Console.WriteLine();
            }
        }
        public void SetBonuses()
        {
            int bonus = 5;
            int Min = 0;
            int Max_x = field.GetLength(0);
            int Max_y = field.GetLength(1);

            Random rand = new Random();

            int[] bonuses_x = Enumerable
            .Repeat(0, bonus)
            .Select(i => rand.Next(Min, Max_x))
            .ToArray();

            int[] bonuses_y = Enumerable
            .Repeat(0, bonus)
            .Select(i => rand.Next(Min, Max_y))
            .ToArray();

            for (int i = 0; i < bonus; i++)
                field[bonuses_x[i], bonuses_y[i]] = Options.BONUS;
        }
        public void SetObstruction()
        {
            int obstruction = 7;
            int Min = 0;
            int Max_x = field.GetLength(0);
            int Max_y = field.GetLength(1);

            Random rand = new Random();

            int[] obstruction_x = Enumerable
            .Repeat(0, obstruction)
            .Select(i => rand.Next(Min, Max_x))
            .ToArray();

            int[] obstruction_y = Enumerable
            .Repeat(0, obstruction)
            .Select(i => rand.Next(Min, Max_y))
            .ToArray();

            for (int i = 0; i < obstruction; i++)
                field[obstruction_x[i], obstruction_y[i]] = Options.OBSTRUCTION;
        }
    }
    class Bonuses
    {
        public static int collected = 0;
    }

    class inputManager
    {
        public Player player;
        public Field field;
        public void ListenAsync()
        {
            Thread ListeningThread = new Thread(input);
            ListeningThread.Start();
        }
        void input()
        {
            while (true)
            {
                var number = Console.ReadKey(true).Key;
                switch (number)
                {
                    case ConsoleKey.S:
                        {
                            if (player.X == field.GetStats()[0] - 1)
                                field.SetHero(0, player.Y, player);
                            else
                                field.SetHero(player.X + 1, player.Y, player);

                            DrawEngine.drawFieldSync(field);
                            break;
                        }
                    case ConsoleKey.W:
                        {
                            if (player.X == 0)
                                field.SetHero(field.GetStats()[0] - 1, player.Y, player);
                            else
                                field.SetHero(player.X - 1, player.Y, player);

                            DrawEngine.drawFieldSync(field);
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            if (player.Y == 0)
                                field.SetHero(player.X, field.GetStats()[1] - 1, player);
                            else
                                field.SetHero(player.X, player.Y - 1, player);

                            DrawEngine.drawFieldSync(field);
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            if (player.Y == field.GetStats()[1] - 1)
                                field.SetHero(player.X, 0, player);
                            else
                                field.SetHero(player.X, player.Y + 1, player);

                            DrawEngine.drawFieldSync(field);
                            break;
                        }
                    default:
                        break;
                }
                Thread.Sleep(Options.DRAW_LATENCY);
            }
        }
    }
}