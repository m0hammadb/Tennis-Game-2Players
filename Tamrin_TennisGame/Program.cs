using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamrin_TennisGame
{
    class Program
    {

        static int xMargin = 35;
        static int yMargin = 0;
        static void MapScreen(int y, int x, int gameValue)
        {
            Console.SetCursorPosition(xMargin + x, yMargin + y);
            Console.ForegroundColor = ConsoleColor.White;
            switch (gameValue)
            {
                case 0:
                    Console.Write(" ");
                    break;
                case 1:
                    // Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("█");
                    break;
                case 2:
                    Console.Write("▄");
                    break;
                case 3:
                  //  Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("●");
                    break;
                case 4:
                    Console.Write("▬");
                    break;
                case 5:
                    // Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("▬");
                    break;
                case 6:

                    Console.Write("▀");
                    break;


            }

            Console.SetCursorPosition(30, 0);
        }
        static void Main(string[] args)
        {
            int playerOneScore = 0;
            int playerTwoScore = 0;
            while (true)
            {
                int rows = 30, cols = 40;
                int[,] gameBoardMatrix = new int[rows, cols];
                int playerOnePosition = cols / 2;
                int playerTwoPosition = cols / 2;
                int ballPositionX = rows - 3;
                int ballPositionY = cols / 2;
                int ballDirection = 0;
                bool isPlaying = false;
                bool gameOver = false;


                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(5, 2);
                Console.Write("Player1: " + playerOneScore);
                Console.SetCursorPosition(5, 3);
                Console.Write("Player2: " + playerTwoScore);
                Console.CursorVisible = false;
                Console.OutputEncoding = System.Text.Encoding.UTF8;


                //Init

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (i == 0)
                        {
                            gameBoardMatrix[i, j] = 2;
                            MapScreen(i, j, 2);
                        }
                        else if (i == rows - 1)
                        {
                            gameBoardMatrix[i, j] = 6;
                            MapScreen(i, j, 6);
                        }
                        else if (j == 0 || j == cols - 1)
                        {
                            gameBoardMatrix[i, j] = 1;
                            MapScreen(i, j, 1);
                        }

                    }
                }
                //player 1 init
                gameBoardMatrix[rows - 2, playerOnePosition] = 4;
                gameBoardMatrix[rows - 2, playerOnePosition - 1] = 4;
                gameBoardMatrix[rows - 2, playerOnePosition + 1] = 4;
                MapScreen(rows - 2, playerOnePosition, 4);
                MapScreen(rows - 2, playerOnePosition - 1, 4);
                MapScreen(rows - 2, playerOnePosition + 1, 4);
                gameBoardMatrix[rows - 3, playerOnePosition] = 3;
                MapScreen(rows - 3, playerOnePosition, 3);


                //player 2 init

                gameBoardMatrix[1, playerTwoPosition] = 4;
                gameBoardMatrix[1, playerTwoPosition - 1] = 4;
                gameBoardMatrix[1, playerTwoPosition + 1] = 4;
                MapScreen(1, playerTwoPosition, 4);
                MapScreen(1, playerTwoPosition - 1, 4);
                MapScreen(1, playerTwoPosition + 1, 4);

                while (true)
                {
                    if(gameOver)
                    {
                        break;
                    }
                    if (isPlaying)
                    {

                        if (ballDirection == 1)
                        {
                            if (ballPositionX > 1)
                            {
                                if (gameBoardMatrix[ballPositionX, ballPositionY] == 3)
                                {
                                    gameBoardMatrix[ballPositionX, ballPositionY] = 0;
                                    MapScreen(ballPositionX, ballPositionY, 0);
                                }

                                ballPositionX--;
                                gameBoardMatrix[ballPositionX, ballPositionY] = 3;
                                MapScreen(ballPositionX, ballPositionY, 3);
                            }
                            else
                            {
                                if (ballPositionY == playerTwoPosition || ballPositionY == playerTwoPosition + 1 || ballPositionY == playerTwoPosition - 1 || ballPositionY == playerTwoPosition -2 || ballPositionY == playerTwoPosition + 2)
                                {
                                    if (ballPositionY == playerTwoPosition)
                                    {
                                        ballDirection = 4;
                                        gameBoardMatrix[1, playerTwoPosition] = 5;
                                        MapScreen(1, playerTwoPosition, 5);
                                    }
                                    else if (ballPositionY == playerTwoPosition + 1 || ballPositionY == playerTwoPosition + 2)
                                    {
                                        ballDirection = 5;
                                        gameBoardMatrix[1, playerTwoPosition + 1] = 5;
                                        MapScreen(1, playerTwoPosition + 1, 5);
                                    }
                                    else
                                    {
                                        ballDirection = 6;
                                        gameBoardMatrix[1, playerTwoPosition - 1] = 5;
                                        MapScreen(1, playerTwoPosition - 1, 5);
                                    }
                                }
                                else
                                {
                                    //Game Over
                                    playerOneScore++;
                                    gameOver = true;
                                }
                            }

                        }
                        else if (ballDirection == 4)
                        {
                            if (ballPositionX < rows - 2)
                            {
                                if (gameBoardMatrix[ballPositionX, ballPositionY] == 3)
                                {
                                    gameBoardMatrix[ballPositionX, ballPositionY] = 0;
                                    MapScreen(ballPositionX, ballPositionY, 0);
                                }

                                ballPositionX++;
                                gameBoardMatrix[ballPositionX, ballPositionY] = 3;
                                MapScreen(ballPositionX, ballPositionY, 3);
                            }
                            else if (ballPositionY == playerOnePosition || ballPositionY == playerOnePosition + 1 || ballPositionY == playerOnePosition - 1 || ballPositionY == playerOnePosition - 2 || ballPositionY == playerOnePosition + 2)
                            {
                                if (ballPositionY == playerOnePosition)
                                {
                                    ballDirection = 1;
                                    gameBoardMatrix[rows - 2, playerOnePosition] = 4;
                                    MapScreen(rows - 2, playerOnePosition, 4);
                                }
                                else if (ballPositionY == playerOnePosition + 1 || ballPositionY == playerOnePosition + 2)
                                {
                                    ballDirection = 2;
                                    gameBoardMatrix[rows - 2, playerOnePosition + 1] = 4;
                                    MapScreen(rows - 2, playerOnePosition + 1, 4);
                                }
                                else
                                {
                                    ballDirection = 3;
                                    gameBoardMatrix[rows - 2, playerOnePosition - 1] = 4;
                                    MapScreen(rows - 2, playerOnePosition - 1, 4);
                                }
                            }
                            else
                            {
                                //Game over
                                playerTwoScore++;
                                gameOver = true;
                            }
                        }
                        else if (ballDirection == 2)
                        {
                            if (ballPositionX > 1 && ballPositionY < cols - 1)
                            {
                                if (gameBoardMatrix[ballPositionX, ballPositionY] == 3)
                                {
                                    gameBoardMatrix[ballPositionX, ballPositionY] = 0;
                                    MapScreen(ballPositionX, ballPositionY, 0);
                                }
                                ballPositionY++;
                                ballPositionX--;

                                gameBoardMatrix[ballPositionX, ballPositionY] = 3;
                                MapScreen(ballPositionX, ballPositionY, 3);
                            }
                            else if (ballPositionY == cols - 1)
                            {
                                //wall hit
                                ballDirection = 3;
                                gameBoardMatrix[ballPositionX, ballPositionY] = 1;
                                MapScreen(ballPositionX, ballPositionY, 1);
                            }
                            else
                            {
                                if (ballPositionY == playerTwoPosition || ballPositionY == playerTwoPosition + 1 || ballPositionY == playerTwoPosition - 1 || ballPositionY == playerTwoPosition - 2 || ballPositionY == playerTwoPosition + 2)
                                {
                                    if (ballPositionY == playerTwoPosition)
                                    {
                                        ballDirection = 4;
                                        gameBoardMatrix[1, playerTwoPosition] = 5;
                                        MapScreen(1, playerTwoPosition, 5);
                                    }
                                    else if (ballPositionY == playerTwoPosition + 1 || ballPositionY == playerTwoPosition + 2)
                                    {
                                        ballDirection = 5;
                                        gameBoardMatrix[1, playerTwoPosition + 1] = 5;
                                        MapScreen(1, playerTwoPosition + 1, 5);
                                    }
                                    else
                                    {
                                        ballDirection = 6;
                                        gameBoardMatrix[1, playerTwoPosition - 1] = 5;
                                        MapScreen(1, playerTwoPosition - 1, 5);
                                    }
                                }
                                else
                                {
                                    //Game OVER
                                    playerOneScore++;
                                    gameOver = true;
                                }
                            }
                        }
                        else if (ballDirection == 3)
                        {
                            if (ballPositionX > 1 && ballPositionY > 0)
                            {
                                if (gameBoardMatrix[ballPositionX, ballPositionY] == 3)
                                {
                                    gameBoardMatrix[ballPositionX, ballPositionY] = 0;
                                    MapScreen(ballPositionX, ballPositionY, 0);
                                }

                                ballPositionY--;
                                ballPositionX--;

                                gameBoardMatrix[ballPositionX, ballPositionY] = 3;
                                MapScreen(ballPositionX, ballPositionY, 3);
                            }
                            else if (ballPositionY == 0)
                            {
                                ballDirection = 2;
                                gameBoardMatrix[ballPositionX, ballPositionY] = 1;
                                MapScreen(ballPositionX, ballPositionY, 1);
                            }
                            else
                            {
                                if (ballPositionY == playerTwoPosition || ballPositionY == playerTwoPosition + 1 || ballPositionY == playerTwoPosition - 1 || ballPositionY == playerTwoPosition -2 || ballPositionY == playerTwoPosition + 2)
                                {
                                    if (ballPositionY == playerTwoPosition)
                                    {
                                        ballDirection = 4;
                                        gameBoardMatrix[1, playerTwoPosition] = 5;
                                        MapScreen(1, playerTwoPosition, 5);
                                    }
                                    else if (ballPositionY == playerTwoPosition + 1 || ballPositionY == playerTwoPosition + 2)
                                    {
                                        ballDirection = 5;
                                        gameBoardMatrix[1, playerTwoPosition + 1] = 5;
                                        MapScreen(1, playerTwoPosition + 1, 5);
                                    }
                                    else
                                    {
                                        ballDirection = 6;
                                        gameBoardMatrix[1, playerTwoPosition - 1] = 5;
                                        MapScreen(1, playerTwoPosition - 1, 5);
                                    }
                                }
                                else
                                {
                                    //Game OVER
                                    playerOneScore++;
                                    gameOver = true;
                                }
                            }
                        }
                        else if (ballDirection == 5)
                        {
                            if (ballPositionX < rows - 2 && ballPositionY < cols - 1)
                            {
                                if (gameBoardMatrix[ballPositionX, ballPositionY] == 3)
                                {
                                    gameBoardMatrix[ballPositionX, ballPositionY] = 0;
                                    MapScreen(ballPositionX, ballPositionY, 0);
                                }

                                ballPositionX++;
                                ballPositionY++;
                                gameBoardMatrix[ballPositionX, ballPositionY] = 3;
                                MapScreen(ballPositionX, ballPositionY, 3);
                            }
                            else if (ballPositionY == cols - 1)
                            {
                                ballDirection = 6;
                                gameBoardMatrix[ballPositionX, ballPositionY] = 1;
                                MapScreen(ballPositionX, ballPositionY, 1);
                            }
                            else
                            {
                                if (ballPositionY == playerOnePosition || ballPositionY == playerOnePosition + 1 || ballPositionY == playerOnePosition - 1 || ballPositionY == playerOnePosition - 2 || ballPositionY == playerOnePosition + 2)
                                {
                                    if (ballPositionY == playerOnePosition)
                                    {
                                        ballDirection = 1;
                                        gameBoardMatrix[rows - 2, playerOnePosition] = 4;
                                        MapScreen(rows - 2, playerOnePosition, 4);
                                    }
                                    else if (ballPositionY == playerOnePosition + 1 || ballPositionY == playerOnePosition + 2)
                                    {
                                        ballDirection = 2;
                                        gameBoardMatrix[rows - 2, playerOnePosition + 1] = 4;
                                        MapScreen(rows - 2, playerOnePosition + 1, 4);
                                    }
                                    else
                                    {
                                        ballDirection = 3;
                                        gameBoardMatrix[rows - 2, playerOnePosition - 1] = 4;
                                        MapScreen(rows - 2, playerOnePosition - 1, 4);
                                    }
                                }
                                else
                                {
                                    //Game over
                                    playerTwoScore++;
                                    gameOver = true;
                                }
                            }
                        }
                        else if (ballDirection == 6)
                        {
                            if (ballPositionX < rows - 2 && ballPositionY > 0)
                            {
                                if (gameBoardMatrix[ballPositionX, ballPositionY] == 3)
                                {
                                    gameBoardMatrix[ballPositionX, ballPositionY] = 0;
                                    MapScreen(ballPositionX, ballPositionY, 0);
                                }

                                ballPositionX++;
                                ballPositionY--;
                                gameBoardMatrix[ballPositionX, ballPositionY] = 3;
                                MapScreen(ballPositionX, ballPositionY, 3);
                            }
                            else if (ballPositionY == 0)
                            {
                                ballDirection = 5;
                                gameBoardMatrix[ballPositionX, ballPositionY] = 1;
                                MapScreen(ballPositionX, ballPositionY, 1);
                            }
                            else
                            {
                                if (ballPositionY == playerOnePosition || ballPositionY == playerOnePosition + 1 || ballPositionY == playerOnePosition - 1 || ballPositionY == playerOnePosition - 2 || ballPositionY == playerOnePosition + 2)
                                {
                                    if (ballPositionY == playerOnePosition)
                                    {
                                        ballDirection = 1;
                                        gameBoardMatrix[rows - 2, playerOnePosition] = 4;
                                        MapScreen(rows - 2, playerOnePosition, 4);
                                    }
                                    else if (ballPositionY == playerOnePosition + 1 || ballPositionY == playerOnePosition + 2)
                                    {
                                        ballDirection = 2;
                                        gameBoardMatrix[rows - 2, playerOnePosition + 1] = 4;
                                        MapScreen(rows - 2, playerOnePosition + 1, 4);
                                    }
                                    else
                                    {
                                        ballDirection = 3;
                                        gameBoardMatrix[rows - 2, playerOnePosition - 1] = 4;
                                        MapScreen(rows - 2, playerOnePosition - 1, 4);
                                    }
                                }
                                else
                                {
                                    //Game over
                                    playerTwoScore++;
                                    gameOver = true;
                                }
                            }
                        }
                    }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo ki = Console.ReadKey(true);
                        if (ki.Key == ConsoleKey.RightArrow)
                        {
                            if (playerOnePosition + 4 < cols)
                            {
                                gameBoardMatrix[rows - 2, playerOnePosition - 1] = 0;
                                gameBoardMatrix[rows - 2, playerOnePosition + 2] = 4;

                                MapScreen(rows - 2, playerOnePosition - 1, 0);
                                MapScreen(rows - 2, playerOnePosition + 2, 4);
                                playerOnePosition++;

                                if (!isPlaying)
                                {
                                    gameBoardMatrix[rows - 3, playerOnePosition - 1] = 0;
                                    MapScreen(rows - 3, playerOnePosition - 1, 0);

                                    gameBoardMatrix[rows - 3, playerOnePosition] = 3;
                                    MapScreen(rows - 3, playerOnePosition, 3);
                                    ballPositionY++;
                                }
                            }
                            if (playerOnePosition + 3 < cols)
                            {
                                gameBoardMatrix[rows - 2, playerOnePosition - 1] = 0;
                                gameBoardMatrix[rows - 2, playerOnePosition + 2] = 4;

                                MapScreen(rows - 2, playerOnePosition - 1, 0);
                                MapScreen(rows - 2, playerOnePosition + 2, 4);
                                playerOnePosition++;

                                if (!isPlaying)
                                {
                                    gameBoardMatrix[rows - 3, playerOnePosition - 1] = 0;
                                    MapScreen(rows - 3, playerOnePosition - 1, 0);

                                    gameBoardMatrix[rows - 3, playerOnePosition] = 3;
                                    MapScreen(rows - 3, playerOnePosition, 3);
                                    ballPositionY++;
                                }
                            }
                        }

                        else if (ki.Key == ConsoleKey.LeftArrow)
                        {
                            if (playerOnePosition - 4 >= 0)
                            {
                                gameBoardMatrix[rows - 2, playerOnePosition - 2] = 4;
                                gameBoardMatrix[rows - 2, playerOnePosition + 1] = 0;

                                MapScreen(rows - 2, playerOnePosition + 1, 0);
                                MapScreen(rows - 2, playerOnePosition - 2, 4);
                                playerOnePosition--;

                                if (!isPlaying)
                                {
                                    gameBoardMatrix[rows - 3, playerOnePosition + 1] = 0;
                                    MapScreen(rows - 3, playerOnePosition + 1, 0);

                                    gameBoardMatrix[rows - 3, playerOnePosition] = 3;
                                    MapScreen(rows - 3, playerOnePosition, 3);
                                    ballPositionY--;

                                }
                            }

                            if (playerOnePosition - 3 >= 0)
                            {
                                gameBoardMatrix[rows - 2, playerOnePosition - 2] = 4;
                                gameBoardMatrix[rows - 2, playerOnePosition + 1] = 0;

                                MapScreen(rows - 2, playerOnePosition + 1, 0);
                                MapScreen(rows - 2, playerOnePosition - 2, 4);
                                playerOnePosition--;

                                if (!isPlaying)
                                {
                                    gameBoardMatrix[rows - 3, playerOnePosition + 1] = 0;
                                    MapScreen(rows - 3, playerOnePosition + 1, 0);

                                    gameBoardMatrix[rows - 3, playerOnePosition] = 3;
                                    MapScreen(rows - 3, playerOnePosition, 3);
                                    ballPositionY--;

                                }
                            }
                        }
                        else if (ki.Key == ConsoleKey.A)
                        {
                            if (playerTwoPosition - 4 >= 0)
                            {
                                gameBoardMatrix[1, playerTwoPosition - 2] = 5;
                                gameBoardMatrix[1, playerTwoPosition + 1] = 0;

                                MapScreen(1, playerTwoPosition + 1, 0);
                                MapScreen(1, playerTwoPosition - 2, 5);
                                playerTwoPosition--;


                            }
                            if (playerTwoPosition - 3 >= 0)
                            {
                                gameBoardMatrix[1, playerTwoPosition - 2] = 5;
                                gameBoardMatrix[1, playerTwoPosition + 1] = 0;

                                MapScreen(1, playerTwoPosition + 1, 0);
                                MapScreen(1, playerTwoPosition - 2, 5);
                                playerTwoPosition--;


                            }
                        }
                        else if (ki.Key == ConsoleKey.D)
                        {
                            if (playerTwoPosition + 4 < cols)
                            {
                                gameBoardMatrix[1, playerTwoPosition + 2] = 5;
                                gameBoardMatrix[1, playerTwoPosition - 1] = 0;

                                MapScreen(1, playerTwoPosition - 1, 0);
                                MapScreen(1, playerTwoPosition + 2, 5);
                                playerTwoPosition++;


                            }
                            if (playerTwoPosition + 3 < cols)
                            {
                                gameBoardMatrix[1, playerTwoPosition + 2] = 5;
                                gameBoardMatrix[1, playerTwoPosition - 1] = 0;

                                MapScreen(1, playerTwoPosition - 1, 0);
                                MapScreen(1, playerTwoPosition + 2, 5);
                                playerTwoPosition++;


                            }
                        }
                        else if (ki.Key == ConsoleKey.Spacebar)
                        {
                            ballDirection = 1;
                            isPlaying = true;
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                }
            }
            Console.ReadKey();
        }
    }
}
