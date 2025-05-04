/*
 * 838. Push Dominoes
 * https://leetcode.com/problems/push-dominoes/description/?envType=daily-question&envId=2025-05-02
 *
 * There are `n` dominoes in a line, and we place each domino vertically upright. In the beginning,
 * we simultaneously push some of the dominoes either to the left or to the right.
 *
 * After each second, each domino that is falling to the left pushes the adjacent domino on the left.
 * Similarly, the dominoes falling to the right push their adjacent dominoes standing on the right.
 *
 * When a vertical domino has dominoes falling on it from both sides, it stays still due
 * to the balance of the forces.
 *
 * For the purposes of this question, we will consider that a falling domino expends no additional
 * force to a falling or already fallen domino.
 *
 * You are given a string `dominoes` representing the initial state where:
 *   - `dominoes[i] = 'L'`, if the `i-th` domino has been pushed to the left,
 *   - `dominoes[i] = 'R'`, if the `i-th` domino has been pushed to the right, and
 *   - `dominoes[i] = '.'`, if the `i-th` domino has not been pushed.
 *
 * Return a string representing the final state.
 *
 * Example 1:
 *   Input: dominoes = "RR.L"
 *   Output: "RR.L"
 *   Explanation: The first domino expends no additional force on the second domino.
 *
 * Example 2:
 *   Input: dominoes = ".L.R...LR..L.."
 *   Output: "LL.RR.LLRRLL.."
 *
 * Constraints:
 *   n == dominoes.length
 *   1 <= n <= 10^5
 *   dominoes[i] is either 'L', 'R', or '.'.
 */

var s = new Solution();
Console.WriteLine(s.PushDominoes(".R..L."));

public class Solution
{
    public string PushDominoes(string dominoes)
    {
        var n = dominoes.Length;

        if (n == 1)
        {
            return dominoes;
        }
        
        char[] current = new char[n];
        char[] result = dominoes.ToCharArray();
        var hasChanged = true;

        while (hasChanged)
        {
            hasChanged = false;
            (current, result) = (result, current);

            result[0] = current[0] == '.' && current[1] == 'L' ? 'L' : current[0];
            result[^1] = current[^1] == '.' && current[^2] == 'R' ? 'R' : current[^1];
            
            for (var i = 1; i < n - 1; i++)
            {
                if (current[i] == '.')
                {
                    char l = current[i - 1], r = current[i + 1];
                    
                    if (l == 'R' && r != 'L')
                    {
                        result[i] = 'R';
                        hasChanged = true;
                    }
                    else if (r == 'L' && l != 'R')
                    {
                        result[i] = 'L';
                        hasChanged = true;
                    }
                    else
                    {
                        result[i] = '.';
                    }
                }
                else
                {
                    result[i] = current[i];
                }
            }
        }
        
        return new string(result);
    }
}