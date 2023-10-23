using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    internal class FieldListBuilder
    {

        public static string GetConditionalExpression(string[] columnArray, string prefix = "@", string separator = "AND")
        {
            var prefixedArray = columnArray.Select(item =>  item + " = " + prefix + item);

            string CondExpression = string.Join(separator, prefixedArray);

            return CondExpression;
        }


        public static string GetCommaSeparatedString(string[] columnArray, string prefix)
        {
            var prefixedArray = columnArray.Select(item => prefix + item);

            string commaSeparatedString = string.Join(", ", prefixedArray);

            return commaSeparatedString;
        }

        public static string ConcatenateWithComma(string first, string second)
        {
            if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second))
            {
                return first + second;
            }
            else
            {
                return first + ", " + second;
            }
        }

    }
}
