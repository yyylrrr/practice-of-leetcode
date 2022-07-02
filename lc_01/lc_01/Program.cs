using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Output output = new Output();
            output.OutputArr(solution.TwoSum(new int[] { 2, 7, 11, 15 }, 9));
            output.OutputArr(solution.TwoSum(new int[] { 3, 2, 4 }, 6));
            output.OutputArr(solution.TwoSum(new int[] { 3, 3 }, 6));
            output.OutputArr(solution.TwoSumDic(new int[] { 2, 7, 11, 15 }, 9));
            output.OutputArr(solution.TwoSumDic(new int[] { 3, 2, 4 }, 6));
            output.OutputArr(solution.TwoSumDic(new int[] { 3, 3 }, 6));
            output.OutputArr(solution.TwoSumDic_another(new int[] { 2, 7, 11, 15 }, 9));
            output.OutputArr(solution.TwoSumDic_another(new int[] { 3, 2, 4 }, 6));
            output.OutputArr(solution.TwoSumDic(new int[] { 3, 3 }, 6));
        }
    }
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { };
        }

        public int[] TwoSumDic(int[] nums, int target)
        {
            Dictionary<int, int> numdic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int dif = target - nums[i];
                if (numdic.ContainsValue(dif))
                {
                    int dif_key = numdic.FirstOrDefault(q => q.Value == dif).Key;
                    return new int[] { dif_key, i };
                }
                else
                {
                    numdic.Add(i, nums[i]);
                }
            }
            return new int[] { };
        }

        public int[] TwoSumDic_another(int[] nums, int target)
        {
            Dictionary<int, int> numdic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int dif = target - nums[i];
                if (numdic.ContainsKey(dif))
                {
                    return new int[] { numdic[dif], i };
                }
                else if (!numdic.ContainsKey(nums[i]))
                {
                    numdic.Add(nums[i], i);
                }
                else
                {

                }
            }
            return new int[] { };
        }
    }

    public class Output
    {
        public void OutputArr(int[] nums)
        {
            Console.WriteLine("[{0}]", string.Join(", ", nums));
        }
    }
}
