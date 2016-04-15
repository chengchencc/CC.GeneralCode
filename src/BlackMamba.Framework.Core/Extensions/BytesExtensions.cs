using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackMamba.Framework.Core
{
    public static class BytesExtensions
    {
        public static string ToHexString(this byte[] value, int startIndex, int length)
        {
            var stringWith_ = BitConverter.ToString(value,startIndex,length);
            var result = stringWith_.Replace("-", string.Empty);
            return result;
        }
        public static string ToHexString(this List<byte> value, int startIndex, int length)
        {
            var stringWith_ = BitConverter.ToString(value.ToArray(),startIndex,length);
            var result = stringWith_.Replace("-", string.Empty);
            return result;
        }
        public static bool EqualWithString(this byte[] value, int startIndex, int length,string compareString)
        {
            var hexString = value.ToHexString(startIndex, length);
            return hexString.Equals(compareString);
        }
        public static bool EqualWithString(this byte[] value, int startIndex, int length,string compareString,StringComparison comparisonType)
        {
            var hexString = value.ToHexString(startIndex, length);
            return hexString.Equals(compareString, comparisonType);
        }

        public static bool EqualWithString(this List<byte> value, int startIndex, int length, string compareString)
        {
            var hexString = value.ToHexString(startIndex, length);
            return hexString.Equals(compareString);
        }
        public static bool EqualWithString(this List<byte> value, int startIndex, int length, string compareString, StringComparison comparisonType)
        {
            var hexString = value.ToHexString(startIndex, length);
            return hexString.Equals(compareString, comparisonType);
        }


        public static byte[] ToBytes(this string value)
        {
            var result = Enumerable.Range(0, value.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(value.Substring(x, 2), 16))
                             .ToArray();
            return result;
        }
        public static List<byte> ToByteList(this string value)
        {
            var result = Enumerable.Range(0, value.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(value.Substring(x, 2), 16))
                             .ToList();
            return result;
        }
        public static bool EqualWithBytes(this string value, int startIndex, int length, byte[] compareString)
        {
            var hexString = compareString.ToHexString(startIndex, length);
            return hexString.Equals(compareString);
        }
        public static bool EqualWithBytes(this string value, int startIndex, int length, byte[] compareString, StringComparison comparisonType)
        {
            var hexString = compareString.ToHexString(startIndex, length);
            return hexString.Equals(value,comparisonType);
        }

        /// <summary>
        /// 字节转为二进制字符串(自动补全8位)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBinaryString(this byte value)
        {
            return Convert.ToString(value, 2).PadLeft(8,'0');
        }

    }
}
