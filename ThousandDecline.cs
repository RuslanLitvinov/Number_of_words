using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_classes
{
    class ThousandDecline: DeclinObjectRus
    {
        public override string GetOneName(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "тысяча";     // !!!
                case 'Р':
                    return "тысячи";     // !!!
                case 'Д':
                    return "тысяче";     // !!!
                case 'В':
                    return "тысячу";     // !!!
                case 'Т':
                    return "тысячей";     // !!!
                case 'П':
                    return "тысяче";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");
        }
        public override string GetFewName(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "тысячи";     // !!!
                case 'Р':
                    return "тысяч";     // !!!
                case 'Д':
                    return "тысячам";     // !!!
                case 'В':
                    return "тысячи";     // !!!
                case 'Т':
                    return "тысячами";     // !!!
                case 'П':
                    return "тысячах";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");
        }
        public override string GetLotOfName(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "тысяч";     // !!!
                case 'Р':
                    return "тысячи";     // !!!
                case 'Д':
                    return "тысячам";     // !!!
                case 'В':
                    return "тысяч";     // !!!
                case 'Т':
                    return "тысячами";     // !!!
                case 'П':
                    return "тысячах";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");
        }

    }
}
