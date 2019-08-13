using System;
using Words_classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordsTest
{
    [TestClass]
    public class WordsTest
    {
        [TestMethod]
        public void DecadeLowNumber_FemGender_Icase()   
        {
            var words = new Words();
            string inputStr = "12";
            char gender = 'Ж';
            char cases = 'И';           // Падеж

            string expected = "двенадцать";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecadeLowNumber_FemGender_Rcase()
        {
            var words = new Words();
            string inputStr = "13";
            char gender = 'Ж';
            char cases = 'Р';           // Падеж

            string expected = "тринадцати";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecadeLowNumber_FemGender_Dcase()
        {
            var words = new Words();
            string inputStr = "14";
            char gender = 'Ж';
            char cases = 'Д';           // Падеж

            string expected = "четырнадцати";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecadeLowNumber_FemGender_Vcase()
        {
            var words = new Words();
            string inputStr = "15";
            char gender = 'Ж';
            char cases = 'В';           // Падеж

            string expected = "пятнадцать";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecadeLowNumber_FemGender_Tcase()
        {
            var words = new Words();
            string inputStr = "11";
            char gender = 'Ж';
            char cases = 'Т';           // Падеж

            string expected = "одиннадцатью";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecadeLowNumber_FemGender_Pcase()
        {
            var words = new Words();
            string inputStr = "16";
            char gender = 'Ж';
            char cases = 'П';           // Падеж

            string expected = "шестнадцати";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decade2_LargeNumber_MalGender_Pcase()
        {
            var words = new Words();
            string inputStr = "21";
            char gender = 'М';
            char cases = 'П';           // Падеж

            string expected = "двадцати одном";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decade3_LargeNumber_MalGender_Pcase()
        {
            var words = new Words();
            string inputStr = "32";
            char gender = 'М';
            char cases = 'П';           // Падеж

            string expected = "тридцати двух";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decade4_LargeNumber_MalGender_Pcase()
        {
            var words = new Words();
            string inputStr = "43";
            char gender = 'М';
            char cases = 'П';           // Падеж

            string expected = "сорока трех";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decade5_LargeNumber_MalGender_Pcase()
        {
            var words = new Words();
            string inputStr = "54";
            char gender = 'М';
            char cases = 'П';           // Падеж

            string expected = "пятидесяти четырех";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decade6_LargeNumber_MalGender_Pcase()
        {
            var words = new Words();
            string inputStr = "65";
            char gender = 'М';
            char cases = 'П';           // Падеж

            string expected = "шестидесяти пяти";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decade7_LargeNumber_MalGender_Pcase()
        {
            var words = new Words();
            string inputStr = "76";
            char gender = 'М';
            char cases = 'П';           // Падеж

            string expected = "семидесяти шести";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decade8_LargeNumber_MalGender_Pcase()
        {
            var words = new Words();
            string inputStr = "87";
            char gender = 'М';
            char cases = 'П';           // Падеж

            string expected = "восьмидесяти семи";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decade9_LargeNumber_MalGender_Pcase()
        {
            var words = new Words();
            string inputStr = "98";
            char gender = 'М';
            char cases = 'П';           // Падеж

            string expected = "девяноста восьми";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FemGender_Tcase()
        {
            var words = new Words();
            string inputStr = "61";
            char gender = 'Ж';       
            char cases = 'Т';           // Падеж

            string expected = "шестьюдесятью одной";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Hundred8_FemGender_Tcase()
        {
            var words = new Words();
            string inputStr = "861";
            char gender = 'Ж';
            char cases = 'Т';           // Падеж

            string expected = "восьмьюстами шестьюдесятью одной";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GroupOne_neuGender_Icase()
        {
            var words = new Words();
            string inputStr = "1";
            char gender = 'С';
            char cases = 'И';           // Падеж

            string expected = "одно";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MissingBit_FemGender_Tcase()
        {
            var words = new Words();
            string inputStr = "901";
            char gender = 'Ж';
            char cases = 'Т';           // Падеж

            string expected = "девятьюстами одной";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LeadingZero_GroupFull_FemGender_Tcase()
        {
            var words = new Words();
            string inputStr = "012";
            char gender = 'Ж';
            char cases = 'Т';           // Падеж

            string expected = "двенадцатью";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LeadingZero_GroupTwo_FemGender_Tcase()
        {
            var words = new Words();
            string inputStr = "05";
            char gender = 'Ж';
            char cases = 'Т';           // Падеж

            string expected = "пятью";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TwoLeadingZero_GroupFull_FemGender_Tcase()
        {
            var words = new Words();
            string inputStr = "009";
            char gender = 'Ж';
            char cases = 'Т';           // Падеж

            string expected = "девятью";
            string actual = words.GroupByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ThousandName_FemGender_PCase()
        {
            var words = new Words();
            string inputStr = "5 922";
            char gender = 'Ж';
            char cases = 'П';           // Падеж

            string expected = "пяти тысячах девятистах двадцати двух";
            string actual = words.ByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MillionName_FemGender_PCase()
        {
            var words = new Words();
            string inputStr = "79 893 992";
            char gender = 'Ж';
            char cases = 'П';           // Падеж

            string expected = "семидесяти девяти миллионах восьмистах девяноста трех тысячах девятистах девяноста двух";
                             //семидесяти девяти миллионах восьмистах девяноста трех тысячах девятистах девяноста двух
            string actual = words.ByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MilliardName_MalGender_DCase()
        {
            var words = new Words();
            string inputStr = "231 579 893 995";
            char gender = 'М';
            char cases = 'Д';           // Падеж

            string expected = "двумстам тридцати одному миллиарду пятистам семидесяти девяти миллионам восьмистам девяноста трем тысячам девятистам девяноста пяти";
                             //двумстам тридцати одному миллиарду пятистам семидесяти девяти миллионам восьмистам девяноста трем тысячам девятистам девяноста пяти
            string actual = words.ByWords(inputStr, gender, cases);

            Assert.AreEqual(expected, actual);
        }

    }
}
