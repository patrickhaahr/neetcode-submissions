public class Solution {
    public int[] TwoSum(int[] nums, int target) {

        // laver en hashmap med int i key og value.
        Dictionary <int, int> indices = new Dictionary<int, int>();

        // loop though each index of the array and stores the values in the hashmap
        for (int i = 0; i < nums.Length; i++) {
            // if target = 9 and nums at index is 1 with value 7, the complement is 9-7 = 2
            int complement = target - nums[i];

            // if the complement (target - nums[i]) exists in the dictionary
            // it means we found two numbers that add up to the target. So, we return the indices of these two numbers:
            // the first one (complement) is stored in the dictionary, and the second one is the current index `i`.

            if (indices.ContainsKey(complement)) {
                return new int[] { indices[complement], i };
            }

            // add the current number and its index to the dictionary
            if (!indices.ContainsKey(nums[i])) {
                indices.Add(nums[i], i);
            }
        }

        // no solution found, return empty array
        return new int[0];
    }
}
