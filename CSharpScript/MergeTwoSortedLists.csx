public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public void PrintAll()
    {
        var current = this;
        do
        {
            Console.WriteLine(current.val);
            current = current.next;
        } while(current != null);
    }

    public static ListNode ToListNode(IEnumerable<int> list)
    {
        ListNode head = null;
        ListNode current = null;

        foreach (var i in list)
        {
            if(head == null) {
                head = new ListNode(i);
                current = head;
            } else {
                current.next = new ListNode(i);
                current = current.next;
            }
        }

        return head;
    }
}

public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode head = null;
        ListNode current = null;
        var cursor1 = list1;
        var cursor2 = list2;

        if(cursor1 == null)
        {
            return cursor2;
        } else if(cursor2 == null)
        {
            return cursor1;
        } else 
        {
            if(cursor1.val <= cursor2.val) 
            {
                head = new ListNode(cursor1.val);
                current = head;
                cursor1 = cursor1.next;
            } else {
                head = new ListNode(cursor2.val);
                current = head;
                cursor2 = cursor2.next;
            }
        }

        while(cursor1 != null || cursor2 != null)
        {
            if(cursor2 == null || (cursor1 != null && cursor1.val <= cursor2.val))
            {
                current.next = new ListNode(cursor1.val);
                cursor1 = cursor1.next;
            } 
            else 
            {
                current.next = new ListNode(cursor2.val);
                cursor2 = cursor2.next;
            }

            current = current.next;
        }

        return head;
    }
}

List<int> arg1 = [0, 2, 5];
List<int> arg2 = [1, 3, 4];

var list1 = ListNode.ToListNode(arg1);
var list2 = ListNode.ToListNode(arg2);

new Solution().MergeTwoLists(list1, list2).PrintAll();
