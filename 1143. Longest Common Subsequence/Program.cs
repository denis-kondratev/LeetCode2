/*
 * 1143. Longest Common Subsequence
 * https://leetcode.com/problems/longest-common-subsequence/?envType=daily-question&envId=2024-01-25
 *
 * Given two strings text1 and text2, return the length of their longest common subsequence. If there is
 * no common subsequence, return 0. A subsequence of a string is a new string generated from the original
 * string with some characters (can be none) deleted without changing the relative order of the remaining characters.
 *
 * For example, "ace" is a subsequence of "abcde".
 * A common subsequence of two strings is a subsequence that is common to both strings.
 *
 * Example 1:
 *   Input: text1 = "abcde", text2 = "ace"
 *   Output: 3
 *   Explanation: The longest common subsequence is "ace" and its length is 3.
 *
 * Example 2:
 *   Input: text1 = "abc", text2 = "abc"
 *   Output: 3
 *   Explanation: The longest common subsequence is "abc" and its length is 3.
 *
 * Example 3:
 *   Input: text1 = "abc", text2 = "def"
 *   Output: 0
 *   Explanation: There is no such common subsequence, so the result is 0.
 *
 * Constraints:
 *   1 <= text1.length, text2.length <= 1000
 *   text1 and text2 consist of only lowercase English characters.
 */

string text1 = "abc", text2 = "abc";
var solution = new Solution();
Console.WriteLine(solution.LongestCommonSubsequence(text1, text2));

public class Solution 
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int m = text1.Length, n = text2.Length;
        var dp = new int[n];

        for (var i = 0; i < m; i++)
        {
            var prev = dp[0] = text1[i] == text2[0] ? 1 : Math.Max(0, dp[0]);

            for (var j = 1; j < n; j++)
            {
                (prev, dp[j]) = (dp[j], text1[i] == text2[j] ? prev + 1 : Math.Max(dp[j - 1], dp[j]));
            }
        }

        return dp[^1];
    }
}