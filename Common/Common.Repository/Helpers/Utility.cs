using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Common.Repository.Helpers
{
    public static class Utility
    {
        // Utility method to handle DBNull and null values
        public static string isStringNull(object value)
        {
            if ((value == DBNull.Value) || (value == null))
                return String.Empty;
            else
                return value.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        // Utility method to handle convert oracle type varchar to C# type Boolean  
        public static bool isBoolNull(object value)
        {
            if ((value == DBNull.Value) || (value == null))
                return false;
            else
                if (value.ToString() == "Y")
                return true;
            else
                return false;
        }

        public static bool isSqlBoolNull(object value)
        {
            if ((value == DBNull.Value) || (value == null))
                return false;
            else if (value.ToString() == "True")
                return true;
            else
                return false;
        }

        public static bool ParseBool(object value)
        {
            if ((value == DBNull.Value) || (value == null))
                return false;
            else
                return bool.Parse(value.ToString());
        }

        //Utility method to convert object type to int
        public static int isNumberNull(object value)
        {
            if ((value == DBNull.Value) || (value == null))
            {
                return 0;
            }
            else
            {
                int convertedInteger;
                if (!int.TryParse(value.ToString(), out convertedInteger))
                {
                    return 0;
                }
                else
                {
                    return convertedInteger;
                }
            }
        }

        //Utility method to convert object type to long
        public static long isLongNumberNull(object value)
        {
            if ((value == DBNull.Value) || (value == null))
            {
                return 0;
            }
            else
            {
                long convertedLong;
                if (!long.TryParse(value.ToString(), out convertedLong))
                {
                    return 0;
                }
                else
                {
                    return convertedLong;
                }
            }
        }

        //Utility method to convert object type to decimal
        public static decimal isDecimalNull(object value)
        {
            if ((value == DBNull.Value) || (value == null))
            {
                return 0;
            }
            else
            {
                decimal convertedDecimal;
                if (!decimal.TryParse(value.ToString(), out convertedDecimal))
                {
                    return 0;
                }
                else
                {
                    return convertedDecimal;
                }
            }
        }

        //Utility method to convert C# type bool to varchar
        public static string isBoolConvert(bool value)
        {

            if (value == true)
                return "Y";
            else
                return "N";
        }

        //Utility method to convert object type to int
        public static DateTime isDateTimeNull(object value)
        {
            if ((value == DBNull.Value) || (value == null) || (value.ToString() == "null"))
                return Convert.ToDateTime(null);
            else
                return Convert.ToDateTime(value);
        }

        //Utility method to convert object type to int
        public static DateTime? isDateNullableTimeNull(object value)
        {
            if ((value == DBNull.Value) || (value == null) || (value.ToString() == "null"))
                return Convert.ToDateTime(null);
            else
                return Convert.ToDateTime(value);
        }

        //Utility method to convert object type to GUID
        public static Guid isGuidNull(object value)
        {
            Guid gId;

            if ((value == DBNull.Value) || (value == null))
                return Guid.Empty;
            else
                gId = new Guid(value.ToString());
            return gId;
        }

        //Utility method to convert GUID type to String
        public static string isGuidConvert(Guid value)
        {
            return value.ToString();
        }
    }
}