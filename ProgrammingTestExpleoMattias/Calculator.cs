using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTestExpleoMattias
{
    public static class Calculator
    {
        public static double LevelOne(string input)
        {
            var InputToArray = input //Tidy input and convert to a char array.
                .ToCharArray()
                .Where(x => !char.IsWhiteSpace(x))
                .ToArray();

            //Variables used to arrange data and determine what mathematical operator to use.
            string stringParamOne = null, stringParamTwo = null;
            char operatorValue = default;
            bool operatorDetected = false; 

            foreach (var c in InputToArray)
            {
                if (c == '*' || c == '/' || c == '+' || c == '-')
                {
                    operatorValue = c;
                    operatorDetected = true;
                }
                else if (char.IsDigit(c) || c == ',') //Sorting of the chars(left or right of the operator)
                {
                    if (!operatorDetected)
                        stringParamOne += c; 
                    else
                        stringParamTwo += c;
                }
                else
                    return 0;
            }

            double numParamOne = double.Parse(stringParamOne); 
            double numParamTwo = double.Parse(stringParamTwo);

            switch (operatorValue)
            {
                case '*':
                    return numParamOne * numParamTwo;
                case '/':
                    if (numParamTwo == 0)
                        return 0;
                    else
                        return numParamOne / numParamTwo;
                case '+':
                    return numParamOne + numParamTwo;
                case '-':
                    return numParamOne - numParamTwo;
                default:
                    return 0;
            }
        }
        public static double LevelTwo(string input)
        {
            var InputToArray = input
               .ToCharArray()
               .Where(x => !char.IsWhiteSpace(x))
               .ToArray();

            var operatorList = new List<char>(); //The variables from level 1 has transformed to lists instead since there may be several operators.
            var stringNumberList = new List<string>();
            string stringNumbers = null;

            for (int i = 0; i < InputToArray.Length; i++) 
            {
                if (InputToArray[i] == '*' || InputToArray[i] == '/' || InputToArray[i] == '+' || InputToArray[i] == '-')
                {
                    operatorList.Add(InputToArray[i]);
                    stringNumberList.Add(stringNumbers);
                    stringNumbers = null; //as soon as the operator shows up, the string with the numbers will be moved and the variabel reset.
                }
                else if (char.IsDigit(InputToArray[i]) || InputToArray[i] == ',')
                {
                    stringNumbers += InputToArray[i];

                    if (i == InputToArray.Length - 1) //Not to forget to add the last element.
                    {
                        stringNumberList.Add(stringNumbers);
                    }
                }
                else
                    return 0;
            }

            var doubleParsedList = new List<double>();

            foreach (var stringNumber in stringNumberList)
            {
                double doubleNumber = double.Parse(stringNumber); //converting the stringvalues.
                doubleParsedList.Add(doubleNumber);
            }

            double result = doubleParsedList[0]; 

            for (int i = 0; i < operatorList.Count; i++) //In this switch the indexes in order of "i" and "i+1" will be affected and added 
            {                                           //to the resultvariable.
                switch (operatorList[i])
                {
                    case '*':
                        result *= doubleParsedList[i + 1];
                        break;
                    case '/':
                        if (doubleParsedList[i + 1] == 0) //division by 0.
                            return 0;
                        result /= doubleParsedList[i + 1];
                        break;
                    case '+':
                        result += doubleParsedList[i + 1];
                        break;
                    case '-':
                        result -= doubleParsedList[i + 1];
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
        public static double LevelThree(string input)
        {
            var InputToArray = input //This first part works the same as in LevelTwo.
               .ToCharArray()
               .Where(x => !char.IsWhiteSpace(x))
               .ToArray();

            var operatorList = new List<char>();
            var numList = new List<string>();
            string stringNumbers = null;

            for (int i = 0; i < InputToArray.Length; i++)
            {
                if (InputToArray[i] == '*' || InputToArray[i] == '/' || InputToArray[i] == '+' || InputToArray[i] == '-')
                {
                    operatorList.Add(InputToArray[i]);
                    numList.Add(stringNumbers);
                    stringNumbers = null;
                }
                else if (char.IsDigit(InputToArray[i]) || InputToArray[i] == ',')
                {
                    stringNumbers += InputToArray[i];

                    if (i == InputToArray.Length - 1)
                    {
                        numList.Add(stringNumbers);
                    }
                }
                else
                    return 0;
            }

            var doubleParsedList = new List<double>();

            foreach (var stringNumber in numList)
            {
                double doubleNumber = double.Parse(stringNumber);
                doubleParsedList.Add(doubleNumber);
            }

            for (int i = 0; i < operatorList.Count; i++) //The news starts here..
            {
                if (operatorList[i] == '*' || operatorList[i] == '/') //To consider mathematical rules the division and 
                {                                                    //multiplication happens earlier.
                    char tempChar = operatorList[i];
                    operatorList.RemoveAt(i);

                    double tempNr, tempNr2;                       //This is done by "lifting" out the numbers and operators that should be affected first,
                    tempNr = doubleParsedList[i];                //directly do the math and then insert the new value.
                    tempNr2 = doubleParsedList[i + 1];
                    doubleParsedList.RemoveAt(i);
                    doubleParsedList.RemoveAt(i);

                    if (tempChar == '*')
                        doubleParsedList.Insert(i, tempNr * tempNr2);
                    if (tempChar == '/')
                    {
                        if (tempNr2 == 0) //division by 0.
                            return 0;
                        else
                            doubleParsedList.Insert(i, tempNr / tempNr2);
                    }
                    i--; 
                }
            }

            double result = doubleParsedList[0];

            for (int i = 0; i < operatorList.Count; i++) //works as in earlier methods (* and / taken care of earlier)
            {
                switch (operatorList[i])
                {
                    case '+':
                        result += doubleParsedList[i + 1];
                        break;
                    case '-':
                        result -= doubleParsedList[i + 1];
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
