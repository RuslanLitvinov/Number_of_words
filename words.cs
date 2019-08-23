using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_classes
{
    public class Words
    {
        private readonly IInputNumber inputNumber;
        private readonly INumberLinguist numberLinguist;
        /// <summary>
        /// Временный конструктор для модульных тестов
        /// TODO: перейти на абстрактную фабрику
        /// </summary>
        public Words()
        {
            inputNumber = new InputNumber();
            numberLinguist = new NumberLinguistRus();
        }
        public Words(IInputNumber oInputNumber, INumberLinguist oNumberLinguist) 
        {
            inputNumber = oInputNumber;
            numberLinguist = oNumberLinguist;
        }
        public void ValidateInputString(string inputString)
        {
            inputNumber.ValidateInputString(inputString);
        }
        public string ByWords(string inputString, char sGender, char sCase)
        {
            string NumberStr = TransformInput(inputString);
            inputNumber.ValidateInputString(NumberStr);

            char gender = char.ToUpper(sGender);
            Words.ValidateGender(gender);

            char cases = char.ToUpper(sCase);
            Words.ValidateCases(cases);

            var groups = inputNumber.Split(NumberStr);
            string resultStr = "";

            for (int ord = groups.Count - 1; ord >= 0; ord--)
            {
                int groupInt = int.Parse(groups[ord]); 
                // Порядок числовых групп
                switch (ord)
                {
                    case 0:    // сотни единиц
                        resultStr = (resultStr + " ").TrimStart() + GroupByWords(groups[ord], gender, cases);
                        break;
                    case 1:    // тысячи
                        resultStr = (resultStr + " ").TrimStart() +
                                    GroupByWords(groups[ord], 'Ж', cases) + " " +   // всегда жен. рода, потому, что тысяча
                                    numberLinguist.Thousand_GetDecline(groupInt, cases);
                        break;
                    case 2:    // миллионы
                        resultStr = (resultStr + " ").TrimStart() +
                                    GroupByWords(groups[ord], 'М', cases) + " " +   // всегда муж. рода, потому, что миллион муж.
                                    numberLinguist.Million_GetDecline(groupInt, cases);
                        break;
                    case 3:    // миллиарды
                        resultStr = (resultStr + " ").TrimStart() +
                                    GroupByWords(groups[ord], 'М', cases) + " " +   // всегда муж. рода, потому, что миллиард муж.
                                    numberLinguist.Milliard_GetDecline(groupInt, cases);
                        break;
                }
            }

            return resultStr;    // !!!
        }
        public string TransformInput(string inputString)
        {
            string result = inputString.Trim().Replace(" ","");
            return result;         // !!!
        }
        /// <summary>
        /// TODO: Перенести в русский лингвистический класс
        /// </summary>
        /// <param name="gender"></param>
        public static void ValidateGender(char gender)
        {
            char testGender = char.ToUpper(gender);
            if (testGender != 'М' &&
                testGender != 'Ж' &&
                testGender != 'С')
            {
                throw new InvalidOperationException($"Род <{testGender}> должен быть из <М,Ж,С> русскими буквами.");
            }
        }
        /// <summary>
        /// TODO: Перенести в русский лингвистический класс
        /// </summary>
        /// <param name="cases"></param>
        public static void ValidateCases(char cases)
        {
            char testCases = char.ToUpper(cases);
            char[] casesTmpl = {'И','Р','Д','В','Т','П'};
            if (Array.IndexOf(casesTmpl, testCases) == -1)
            {
                throw new InvalidOperationException($"Падеж <{testCases}> должен быть из <И,Р,Д,В,Т,П> русскими буквами.");
            }
        }


        /// <summary>
        /// Возвращает группу цифр словами.
        /// Метод не содержить валидацию, что не размазывать по методам проверки:
        /// группа должна состоять только из цифр, от 1 до 3 цифр.
        /// </summary>
        /// <param name="group">
        /// цифры количеством от 1..3
        /// </param>
        /// <param name="Gender">
        /// Род: ("М"-мужской, "Ж"-женский, "С"-средний
        /// </param>
        /// <param name="Case">
        /// Падеж ("И"-именительный, …, "П"-предложный)
        /// </param>
        /// <returns></returns>
        public string GroupByWords(string group, char gender, char cases)
        {

            if (string.IsNullOrEmpty(group))
            {
                return "";                  // !!!
            } 

            if (group.Length == 3)
            {
                return numberLinguist.GroupThree(group, gender, cases);         // !!!
            }
            else if (group.Length == 2)
            {
                return numberLinguist.GroupTwo(group, gender, cases);         // !!!

            }
            else if (group.Length == 1)
            {
                return numberLinguist.GroupOne(group[0], gender, cases);         // !!!
            }

            throw new InvalidOperationException($"Число цифр должно быть от 1 до 3-х");

        }
        public void GroupsOutput(List<string> groups)
        {
            Console.WriteLine("Полученные группы (с младших разрядов к старшим):");
            foreach (string str in groups)
            {
                Console.WriteLine(str);
            }
        }
    }
}
