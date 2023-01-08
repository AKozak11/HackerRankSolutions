using System;
using System.Linq;

namespace SuperDigit
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }


        public static int SuperDigit(string n, int k)
        {
            if (n is null)
            {
                n = "0";
            }
            if (n.Length == 1)
            {
                return Int32.Parse(n);
            }

            Int64 superD = 0;
            for (int i = 0; i < n.Length; i++)
            {
                superD += Int64.Parse(n[i].ToString());
            }

            return SuperDigit((superD * k).ToString(), 1);
            // string p = string.Empty;
            // if (n is null)
            // {
            //     return 0;
            // }

            // if (n.Length == 1)
            // {
            //     return Int32.Parse(n);
            // }

            // if (k < 1) return 0;
            // for (int i = 0; i < k; i++)
            // {
            //     p += n;
            // }

            // List<int> intList = new List<int>();
            // foreach (char c in p)
            // {
            //     intList.Add(Int32.Parse(c.ToString()));
            // }
            // int superD = intList.Aggregate((a, b) => a + b);

            // return SuperDigit(superD.ToString(), 1);

        }
    }
}