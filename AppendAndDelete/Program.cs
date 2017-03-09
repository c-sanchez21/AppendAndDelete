using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppendAndDelete
{
    /*
    Problem:
    Given an integer, k, and two strings, s and t, 
    determine whether or not you can convert s to t 
    by performing exactly k operations of append and delete on t.
    If it's possible, print Yes; otherwise, print No.
    */
    class Program
    {
        static void Main(string[] args)
        {
            int k = 6;
            string s = "qwerasdf";
            string t = "qwerbsdf";
            string result = CanAppendAndDelete(s, t, k) ? "Yes" : "No";
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static bool CanAppendAndDelete(string s, string t, int k)
        {
            //Logic: t can be completely deleted and appened into s
            //any exra moves can be offseted by doing an extra delete when t is empty;
            if (k >= s.Length + t.Length) return true;

            int longestMatch = 0;//variable to hold how many chars are the same

            //Get the length of the shorter of the two strings
            int shortest = Math.Min(s.Length, t.Length);

            //Count how many chars are the same
            for (int i = 0; i < shortest; i++)
                if (s[i] == t[i])
                    longestMatch++;
                else break;

            int deletesNeeded = t.Length - longestMatch;
            int appendsNeeded = s.Length - longestMatch;
            int remaining = k - (deletesNeeded + appendsNeeded);

            //Logic: If the number of appends and deletes is less than or equal to k 
            //and any reminaing moves can be offseted by doing a delete and append (i.e mod 2)
            //then return true;
            return (remaining >= 0 && remaining % 2 == 0);
        }
    }
}
