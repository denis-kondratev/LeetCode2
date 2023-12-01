﻿/*
 * 1662. Check If Two String Arrays are Equivalent
 * https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent/description/?envType=daily-question&envId=2023-12-01
 * 
 * Given two string arrays word1 and word2, return true if the two arrays represent the same string, and false otherwise.
 * A string is represented by an array if the array elements concatenated in order forms the string.
 *
 * Example 1:
 *
 * Input: word1 = ["ab", "c"], word2 = ["a", "bc"]
 * Output: true
 * Explanation:
 * word1 represents string "ab" + "c" -> "abc"
 * word2 represents string "a" + "bc" -> "abc"
 * The strings are the same, so return true.
 * Example 2:
 *
 * Input: word1 = ["a", "cb"], word2 = ["ab", "c"]
 * Output: false
 * Example 3:
 *
 * Input: word1  = ["abc", "d", "defg"], word2 = ["abcddefg"]
 * Output: true
 *
 * Constraints:
 *
 * 1 <= word1.length, word2.length <= 103
 * 1 <= word1[i].length, word2[i].length <= 103
 * 1 <= sum(word1[i].length), sum(word2[i].length) <= 103
 * word1[i] and word2[i] consist of lowercase letters.
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        int i1 = 0, i2 = 0, j1 = 0, j2 = 0;

        if (word1.Sum(x => x.Length) != word2.Sum(x => x.Length)) return false;

        while (i1 < word1.Length)
        {
            if (word1[i1][j1] != word2[i2][j2]) return false;

            if (++j1 >= word1[i1].Length)
            {
                i1++;
                j1 = 0;
            }
            
            if (++j2 >= word2[i2].Length)
            {
                i2++;
                j2 = 0;
            }
        }

        return true;
    }
}