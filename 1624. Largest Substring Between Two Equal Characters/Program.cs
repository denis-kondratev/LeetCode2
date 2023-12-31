/*
 * 1624. Largest Substring Between Two Equal Characters
 * https://leetcode.com/problems/largest-substring-between-two-equal-characters/description/?envType=daily-question&envId=2023-12-31
 *
 * Given a string s, return the length of the longest substring between two equal characters, excluding the two
 * characters. If there is no such substring return -1. A substring is a contiguous sequence of characters within
 * a string.
 *
 * Example 1:
 *
 * Input: s = "aa"
 * Output: 0
 * Explanation: The optimal substring here is an empty substring between the two 'a's.
 *
 * Example 2:
 *
 * Input: s = "abca"
 * Output: 2
 * Explanation: The optimal substring here is "bc".
 *
 * Example 3:
 *
 * Input: s = "cbzxy"
 * Output: -1
 * Explanation: There are no characters that appear twice in s.
 *
 * Constraints:
 * 1 <= s.length <= 300
 * s contains only lowercase English letters.
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        var a = new (int first, int last)[26];
        Array.Fill(a, (0, -1));
        
        for (var i = 0; i < s.Length; i++)
        {
            var index = s[i] - 'a';
            var (first, _) = a[index];
            a[index] = first == 0 ? (i + 1, -1) : (first, i);
        }
        
        var max = a.Max(x => x.last - x.first);
        return max >= 0 ? max : -1;
    }
}