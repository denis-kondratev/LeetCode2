﻿/*
 * 1235. Maximum Profit in Job Scheduling
 * https://leetcode.com/problems/maximum-profit-in-job-scheduling/?envType=daily-question&envId=2024-01-06
 *
 * We have n jobs, where every job is scheduled to be done from startTime[i] to endTime[i],
 * obtaining a profit of profit[i]. You're given the startTime, endTime and profit arrays, return the maximum profit
 * you can take such that there are no two jobs in the subset with overlapping time range.
 *
 * If you choose a job that ends at time X you will be able to start another job that starts at time X.
 *
 * Example 1:
 *  Input: startTime = [1,2,3,3], endTime = [3,4,5,6], profit = [50,10,40,70]
 *  Output: 120
 *  Explanation: The subset chosen is the first and fourth job.
 *  Time range [1-3]+[3-6] , we get profit of 120 = 50 + 70.
 *
 * Example 2:
 *  Input: startTime = [1,2,3,4,6], endTime = [3,5,10,6,9], profit = [20,20,100,70,60]
 *  Output: 150
 *  Explanation: The subset chosen is the first, fourth and fifth job.
 *  Profit obtained 150 = 20 + 70 + 60.
 *
 * Example 3:
 *  Input: startTime = [1,1,1], endTime = [2,3,4], profit = [5,6,4]
 *  Output: 6
 *
 * Constraints:
 *  1 <= startTime.length == endTime.length == profit.length <= 5 * 10^4
 *  1 <= startTime[i] < endTime[i] <= 10^9
 *  1 <= profit[i] <= 10^4
 */

int[] startTime = [1, 2, 3, 4, 6];
int[] endTime = [3, 5, 10, 6, 9];
int[] profit = [20, 20, 100, 70, 60];
var solution = new Solution();
Console.WriteLine(solution.JobScheduling(startTime, endTime, profit));

public class Solution 
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        var n = startTime.Length;
        var orderedIndices = Enumerable.Range(0, n).OrderBy(i => endTime[i]).ToArray();
        var timeline = new List<(int endTime, int profit)>(n + 1) { (0, 0) };

        foreach (var i in orderedIndices)
        {
            if (endTime[i] != timeline[^1].endTime)
            {
                timeline.Add((endTime[i], timeline[^1].profit));
            }
            
            var curProfit = FindPreviousProfit(timeline, startTime[i]) + profit[i];

            if (curProfit > timeline[^1].profit)
            {
                timeline[^1] = (endTime[i], curProfit);
            }
        }
        
        return timeline[^1].profit;
    }

    private int FindPreviousProfit(List<(int endTime, int profit)> dp, int endTime)
    {
        int left = 0, right = dp.Count - 2;

        while (left < right)
        {
            var middle = (left + right - 1) / 2 + 1;

            if (dp[middle].endTime <= endTime)
            {
                left = middle;
            }
            else
            {
                right = middle - 1;
            }
        }

        return dp[left].profit;
    }
}