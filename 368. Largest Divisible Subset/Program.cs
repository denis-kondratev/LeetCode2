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

int[] nums = [1, 2, 3];
var solution = new Solution();
Console.WriteLine(solution.LargestDivisibleSubset(nums));

public class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        Array.Sort(nums);
        var sets = new (int length, int previous)[nums.Length];
        var maxLength = -1;
        var index = -1;

        for (var i = 0; i < nums.Length; i++)
        {
            var length = 0;
            var previous = -1;

            for (var j = 0; j < i; j++)
            {
                if (sets[j].length > length && nums[i] % nums[j] == 0)
                {
                    length = sets[j].length;
                    previous = j;
                }
            }

            if (length >= maxLength)
            {
                maxLength = length;
                index = i;
            }
            
            sets[i] = (length + 1, previous);
        }

        var result = new List<int>(maxLength);
        
        while (index > 0)
        {
            result.Add(nums[index]);
            index = sets[index].previous;
        }

        return result;
    }
}