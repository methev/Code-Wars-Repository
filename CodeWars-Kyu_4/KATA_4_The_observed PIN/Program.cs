using System.Text;
using System.Collections.Generic;
using System;

//! OOP aproach!!!!

public class Kata
{
    public static List<string> GetPINs(string observed)
    {

        List<string> result = new List<string>();

        Dictionary<int, int[]>  kp = new Dictionary<int, int[]>()       //Key Pad Dictionary
        {
            {1, new int[]{1,2,4}},
            {2, new int[]{1,2,3,5}},
            {3, new int[]{2,3,6}},
            {4, new int[]{1,4,5,7}},
            {5, new int[]{2,4,5,6,8}},
            {6, new int[]{3,5,6,9}},
            {7, new int[]{4,7,8}},
            {8, new int[]{5,7,8,9,0}},
            {9, new int[]{6,8,9}},
            {0, new int[]{0,8}}
        };
        int ol = observed.Length;                                     //input string length
        int[][] obsCombi = new int [ol][];

        int[] obsArr = new int[ol];                                   //input string splitted into individual digits
        obsArr = StrToIntArr(observed);

        StringBuilder strBld = new StringBuilder();                   //Build string as result
        List<string> lstBld = new List<string>();

        int allPINCombi = 1;                                          //all PIN combinations

        for (int i = 0; i < ol; i++)                                  //assign Dict values to corespondent place in jagged array
        {
            obsCombi[i] = kp[obsArr[i]];
            allPINCombi *= obsCombi[i].Length;
        }

        PtrClass[] blocks = new PtrClass[ol];                         //Create Array of objects


        //! INIT objects in Array                                                
        for (int feC = 0; feC < ol; feC++)
        {
            blocks[feC] = new PtrClass(obsCombi[feC]);
        }
        //! ----------------------

        //! Calculation based on POINTER
        for (int y = 0; y < allPINCombi; y++)
        {


            for (int i = 0; i < ol; i++)
            {
                int accuPtr = blocks[i].Pointer;
                strBld.Append(obsCombi[i][accuPtr]);
            }

            lstBld.Add(strBld.ToString());

            strBld.Clear();

            for (int check = ol-1; check >= 0; check--)
            {
                if (blocks[check].Reached == false)
                {
                    blocks[check].Pointer++;
                    break;
                }
                else
                {
                    blocks[check].PointerToStart();
                    blocks[check].Reached = false;

                }
            }
        }
        //! ----------------------

        return lstBld;

    }

    //! Method to convert string into int[], every char to separate array cell
    private static int[] StrToIntArr(string inStr)                    
    { 
        int     loop = 0;
        int[]   result = new int[inStr.Length];

        foreach (var item in inStr)
        {                
            result[loop] = item - '0';      //CHAR to INT
            loop++;
        }
        return result;
    }
    //! ----------------------
}

//! Class represent all variations of adjacent digits
public class PtrClass
{

    public int Lvl { get; set; }
    public int ArrLen
    {
        get { return _item.Length; }
    }


    private int _pointer = 0;
    public int Pointer
    {
        get { return _pointer; }
        set { _pointer = value; }
    }
    private bool _reached = false;
    public bool Reached
    {
        get {
            if ( _pointer == (ArrLen - 1)){
                return true;
            } else{
                return false;
            }
            }
        set { _reached = value; }
    }

    private int[] _item;

    public PtrClass(int [] item)
    {
        _item = item;
    }
}
//! ----------------------

//! Extension method of PtrClass type - Pointer to zero
public static class ExtMethods
{
    public static void PointerToStart(this PtrClass prop)
    {
        prop.Pointer = 0;
    }
}
//! ----------------------