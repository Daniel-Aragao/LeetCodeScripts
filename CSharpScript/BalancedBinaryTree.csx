/**
Given a binary tree, determine if it is height-balanced

Height-Balanced: A height-balanced binary tree is a binary tree in which the depth of the 
two subtrees of every node never differs by more than one.
 */

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    private Dictionary<TreeNode, int> maxDepths;

    public bool IsBalanced(TreeNode root) 
    {
        maxDepths = new Dictionary<TreeNode, int>();
        if(root == null) return true;

        var stack = new Stack<(TreeNode, int)>();
        stack.Push((root, 0));

        while(stack.Any())
        {
            var (node, depth) = stack.Pop();

            if(node == null) continue;

            var nextDepth = depth + 1;
            int depthLeft = GetDepth(node.left, nextDepth);
            int depthRight = GetDepth(node.right, nextDepth);

            if(Math.Abs(depthLeft - depthRight) > 1)
            {
                return false;
            }
            
            stack.Push((node.left, nextDepth));
            stack.Push((node.right, nextDepth));
        }
        
        return true;
    }

    private int GetDepth(TreeNode node, int depth)
    {
        if(node == null) return depth - 1;

        if(maxDepths.ContainsKey(node))
        {
            return maxDepths[node];
        }

        var maxDepth = Math.Max(GetDepth(node.left, depth + 1), 
                GetDepth(node.right, depth +1));
        
        maxDepths.Add(node, maxDepth);

        return maxDepth;
    }
}