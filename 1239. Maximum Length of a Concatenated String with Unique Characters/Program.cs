/*
 * 1239. Maximum Length of a Concatenated String with Unique Characters
 * https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/description/?envType=daily-question&envId=2024-01-23
 *
 * You are given an array of strings arr. A string s is formed by the concatenation of a subsequence of arr that has
 * unique characters. Return the maximum possible length of s. A subsequence is an array that can be derived from
 * another array by deleting some or no elements without changing the order of the remaining elements.
 *
 * Example 1:
 *   Input: arr = ["un","iq","ue"]
 *   Output: 4
 *   Explanation: All the valid concatenations are:
 *     - ""
 *     - "un"
 *     - "iq"
 *     - "ue"
 *     - "uniq" ("un" + "iq")
 *     - "ique" ("iq" + "ue")
 *   Maximum length is 4.
 *
 * Example 2:
 *   Input: arr = ["cha","r","act","ers"]
 *   Output: 6
 *   Explanation: Possible longest valid concatenations are "chaers" ("cha" + "ers") and "acters" ("act" + "ers").
 *
 * Example 3:
 *   Input: arr = ["abcdefghijklmnopqrstuvwxyz"]
 *   Output: 26
 *   Explanation: The only string in arr has all 26 characters.
 *
 * Constraints:
 *   1 <= arr.length <= 16
 *   1 <= arr[i].length <= 26
 *   arr[i] contains only lowercase English letters.
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    private const int MaxStrLength = 26;
    
    public int MaxLength(IList<string> arr)
    {
        var list = arr.Where(x => x.ToHashSet().Count == x.Length).ToArray();
        return MaxLength(list, 0, new HashSet<char>(MaxStrLength));
    }

    private static int MaxLength(string[] arr, int current, HashSet<char> set)
    {
        var maxLength = set.Count;
        
        for (var i = current; i < arr.Length; i++)
        {
            if (arr[i].Length + set.Count > MaxStrLength || set.Overlaps(arr[i])) continue;
            set.UnionWith(arr[i]);
            maxLength = Math.Max(maxLength, MaxLength(arr, i + 1, set));
            if (maxLength == MaxStrLength) return maxLength;
            set.ExceptWith(arr[i]);
        }

        return maxLength;
    }
}