/*
 * 647. Palindromic Substrings
 * https://leetcode.com/problems/palindromic-substrings/?envType=daily-question&envId=2024-02-10
 *
 * Given a string s, return the number of palindromic substrings in it.
 * A string is a palindrome when it reads the same backward as forward.
 * A substring is a contiguous sequence of characters within the string.
 *
 * Example 1:
 *   Input: s = "abc"
 *   Output: 3
 *   Explanation: Three palindromic strings: "a", "b", "c".
 *
 * Example 2:
 *   Input: s = "aaa"
 *   Output: 6
 *   Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
 *
 * Constraints:
 *   1 <= s.length <= 1000
 *   s consists of lowercase English letters.
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    public int CountSubstrings(string s)
    {
        var n = s.Length;
        var dp = new bool[n,n];
        dp[0, 0] = true;
        var count = n;

        for (var i = 1; i < n; i++)
        {
            dp[i, i] = true;
            
            if (s[i] == s[i - 1])
            {
                dp[i, i - 1] = true;
                count++;
            }
            
            for (int j = i - 2; j >= 0; j--)
            {
                if (s[i] == s[j] && dp[i - 1, j + 1])
                {
                    dp[i, j] = true;
                    count++;
                }
            }
        }
        
        return count;
    }
}