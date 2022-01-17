using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using System.Diagnostics;

namespace KATA4NextSmallerNumberWithTheSameDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            long test1 = 36119868601116; //36119868166110

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            long out1 = Kata.NextSmaller(test1);

            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            
            
        }
    }

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public class Kata
    {
        public static long NextSmaller(long n)
        {
            //declarations
            long result;
            int nDigAmount;
            int resultDigAmount;
            int startIndex;

            //assignment
            nDigAmount = CountDigitsLong(n);                                        //Amount of digits in input var
            int[] nArrInt = new int[nDigAmount];                                    //define nArrInt length
            nArrInt = n.ToString().Select(t=>int.Parse(t.ToString())).ToArray();    // from STRING to INT[]
            resultDigAmount = 0;                                                    //INIT
            startIndex = FindStartIndex(nArrInt);                                   //Start index to find 'next smaller'

            if (nDigAmount == 1)                                                    // 1 digit case
            {
                return -1;
            }
            else                                                                    // more than 2 digits case
            { 
                if (nDigAmount >= 2)
                {
                FindSmaller(startIndex, ref nArrInt);                               // execute 'next smaller' algoritm
                }
                result = IntArrayToLong(nArrInt);                                   // INT[]  to LONG - result

                resultDigAmount = CountDigitsLong(result);                          // Check amount of digits of result -
                                                                                    //to avoid 0 situation
                if (result < n && nDigAmount == resultDigAmount)
                {
                    return result;
                }
                return -1;
            }
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private static int FindStartIndex(int[] n)
        {
            int nLen = n.Count() - 1;

            for (int i = nLen - 1; i >= 0; i--)
            {
                if (n[i] > n[i+1])
                {
                    return i ;
                }
            }
            return 0;
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // public static String swap(String a, int i, int j)
        // {
        //     char temp;
        //     char[] charArray = a.ToCharArray();
        //     temp = charArray[i];
        //     charArray[i] = charArray[j];
        //     charArray[j] = temp;
        //     string s = new string(charArray);
        //     return s;
        // }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public static bool NoSmaller(long n)
        {
            int CountDigits = n.ToString().Count();
            if(CountDigits == 1)
            {
                return true;
            }
            return false;
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private static int CountDigitsLong(long number)
        {
        int count = 0;
            while (number > 0)
            {
                number /= 10;
                count++;
            }
            return count;
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        /// <summary>
        /// Swap the values in positions 1 and 2 with each other. 
        /// </summary>
        /// <param name="input">Input Array</param>
        /// <param name="pos1">Position 1 in array.</param>
        /// <param name="pos2">Position 2 in array.</param>
        /// <typeparam name="TInput">This is the first generic argument.</typeparam>
        public static void SwapPositionsInArray<TInput>(ref TInput[] input, int pos1, int pos2)
        {
            TInput buff =  input[pos1];

            input[pos1] = input[pos2];
            input[pos2] = buff;
        }

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public static void FindSmaller(int strtIndex, ref int[] input)
        {
            int inLen = input.Count() - 1;
            int? accu1;
            int accu2;
            int i1_C = 0;
            int indexStart = strtIndex;

            for (int i1 = indexStart; i1 < inLen; i1++)
            {
                i1_C++;
                accu1 = null;
                accu2 = 0;

                for (int i2 = indexStart + i1_C ; i2 <= inLen; i2++)
                {
                    if(i1 == indexStart)
                    {
                        if (input[i2] < input[i1] && input[i2] >= accu2)
                        {
                            accu1 = i2;
                            accu2 = input[i2];
                        }
                    }
                    else if(i1 != indexStart)
                    {
                        if (input[i2] > input[i1] && input[i2] >= accu2)
                        {
                            accu1 = i2;
                            accu2 = input[i2];
                        }
                    }
                }

                if (accu1 != null)
                {
                    accu2 = accu1 ?? default(int); 
                    SwapPositionsInArray(ref input, i1, accu2);
                }
            }
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        public static long IntArrayToLong(int[] input)
        {
            string strAccu1;
            long outt = 0;

            strAccu1 = string.Join("",input);//input.ToString();
            outt = Convert.ToInt64(strAccu1);

            return outt;
        }
    }
}

