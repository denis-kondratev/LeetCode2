/*
 * 49. Group Anagrams
 * https://leetcode.com/problems/group-anagrams/?envType=daily-question&envId=2024-02-06
 *
 * Given an array of strings strs, group the anagrams together. You can return the answer in any order.
 * An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
 * typically using all the original letters exactly once.
 *
 * Example 1:
 *   Input: strs = ["eat","tea","tan","ate","nat","bat"]
 *   Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
 *
 * Example 2:
 *   Input: strs = [""]
 *   Output: [[""]]
 *
 * Example 3:
 *   Input: strs = ["a"]
 *   Output: [["a"]]
 *
 * Constraints:
 *   1 <= strs.length <= 10^4
 *   0 <= strs[i].length <= 100
 *   strs[i] consists of lowercase English letters.
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var anagrams = new Dictionary<string, IList<string>>();
        var buffer = new char[100];

        foreach (var str in strs)
        {
            var length = str.Length;
            str.CopyTo(0, buffer, 0, length);
            Array.Sort(buffer, 0, length);
            var key = new string(buffer, 0, length);

            if (anagrams.TryGetValue(key, out var list))
            {
                list.Add(str);
            }
            else
            {
                anagrams[key] = new List<string> { str };
            }
        }
        
        return anagrams.Select(x => x.Value).ToArray();
    }
}