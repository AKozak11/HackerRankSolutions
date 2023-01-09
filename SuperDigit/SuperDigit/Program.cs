using System;
using System.Linq;

namespace SuperDigit
{
    public class Program
    {
        public static long SuperDigit(string n, int k)
        {
            if (n is null) n = "0";
            if (n.Length < 2) return Int64.Parse(n);

            Int64 superD = 0;
            for (int i = 0; i < n.Length; i++) superD += Int64.Parse(n[i].ToString());

            return SuperDigit((superD * (long)k).ToString(), 1);
        }
    }
}