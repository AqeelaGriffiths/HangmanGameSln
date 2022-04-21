using System;
using Hangman.Core.Game;
using System.Collections.Generic;
using System.Text;
using static System.Random;

namespace HangmanGameConsole
{
    internal class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }

            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine(" |   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }

            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/  \\  |");
                Console.WriteLine("   ===");
            }


        }

        private static int printword(List<char> guessedLetters, String randomword)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomword) 
            {
                if (guessedLetters.Contains(c)) 
                {
                    Console.WriteLine(c + " ");
                    rightLetters++;
                }
                else
                {
                    Console.WriteLine(" ");
                }
                counter++;
            }
            return rightLetters;
        }

        private static void printLines(String randomword)
        {
            Console.WriteLine("\r");
            foreach ( char c in randomword)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine("\u0305");
            }
        }
       
        
        static void Main(string[] args)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 2);
            Console.Write("Welcome to Hangman!!");

            var hangman = new HangmanGame();
            hangman.Run();

            Console.ForegroundColor = oldColor;


            Console.SetCursorPosition(20, 25);
            Console.WriteLine("Thank you for playing");
            Console.ReadLine();

            Random random = new Random();
            List<String> wordDictionary = new List<string>
            {"pink","blue","turquoise","black","silver","green","olive","rosegold"," brown", "grey","yellow","orange","purple","white","red","plum","magenta","cyan","gold","lime"};
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            foreach (char x in randomWord )
            {
                Console.WriteLine("_ ");
            }

            int lengthOfTheWordToGuess = randomWord.Length;
            int amountOfTimeWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersGuessedRight = 0;

            while(amountOfTimeWrong !=6 && currentLettersGuessedRight !=lengthOfTheWordToGuess)
            {
                Console.WriteLine("\nLetters guessed so far : ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.WriteLine(letter + " ");
                }

                Console.WriteLine("\n Guess a letter: ");
                char letterGuessed = Console.ReadLine()[0];

                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.WriteLine("\r\nYou have already guessed this letter ");
                    printHangman(amountOfTimeWrong);
                    currentLettersGuessedRight = printword(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) { if (letterGuessed == i) { right = true; }

                        if (right)
                        {
                            printHangman(amountOfTimeWrong);
                            currentLettersGuessed.Add(letterGuessed);
                            currentLettersGuessedRight = printword(currentLettersGuessed, randomWord);
                            Console.WriteLine("\r\n");
                            printLines(randomWord);
                        }
                        else
                        {
                            amountOfTimeWrong++;
                            currentLettersGuessed.Add(letterGuessed);
                            printHangman(amountOfTimeWrong);
                            currentLettersGuessedRight = printword(currentLettersGuessed, randomWord);
                            Console.WriteLine("\r\n");
                            printLines(randomWord);
                        }
                }   }
            }
            
        }
    }
}
