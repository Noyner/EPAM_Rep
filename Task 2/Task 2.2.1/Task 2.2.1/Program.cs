using System;
using System.Collections.Generic;
using System.Threading;

namespace GameDev
{
    class Options
    {
       public const int DRAW_LATENCY = 50;
       public const string HERO_SYMBOL = "T";
       public const string EMPTY_CELL = "_";
        
    }
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
            f.SetHero(0, 9, p);

            DrawEngine.player = p;
            DrawEngine.drawFieldSync(f);

        }
    }

    class Player
    {
       public int X;
        public int Y;
        string hero = Options.HERO_SYMBOL;
        public override string ToString()
        {
            return hero;
        }

    }

    class DrawEngine
    {
        public static Player player;
        public void DrawAsyc()
        {

        }

        public static void drawFieldSync(Field f)
        {
            Console.Clear();
            string fieldPrint = "";
            for (int i=0; i<f.getStats()[0]; i++)
            {
                for (int j = 0; j < f.getStats()[1]; j++)
                {
                    fieldPrint += f.getSymbolIn(i, j);
                }
                fieldPrint += "\n";
            }
            Console.WriteLine(fieldPrint);

            Console.WriteLine("X: " + player.X + "\n" + "Y: " + player.Y);
        }


        void draw()
        {

        }
    }

    class Field
    {
        int Width = 10;
        int Height = 15;
        string fieldSymbol = Options.EMPTY_CELL;
        string [,] field;

        public void SetEmptyCell(int x, int y)
        {
            field[x, y] = Options.EMPTY_CELL;
        }
        public string getSymbolIn(int x, int y)
        {
            return field[x, y];
        }


        public int[] getStats()
        {
            return new int[2] { Width, Height };
        }
       public void SetHero(int x, int y, Player p)
        {
            field[x, y] = Options.HERO_SYMBOL;
            field[p.X, p.Y] = Options.EMPTY_CELL;
            p.X = x;
            p.Y = y;
            
        }
        public void fillField()
        {
            field = new string[Width, Height];

            for (int i = 0; i<Width; i++)
            {
                for (int k =0; k<Height; k++)
                {
                    Console.Write(fieldSymbol);
                    field[i, k] = fieldSymbol; ;
                }
                Console.WriteLine();
            }
        }

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
                            //if (last_x == Field.GetLength(0) - 1)
                            //    setDude(0, last_y);
                            //else
                            //    setDude(last_x + 1, last_y);
                            ////	drawField();
                            ////	Thread.Sleep(DRAW_LATENCY);
                            //break;

                            if (player.X == field.getStats()[0] - 1)
                                field.SetHero(0, player.Y, player);
                            else
                                field.SetHero(player.X + 1, player.Y, player);

                            DrawEngine.drawFieldSync(field);

                            //Console.WriteLine(number.ToString());
                            break;
                        }
                    case ConsoleKey.W:
                        {
                            if (player.X == 0)
                                field.SetHero(field.getStats()[0] - 1, player.Y, player);
                            else
                                field.SetHero(player.X - 1, player.Y, player);

                            DrawEngine.drawFieldSync(field);
                            // Console.WriteLine(number.ToString());
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            if (player.Y == 0)
                                field.SetHero(player.X, field.getStats()[1] - 1, player);
                            else
                                field.SetHero(player.X, player.Y-1, player);

                            DrawEngine.drawFieldSync(field);
                            //Console.WriteLine(number.ToString());
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            if (player.Y == field.getStats()[1] - 1)
                                field.SetHero(player.X, 0, player);
                            else
                                field.SetHero(player.X, player.Y + 1, player);

                            DrawEngine.drawFieldSync(field);
                            // Console.WriteLine(number.ToString());
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