using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            PigLatin();
        }

        public static void PigLatin()
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            Console.WriteLine("Enter your word");
            string answer = Console.ReadLine();

            string firstLetter = answer.Substring(0, 1);
            string lastLetter = answer.Substring(answer.Length - 1, 1);
            int index = answer.IndexOfAny(vowels);
            string test = answer.Substring(0, index);

            string newWord = answer = answer.Substring(index) + test;


            if (answer.IndexOfAny(vowels) == -1) //no vowels
            {
                Console.WriteLine(newWord + "ay");
            }

            else if (firstLetter.IndexOfAny(vowels) == 0) //first letter is vowel
            {
                if (lastLetter.IndexOfAny(vowels) == 0)
                {
                    Console.WriteLine(answer + "yay");
                }
                else
                {
                    Console.WriteLine(answer + "ay");
                }
            }
            else // first letter is consanant
            {
                Console.WriteLine(newWord + "ay");
            }

            Console.WriteLine("Do you want to play again yes or no?");
            string playagain = Console.ReadLine().ToLower();
            if (playagain == "yes")
            {
                PigLatin();
            }
            else
            {
                Console.ReadLine();
            }


        }
    }
}