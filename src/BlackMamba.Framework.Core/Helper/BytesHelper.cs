using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackMamba.Framework.Core.Helper
{
   public static class BytesHelper
    {
       public static byte[] ConvertIntToBcd(int value, int bytesLength)
       {
           if (value < 0 || value > 99999999)
               throw new ArgumentOutOfRangeException("value");
           byte[] ret = new byte[bytesLength];
           for (int i = 0; i < bytesLength; i++)
           {
               ret[i] = (byte)(value % 10);
               value /= 10;
               ret[i] |= (byte)((value % 10) << 4);
               value /= 10;
           }
           return ret;
       }

       public static byte[] ConvertIntToBcdReversed(int value, int bytesLength)
       {
           if (value < 0 || value > 99999999)
               throw new ArgumentOutOfRangeException("value");
           byte[] ret = new byte[bytesLength];
           for (int i = bytesLength - 1; i >= 0; i--)
           {
               ret[i] = (byte)(value % 10);
               value /= 10;
               ret[i] |= (byte)((value % 10) << 4);
               value /= 10;
           }
           return ret;
       }

       public static int ConvertBcdToInt(byte[] value,int startIndex,int length)
       {
           if (value == null || value.Length<startIndex+length)
           {
               throw new ArgumentException();
           }
           var result = 0;
           for (int i = 0; i < length; i++)
           {
               result *= 100;
               result += 10 * (value[startIndex+ i] >> 4);
               result += value[startIndex+i] & 0xf;
           }
           return result;

       }

       public static byte[] ConvertIpToBytes(string ip)
       {
           List<byte> result = new List<byte>();
           var ipArrary = ip.Split('.');
           foreach (var item in ipArrary)
           {
              result.Add(Convert.ToByte(item, 10));
           }
           return result.ToArray();
       }

       public static string ConvertBytesToIpString(byte[] value,int startIndex)
       {
           var res = string.Empty;
           for (int i = 0; i < 4; i++)
           {
              res+= Convert.ToInt32(value[startIndex + i])+".";
           }
           res = res.TrimEnd('.');
           return res;
       }

    }
}
