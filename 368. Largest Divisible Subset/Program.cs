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
        var dp = new (int value, int next, int length)[nums.Length];
        var n = nums.Length;
        int maxLength = 0, maxIndex = -1;
        
        for (var i = n - 1; i >= 0; i--)
        {
            var num = nums[i];
            (int currentIndex, int nextIndex, int length) cur = (num, -1, 1);

            for (var j = i + 1; j < n; j++)
            {
                var (value, next, length) = dp[j];
                
                if (length >= cur.length && value % num == 0)
                {
                    cur = (num, j, length + 1);
                }
            }

            dp[i] = cur;
            
            if (cur.length > maxLength)
            {
                maxLength = cur.length;
                maxIndex = i;
            }
        }

        var result = new List<int>(maxLength);
        var k = maxIndex;
        
        while (k != -1)
        {
            var (value, next, length) = dp[k];
            result.Add(value);
            k = next;
        }
        
        return result;
    }
}