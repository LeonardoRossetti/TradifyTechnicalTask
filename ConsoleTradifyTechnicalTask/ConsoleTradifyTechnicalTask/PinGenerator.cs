using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTradifyTechnicalTask
{
    public class PinGenerator
    {
        public PinGenerator()
        {
            
        }
        
        /// <summary>
        /// Verify if the pin has incremental digits, e.g. 1234, or 1248
        /// </summary>
        public Boolean HasIncrementalDigits(String Pin)
        {
            Char[] pinDigits = Pin.ToCharArray();

            for (Int32 i = 1; i < pinDigits.Length; i++)
            {
                Int32 previousDigit = Convert.ToInt32(pinDigits[i - 1].ToString());
                Int32 currentDigit = Convert.ToInt32(pinDigits[i].ToString());

                if ((previousDigit + 1) == currentDigit)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verify if the pin has repeated digits, e.g. 8888, or 8863
        /// Including if a digit is repeated anywhere in the pin, e.g. 8528
        /// </summary>
        /// <param name="Pin">The number of digits in each pin.</param>
        /// <returns>Returns if the pin contains digits that occur more tha once. </returns>
        public Boolean HasRepeatedDigits(String Pin)
        {
            Char[] pinDigits = Pin.ToCharArray();

            for (Int32 i = 0; i < pinDigits.Length; i++)
            {
                Char currentDigit = pinDigits[i];

                IEnumerable<Char> matchedDigits = from digit in pinDigits
                                 where digit == currentDigit
                                 select digit;
                
                if (matchedDigits.Count() > 1)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// The pins are generated according to the following criteria:
        /// o Be 4 Digits
        /// o Cannot have incremental digits, e.g. 1234, or 1248 
        /// o Cannot have repeated digits, e.g. 8888, or 8863 (including if a digit is repeated anywhere in the pin, e.g. 8528)
        /// o In the list of 1000, we cannot have repeated pin numbers(this is the unique criteria)
        /// </summary>
        /// <param name="quantity">The number of pins that will be generated.</param>
        /// <param name="PinLength">The number of digits in each pin.</param>
        /// <returns>Returns a list of unique pins. </returns>
        public List<Int32> GeneratePins(Int32 Quantity, Int32 PinLength)
        {
            Random random = new Random();

            if (Quantity < 1)
            {
                throw new ArgumentException("Value should be 1 or greater.", "Quantity");
            }
            else if (PinLength < 1)
            {
                throw new ArgumentException("Value should be 1 or greater.", "PinLength");
            }
                
            List<Int32> pins = new List<Int32>();

            Int32 rangeMin = (Int32)(Math.Pow(10, PinLength - 1));
            Int32 rangeMax = (Int32)(Math.Pow(10, PinLength)) - 1;

            //maxPossiblePins does not take into account repeated or incremental digits
            Int32 maxPossiblePins = rangeMax - rangeMin + 1;

            if (Quantity > maxPossiblePins)
            {
                throw new Exception("Quantity exceds maximum possibilities available.");
            } 

            while (pins.Count < Quantity)
            {
                Int32 pin = random.Next(rangeMin, rangeMax);

                if (!pins.Contains(pin)
                    && !HasRepeatedDigits(pin.ToString())
                    && !HasIncrementalDigits(pin.ToString()))
                {
                    pins.Add(pin);
                }
            }

            return pins;
        }
    }
}
