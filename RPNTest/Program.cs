using System;
using System.Collections.Generic;
using System.Linq;

namespace RPNTest
{
    public class Program
    {
        public static List<int> primeNumList = new List<int>();
        public static List<int> resultListRPN = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the input number to calculate RPN: ");
            string input = Console.ReadLine();
            if (int.TryParse(input,out int inputNum))
            {
                if(inputNum > 0 && inputNum <= 2209)
                {
                    int result = getOutputRPN(inputNum);
                    Console.WriteLine("The result RPN output is: " + result);
                }
                else
                {
                    Console.WriteLine("Invalid input(Out of range).");
                }
            }
            else
            {
                Console.WriteLine("Invalid input(Wrong input type).");
            }
        }

        public static int getOutputRPN(int inputNum)
        {
            int primeNumLimit = 1000000;
            if(inputNum <= 500)
            {
                primeNumLimit = 650000;
            }

            if (inputNum > 500 && inputNum <= 1000)
            {
                primeNumLimit = 9000000;
            }

            if (inputNum > 1000 && inputNum <= 1100)
            {
                primeNumLimit = 30000000;
            }

            if (inputNum > 1100 && inputNum <= 1300)
            {
                primeNumLimit = 1200000000;
            }

            if (inputNum > 1300 && inputNum <= 1500)
            {
                primeNumLimit = 1500000000;
            }

            if (inputNum > 1500)
            {
                primeNumLimit = int.MaxValue;
            }

            bool[] primeNumArr = getPrimeNumBoolArr(primeNumLimit);
            for (int i = 2; i < primeNumLimit; i++)
                if (primeNumArr[i] == true)
                {
                    primeNumList.Add(i);
                }
            getRPN();
            resultListRPN.OrderBy(i => i);
            return resultListRPN[inputNum - 1];
        }

        public static void getRPN ()
        {
            foreach(int num in primeNumList)
            {
                checkPrime(num);
            }
        }

        public static void checkPrime(int input)
        {
            bool hasZeroNum = input.ToString().Contains(0.ToString());
            if (hasZeroNum == false)
            {
                bool isRPN = true;
                int numLength = input.ToString().Length;
                for (int b = 1; b < numLength; b++)
                {
                    int remainNum = int.Parse(input.ToString().Substring(b));
                    bool hasZeroRemainNum = remainNum.ToString().Contains(0.ToString());
                    if (hasZeroRemainNum == true)
                    {
                        isRPN = false;
                    }

                    if (primeNumList.Contains(remainNum) == false)
                    {
                        isRPN = false;
                    }
                }
                if (isRPN == true)
                {
                    resultListRPN.Add(input);
                }
            }
        }

        public static bool[] getPrimeNumBoolArr(int limit)
        {
            bool[] primeArr = new bool[limit + 1];
            for (int a = 2; a <= limit; a++) {
                primeArr[a] = true;
            } 

            for (int a = 2; a <= limit; a++)
            {
                if (primeArr[a])
                {
                    for (int b = a * 2; b <= limit; b += a)
                        primeArr[b] = false;
                }
            }
            return primeArr;
        }
    }
}
