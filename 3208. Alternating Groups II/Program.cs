/*
 * 3208. Alternating Groups II
 * https://leetcode.com/problems/alternating-groups-ii/description/?envType=daily-question&envId=2025-03-09
 *
 * There is a circle of red and blue tiles. You are given an array of integers colors and an integer k.
 * The color of tile i is represented by colors[i]:
 *   colors[i] == 0 means that tile i is red.
 *   colors[i] == 1 means that tile i is blue.
 *
 * An alternating group is every k contiguous tiles in the circle with alternating colors (each tile in the
 * group except the first and last one has a different color from its left and right tiles).
 *
 * Return the number of alternating groups.
 * Note that since colors represents a circle, the first and the last tiles are considered to be next to each other.
 *
 * Constraints:
 *   3 <= colors.length <= 105
 *   0 <= colors[i] <= 1
 *   3 <= k <= colors.length
 */

var s = new Solution();
s.NumberOfAlternatingGroups([0, 1, 0, 1, 0], 3); // 2
Console.WriteLine("Hello, World!");

public class Solution
{
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        var n = colors.Length;

        if (n < k)
        {
            return 0;
        }

        var beginning = 0;
        var end = 0;
        var length = 0;
        var result = 0;
        k--;

        while (beginning < n)
        {
            var prevEnd = end;
            end = (end + 1) % n;

            if (colors[prevEnd] != colors[end])
            {
                length++;

                if (length >= k)
                {
                    result++;
                    beginning++;
                }
            }
            else
            {
                length = 0;
                if (end < beginning)
                {
                    break;
                }

                beginning = end;
            }
        }

        return result;
    }
}