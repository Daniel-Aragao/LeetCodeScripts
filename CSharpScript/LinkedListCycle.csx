/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        var dict = new Dictionary<ListNode, int>();
        var pos = -1;
        var current = head;
        var index = 0;

        while(pos == -1 && current != null)
        {
            if(dict.ContainsKey(current))
            {
                pos = index;
            } else {
                dict.Add(current, index);
            }

            current = current.next;

            index++;
        }

        return pos != -1;
    }
}