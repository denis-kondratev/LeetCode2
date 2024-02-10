﻿/*
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
        int n = s.Length, count = n;

        for (int i = 0; i < n; i++)
        {
            int l = i, r = i + 1;

            while (l >= 0 && r < n && s[l--] == s[r++])
            {
                count++;
            }

            l = i - 1;
            r = i + 1;
            
            while (l >= 0 && r < n && s[l--] == s[r++])
            {
                count++;
            }
        }

        return count;
    }
}