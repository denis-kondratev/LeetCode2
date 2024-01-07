/*
 * 446. Arithmetic Slices II - Subsequence
 * https://leetcode.com/problems/arithmetic-slices-ii-subsequence/?envType=daily-question&envId=2024-01-07
 *
 * Given an integer array nums, return the number of all the arithmetic subsequences of nums.
 *
 * A sequence of numbers is called arithmetic if it consists of at least three elements and if the difference
 * between any two consecutive elements is the same.
 *
 *   - For example, [1, 3, 5, 7, 9], [7, 7, 7, 7], and [3, -1, -5, -9] are arithmetic sequences.
 *   - For example, [1, 1, 2, 5, 7] is not an arithmetic sequence.
 *
 * A subsequence of an array is a sequence that can be formed by removing some elements (possibly none) of the array.
 *
 *   - For example, [2,5,10] is a subsequence of [1,2,1,2,4,1,5,10].
 *
 * The test cases are generated so that the answer fits in 32-bit integer.
 *
 * Example 1:
 *   Input: nums = [2,4,6,8,10]
 *   Output: 7
 *   Explanation: All arithmetic subsequence slices are:
 *     [2,4,6]
 *     [4,6,8]
 *     [6,8,10]
 *     [2,4,6,8]
 *     [4,6,8,10]
 *     [2,4,6,8,10]
 *     [2,6,10]
 *
 * Example 2:
 *   Input: nums = [7,7,7,7,7]
 *   Output: 16
 *   Explanation: Any subsequence of this array is arithmetic.
 *
 * Constraints:
 *   1  <= nums.length <= 1000
 *   -231 <= nums[i] <= 231 - 1
 */

using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

public class Solution
{
    private readonly Dictionary<long, int[]> _slices = new ();
    
    public int NumberOfArithmeticSlices(int[] nums)
    {
        _slices.Clear();
        var counter = 0;
        
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                counter += NumberOfArithmeticSlices(nums, j, (long)nums[j] - nums[i]);
            }
        }

        return counter;
    }
    
    private int NumberOfArithmeticSlices(int[] nums, int i, long diff)
    {
        if (_slices.TryGetValue(diff, out var slice) && slice[i] > 0)
        {
            return slice[i];
        }
        
        for (var j = i + 1; j < nums.Length; j++)
        {
            if ((long)nums[j] - nums[i] != diff) continue;

            slice ??= GetSlice(diff, nums.Length);
            slice[i] += 1 + NumberOfArithmeticSlices(nums, j, diff);
        }
        
        return slice?[i] ?? 0;
    }

    private int[] GetSlice(long diff, int length)
    {
        if (!_slices.TryGetValue(diff, out var slice))
        {
            slice = new int[length];
            _slices[diff] = slice;
        }

        return slice;
    }
}