using System;

namespace lc_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.FindMedianSortedArrays(new int[] { }, new int[] { 1}));
        }
    }

    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            
            if ((nums1.Length + nums2.Length) % 2 == 1)
            {
                int specnum = (nums1.Length + nums2.Length) / 2 + 1;
                double result = GetSpecifiedNumberSortedArrays(nums1, nums2, specnum);
                return result;

            }
            else
            {
                int specnum1 = (nums1.Length + nums2.Length) / 2;
                int specnum2 = (nums1.Length + nums2.Length) / 2 + 1;
                int result1 = GetSpecifiedNumberSortedArrays(nums1, nums2, specnum1);
                int result2 = GetSpecifiedNumberSortedArrays(nums1, nums2, specnum2);
                float result = ((float)result1 + (float)result2) / 2;
                return result;
            }
        }

        public int GetSpecifiedNumberSortedArrays(int[] nums1, int[] nums2, int specnum)
        {
            int indexnum = specnum;
            int half = indexnum / 2 < 1 ? 1 : indexnum / 2;
            int key1 = 0, key2 = 0;
            int num1 = 0, num2 = 0;
            int result = 0;
                while (indexnum >= 1)
                {
                    num1 = nums1[half + key1 < nums1.Length ? half + key1 - 1 : nums1.Length - 1];
                    num2 = nums2[half + key2 < nums2.Length ? half + key2 - 1 : nums2.Length - 1];
                    key1 = num1 <= num2 ? key1 + half : key1;
                    key2 = num1 > num2 ? key2 + half : key2;
                    if (key1 > nums1.Length)
                    {
                        return nums2[specnum - nums1.Length - 1];
                    }
                    if (key2 > nums2.Length)
                    {
                        return nums1[specnum - nums2.Length - 1];
                    }
                    indexnum -= half;
                    half = indexnum / 2 < 1 ? 1 : indexnum / 2;
                }
                if (indexnum == 0)
                {
                    result = num1 < num2 ? num1 : num2;
                }
            return result;
        }
    }
}
