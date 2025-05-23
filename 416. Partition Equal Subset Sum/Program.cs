﻿/*
 * 416. Partition Equal Subset Sum
 * https://leetcode.com/problems/partition-equal-subset-sum/description/?envType=daily-question&envId=2025-04-07
 *
 * Given an integer array nums, return true if you can partition the array into two subsets such that
 * the sum of the elements in both subsets is equal or false otherwise.
 *
 * Example 1:
 *   Input: nums = [1,5,11,5]
 *   Output: true
 *   Explanation: The array can be partitioned as [1, 5, 5] and [11].
 *
 * Example 2:
 *   Input: nums = [1,2,3,5]
 *   Output: false
 *   Explanation: The array cannot be partitioned into equal sum subsets.
 *
 * Constraints:
 *   1 <= nums.length <= 200
 *   1 <= nums[i] <= 100
 */

var s = new Solution();
Console.WriteLine(s.CanPartition([1,5,11,5]));

public class Solution
{
    public bool CanPartition(int[] nums)
    {
        var sum = nums.Sum();
        if ((sum & 1) == 1)
        {
            return false;
        }

        var target = sum / 2;
        var dp = new bool[target + 1];
        dp[0] = true;

        foreach (var num in nums)
        {
            for (var j = target; j >= num; j--)
            {
                dp[j] = dp[j] || dp[j - num];
            }

            if (dp[target])
            {
                return true;
            }
        }

        return false;
    }
}