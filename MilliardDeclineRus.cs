using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_classes
{
    class MilliardDeclineRus : DeclinObjectRus
    {
        public override string GetOneName(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "миллиард";     // !!!
                case 'Р':
                    return "миллиарда";     // !!!
                case 'Д':
                    return "миллиарду";     // !!!
                case 'В':
                    return "миллиард";     // !!!
                case 'Т':
                    return "миллиардом";     // !!!
                case 'П':
                    return "миллиарде";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");
        }
        public override string GetFewName(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "миллиарда";     // !!!
                case 'Р':
                    return "миллиардов";     // !!!
                case 'Д':
                    return "миллиардам";     // !!!
                case 'В':
                    return "миллиарда";     // !!!
                case 'Т':
                    return "миллиардами";     // !!!
                case 'П':
                    return "миллиардах";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");
        }
        public override string GetLotOfName(char cases)
        {
            switch (cases)
            {
                case 'И':
                    return "миллиардов";     // !!!
                case 'Р':
                    return "миллиардов";     // !!!
                case 'Д':
                    return "миллиардам";     // !!!
                case 'В':
                    return "миллиардов";     // !!!
                case 'Т':
                    return "миллиардами";     // !!!
                case 'П':
                    return "миллиардах";     // !!!
            }

            throw new InvalidOperationException($"Неверный падеж");
        }

    }
}
