using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_classes
{
    public class InputNumber : IInputNumber
    {
        public InputNumber()
        {
            ;
        }
        /// <summary>
        /// Создает разбивку строки inputString в коллекцию groups,
        /// где младшим индексам соответствуют младшие разряды числа в строке string_view, 
        /// </summary>
        public List<string> Split(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return null;           // !!!
            }

            var groups = new List<string>();
            string stringForSplit = inputString;
            int splitStep = 3;
            int beginPosForSplit = -1;
            while (stringForSplit.Length > splitStep)
            {   //Что бы получить столбик с нач.номером (нач) по известному количеству кол нужно нач = кон - кол +1
                // столбик с конечным номером кол всегда равен stringForSplit.Length -1
                beginPosForSplit = stringForSplit.Length - 1 - splitStep + 1;
                groups.Add(stringForSplit.Substring(beginPosForSplit));
                stringForSplit = stringForSplit.Remove(beginPosForSplit);
            }
            if (!string.IsNullOrEmpty(stringForSplit))
            {
                groups.Add(stringForSplit);     // Оставшиеся старшие разряды по числу меньше splitStep
            }

            return groups;    //  !!!
        }
        public void ValidateInputString(string input)
        {
            try
            {
                long number = long.Parse(input);
            }
            catch (FormatException)
            {
                throw new InvalidOperationException($"Входная строка <{input}> по заданию должна быть числом, целым");
            }
            catch (OverflowException)
            {
                throw new InvalidOperationException($"Число <{input}> слишком большое.");
            }
        }

    }
}
