/*
 * 368. Largest Divisible Subset
 * https://leetcode.com/problems/largest-divisible-subset/?envType=daily-question&envId=2024-02-09
 *
 * Given a set of distinct positive integers nums, return the largest subset answer such that every
 * pair (answer[i], answer[j]) of elements in this subset satisfies:
 *   - answer[i] % answer[j] == 0, or
 *   - answer[j] % answer[i] == 0
 * If there are multiple solutions, return any of them.
 *
 * Example 1:
 *   Input: nums = [1,2,3]
 *   Output: [1,2]
 *   Explanation: [1,3] is also accepted.
 *
 * Example 2:
 *   Input: nums = [1,2,4,8]
 *   Output: [1,2,4,8]
 *
 * Constraints:
 *   1 <= nums.length <= 1000
 *   1 <= nums[i] <= 2 * 10^9
 *   All the integers in nums are unique.
 */

var solution = new Solution();
Console.WriteLine(solution.LargestDivisibleSubset([4,8,10,240]));

public class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        Array.Sort(nums);
        var subsets = new List<int[]>(nums.Length);
        
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var num = nums[i];
            int[]? max = null;
            
            foreach (var subset in subsets)
            {
                if (max is not null && max.Length >= subset.Length)
                {
                    continue;
                }

                if (subset[^1] % num == 0)
                {
                    max = subset;
                }
            }

            subsets.Add(NewArray(num, max));
        }


        return subsets.MaxBy(x => x.Length)!;
    }

    int[] NewArray(int value, int[]? other)
    {
        if (other is null)
        {
            return [value];
        }
        
        var result = new int[other.Length + 1];
        Array.Copy(other, result, other.Length);
        result[^1] = value;
        return result;
    }
}