using System;

namespace ManyMethods
{
    internal class Program
    {
        public static string kilograms;
        public static string killograms;

        public static int Total { get; private set; }

        public static void Main(string[] args)
        {
            hello();
        }

        public static void hello()
        {
            Console.WriteLine("Please enter your name");
            string x = Console.ReadLine();
            Console.WriteLine("Goodbye " + x);
            Console.ReadKey();
        }

        public static void addition(object Total, int Value1)
        {
            int value1 = 0;
            int value2 = 0;
            int value3 = 0;
            Console.Write("Enter a number");
            value1 = ConvertToInt32(Console.ReadLine());
            Console.Write("Enter another number");
            Total = (Value1 + value2);
            Console.Write("The total of (0) and {1} = {2}", value1, value2, value3, Total);
            _ = Console.ReadLine();

            Console.WriteLine("Enter a number");
            string FirstNumber = Console.ReadLine();
            Console.WriteLine("Please enter in second number");
            string SecondNumber = Console.ReadLine();
            Console.WriteLine("Please enter in third number");
            Console.ReadKey();
        }

        public static int ConvertToInt32(string v)
        {
            throw new NotImplementedException();
        }

        public static void catDog(string meow)
        {
            Console.WriteLine("Enter a cat");
            string cats = Console.ReadLine();
            Console.WriteLine("Enter a dog");
            string dog = Console.ReadLine();
            Console.WriteLine("Enter Barks");
            string Barks = Console.ReadLine();
            Console.WriteLine("Enter Meows");
            string Meows = Console.ReadLine();
        }

        public static void OddEvent()
        {
            int value1 = 0;
            int value2 = 0;
            int value3 = 0;
            Console.Write("Please enter a odd and even number");
            value1 = ConvertToInt32(Console.ReadLine());
            Console.Write("Enter another number");
            Total = (value1 + value2);
            Console.Write("The total of (0) and {1} = {2}", value1, value2, value3, Total);
            _ = Console.ReadLine();

            Console.WriteLine("Please enter a odd number");
            string OddNumber = Console.ReadLine();
            Console.WriteLine("Enter in even number");
            string EvenNumber = Console.ReadLine();
            Console.ReadKey();
        }

        public static void inches()
        {
            Console.WriteLine("Please enter a height in feet");
            string feet = Console.ReadLine();
            Console.WriteLine("Enter height in inches");
            string inches = Console.ReadLine();
            Console.ReadKey();
        }

        public static void Echo()
        {
            Console.WriteLine("Please enter the first word in all caps");
            string caps = Console.ReadLine();
            Console.WriteLine("Enter 2 more time in all lower case");
            string lowercase = Console.ReadLine();
            Console.ReadLine();
        }

        public static void killGrams()
        {
            Console.WriteLine("Please enter the weight in pounds");
            string pounds = Console.ReadLine();
            Console.WriteLine(pounds + "pounds is" + "kilograms.");
            string kilograms = Console.ReadLine();
        }

        public static void date()
        {
            Console.WriteLine("Please enter current date");
            string x = Console.ReadLine();
            Console.WriteLine("enter date" + x);
            Console.ReadLine();
        }

        public static void age()
        {
            Console.WriteLine("Please enter your birth year");
            string birthyear = Console.ReadLine();
            Console.WriteLine("Enter your age");
            string age = Console.ReadLine();
        }

        public static void guess()
        {
            Console.WriteLine("Please enter CORRECT");
            string CORRECT = Console.ReadLine();
            Console.WriteLine("Enter WRONG");
            string WRONG = Console.ReadLine();
        }




    }
}

