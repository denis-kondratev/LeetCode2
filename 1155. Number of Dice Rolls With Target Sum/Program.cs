/*
 * 1155. Number of Dice Rolls With Target Sum
 * https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/description/?envType=daily-question&envId=2023-12-26
 * 
 * You have n dice, and each die has k faces numbered from 1 to k.
 *
 * Given three integers n, k, and target, return the number of possible ways (out of the kn total ways) to roll the dice, 
 * so the sum of the face-up numbers equals target. Since the answer may be too large, return it modulo 10^9 + 7.
 *
 * Example 1:
 * Input: n = 1, k = 6, target = 3
 * Output: 1
 * Explanation: You throw one die with 6 faces.
 * There is only one way to get a sum of 3.
 * 
 * Example 2:
 * Input: n = 2, k = 6, target = 7
 * Output: 6
 * Explanation: You throw two dice, each with 6 faces.
 * There are 6 ways to get a sum of 7: 1+6, 2+5, 3+4, 4+3, 5+2, 6+1.
 *
 * Example 3:
 * Input: n = 30, k = 30, target = 500
 * Output: 222616187
 * Explanation: The answer must be returned modulo 10^9 + 7.
 *
 * Constraints:
 * 1 <= n, k <= 30
 * 1 <= target <= 1000
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    public int NumRollsToTarget(int n, int k, int target)
    {
        if (target > k*n) return 0;
        
        if (n == 1) return 1;

        const int mod = 1_000_000_007;
        var prev = new int[target];
        var cur = new int[target];
        Array.Fill(cur, 1, 0, Math.Min(target, k));

        for (var i = 1; i < n; i++)
        {
            (cur, prev) = (prev, cur);
            var sum = 0L;

            for (int j = 0, l = -k; j < target; j++, l++)
            {
                cur[j] = (int)(sum % mod);
                var dif = l >= 0 ? prev[l] : 0;
                sum += prev[j] - dif;
            }
        }

        return cur[^1];
    }
}