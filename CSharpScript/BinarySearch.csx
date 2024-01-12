/// <summary>
/// Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.
/// You must write an algorithm with O(log n) runtime complexity.
/// <br/>
/// Example 1:
///     Input: nums = [-1,0,3,5,9,12], target = 9
///     Output: 4
///     Explanation: 9 exists in nums and its index is 4
/// <br/>
/// Example 2:
///     Input: nums = [-1,0,3,5,9,12], target = 2
///     Output: -1
///     Explanation: 2 does not exist in nums so return -1
/// </summary>
public class Solution {
    public int Search(int[] nums, int target) {
        var size = nums.Count();
        var headCursor = 0;
        var tailCursor = size - 1;
        // 0 1 2 3 4 5

         while(headCursor <= tailCursor) 
         {
            var half = (headCursor + tailCursor) / 2;
            var halfValue = nums[half];

            if(halfValue == target)
            {
                return half;
            } else if(halfValue < target)
            {
                headCursor = half + 1;
            } else {
                tailCursor = half - 1;
            }
        }

        return -1;
    }
}

new Solution().Search([-1,0,3,5,9,12], 13);
// new Solution().Search([2,5], 0);