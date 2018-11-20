using System;
using System.Collections.Generic;

namespace ConsoleTradifyTechnicalTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            NumberControl numberControl = new NumberControl(1000, 9999);

            List<Int32> uniquePinList = numberControl.GetUniquePinList();

            for (int i = 0; i < uniquePinList.Count; i++)
            {
                Console.WriteLine(String.Format("ID({0}): {1}", i, uniquePinList[i]));
            }
            
            Console.ReadKey();
        }
    }
}
/*
 The exercise here is to return a list of 1000 unique pin numbers which meets the criteria set out below:
• Pin numbers must:
o Be 4 Digits
o Cannot have incremental digits, e.g. 1234, or 1248
o Cannot have repeated digits, e.g. 8888, or 8863
• In the list of 1000, we cannot have repeated pin numbers (this is the unique criteria)
*/
