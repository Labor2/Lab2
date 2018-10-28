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
        // salaries.txt contains only one bruto value per row. Returns neto for each row
        // REQUIREMENT: Calculate BRUTO to NETO from value in .txt file
        static void Main(string[] args)
        {
            string tempLine;
            
            using (StreamReader reader = new StreamReader("salaries.txt"))
            {
                    while (!reader.EndOfStream)
                    {
                        tempLine = reader.ReadLine();

                        double netoSalary = CalculateNetoSalary(tempLine);
                        if (netoSalary < 0)
                        {
                            Console.WriteLine("Value is incorrect");
                        }
                        else
                        {
                            Console.WriteLine(netoSalary);
                        }
                }
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
