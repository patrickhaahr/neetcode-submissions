public class Solution {
    public int LongestConsecutive(int[] nums) {
        // make the int array nums values store in numSet hashset
        HashSet<int> numSet = new HashSet<int>(nums);
        // longest length of consecutive sequence of elements
        int longest = 0;

        // iterate over the numSet
        foreach (int num in numSet) {
            // check if it's the start of the sequence
            // if the current value in numSet doesn't contain (num - 1), then it's the first sequence of an element and we start counting with 1 in "length"
            if (!numSet.Contains(num - 1)) {
                int length = 1;
                // continue to +1 in "length" if there is a value of consecutive sequence (num + length)
                while (numSet.Contains(num + length)){
                    length++;
                }
                // longest = maximum value between "longest" and "length"
                longest = Math.Max(longest, length);
            }
        }
        return longest;
    }
}