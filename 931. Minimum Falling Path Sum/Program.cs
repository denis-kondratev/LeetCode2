/*
 * 931. Minimum Falling Path Sum
 * https://leetcode.com/problems/minimum-falling-path-sum/?envType=daily-question&envId=2024-01-19
 *
 * Given an n x n array of integers matrix, return the minimum sum of any falling path through matrix. A falling
 * path starts at any element in the first row and chooses the element in the next row that is either directly below
 * or diagonally left/right. Specifically, the next element from position (row, col) will be (row + 1, col - 1),
 * (row + 1, col), or (row + 1, col + 1).
 *
 * Example 1:
 *   Input: matrix = [[2,1,3],[6,5,4],[7,8,9]]
 *   Output: 13
 *   Explanation: There are two falling paths with a minimum sum as shown.
 *
 * Example 2:
 *   Input: matrix = [[-19,57],[-40,-5]]
 *   Output: -59
 *   Explanation: The falling path with a minimum sum is shown.
 *
 * Constraints:
 *   n == matrix.length == matrix[i].length
 *   1 <= n <= 100
 *   -100 <= matrix[i][j] <= 100
 */

int[][] matrix = [[2, 1, 3], [6, 5, 4], [7, 8, 9]];
var solution = new Solution();
Console.WriteLine(solution.MinFallingPathSum(matrix));

public class Solution 
{
    public int MinFallingPathSum(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length - 1;
        int[] desc = matrix[0];

        for (var i = 1; i < m; i++)
        {
            var prev = int.MaxValue;
            
            for (var j = 0; j < n; j++)
            {
                var value = Math.Min(Math.Min(prev, desc[j]), desc[j + 1]);
                prev = desc[j];
                desc[j] = value + matrix[i][j];
            }
            
            desc[n] = matrix[i][n] + Math.Min(prev, desc[n]);
        }
        
        return desc.Min();
    }
}