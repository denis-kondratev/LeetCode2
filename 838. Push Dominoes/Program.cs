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
Console.WriteLine(s.PushDominoes(".L.R...LR..L.."));

public class Solution
{
    public string PushDominoes(string dominoes)
    {
        var n = dominoes.Length;

        if (n == 1)
        {
            return dominoes;
        }

        Span<short> arr = stackalloc short[n];
        arr[0] = dominoes[0] switch
        {
            'L' => -1,
            'R' => 1,
            _ => 0
        };

        for (var i = 1; i < n; i++)
        {
            arr[i] = dominoes[i] switch
            {
                'L' => -1,
                'R' => 1,
                _ when arr[i - 1] > 0 => (short)(arr[i - 1] + 1),
                _ => 0
            };
        }
        
        for (var i = n - 2; i >= 0; i--)
        {
            var cur = arr[i];
            
            if (cur is 1 or -1)
            {
                continue;
            }
            
            var prev = arr[i + 1];

            if (prev < 0)
            {
                arr[i] = (prev + cur) switch
                {
                    1 => 0,
                    < 1 when cur is not 0 => cur,
                    _ => (short)(prev - 1)
                };
            }
        }

        return string.Create(n, arr, (span, origin) =>
        {
            for (var i = 0; i < n; i++)
            {
                span[i] = origin[i] switch
                {
                    < 0 => 'L',
                    > 0 => 'R',
                    _ => '.'
                };
            }
        });
    }
}