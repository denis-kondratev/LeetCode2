/*
 * 91. Decode Ways
 * https://leetcode.com/problems/decode-ways/description/?envType=daily-question&envId=2023-12-25
 * 
 * A message containing letters from A-Z can be encoded into numbers using the following mapping:
 *
 * 'A' -> "1"
 * 'B' -> "2"
 * ...
 * 'Z' -> "26"
 * To decode an encoded message, all the digits must be grouped then mapped back into letters using the reverse 
 * of the mapping above (there may be multiple ways). For example, "11106" can be mapped into:
 *
 * "AAJF" with the grouping (1 1 10 6)
 * "KJF" with the grouping (11 10 6)
 * Note that the grouping (1 11 06) is invalid because "06" cannot be mapped into 'F' since "6" is different from "06".
 *
 * Given a string s containing only digits, return the number of ways to decode it.
 *
 * The test cases are generated so that the answer fits in a 32-bit integer.
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    public int NumDecodings(string s)
    {
        if (s[0] == '0') return 0;
        
        var penultimate = 1;
        var last = 1;
        var a = s[0] - '0';

        for (var i = 1; i < s.Length; i++)
        {
            var b = s[i] - '0';
            int current;

            if (b == 0)
            {
                if (a is < 1 or > 2) return 0;
                
                current = penultimate;
            }
            else
            {
                current = a * 10 + b > 26 || a == 0 ? last : penultimate + last;
            }
            
            (a, penultimate, last) = (b, last, current);
        }
        
        return last;
    }
}