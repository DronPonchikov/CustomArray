using System;
using CustomArray;

namespace DebugArray
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomArray<int>  a = new CustomArray<int> (-3, 6);
            Console.WriteLine(a.First + a.Last + a.Length);
            Console.ReadLine();
        }
    }
}
