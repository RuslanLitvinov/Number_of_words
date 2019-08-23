using System.Collections.Generic;

namespace Words_classes
{
    public interface IInputNumber
    {
        /// <summary>
        /// Создает разбивку строки inputString в коллекцию groups,
        /// где младшим индексам соответствуют младшие разряды числа в строке string_view, 
        /// </summary>
        List<string> Split(string inputString);
        void ValidateInputString(string input);
    }
}
