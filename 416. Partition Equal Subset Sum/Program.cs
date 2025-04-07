/*
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

Console.WriteLine("Hello, World!");

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

        return CanPartition(nums, target, 0);
    }

    private bool CanPartition(int[] nums, int target, int start)
    {
        switch (target)
        {
            case 0:
                return true;
            case < 0:
                return false;
        }

        for (var i = start; i < nums.Length; i++)
        {
            if (CanPartition(nums, target - nums[i], i + 1))
            {
                return true;
            }
        }

        return false;
    }
}