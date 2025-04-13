/*
 * 1922. Count Good Numbers
 * https://leetcode.com/problems/count-good-numbers/description/?envType=daily-question&envId=2025-04-13
 *
 * A digit string is good if the digits (0-indexed) at even indices are even and the digits at odd
 * indices are prime (2, 3, 5, or 7).
 *
 * For example, "2582" is good because the digits (2 and 8) at even positions are even and the
 * digits (5 and 2) at odd positions are prime. However, "3245" is not good because 3 is at an
 * even index but is not even.
 *
 * Given an integer n, return the total number of good digit strings of length n. Since the answer
 * may be large, return it modulo 10^9 + 7.
 *
 * A digit string is a string consisting of digits 0 through 9 that may contain leading zeros.
 *
 * Example 1:
 *   Input: n = 1
 *   Output: 5
 *   Explanation: The good numbers of length 1 are "0", "2", "4", "6", "8".
 *
 * Example 2:
 *   Input: n = 4
 *   Output: 400
 *
 * Example 3:
 *   Input: n = 50
 *   Output: 564908303
 *
 * Constraints:
 *   1 <= n <= 10^15
 */

var s = new Solution();
Console.WriteLine(s.CountGoodNumbers(1));

public class Solution
{
    private const int Mod = 1_000_000_007;
    
    public int CountGoodNumbers(long n)
    {
        long oddCount = n / 2, evenCount = n - oddCount;
        return (int)(ModPow(5, evenCount) * ModPow(4, oddCount) % Mod);
    }
    
    private long ModPow(long value, long power)
    {
        long result = 1;
        
        while (power > 0)
        {
            if ((power & 1) == 1)
            {
                result = result * value % Mod;
            }
            value = value * value % Mod;
            power >>= 1;
        }
        
        return result;
    }
}