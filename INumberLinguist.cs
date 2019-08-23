using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_classes
{
    public interface INumberLinguist
    {
        /// <summary>
        /// Формирует массивы названий по родам и падежам для тех цифр, которые 
        /// изменяются не только по падежам, но и по родам и их удобнее заложить в словарь,
        /// а не возвращать методом.
        /// </summary>
        void InitNumberArrays();

        /// <summary>
        /// Именует группу из одной цифры
        /// </summary>
        /// <param name="group"></param>
        /// <param name="gender"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        string GroupOne(char group, char gender, char cases);
        /// <summary>
        /// Именует группу из двух цифр
        /// </summary>
        /// <param name="group"></param>
        /// <param name="gender"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        string GroupTwo(string group, char gender, char cases);
        /// <summary>
        /// Именует группы из трех цифр.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="gender"></param>
        /// <param name="cases"></param>
        /// <returns></returns>
        string GroupThree(string group, char gender, char cases);
        string Thousand_GetDecline(int number, char cases);
        string Million_GetDecline(int number, char cases);
        string Milliard_GetDecline(int number, char cases);
    }
}
