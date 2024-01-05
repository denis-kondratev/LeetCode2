/*
 * 300. Longest Increasing Subsequence
 * https://leetcode.com/problems/longest-increasing-subsequence/?envType=daily-question&envId=2024-01-05
 *
 * Given an integer array nums, return the length of the longest strictly increasing subsequence.
 *
 * Example 1:
 *   Input: nums = [10,9,2,5,3,7,101,18]
 *   Output: 4
 *   Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
 *
 * Example 2:
 *   Input: nums = [0,1,0,3,2,3]
 *   Output: 4
 *
 * Example 3:
 *   Input: nums = [7,7,7,7,7,7,7]
 *   Output: 1
 *
 * Constraints:
 *   1 <= nums.length <= 2500
 *   -10^4 <= nums[i] <= 10^4
 *
 * Follow up: Can you come up with an algorithm that runs in O(n log(n)) time complexity?
 */

int[] nums = [5, 6, 7, 2, 3];
var solution = new Solution();
Console.WriteLine(solution.LengthOfLIS(nums));

public class Solution
{
    private int[] _sequence = null!;
    
    public int LengthOfLIS(int[] nums)
    {
        _sequence = new int[nums.Length];
        _sequence[0] = nums[0];
        var sequenceLength = 1;
        
        for (var i = 1; i < nums.Length; i++)
        {
            var index = FindIndexInChain(nums[i], sequenceLength);
            _sequence[index] = nums[i];
            sequenceLength = sequenceLength == index ? sequenceLength + 1 : sequenceLength;
        }

        return sequenceLength;
    }

    int FindIndexInChain(int num, int right)
    {
        var left = 0;

        while (left < right)
        { 
            var current = (left + right) / 2;

            if (_sequence[current] < num)
                left = current + 1;
            else
                right = current;
        }

        return left;
    }
}