﻿/*
 * 2537. Count the Number of Good Subarrays
 * https://leetcode.com/problems/count-the-number-of-good-subarrays/description/?envType=daily-question&envId=2025-04-16
 *
 * Given an integer array nums and an integer k, return the number of good subarrays of nums.
 *
 * A subarray arr is good if there are at least k pairs of indices (i, j) such that i < j and arr[i] == arr[j].
 *
 * A subarray is a contiguous non-empty sequence of elements within an array.
 *
 * Example 1:
 *   Input: nums = [1,1,1,1,1], k = 10
 *   Output: 1
 *   Explanation: The only good subarray is the array nums itself.
 *
 * Example 2:
 *   Input: nums = [3,1,4,3,2,2,4], k = 2
 *   Output: 4
 *   Explanation: There are 4 different good subarrays:
 *     - [3,1,4,3,2,2] that has 2 pairs.
 *     - [3,1,4,3,2,2,4] that has 3 pairs.
 *     - [1,4,3,2,2,4] that has 2 pairs.
 *     - [4,3,2,2,4] that has 2 pairs.
 *
 * Constraints:
 *   1 <= nums.length <= 10^5
 *   1 <= nums[i], k <= 10^9
 */

var s = new Solution();
Console.WriteLine(s.CountGood([3, 1, 4, 3, 2, 2, 4], 2));

public class Solution
{
    public long CountGood(int[] nums, int k)
    {
        int pairs = 0, right = -1, n = nums.Length;
        var map = new Dictionary<int, int>();
        long result = 0;

        for (var left = 0; left < n; left++)
        {
            var leftNum = nums[left];
            while (pairs < k && right + 1 < n)
            {
                var rightNum = nums[++right];
                map.TryGetValue(rightNum, out var rightNumCount);
                pairs += rightNumCount;
                map[rightNum] = rightNumCount + 1;
            }

            if (pairs >= k)
            {
                result += n - right;
            }

            var leftNumCount = map[leftNum] - 1;
            map[leftNum] = leftNumCount;
            pairs -= leftNumCount;
        }

        return result;
    }
}