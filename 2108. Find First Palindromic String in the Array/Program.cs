/*
 * 2108. Find First Palindromic String in the Array
 * https://leetcode.com/problems/find-first-palindromic-string-in-the-array/?envType=daily-question&envId=2024-02-13
 *
 * Given an array of strings words, return the first palindromic string in the array.
 * If there is no such string, return an empty string "".
 * A string is palindromic if it reads the same forward and backward.
 *
 * Example 1:
 *   Input: words = ["abc","car","ada","racecar","cool"]
 *   Output: "ada"
 *   Explanation: The first string that is palindromic is "ada".
 *                Note that "racecar" is also palindromic, but it is not the first.
 *
 * Example 2:
 *   Input: words = ["notapalindrome","racecar"]
 *   Output: "racecar"
 *   Explanation: The first and only string that is palindromic is "racecar".
 *
 * Example 3:
 *   Input: words = ["def","ghi"]
 *   Output: ""
 *   Explanation: There are no palindromic strings, so the empty string is returned.
 *
 * Constraints:
 *   1 <= words.length <= 100
 *   1 <= words[i].length <= 100
 *   words[i] consists only of lowercase English letters.
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    public string FirstPalindrome(string[] words)
    {
        foreach (var word in words)
        {
            int l = -1, r = word.Length;

            while (++l < --r)
            {
                if (word[l] != word[r])
                {
                    break;
                }
            }

            if (l >= r)
            {
                return word;
            }
        }

        return "";
    }
}