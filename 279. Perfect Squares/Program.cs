/*
 * 279. Perfect Squares
 * https://leetcode.com/problems/perfect-squares/?envType=daily-question&envId=2024-02-08
 *
 * Given an integer n, return the least number of perfect square numbers that sum to n. A perfect square is an
 * integer that is the square of an integer; in other words, it is the product of some integer with itself.
 * For example, 1, 4, 9, and 16 are perfect squares while 3 and 11 are not.
 *
 * Example 1:
 *   Input: n = 12
 *   Output: 3
 *   Explanation: 12 = 4 + 4 + 4.
 *
 * Example 2:
 *   Input: n = 13
 *   Output: 2
 *
 * Explanation: 13 = 4 + 9.
 *   Constraints:
 *   1 <= n <= 10^4
 */

var solution = new Solution();
Console.WriteLine(solution.NumSquares(13));

public class Solution
{
    public int NumSquares(int n)
    {
        var lengths = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            var minLength = lengths[i - 1] + 1;

            for (int j = 2, sqr = j * j; sqr <= i; ++j, sqr = j * j)
            {
                minLength = Math.Min(minLength, lengths[i - sqr] + 1);
            }

            lengths[i] = minLength;
        }
        
        return lengths[^1];
    }
}