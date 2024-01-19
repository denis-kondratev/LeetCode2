/*
 * 70. Climbing Stairs
 * https://leetcode.com/problems/climbing-stairs/?envType=daily-question&envId=2024-01-18
 *
 * You are climbing a staircase. It takes n steps to reach the top. Each time you can either climb 1 or 2 steps.
 * In how many distinct ways can you climb to the top?
 *
 * Example 1:
 *   Input: n = 2
 *   Output: 2
 *   Explanation: There are two ways to climb to the top.
 *                1. 1 step + 1 step
 *                2. 2 steps
 *
 * Example 2:
 *   Input: n = 3
 *   Output: 3
 *   Explanation: There are three ways to climb to the top.
 *                1. 1 step + 1 step + 1 step
 *                2. 1 step + 2 steps
 *                3. 2 steps + 1 step
 *
 * Constraints:
 *   1 <= n <= 45
 */

var solution = new Solution();
Console.WriteLine(solution.ClimbStairs(4));

public class Solution
{
    private static readonly double Phi = (1 - Math.Sqrt(5)) / 2;
    
    public int ClimbStairs(int n)
    {
        n++;
        var proxy = (Math.Pow(Phi, n) - Math.Pow(-Phi, -n)) / (2 * Phi - 1);
        return (int)Math.Round(proxy);
    }
}