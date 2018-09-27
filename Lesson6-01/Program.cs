using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
       class Program
       {
        static void Main(string[] args)
        {
            MyArrayIntList<int> L = new MyArrayIntList<int>();

            for (int i = 0; i < 10; i++)
            {
                L.Add(i);
            }
            int[] arr = new int[30]; 
            L.RemoveAt(5);
            L.Remove(9);
            L.Contains(0);
            L.CopyTo(arr, 5);
            L.IndexOf(3);
            L.Insert(4,5);
            L.Clear();
            Console.ReadLine();



            
        }
    }
}
