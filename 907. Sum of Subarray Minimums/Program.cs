/*
 * 907. Sum of Subarray Minimums
 * https://leetcode.com/problems/sum-of-subarray-minimums/?envType=daily-question&envId=2024-01-20
 *
 * Given an array of integers arr, find the sum of min(b), where b ranges over every (contiguous) subarray of arr.
 * Since the answer may be large, return the answer modulo 109 + 7.
 *
 * Example 1:
 *   Input: arr = [3,1,2,4]
 *   Output: 17
 *   Explanation:
 *     Subarrays are [3], [1], [2], [4], [3,1], [1,2], [2,4], [3,1,2], [1,2,4], [3,1,2,4].
 *     Minimums are 3, 1, 2, 4, 1, 1, 2, 1, 1, 1.
 *     Sum is 17.
 *
 * Example 2:
 *   Input: arr = [11,81,94,43,3]
 *   Output: 444
 *
 * Constraints:
 *   1 <= arr.length <= 3 * 104
 *   1 <= arr[i] <= 3 * 104
 */

int[] arr = [5, 7, 8, 6, 4];
var solution = new Solution();
Console.WriteLine(solution.SumSubarrayMins(arr));

public class Solution
{
    private const int Mod = 1_000_000_007;
    
    public int SumSubarrayMins(int[] arr)
    {
        int n = arr.Length, sum = arr[^1], rowSum = sum;
        var peeks = new Stack<(int value, int index)>(n);
        peeks.Push((sum, n - 1));

        for (var i = n - 2; i >= 0; i--)
        {
            var curPeek = (value: arr[i], index: i);

            while (peeks.TryPeek(out var peek) && peek.value >= curPeek.value)
            {
                rowSum -= peek.value * (peek.index - curPeek.index);
                curPeek.index = peek.index;
                peeks.Pop();
            }

            rowSum = (int)((rowSum + (long)curPeek.value * (curPeek.index - i + 1)) % Mod);
            peeks.Push(curPeek);
            sum = (sum + rowSum) % Mod;
        }
        
        return sum;
    }
}