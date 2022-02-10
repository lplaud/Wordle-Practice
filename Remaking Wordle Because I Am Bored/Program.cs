using System;

namespace WordleRipoff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
              __  __        __          __           _ _         _____ _                  
             |  \/  |       \ \        / /          | | |       / ____| |                 
             | \  / |_   _   \ \  /\  / /__  _ __ __| | | ___  | |    | | ___  _ __   ___ 
             | |\/| | | | |   \ \/  \/ / _ \| '__/ _` | |/ _ \ | |    | |/ _ \| '_ \ / _ \
             | |  | | |_| |    \  /\  / (_) | | | (_| | |  __/ | |____| | (_) | | | |  __/
             |_|  |_|\__, |     \/  \/ \___/|_|  \__,_|_|\___|  \_____|_|\___/|_| |_|\___|
                      __/ |                                                               
                     |___/                                                                                                                                                                                                                                              
            ");
            Console.WriteLine("Welcome to Lucas's ripoff of the popular game \"wordle\" because he was bored out of his mind in class.");
            bool wincon = false;
            string[] lines = GrabArray();
            while (!wincon)
            {
                string chosenWord = GetChosenWord();
                Console.WriteLine("The Word has been chosen");
                int guessCount = 0;
                bool correct = false;
                string[] wordle = { "|", "   ", "|", " ", "|", "   ", "|", " ", "|", "   ", "|", " ", "|", "   ", "|", " ", "|", "   ", "|"};
                while (guessCount < 6 && correct == false)
                {
                    Console.WriteLine("Guess " + guessCount + "/6");

                    if (guessCount == 0)
                    {
                        Console.WriteLine(" ___   ___   ___   ___   ___ ");
                        Console.WriteLine(string.Join("", wordle));
                        Console.WriteLine(" ---   ---   ---   ---   ---");
                    }
                    string guessInput = "IFTHISISTHESTRINGBADNEWS!!!";
                    bool invalid = true;
                    while (invalid)
                    {
                        Console.WriteLine("Please enter your guess");
                        guessInput = Console.ReadLine();
                        if (string.IsNullOrEmpty(guessInput))
                        {
                            Console.WriteLine("String is Null or Empty, Please try again.");
                        }
                        else if (guessInput.Length != 5)
                        {
                            Console.WriteLine("String needs to be 5 chars long");
                        }
                        else if (!lines.Contains(guessInput))
                        {
                            Console.WriteLine("Guess not on wordlist- retry");
                        }
                        else
                        {
                            invalid = false;
                        }
                    }
                    Console.WriteLine(" ___   ___   ___   ___   ___");
                    char[] guessArr = guessInput.ToCharArray();
                    char[] chosenArr = chosenWord.ToCharArray();

                    var emptyWordle = new string[wordle.Length];
                    wordle.CopyTo(emptyWordle, 0);
                    int currCount = 0;
                    for (int i = 0; i < wordle.Length; i++)
                    {
                        if(emptyWordle[i] == "   ")
                        {
                            Console.Write("|");
                            if (chosenArr[currCount].Equals(guessArr[currCount]))
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.Black;
                            }else if (chosenWord.Contains(guessArr[currCount]))
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                            Console.Write(" ");
                            emptyWordle[i] = " " + guessArr[currCount].ToString() + " ";
                            Console.Write(guessArr[currCount].ToString().ToUpper());
                            Console.Write(" ");
                            currCount++;
                            Console.ResetColor();
                            Console.Write("| ");
                        }
                    }
                    //Console.WriteLine(string.Join("", wordle));
                    Console.WriteLine("\n ---   ---   ---   ---   ---");
                    if (guessInput.Equals(chosenWord))
                    {
                        correct = true;
                        wincon = true;
                        Console.WriteLine("Great job! You got it correct in " + guessCount + " guesses!");
                        wincon = true;
                    }
                    guessCount++;
                }
                Console.WriteLine("Nice try! The word was " + chosenWord);
                Console.ReadKey();
            }
        }

        public static string[] GrabArray()
        {
            //Grabs everything from a text file and throws back an array
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\defnotthewordlelist.txt");
            return lines;
        }

        public static string GetChosenWord()
        {
            string[] words = GrabArray();
            Random random = new Random();
            int chosenNum = random.Next(words.Length);
            string chosenWord = words[chosenNum];
            return chosenWord;
        }
    }
}