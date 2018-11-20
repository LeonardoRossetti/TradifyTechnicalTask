using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTradifyTechnicalTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            int _min = 1000;
            int _max = 9999;
            Random _random = new Random();

            List<Int32> list = new List<Int32>();
            int a = 0;
            while(list.Count < 1000)
            {
                a++;

                Int32 randomNumber = _random.Next(_min, _max);

                if (!list.Contains(randomNumber) 
                    && !HaveIncrementalNumber(randomNumber.ToString())
                    && !HaveRepeatedDigit(randomNumber.ToString()))
                {
                    list.Add(randomNumber);
                    Console.WriteLine(randomNumber);
                }

                if (a == 10000)
                {
                    Console.WriteLine("Take care!");
                    break;
                }
            }
            
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        /// <summary>
        /// Verify if the number have incremental digits, e.g. 1234, or 1248
        /// </summary>
        public static Boolean HaveIncrementalNumber(String number)
        {
            Char[] values = number.ToCharArray();

            for (int i = 1; i < values.Length; i++)
            {
                Int32 previousValue = Convert.ToInt32(values[i - 1].ToString());
                Int32 currentValue = Convert.ToInt32(values[i].ToString());

                if ((previousValue + 1) == currentValue)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verify if the number have repeated digits, e.g. 8888, or 8863
        /// </summary>
        public static Boolean HaveRepeatedDigit(String number)
        {
            Char[] values = number.ToCharArray();

            for (int i = 0; i < values.Length; i++)
            {

                Char currentNumber = values[i];
  
                var matchQuery = from value in values
                                 where value == currentNumber
                                 select value;

                //If there are more than one reference of currentNumber in number
                if (matchQuery.Count() > 1)
                {
                    return true;
                }
            }

            return false;
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
