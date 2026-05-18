public class Solution {
    public int[] ProductExceptSelf(int[] nums) {

        int n = nums.Length;
        
        int[] right = new int[n];  // Array to store the product of elements to the right of each index.
        int[] left = new int[n];   // Array to store the product of elements to the left of each index.
        int[] output_array = new int[n];  // Array to store the final result.

        // Initialize the first element of left array as 1 (since there's no element to the left of index 0).
        left[0] = 1;
        // Initialize the last element of right array as 1 (since there's no element to the right of the last index).
        right[n-1] = 1;

        // Calculate the product of all elements to the left of each index.
        // For each index in the "left" array, we multiply all the numbers that come before the current number in "nums"
        for (int i = 1; i < n; i++) {
            left[i] = nums[i-1] * left[i-1]; // Multiply the current element with the product of all previous elements.
        }
        
        // Calculate the product of all elements to the right of each index.
        for (int i = n - 2; i >= 0; i--) {
            right[i] = nums[i+1] * right[i+1]; // Multiply the current element with the product of all elements after it.
        }

        // Multiply the corresponding left and right products to get the final result.
        // output_array[i] is the product of all elements except nums[i].
        for (int i = 0; i < n; i++) {
            output_array[i] = left[i] * right[i];
        }

        return output_array;
    }
}
