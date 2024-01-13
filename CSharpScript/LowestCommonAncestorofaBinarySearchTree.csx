/**
 * Definition for a binary tree node.
 * Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST.
 * According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes 
 * p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a 
 * descendant of itself).”
 */
 public class TreeNode {
     public int val
     public TreeNode left
     public TreeNode right
     public TreeNode(int x) { val = x; }
 }

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var ancestor = root;

        var ancestorsP = SearchNode(root, p);
        var ancestorsQ = SearchNode(root, q);

        while(ancestorsP.Count() > 0)
        {
            var ancestorP = ancestorsP.Pop();

            if(ancestorsQ.Any(a => a.val == ancestorP.val))
            {
                return ancestorP;
            }
        }

        return null;
    }

    private Stack<TreeNode> SearchNode(TreeNode root, TreeNode node)
    {
        TreeNode ancestor = root;
        var ancestors = new Stack<TreeNode>();
        ancestors.Push(ancestor);

        while(ancestor.val != node.val)
        {
            if(ancestor.val > node.val)
            {
                ancestor = ancestor.left;
            } else {
                ancestor = ancestor.right;
            }

            ancestors.Push(ancestor);
        }

        return ancestors;
    }
}
// var list = ListNode.ToListNode([6,2,8,0,4,7,9,null,null,3,5]);

// var solution = new Solution().LowestCommonAncestor(list, 2, 8)
// Console.WriteLine(solution);