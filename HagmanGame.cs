using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class HagmanGame
    {
        private bool keepPlaying;
        private int guessingLeft;
        private string answer;
        private int lettersFound;

        private string[] guessedLetters;
        private int guessedLettersIndex;

        private string[] wordDisplay;

        public void play()
        {
            SetUp();
            while (keepPlaying)
            {
                DisplayPuzzle();
                
                PromptUser();
            }

           DisplayResult();
        }

        private void PromptUser()
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.Write("Guess a letter or the whole words: ");
                validInput = ParseInput(Console.ReadLine().ToUpper());
            }

            Console.WriteLine("\nPress enter to continue.");
            Console.ReadLine();
        }

        private bool ParseInput(string input)
        {
            if (input.Length > 1)
            {
                if(input == answer)
                {
                    Console.WriteLine("That is correct!");
                    keepPlaying = false;
                    return true;
                }

                Console.WriteLine("Wrong answer!");
                guessingLeft--;
            }
            else
            {
                if (guessedLetters.Contains(input))
                {
                    Console.WriteLine("You already guessed {0}", input);
                    return false;
                }

                bool foundLetterAtLeastOnce = false;
                for (int i = 0; i < answer.Length; i++)
                {
                    if (input == answer[i].ToString())
                    {
                        foundLetterAtLeastOnce = true;
                        lettersFound++;
                        wordDisplay[i] = input;
                    }
                }

                if (foundLetterAtLeastOnce)
                {
                    Console.WriteLine("That was a good guess!");
                    if (lettersFound == answer.Length)
                    {
                        keepPlaying = false;
                    }
                }
                else
                {
                    Console.WriteLine("No, that letter was not found!");
                    guessingLeft--;
                }
            }
            guessedLetters[guessedLettersIndex] = input;
            guessedLettersIndex++;

            if (guessingLeft == 0)
            {
                keepPlaying = false;
            }
            return true;
        }

        private void DisplayResult()
        {
            if (guessingLeft > 0)
            {
                Console.WriteLine("You guessed the word!");
            }
            else
            {
                Console.WriteLine("You lose! The word was: {0}", answer);
            }
        }

        private void DisplayPuzzle()
        {
            Console.WriteLine("\nPuzzle: ");
            for (int i = 0; i < wordDisplay.Length; i++)
            {
                Console.Write("{0}", wordDisplay[i]);
            }
            Console.WriteLine("\n\nYou have {0} guesses left.\n", guessingLeft);
        }

        private void SetUp()
        {
            guessingLeft = 5;
            keepPlaying = true;
            guessedLetters = new string[26];
            guessedLettersIndex = 0;
            GetWordFromPlayer();
            CreateWordDisplay();
        }

        private void CreateWordDisplay()
        {
            wordDisplay = new string[answer.Length];
            for (int i = 0; i < wordDisplay.Length; i++)
            {
                wordDisplay[i] = "_ ";
            }
        }

        private void GetWordFromPlayer()
        {
            Console.Write("Enter the word to guess (have the other person look away!): ");
            answer = Console.ReadLine().ToUpper();
            Console.Clear();
        }
    }
}
