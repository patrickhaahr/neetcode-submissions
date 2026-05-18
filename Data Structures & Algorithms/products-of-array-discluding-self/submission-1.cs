public class Solution {
    public int[] ProductExceptSelf(int[] nums) {

        int n = nums.Length;
        
        int[] output_array = new int[n];  // Array to store the final result.

        // Initialize the first element of left array as 1 (since there's no element to the left of index 0).
        output_array[0] = 1;

        // calculating all the values for the product of all numbers to the current elements from the left
        for (int i = 1; i < n; i++) {
            output_array[i] = nums[i-1] * output_array[i-1]; // Multiply the current element with the product of all previous elements.
        }
        
        // Variable R to handle all the products of the elements from the right up to the current element.
        // keep multiplying the varible to make it bigger
        int R = 1;
        for (int i = n - 1; i >= 0; i--) {
            output_array[i] = output_array[i] * R;
            R = R * nums[i]; // R will keep multiplying by the current element, thus making it bigger
        }

        return output_array;
    }
}
