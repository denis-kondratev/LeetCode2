/*
 * 645. Set Mismatch
 * https://leetcode.com/problems/set-mismatch/?envType=daily-question&envId=2024-01-22
 *
 * You have a set of integers s, which originally contains all the numbers from 1 to n. Unfortunately,
 * due to some error, one of the numbers in s got duplicated to another number in the set, which results
 * in repetition of one number and loss of another number.
 *
 * You are given an integer array nums representing the data status of this set after the error.
 * Find the number that occurs twice and the number that is missing and return them in the form of an array.
 *
 * Example 1:
 *   Input: nums = [1,2,2,4]
 *   Output: [2,3]
 *
 * Example 2:
 *   Input: nums = [1,1]
 *   Output: [1,2]
 *
 * Constraints:
 *   2 <= nums.length <= 10^4
 *   1 <= nums[i] <= 10^4
 */

int[] nums = [2, 3, 2];
var solution = new Solution();
Console.WriteLine(solution.FindErrorNums(nums));

public class Solution  
{
    public int[] FindErrorNums(int[] nums)
    {
        var dup = 0;
        
        for (var i = 0; i < nums.Length; i++)
        {
            var j = Math.Abs(nums[i]);

            if (nums[j - 1] < 0)
                dup = j;
            else
                nums[j - 1] *= -1;
        }

        return [dup, Array.FindIndex(nums, x => x > 0) + 1];
    }
}