using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_classes
{
    class MillionDecline : DeclinObject
    {
        public override string GetOneName(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "миллион";     // !!!
                case 'Р':
                    return "миллиона";     // !!!
                case 'Д':
                    return "миллиону";     // !!!
                case 'В':
                    return "миллион";     // !!!
                case 'Т':
                    return "миллионом";     // !!!
                case 'П':
                    return "миллионе";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");
        }
        public override string GetFewName(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "миллиона";     // !!!
                case 'Р':
                    return "миллионов";     // !!!
                case 'Д':
                    return "миллионам";     // !!!
                case 'В':
                    return "миллиона";     // !!!
                case 'Т':
                    return "миллионами";     // !!!
                case 'П':
                    return "миллионах";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");
        }
        public override string GetLotOfName(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "миллионов";     // !!!
                case 'Р':
                    return "миллионов";     // !!!
                case 'Д':
                    return "миллионам";     // !!!
                case 'В':
                    return "миллионов";     // !!!
                case 'Т':
                    return "миллионами";     // !!!
                case 'П':
                    return "миллионах";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");
        }

    }
}
