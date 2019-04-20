using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClient.ComplexCalculatorReference;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexCalculatorClient client = new ComplexCalculatorClient("BasicHttpBinding_IComplexCalculator");

            ComplexNumber complexOne = new ComplexNumber { real = 1.2, imaginary = 3.4 };
            ComplexNumber complexTwo = new ComplexNumber { real = 1.2, imaginary = 3.4 };

            Console.WriteLine("\nClient operations: ");

            string complexOneString = FormatComplex(complexOne);
            string complexTwoString = FormatComplex(complexTwo);

            string addString = FormatComplex(client.add(complexOne, complexTwo));
            string subString = FormatComplex(client.sub(complexOne, complexTwo));
            string multString = FormatComplex(client.mult(complexOne, complexTwo));
            string divString = FormatComplex(client.div(complexOne, complexTwo));

            Console.WriteLine($"Addition: {complexOneString} + {complexTwoString} = {addString}");
            Console.WriteLine($"Subtraction: {complexOneString} - {complexTwoString} = {subString}");
            Console.WriteLine($"Multiplication: {complexOneString} * {complexTwoString} = {multString}");
            Console.WriteLine($"Division: {complexOneString} / {complexTwoString} = {divString}");

            client.Close();
        }

        static string FormatComplex(ComplexNumber number)
        {
            return $"{number.real} + {number.imaginary}i";
        }
    }
}
