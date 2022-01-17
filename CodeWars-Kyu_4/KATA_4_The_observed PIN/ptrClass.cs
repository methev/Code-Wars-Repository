// using System.ComponentModel;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace KATA4TheobservedPIN
// {
//     public class PtrClass
//     {

//         public int Lvl { get; set; }
//         // public int[] Item { get; set; }
//         public int ArrLen
//         {
//             get { return _item.Length; }
//         }


//         private int _pointer = 0;
//         public int Pointer
//         {
//             get { return _pointer; }
//             set { _pointer = value; }
//         }
//         private bool _reached = false;
//         public bool Reached
//         {
//             get {
//                 if ( _pointer == (ArrLen - 1)){
//                     return true;
//                 } else{
//                     return false;
//                 }
//                 }
//             set { _reached = value; }
//         }
        
//         private int[] _item;


//         // public int[] Item
//         // {
//         //     get { return _item; }
//         //     set { _item = value; }
        
        
//         public PtrClass(int [] item)
//         {
//             _item = item;
//         }

//     }
// }

