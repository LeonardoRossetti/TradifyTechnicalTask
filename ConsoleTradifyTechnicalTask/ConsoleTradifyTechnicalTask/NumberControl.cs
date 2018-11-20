using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTradifyTechnicalTask
{
    public class NumberControl
    {
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
        public Random Random { get; set; }

        public NumberControl(Int32 MinNumber, Int32 MaxNumber)
        {
            this.MinNumber = MinNumber;
            this.MaxNumber = MaxNumber;
            Random = new Random();
        }

        public Int32 GetRandom()
        {
            return Random.Next(MinNumber, MaxNumber);
        }

        /// <summary>
        /// Verify if the number have incremental digits, e.g. 1234, or 1248
        /// </summary>
        public Boolean HaveIncrementalNumber(String number)
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
        public Boolean HaveRepeatedDigit(String number)
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

        /// <summary>
        /// Returns a list of unique numbers. 
        /// The numbers doesn't have repeated digits or Incremental Numbers
        /// </summary>
        public List<Int32> GetUniquePinList()
        {
            List<Int32> uniquePinList = new List<Int32>();
            
            while (uniquePinList.Count < 1000)
            {
                Int32 randomNumber = GetRandom();

                if (!uniquePinList.Contains(randomNumber)
                    && !HaveRepeatedDigit(randomNumber.ToString())
                    && !HaveIncrementalNumber(randomNumber.ToString()))
                {
                    uniquePinList.Add(randomNumber);                    
                }
            }

            return uniquePinList;
        }
    }
}
