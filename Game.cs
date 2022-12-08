using System;

namespace Spaceman{

    class Game
    {
        public void Greet()
        {
            Console.WriteLine("Save yout friend by guessing the word");
        }
        //Fields
        private string codeword; // Word to guess
        private string currentWord; // being filled
        private int maxGuess;//max  number of wrong guesses to loose
        private int numWrong; // Curent number of wrong guesses
        private string[] wordarr; //Initial array of words from where to select a radom value

        Ufo f= new Ufo(); // Instance of class Ufo
        Random rand=new Random();

        // Constructor
        public Game(string[] wordarr)
        {
            this.codeword=wordarr[rand.Next(wordarr.Length)];

            this.maxGuess=5;
            this.numWrong=0;

             for (int i = 0; i < codeword.Length; i++)
             {
                 currentWord=currentWord+"_";
             }
        }

        public bool DidWin()
        {
            return codeword.Equals(currentWord);
        } 

        public bool DidLose()
        {
            return numWrong>=maxGuess;
        } 

        public void  Display()
        {
             Console.WriteLine(f.Stringify());
             Console.WriteLine("Current word:  "+ currentWord);
             Console.WriteLine("Guesses remaining:  "+ (maxGuess-numWrong));
        }

        public void  Ask()
        {
              string guess;
            Console.WriteLine("Guess a letter:");
            guess = Console.ReadLine();

            while (guess.Length!=1)
            {
               Console.WriteLine("Input only one letter at a time and press enter");
               guess = Console.ReadLine();
            }
           char character = char.Parse(guess); 

           //Do loop
            Boolean result = codeword.Contains(character);
            if (result==true)
            {
                Console.WriteLine("Well done");
                for (int i = 0; i < codeword.Length; i++)
                {
                    if (codeword[i]==character)
                    {
                        currentWord = currentWord.Remove(i, 1).Insert(i, guess);
                       //  Console.WriteLine(currentWord);
                    } 
                }
            }else
            {
                  Console.WriteLine("Wrong");
                  numWrong++;
                  Console.WriteLine(numWrong);
                  f.AddPart();
            }
        }

        public bool Contains(char character)
        {   
            Boolean result = codeword.Contains(character);
            return result;
        }
    }
}


              