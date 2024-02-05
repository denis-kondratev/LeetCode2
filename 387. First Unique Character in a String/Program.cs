/*
 * 387. First Unique Character in a String
 * https://leetcode.com/problems/first-unique-character-in-a-string/description/?envType=daily-question&envId=2024-02-05
 *
 * Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1.
 *
 * Example 1:
 *   Input: s = "leetcode"
 *   Output: 0
 *
 * Example 2:
 *   Input: s = "loveleetcode"
 *   Output: 2
 *
 * Example 3:
 *   Input: s = "aabb"
 *   Output: -1
 *
 * Constraints:
 *   1 <= s.length <= 10^5
 *   s consists of only lowercase English letters.
 */

Console.WriteLine("Hello, World!");

public class Solution 
{
    public int FirstUniqChar(string s)
    {
        var n = s.Length;
        Span<int> set = stackalloc int['z' + 1];

        foreach (var c in s)
        {
            set[c]++;
        }

        for (var i = 0; i < n; i++)
        {
            if (set[s[i]] == 1)
            {
                return i;
            }
        }

        return -1;
    }
}