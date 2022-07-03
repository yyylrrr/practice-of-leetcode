using System;
using System.Collections.Generic;
using System.Linq;

namespace lc_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.LengthOfLongestSubstring("dvdvf"));;
            Console.WriteLine(solution.LengthOfLongestSubstring_key("dvdvf"));
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int length = 0;
            int point1 = 0, point2 = 0;
            Dictionary<int, char> dic = new Dictionary<int, char>();
            while (point2 < s.Length)
            {
                if (!dic.ContainsValue(s[point2]))
                {
                    dic.Add(point2,s[point2]);
                    point2++;
                    length = length > point2 - point1 ? length : point2 - point1;
                }
                else
                {
                    point1 = dic.FirstOrDefault(q => q.Value == s[point2]).Key + 1;
                    for(int i = 0; i < point1; i++)
                    {
                        dic.Remove(i);
                    }
                }
            }
            return length;
        }

        public int LengthOfLongestSubstring_key(string s)
        {
            int length = 0;
            int point1 = 0, point2 = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            while (point2 < s.Length)
            {
                if (!dic.ContainsKey(s[point2]))
                {
                    dic.Add(s[point2], point2);
                }
                else
                {
                    point1 = dic[s[point2]] + 1 > point1 ? dic[s[point2]] + 1 : point1;
                    dic[s[point2]] = point2;
                }
                point2++;
                length = length > point2 - point1 ? length : point2 - point1;
            }
            return length;
        }
    }
}
