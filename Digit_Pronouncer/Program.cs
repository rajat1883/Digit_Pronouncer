using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        Dictionary<int, string> integerToString = new Dictionary<int, string>();
        Program()
        {
            this.integerToString.Add(0, "Zero");
            this.integerToString.Add(1, "One");
            this.integerToString.Add(2, "Two");
            this.integerToString.Add(3, "Three");
            this.integerToString.Add(4, "Four");
            this.integerToString.Add(5, "Five");
            this.integerToString.Add(6, "Six");
            this.integerToString.Add(7, "Seven");
            this.integerToString.Add(8, "Eight");
            this.integerToString.Add(9, "Nine");
            this.integerToString.Add(10, "Ten");
            this.integerToString.Add(11, "Eleven");
            this.integerToString.Add(12, "Twelve");
            this.integerToString.Add(13, "Thirteen");
            this.integerToString.Add(14, "Fourteen");
            this.integerToString.Add(15, "Fifteen");
            this.integerToString.Add(16, "Sixteen");
            this.integerToString.Add(17, "Seventeen");
            this.integerToString.Add(18, "Eighteen");
            this.integerToString.Add(19, "Nineteen");
            this.integerToString.Add(20, "Twenty");
            this.integerToString.Add(30, "Thirty");
            this.integerToString.Add(40, "Fourty");
            this.integerToString.Add(50, "Fifty");
            this.integerToString.Add(60, "Sixty");
            this.integerToString.Add(70, "Seventy");
            this.integerToString.Add(80, "Eighty");
            this.integerToString.Add(90, "Ninety");

        }
        static void Main(string[] args)
        {
            Start:
            Console.WriteLine("Please enter an integer between 0 and 99 crore");
            var value = Console.ReadLine();
            Program program = new Program();

            Console.WriteLine(program.DynamicDigitCaller(value));
            goto Start;
        }

        private string PronounceOneDigit(string digit)
        {
            return integerToString[Convert.ToInt32(digit)];
        }

        private string PronounceTwoDigits(string number)
        {
            var integerValue = Convert.ToInt32(number);
            if(integerValue >= 11 && integerValue <= 19 || integerValue % 10 == 0)
            {
                return integerToString[Convert.ToInt32(number)];
            }
            else
            {
                return integerToString[Convert.ToInt32(number[0].ToString() + "0")] + " " + integerToString[Convert.ToInt32(number[1].ToString())];
            }
        }

        private string PronounceThreeDigits(string number)
        {
            var integerValue = Convert.ToInt32(number);
            var firstHalf = PronounceOneDigit(number[0].ToString()) + " Hundered" + " ";
            var secondHalf = DynamicDigitCaller(number.Substring(1));
            return integerValue % 100 == 0 ? firstHalf : firstHalf + secondHalf;
        }

        private string PronounceFourDigits(string number)
        {
            var integerValue = Convert.ToInt32(number);
            var firstHalf = PronounceOneDigit(number[0].ToString()) + " Thousand" + " ";
            if (integerValue % 1000 == 0)
                return firstHalf;
            else
            {
                return firstHalf + DynamicDigitCaller(number.Substring(1)); ;
            }
        }

        private string PronounceFiveDigits(string number)
        {
            var integerValue = Convert.ToInt32(number);
            var firstHalf = PronounceTwoDigits(number.Substring(0,2)) + " Thousand" + " ";
            if (integerValue % 1000 == 0)
                return firstHalf;
            else
            {
                return firstHalf + DynamicDigitCaller(number.Substring(2));
            }
        }

        private string PronounceSixDigits(string number)
        {
            var integerValue = Convert.ToInt32(number);
            var firstHalf = PronounceOneDigit(number[0].ToString()) + " Lac" + " ";
            if (integerValue % 100000 == 0)
                return firstHalf;
            else
            {
                return firstHalf + DynamicDigitCaller(number.Substring(1));
            }
        }

        private string PronounceSevenDigits(string number)
        {
            var integerValue = Convert.ToInt32(number);
            var firstHalf = PronounceTwoDigits(number.Substring(0, 2)) + " Lacs" + " ";
            if (integerValue % 1000000 == 0)
                return firstHalf;
            else
            {
                return firstHalf + DynamicDigitCaller(number.Substring(2));
            }
        }

        private string PronounceEightDigits(string number)
        {
            var integerValue = Convert.ToInt32(number);
            var firstHalf = PronounceOneDigit(number[0].ToString()) + " Crore" + " ";
            if (integerValue % 10000000 == 0)
                return firstHalf;
            else
            {
                return firstHalf + DynamicDigitCaller(number.Substring(1));
            }
        }

        private string PronounceNineDigits(string number)
        {
            var integerValue = Convert.ToInt32(number);
            var firstHalf = PronounceTwoDigits(number.Substring(0, 2)) + " Crores" + " ";
            if (integerValue % 100000000 == 0)
                return firstHalf;
            else
            {
                return firstHalf + DynamicDigitCaller(number.Substring(2));
            }
        }

        private string DynamicDigitCaller(string value)
        {
            var integerValue = Convert.ToInt32(value);
            if (integerValue >= 0 && integerValue <= 9)
            {
                return PronounceOneDigit(value);
            }
            else if (integerValue >= 10 && integerValue <= 99)
            {
                return PronounceTwoDigits(value);
            }
            else if (integerValue >= 100 && integerValue <= 999)
            {
                return PronounceThreeDigits(value);
            }
            else if (integerValue >= 1000 && integerValue <= 9999)
            {
                return PronounceFourDigits(value);
            }
            else if (integerValue >= 10000 && integerValue <= 99999)
            {
                return PronounceFiveDigits(value);
            }
            else if (integerValue >= 100000 && integerValue <= 999999)
            {
                return PronounceSixDigits(value);
            }
            else if (integerValue >= 1000000 && integerValue <= 9999999)
            {
                return PronounceSevenDigits(value);
            }
            else if (integerValue >= 10000000 && integerValue <= 99999999)
            {
                return PronounceEightDigits(value);
            }
            else if (integerValue >= 100000000 && integerValue <= 999999999)
            {
                return PronounceNineDigits(value);
            }
            else
            {
                return "Invalid Input";
            }
        }
    }
}
