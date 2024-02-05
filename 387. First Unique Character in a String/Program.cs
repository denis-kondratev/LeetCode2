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
        Span<(int count,int index)> set = stackalloc (int count,int index)[26];

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var j = s[i] - 'a';
            set[j] = (set[j].count + 1, i);
        }

        var result = int.MaxValue;
        
        foreach (var (count, index) in set)
        {
            if (count == 1 && index < result)
            {
                result = index;
            }
        }

        return result == int.MaxValue ? -1 : result;
    }
}