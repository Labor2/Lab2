using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading;
using System.IO;

namespace SimpleSalaries
{
    public class Program
    {
        // REQUIREMENT: Calculate NETO value from string in .txt file (file can contain gross, neto or invalid values)
        static void Main(string[] args)
        {
            string tempLine;

            using (StreamReader reader = new StreamReader("salaries.txt"))
            {
                while (!reader.EndOfStream)
                {
                    tempLine = reader.ReadLine();


                    Console.WriteLine(CalculateFromFile(tempLine));
                }
            }
            Console.ReadLine();
        }

        public static string CalculateFromFile(string tempLine)
        {
            if (!String.IsNullOrEmpty(tempLine) && tempLine.Length >= 2) {
                tempLine = tempLine.Trim();
                Char firstChar = tempLine[0]; //first char
                String numbers = tempLine.Substring(1, tempLine.Length - 1); //rest of the values

                if (firstChar == 'G' && numbers.All(char.IsDigit))
                {
                    double netoSalary = CalculateNetoSalary(numbers);
                    return netoSalary.ToString();

                }
                else if (firstChar == 'N' && numbers.All(char.IsDigit))
                {
                    return numbers;
                }
                else
                {
                    return "invalid";
                }
            } else {
                return "invalid";
            }
        }
        public static double CalculateNetoSalary(string inputNumbers)
        {
            if (inputNumbers.All(char.IsDigit))
            {
                double number = double.Parse(inputNumbers);
                if (number > 0)
                {
                    return (number - (number * 0.236));
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
