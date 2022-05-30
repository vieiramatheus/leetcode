using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.ArrayHash
{
    public class EncodeDecodeStrings
    {
        public static string Encode(string[] strs)
        {
            var res = "";
            foreach (var word in strs)
            {
                res += word.Length + "#" + word;
            }

            return res;
        }

        public static string[] Decode(string str)
        {
            int i = 0, j, size, index=0;
            var res = new string[] { };

            while (i < str.Length)
            {
                j = 0;
                while (str[j] != '#')
                {
                    j++;
                }
                size = int.Parse(str.Substring(i, j));
                Array.Resize(ref res, res.Length + 1);
                res[index] = str.Substring(i + j + 1, size);
                index++;
                i += j + 1 + size;
            }

            return res;
        }
    }
}
