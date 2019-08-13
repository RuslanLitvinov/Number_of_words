using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_classes
{
    class Program
    {
        static void Main()
        {
            var w = new Words();
            char gender;
            char cases;
            string inputNumberString; // 
            do
            {
                Console.WriteLine("Введите целое число ('q' - выход):");
                inputNumberString = Console.ReadLine();

                if (inputNumberString.ToLower() == "q")
                {
                    break;
                }

                try
                {
                    w.ValidateInputString(w.TransformInput(inputNumberString));

                    gender = Program.AskGender();
                    cases = Program.AskCases();
                    Console.WriteLine(w.ByWords(inputNumberString, gender, cases));
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Неверно задано выражение:");
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine();
            } while (inputNumberString.ToLower() != "q");
        }
        public static char AskGender()
        {
            string gender;
            for (; ; )
            {
                Console.WriteLine("Задайте род:");
                gender = Console.ReadLine().ToUpper();
                try
                {
                    Words.ValidateGender(gender[0]);
                    return char.ToUpper(gender[0]);     // !!!
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        public static char AskCases()
        {
            string cases;
            for (; ; )
            {
                Console.WriteLine("Задайте падеж:");
                cases = Console.ReadLine().ToUpper();
                try
                {
                    Words.ValidateCases(cases[0]);
                    return char.ToUpper(cases[0]);     // !!!
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
