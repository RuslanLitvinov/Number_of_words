using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_classes
{
    class DeclinObject
    {
        public DeclinObject()
        {
            ;
        }
        /// <summary>
        /// Получает склонение наименования объекта по падежам
        /// </summary>
        /// <param name="number"></param>
        /// <param name="cases"> Падеж </param>
        /// <returns></returns>
        public virtual string GetDecline(int number, char cases)
        {

            if (number == 0)
            {
                return null;        //  !!!
            }

            if (number >= 11 & number <= 19)
            {
                return GetLotOfName(cases);      // !!!
            }

            int rest = number % 10;

            if (rest == 1)
            {
                return GetOneName(cases);           // !!!
            }

            if (rest >= 2 & rest <= 4)
            {
                return GetFewName(cases);          // !!!
            }
            // это 0, 5 и больше. В том числе если остаток от деления = 0, то это больше 20 и значит тоже по такому правилу

            return GetLotOfName(cases);      // !!!

        }
        /// <summary>
        /// Возвращает склонение по падежам 0, 5-9 имен объектов
        /// </summary>
        /// <param name="cases"> Падеж </param>
        /// <returns></returns>
        public virtual string GetLotOfName(char cases)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Возвращает склонение по падежам 2-4 имен объектов
        /// </summary>
        /// <param name="cases"></param>
        /// <returns></returns>
        public virtual string GetFewName(char cases)
        {
            throw new NotImplementedException();
        }

        public virtual string GetOneName(char cases)
        {
            throw new NotImplementedException();
        }

    }
}
