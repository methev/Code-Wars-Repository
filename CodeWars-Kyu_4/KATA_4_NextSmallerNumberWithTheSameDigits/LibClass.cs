using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using System.Diagnostics;

namespace KATA4NextSmallerNumberWithTheSameDigits
{
    public class LibClass
    {   
        //Permutes methods global variables
        public static int LIST_COUNTER = 0;
        
        public static long LAST_GLOB = 0;
        public static long ORIGINAL_N =0;

        /// <summary>
        /// Permutation method
        /// </summary>
        /// <param name="str"></param>
        /// <param name="l">l starting index</param>
        /// <param name="r">r end index</param>
        public static void Permutes(string str, int l, int r, long last, long origin)
        {
            long current = Convert.ToInt64(str);
            if (l == r)
            {
                if (LIST_COUNTER >=1000)
                {
                    if(LIST_COUNTER == 300)
                    {
                    Console.WriteLine("!!!!!");
                    }
                }
                else
                {
                    if (ORIGINAL_N > current && current > LAST_GLOB)
                    {
                        LAST_GLOB = current;
                    }

                Console.WriteLine(str);

                LIST_COUNTER++;
                }

            }
            else 
            {
                for (int i = l; i <= r; i++) 
                {
                    str = swap(str, l, i);
                    Permutes(str, l + 1, r, last, origin);
                    str = swap(str, l, i);

                }
            }
        }
        
        /// <summary>
        /// Swap characters in string
        /// </summary>
        /// <param name="a">input string</param>
        /// <param name="i">first INDEX</param>
        /// <param name="j">second INDEX</param>
        /// <returns></returns>
        public static String swap(String a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }
   

        /// <summary>
        /// True when numbers in array keep increasing
        /// </summary>
        /// <param name="n">int[]</param>
        /// <returns></returns>
        private static bool IsRised(int[] n)
        {
            int counter = 0;

            foreach (var item in n)
            {
                if (counter >= 1)
                {
                    if (item < n[counter-1])
                    {
                        return false;
                    }
                }

                counter ++;
            }
            return true;
        }
/* */
        /// <summary>
        /// CombinationWithoutRepetition -  formula
        /// </summary>
        /// <param name="n">n Faktor</param>
        /// <param name="k">k Faktor</param>
        /// <returns>int</returns>
           public static int CombinationWithoutRepetition(int n, int k)
        {
            int nFactor = Factorial(n);
            int kFactor = Factorial(k);

            int result= nFactor / (kFactor * Factorial(n-k));
            return result;

        }
   
        /// <summary>
        /// Factorial - 
        /// </summary>
        /// <param name="f"></param>
        /// <returns>intiger</returns>
        public static int Factorial(int f)
        {
        if(f == 0)
            return 1;
        else
            return f * Factorial(f-1); 
        }
    
    
    
    }
}