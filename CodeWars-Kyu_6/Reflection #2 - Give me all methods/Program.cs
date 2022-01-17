using System;

namespace KATA6Reflection2Givemeallmethods
{
    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Console.WriteLine("Hello World!");
    //     }
    // }
    public class Refl 
    {
        static void Main(string[] args) 
        { 
            Console.WriteLine(new Refl().Output());
            Console.WriteLine(new Refl().AddInts(1,2));
        } 
    
        public string Output()
        {
            return "Test-Output";
        }
    
        public int AddInts(int i1, int i2) 
        {
            return i1 + i2;
        }
    }

    
}
