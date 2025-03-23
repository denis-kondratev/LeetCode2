/*
 * 1976. Number of Ways to Arrive at Destination
 * https://leetcode.com/problems/number-of-ways-to-arrive-at-destination/description/?envType=daily-question&envId=2025-03-23
 *
 * You are in a city that consists of n intersections numbered from 0 to n - 1 with bi-directional roads
 * between some intersections. The inputs are generated such that you can reach any intersection from
 * any other intersection and that there is at most one road between any two intersections.
 *
 * You are given an integer n and a 2D integer array roads where roads[i] = [u_i, v_i, time_i] means
 * that there is a road between intersections ui and vi that takes time_i minutes to travel. You
 * want to know in how many ways you can travel from intersection 0 to intersection n - 1 in the
 * shortest amount of time.
 *
 * Return the number of ways you can arrive at your destination in the shortest amount of time.
 * Since the answer may be large, return it modulo 10^9 + 7.
 *
 * Example 1:
 *   Input: n = 7, roads = [[0,6,7],[0,1,2],[1,2,3],[1,3,3],[6,3,3],[3,5,1],[6,5,1],[2,5,1],[0,4,5],[4,6,2]]
 *   Output: 4
 *   Explanation: The shortest amount of time it takes to go from intersection 0 to intersection 6 is 7 minutes.
 *   The four ways to get there in 7 minutes are:
 *     - 0 ➝ 6
 *     - 0 ➝ 4 ➝ 6
 *     - 0 ➝ 1 ➝ 2 ➝ 5 ➝ 6
 *     - 0 ➝ 1 ➝ 3 ➝ 5 ➝ 6
 *
 * Example 2:
 *   Input: n = 2, roads = [[1,0,10]]
 *   Output: 1
 *   Explanation: There is only one way to go from intersection 0 to intersection 1, and it takes 10 minutes.
 *
 * Constraints:
 *   1 <= n <= 200
 *   n - 1 <= roads.length <= n * (n - 1) / 2
 *   roads[i].length == 3
 *   0 <= u_i, v_i <= n - 1
 *   1 <= time_i <= 10^9
 *   u_i != v_i
 *   There is at most one road connecting any two intersections.
 *   You can reach any intersection from any other intersection.
 */

Console.WriteLine("Hello, World!");

public class Solution
{
    private const int Mod = 1_000_000_007;
    
    public int CountPaths(int n, int[][] roads)
    {
        var graph = new List<(int, int)>[n];
        for (var i = 0; i < n; i++) graph[i] = [];

        foreach (var road in roads)
        {
            int u = road[0], v = road[1], time = road[2];
            graph[u].Add((v, time));
            graph[v].Add((u, time));
        }

        var dist = new long[n];
        var ways = new int[n];
        Array.Fill(dist, long.MaxValue);
        Array.Fill(ways, 0);

        dist[0] = 0;
        ways[0] = 1;
        

        PriorityQueue<(long d, int v), (long d, int v)> pq = new();
        pq.Enqueue((0, 0), (0, 0));

        while (pq.Count > 0)
        {
            var (d, node) = pq.Dequeue();
            if (d > dist[node])
            {
                continue;
            }

            foreach (var (neighbor, time) in graph[node])
            {
                if (dist[node] + time < dist[neighbor])
                {
                    dist[neighbor] = dist[node] + time;
                    ways[neighbor] = ways[node];
                    pq.Enqueue((dist[neighbor], neighbor), (dist[neighbor], neighbor));
                }
                else if (dist[node] + time == dist[neighbor])
                {
                    ways[neighbor] = (ways[neighbor] + ways[node]) % Mod;
                }
            }
        }

        return ways[n - 1];
    }
}