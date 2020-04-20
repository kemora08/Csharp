using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            string answer = string.Empty;
            Dictionary<string, string> gradeBook = new Dictionary<string, string>();

            do
            {
                Console.WriteLine("Enter a student's name.");
                name = Console.ReadLine();
                Console.WriteLine("Enter the student's grades.");
                string grades = Console.ReadLine();

                gradeBook.Add(name, grades);
            } while (name.Equals("quit"));

            int lowestGrade = 0;
            int highestGrade = 0;
            foreach (var item in gradeBook)
            {
                Console.WriteLine($"{item.Key}\n"); // name != "quit"

                int[] singleGrades = Array.ConvertAll<string, int>(gradeBook[item.Key].Split(), Convert.ToInt32);

                lowestGrade = singleGrades.Min();
                highestGrade = singleGrades.Max();
                double average = singleGrades.Average();

                Console.WriteLine($"Highest grade = {highestGrade} Lowest Grade = {lowestGrade} Average = {average}");
            }
        }
    }
}