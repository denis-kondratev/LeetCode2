/*
 * 2563. Count the Number of Fair Pairs
 * https://leetcode.com/problems/count-the-number-of-fair-pairs/description/?envType=daily-question&envId=2025-04-19
 *
 * Given a 0-indexed integer array nums of size n and two integers lower and upper, return the number of fair pairs.
 *
 * A pair (i, j) is fair if:
 *   - 0 <= i < j < n, and
 *   - lower <= nums[i] + nums[j] <= upper
 *
 * Example 1:
 *   Input: nums = [0,1,7,4,4,5], lower = 3, upper = 6
 *   Output: 6
 *   Explanation: There are 6 fair pairs: (0,3), (0,4), (0,5), (1,3), (1,4), and (1,5).
 *
 * Example 2:
 *   Input: nums = [1,7,9,2,5], lower = 11, upper = 11
 *   Output: 1
 *   Explanation: There is a single fair pair: (2,3).
 *
 * Constraints:
 *   1 <= nums.length <= 10^5
 *   nums.length == n
 *   -10^9 <= nums[i] <= 10^9
 *   -10^9 <= lower <= upper <= 10^9
 */

var solution = new Solution();
Console.WriteLine(solution.CountFairPairs([0, 1, 4, 4, 5, 7], 3, 6));

public class Solution
{
    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        Array.Sort(nums);
        return CountPairs(nums, upper) - CountPairs(nums, lower - 1);
    }

    private long CountPairs(int[] nums, int target)
    {
        long count = 0;
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            if (nums[left] + nums[right] > target)
            {
                right--;
            }
            else
            {
                count += right - left;
                left++;
            }
        }

        return count;
    }
}