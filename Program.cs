using System;
using System.Collections.Generic;

namespace Polynomials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program defines some polynomials and performs");
            Console.WriteLine("operations between them.");
            Console.WriteLine("");

            Polynomial[] polynomials = new Polynomial[4];
            // + 5 x^11 + 25 x^8 - 17 x^5
            polynomials[0] = new Polynomial();
            polynomials[0].Append(new Monomial(5, 11));
            polynomials[0].Append(new Monomial(25, 8));
            polynomials[0].Append(new Monomial(-17, 5));
            // + 2 x^4 - x^3 + 5 x - 5
            polynomials[1] = new Polynomial();
            polynomials[1].Append(new Monomial(2, 4));
            polynomials[1].Append(new Monomial(-1, 3));
            polynomials[1].Append(new Monomial(5, 1));
            polynomials[1].Append(new Monomial(-5, 0));
            // + 15 x^11
            polynomials[2] = new Polynomial();
            polynomials[2].Append(new Monomial(15, 11));
            // + 1
            polynomials[3] = new Polynomial();
            polynomials[3].Append(new Monomial(1, 0));

            Console.WriteLine("POLYNOMIALS AND THEIR PROPERTIES");
            Console.WriteLine();
            for (int i = 0; i < polynomials.Length; i++)
            {
                Console.WriteLine("P" + (i+1) + "(x) = " + polynomials[i].ToString());
                Console.WriteLine("* Coefficients: " + ListDoubleToString(polynomials[i].Coefficients));
                Console.WriteLine("* Exponents:" + ListIntToString(polynomials[i].Exponents));
                Console.WriteLine("* Degree:" + polynomials[i].Degree);
                Console.WriteLine();
            }

            Console.WriteLine("EVALUATION OF POLYNOMIALS");
            Console.WriteLine();
            double[] values = new double[] {-2.4, -1.7, 0, 1, 3, 7.7};
            foreach (double value in values)
            {
                Console.WriteLine("P1(" + value + ") = " + polynomials[0].Evaluate(value));
                Console.WriteLine("P2(" + value + ") = " + polynomials[1].Evaluate(value));
                Console.WriteLine("P3(" + value + ") = " + polynomials[2].Evaluate(value));
                Console.WriteLine("P4(" + value + ") = " + polynomials[3].Evaluate(value));
                Console.WriteLine();
            }

            Console.WriteLine("OPERATION BETWEEN POLYNOMIALS");
            Console.WriteLine();
            for (int i = 0; i < polynomials.Length; i++)
            {
                for (int j = i+1; j < polynomials.Length; j++)
                {
                    Console.WriteLine("P" +(i+1) + "(x) and P" + (j+1) + "(x)");
                    Console.WriteLine("* SUM: " + polynomials[i].Add(polynomials[j]).ToString());
                    Console.WriteLine("* DIFFERENCE: " + polynomials[i].Subtract(polynomials[j]).ToString());
                    Console.WriteLine("* PRODUCT: " + polynomials[i].Multiply(polynomials[j]).ToString());
                    Console.WriteLine();
                }
            }

            Console.WriteLine("");
            Console.WriteLine("THANK YOU FOR USING THIS PROGRAM!");

            Console.ReadLine();
        }

        // This is an auxiliary method to print a list of doubles.
        static string ListDoubleToString(List<double> list)
        {
            string result = "[";
            foreach (double e in list)
            {
                result += (e.ToString() + ",");
            }
            return result.Substring(0, result.Length - 1) + "]";
        }

        // This is an auxiliary method to print a list of integers.
        static string ListIntToString(List<int> list)
        {
            string result = "[";
            foreach (int e in list)
            {
                result += (e.ToString() + ",");
            }
            return result.Substring(0, result.Length - 1) + "]";
        }
    }
}
