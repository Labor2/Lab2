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
        // REQUIREMENT: Calculate and sum all NETO values from .txt file (file can contain gross, neto or invalid values)
        static void Main(string[] args)
        {

            Console.WriteLine(CalculateFromFile());

        }

        public static double CalculateFromFile()
        {
            double sum = 0;

            using (StreamReader reader = new StreamReader("salaries.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string tempLine;
                    tempLine = reader.ReadLine();

                    if (tempLine != "")
                    {
                        Char firstChar = tempLine[0]; //first char
                        String numbers = tempLine.Substring(1, tempLine.Length - 1); //rest of the values

                        if (firstChar == 'G' && numbers.All(char.IsDigit))
                        {
                            double netoSalary = CalculateNetoSalary(numbers);
                            sum = sum + netoSalary;

                        }
                        else if (firstChar == 'N' && numbers.All(char.IsDigit))
                        {
                            sum = sum + Convert.ToDouble(numbers);
                        }
                    }
                }
            }

            return sum;
        }
        public static double CalculateNetoSalary(string inputNumbers)
        {
            double number = double.Parse(inputNumbers);
            return (number - (number * 0.236));
        }
    }
}
