using System;
using System.Collections.Generic;

namespace ConsoleTradifyTechnicalTask
{
    /// <summary>
    ///  The exercise here is to return a list of 1000 unique pin numbers which meets the criteria set out below:
    ///  • Pin numbers must:
    ///  o Be 4 Digits
    ///  o Cannot have incremental digits, e.g. 1234, or 1248 1489 9851
    ///  o Cannot have repeated digits, e.g. 8888, or 8863
    ///  • In the list of 1000, we cannot have repeated pin numbers(this is the unique criteria)
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PinGenerator pinGenerator = new PinGenerator();

                List<Int32> pins = pinGenerator.GeneratePins(1000, 4);

                for (Int32 i = 0; i < pins.Count; i++)
                {
                    Console.WriteLine(String.Format("ID({0}): {1}", i + 1, pins[i]));
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("{0}. Parameter: {1}", ex.Message, ex.ParamName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}