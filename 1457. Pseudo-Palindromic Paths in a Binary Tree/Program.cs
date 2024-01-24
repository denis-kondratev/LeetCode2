/*
 * 1457. Pseudo-Palindromic Paths in a Binary Tree
 * https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/description/?envType=daily-question&envId=2024-01-24
 *
 * Given a binary tree where node values are digits from 1 to 9. A path in the binary tree is said to be
 * pseudo-palindromic if at least one permutation of the node values in the path is a palindrome. Return the number
 * of pseudo-palindromic paths going from the root node to leaf nodes.
 *
 * Example 1:
 *   Input: root = [2,3,1,3,1,null,1]
 *   Output: 2
 *   Explanation: The figure above represents the given binary tree. There are three paths going from the root
 *                node to leaf nodes: the red path [2,3,3], the green path [2,1,1], and the path [2,3,1].
 *                Among these paths only red path and green path are pseudo-palindromic paths since the red
 *                path [2,3,3] can be rearranged in [3,2,3] (palindrome) and the green path [2,1,1] can be
 *                rearranged in [1,2,1] (palindrome).
 *
 * Example 2:
 *   Input: root = [2,1,1,1,3,null,null,null,null,null,1]
 *   Output: 1
 *   Explanation: The figure above represents the given binary tree. There are three paths going from the root
 *                node to leaf nodes: the green path [2,1,1], the path [2,1,3,1], and the path [2,1]. Among these
 *                paths only the green path is pseudo-palindromic since [2,1,1] can be rearranged in [1,2,1]
 *                (palindrome).
 *
 * Example 3:
 *   Input: root = [9]
 *   Output: 1
 *
 * Constraints:
 *   The number of nodes in the tree is in the range [1, 105].
 *   1 <= Node.val <= 9
 */

using System.Diagnostics;
using System.Numerics;
using System.Security;

Console.WriteLine("Hello, World!");

public class TreeNode
{
    public int val;
    public TreeNode? left; 
    public TreeNode? right;
    
    public TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null)
    { 
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public int PseudoPalindromicPaths (TreeNode root)
    {
        var path = 0;
        return GoThroughPaths(root, ref path);
    }

    private int GoThroughPaths(TreeNode? node, ref int path)
    {
        if (node is null) return 0;

        path ^= 1 << (node.val - 1);
        var counter = 0;

        if (node.left is null && node.right is null)
        {
            counter = BitOperations.PopCount((uint)path) < 2 ? 1 : 0;
        }
        else
        {
            counter += GoThroughPaths(node.left, ref path);
            counter += GoThroughPaths(node.right, ref path);
        }

        path ^= 1 << (node.val - 1);
        return counter;
    }
}