using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_classes
{
    public class Words
    {
        /// <summary>
        /// Склонения по падежам и родам для цифры 1
        /// </summary>
        public static Dictionary<char, Dictionary<char,string>> array1;
        /// <summary>
        /// Склонения по падежам и родам для цифры 2
        /// </summary>
        public static Dictionary<char, Dictionary<char, string>> array2;
        /// <summary>
        /// Целое число было по заданию
        /// </summary>
        /// <param name="num"></param>
        public Words()
        {
            InitArray1();
            InitArray2();
        }
        public string ByWords(string inputString, char sGender, char sCase)
        {
            string NumberStr = TransformInput(inputString);
            ValidateInputString(NumberStr);

            char gender = char.ToUpper(sGender);
            Words.ValidateGender(gender);

            char cases = char.ToUpper(sCase);
            Words.ValidateCases(cases);

            var groups = Split(NumberStr);
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
                        var thousDecline = new ThousandDecline();
                        resultStr = (resultStr + " ").TrimStart() +
                                    GroupByWords(groups[ord], 'Ж', cases) + " " +   // всегда жен. рода, потому, что тысяча
                                    thousDecline.GetDecline(groupInt, cases);
                        break;
                    case 2:    // миллионы
                        var millioneDecline = new MillionDecline();
                        resultStr = (resultStr + " ").TrimStart() +
                                    GroupByWords(groups[ord], 'М', cases) + " " +   // всегда муж. рода, потому, что миллион муж.
                                    millioneDecline.GetDecline(groupInt, cases);
                        break;
                    case 3:    // миллиарды
                        var milliardDecline = new MilliardDecline();
                        resultStr = (resultStr + " ").TrimStart() +
                                    GroupByWords(groups[ord], 'М', cases) + " " +   // всегда муж. рода, потому, что миллиард муж.
                                    milliardDecline.GetDecline(groupInt, cases);
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
        public static void ValidateCases(char cases)
        {
            char testCases = char.ToUpper(cases);
            char[] casesTmpl = {'И','Р','Д','В','Т','П'};
            if (Array.IndexOf(casesTmpl, testCases) == -1)
            {
                throw new InvalidOperationException($"Падеж <{testCases}> должен быть из <И,Р,Д,В,Т,П> русскими буквами.");
            }
        }
        private void InitArray1()
        {
            if (Words.array1 != null)
            {
                return;
            }

            array1 = new Dictionary<char, Dictionary<char, string>>();
            var maleGender = new Dictionary<char, string>();
            maleGender.Add('И', "один");
            maleGender.Add('Р', "одного");
            maleGender.Add('Д', "одному");
            maleGender.Add('В', "один");
            maleGender.Add('Т', "одним");
            maleGender.Add('П', "одном");
            array1.Add('М', maleGender);

            // женский род
            var femGender = new Dictionary<char, string>();
            femGender.Add('И', "одна");
            femGender.Add('Р', "одной");
            femGender.Add('Д', "одной");
            femGender.Add('В', "одну");
            femGender.Add('Т', "одной");
            femGender.Add('П', "одной");
            array1.Add('Ж', femGender);

            // Сдений род
            var neuGender = new Dictionary<char, string>();
            neuGender.Add('И', "одно");
            neuGender.Add('Р', "одного");
            neuGender.Add('Д', "одному");
            neuGender.Add('В', "одно");
            neuGender.Add('Т', "одним");
            neuGender.Add('П', "одном");
            array1.Add('С', neuGender);
        }
        private void InitArray2()
        {
            if (Words.array2 != null)
            {
                return;
            }

            array2 = new Dictionary<char, Dictionary<char, string>>();
            var maleGender = new Dictionary<char, string>();
            maleGender.Add('И', "два");
            maleGender.Add('Р', "двух");
            maleGender.Add('Д', "двум");
            maleGender.Add('В', "два");
            maleGender.Add('Т', "двумя");
            maleGender.Add('П', "двух");
            array2.Add('М', maleGender);

            // женский род
            var femGender = new Dictionary<char, string>();
            femGender.Add('И', "две");
            femGender.Add('Р', "двух");
            femGender.Add('Д', "двум");
            femGender.Add('В', "две");
            femGender.Add('Т', "двумя");
            femGender.Add('П', "двух");
            array2.Add('Ж', femGender);

            // Сдений род такой же как и мужской
            array2.Add('С', maleGender);
        }
        /// <summary>
        /// Создает разбивку строки inputString в коллекцию groups,
        /// где младшим индексам соответствуют младшие разряды числа в строке string_view, 
        /// </summary>
        private List<string> Split(string inputString)
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

        private string Get3(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "три";     // !!!
                case 'Р':
                    return "трех";     // !!!
                case 'Д':
                    return "трем";     // !!!
                case 'В':
                    return "три";     // !!!
                case 'Т':
                    return "тремя";     // !!!
                case 'П':
                    return "трех";     // !!!
            }
            throw new InvalidOperationException($"Неверный падеж");
        }
        private string Get4(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "четыре";     // !!!
                case 'Р':
                    return "четырех";     // !!!
                case 'Д':
                    return "четырем";     // !!!
                case 'В':
                    return "четыре";     // !!!
                case 'Т':
                    return "четырьмя";     // !!!
                case 'П':
                    return "четырех";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");

        }
        private string Get5(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "пять";     // !!!
                case 'Р':
                    return "пяти";     // !!!
                case 'Д':
                    return "пяти";     // !!!
                case 'В':
                    return "пять";     // !!!
                case 'Т':
                    return "пятью";     // !!!
                case 'П':
                    return "пяти";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");

        }
        private string Get6(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "шесть";     // !!!
                case 'Р':
                    return "шести";     // !!!
                case 'Д':
                    return "шести";     // !!!
                case 'В':
                    return "шесть";     // !!!
                case 'Т':
                    return "шестью";     // !!!
                case 'П':
                    return "шести";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");

        }
        private string Get7(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "семь";     // !!!
                case 'Р':
                    return "семи";     // !!!
                case 'Д':
                    return "семи";     // !!!
                case 'В':
                    return "семь";     // !!!
                case 'Т':
                    return "семью";     // !!!
                case 'П':
                    return "семи";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");

        }
        private string Get8(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "восемь";     // !!!
                case 'Р':
                    return "восьми";     // !!!
                case 'Д':
                    return "восьми";     // !!!
                case 'В':
                    return "восемь";     // !!!
                case 'Т':
                    return "восемью";     // !!!
                case 'П':
                    return "восьми";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");

        }
        private string Get9(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "девять";     // !!!
                case 'Р':
                    return "девяти";     // !!!
                case 'Д':
                    return "девяти";     // !!!
                case 'В':
                    return "девять";     // !!!
                case 'Т':
                    return "девятью";     // !!!
                case 'П':
                    return "девяти";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");

        }
        private string Get0(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "ноль";     // !!!
                case 'Р':
                    return "ноля";     // !!!
                case 'Д':
                    return "нулю";     // !!!
                case 'В':
                    return "ноль";     // !!!
                case 'Т':
                    return "нулем";     // !!!
                case 'П':
                    return "нуле";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");

        }
        /// <summary>
        /// Возвращает как произносится цифра, когда она есть часть слова,
        /// например 2, двенадцати = "две".
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string GetNumberAsPartOfWord(char number)
        {
            switch (number)
            {
                case '1':
                    return "один";
                case '2':
                    return "две";
                case '3':
                    return "три";
                case '4':
                    return "четыр";
                case '5':
                    return "пят";
                case '6':
                    return "шест";
                case '7':
                    return "сем";
                case '8':
                    return "восем";
                case '9':
                    return "девят";
                default:
                    throw new InvalidOperationException($"[words.GetNumberAsPartOfWord] параметр number=<{number}> должен содержать только числа 1..9");
            }
        }
        private string Get10(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "десять";     // !!!
                case 'Р':
                    return "десяти";     // !!!
                case 'Д':
                    return "десяти";     // !!!
                case 'В':
                    return "десять";     // !!!
                case 'Т':
                    return "десятью";     // !!!
                case 'П':
                    return "десяти";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");

        }

        private string Get40(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "сорок";     // !!!
                case 'Р':
                    return "сорока";     // !!!
                case 'Д':
                    return "сорока";     // !!!
                case 'В':
                    return "сорок";     // !!!
                case 'Т':
                    return "сорока";     // !!!
                case 'П':
                    return "сорока";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");
        }
        private string Get90(char cases)
        {
            //return "девя" + Get100(cases);    // !!!
            switch (cases)
            {
                case 'И':
                    return "девяносто";     // !!!
                case 'Р':
                    return "девяноста";     // !!!
                case 'Д':
                    return "девяноста";     // !!!
                case 'В':
                    return "девяносто";     // !!!
                case 'Т':
                    return "девяноста";     // !!!
                case 'П':
                    return "девяноста";     // !!!
            }
            throw new InvalidOperationException($"Неверный падеж");
        }
        /// <summary>
        /// Возвращает наименования десятков
        /// </summary>
        /// <param name="decade"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        private string GetDecades(string decade, char cases)
        {
            if (decade[0] == '0')
            {
                return "";      // !!!
            }

            //Особенные случаи
            if (decade == "10")
            {
                return Get10(cases);           // !!!
            }
            else if (decade == "20" || decade == "30")
            {
                return GroupOne(decade[0], 'М', 'И') + "д" + Get10AsPartOfWordSmallNumber(cases);   // !!!
            }
            else if ( decade == "40")
            {
                return Get40(cases);           // !!!
            }
            else if (decade == "90")
            {
                return Get90(cases);           // !!!
            }
            // типичные наименования
            else 
            {
                string tenName = Get10(cases);
                if (cases == 'И' || cases == 'В')
                {
                    tenName = "десят";
                }
                return GroupOne(decade[0], 'М', cases) + tenName;
            }
        }
        /// <summary>
        /// Возвращает как произносится десять, когда она часть слова
        /// в младших числах - цать, в отличие пятьдесят
        /// </summary>
        /// <param name="cases"></param>
        /// <returns></returns>
        private string Get10AsPartOfWordSmallNumber(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "цать";     // !!!
                case 'Р':
                    return "цати";     // !!!
                case 'Д':
                    return "цати";     // !!!
                case 'В':
                    return "цать";     // !!!
                case 'Т':
                    return "цатью";     // !!!
                case 'П':
                    return "цати";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");

        }

        private string GroupOne(char group, char gender, char cases)
        {
            // Приведение к правильному виду должно быть в одном месте
            switch (group)
            {
                case '0':
                    return Get0(cases);          // !!!
                case '1':
                    return Words.array1[gender][cases];     // !!!
                case '2':
                    return Words.array2[gender][cases];  // !!!
                case '3':
                    return Get3(cases);          // !!!
                case '4':
                    return Get4(cases);       // !!!
                case '5':
                    return Get5(cases);       // !!!
                case '6':
                    return Get6(cases);       // !!!
                case '7':
                    return Get7(cases);       // !!!
                case '8':
                    return Get8(cases);       // !!!
                case '9':
                    return Get9(cases);       // !!!
            }

            throw new InvalidOperationException($"Входной параметр должен быть цифрой");

        }
        private string Get100(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "сто";     // !!!
                case 'Р':
                    return "ста";     // !!!
                case 'Д':
                    return "ста";     // !!!
                case 'В':
                    return "сто";     // !!!
                case 'Т':
                    return "ста";     // !!!
                case 'П':
                    return "ста";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");

        }
        private string GetHundreds(string hundreds, char cases)
        {
            if (hundreds == "000")
            {
                return "";
            }
            if (hundreds == "100")
            {
                return Get100(cases);
            }

            string oneHundredName = "";
            string numberName = "";

            if (cases == 'И' || cases == 'В')
            {
                switch (hundreds[0])
                {
                    case '2':
                        oneHundredName = "сти";
                        break;
                    case '3':
                        oneHundredName = "ста";
                        break;
                    case '4':
                        oneHundredName = "ста";
                        break;
                    default:
                        oneHundredName = "сот";
                        break;
                }
            }
            else if (cases == 'Р')
            {
                oneHundredName = "сот"; 
            }
            else if (cases == 'Д')
            {
                oneHundredName = "стам";
            }
            else if (cases == 'Т')
            {
                oneHundredName = "стами";
            }
            else if (cases == 'П')
            {
                oneHundredName = "стах";
            }

            // Наименование количества сотен
            numberName = GroupOne(hundreds[0], 'М', cases);
            if (hundreds[0] == '2' && (cases == 'И' || cases == 'В'))
            {
                numberName = "две";
            }
            if (hundreds[0] == '8' && cases == 'Т')
            {
                numberName = "восьмью";
            }

            return numberName + oneHundredName;       // !!!
        }
        /// <summary>
        /// Метод не содержит валидацию: group - должны быть только цифры и должно быть только две цирфы, не одна и не три
        /// </summary>
        /// <param name="group"></param>
        /// <param name="gender"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        private string GroupTwo(string group, char gender, char cases)
        {
            string resultStr;

            int groupTwoInt = int.Parse(group);    // вся валидация должны быть снаружи, что бы не размазывать валидацию по методам и не затруднять процедуру
            if (group[1] == '0')
            {
                resultStr = GetDecades(group, cases);     // !!!
            }
            else if (groupTwoInt > 10 & groupTwoInt < 20)
            {
                resultStr = GetNumberAsPartOfWord(group[1]) + // вторую цифру двухзначиного числа без склонения
                       "над" + Get10AsPartOfWordSmallNumber(cases);
            }
            else
            {
                resultStr = GetDecades(group[0] + "0", cases) +" "+ GroupOne(group[1], gender, cases); // !!!
            }

            //Если разряд числа = 0, то может получится лишний пробел
            return resultStr.TrimStart();      // !!!
        }
        /// <summary>
        /// Возвращает наименование группы из трех цифр.
        /// Валидацию не содержит
        /// </summary>
        /// <param name="group"></param>
        /// <param name="gender"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        private string GroupThree(string group, char gender, char cases)
        {
            // Разделение на функционал: стоня и два разряда вместе обусловлено отдельными словами.
            // так два младшие разряда могут писаться одним словом. Например "двенадцать".
            return (GetHundreds(group[0] + "00", cases) + " " + GroupTwo(group.Substring(1, 2), gender, cases)).TrimStart();    //!!!
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
                return GroupThree(group, gender, cases);         // !!!
            }
            else if (group.Length == 2)
            {
                return GroupTwo(group, gender, cases);         // !!!

            }
            else if (group.Length == 1)
            {
                return GroupOne(group[0], gender, cases);         // !!!
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
