public class Solution {
    public bool IsValidSudoku(char[][] board) {

        // HashSet for constant time lookup, only stores unique values
        HashSet<string> seen = new HashSet<string>();

        // Rows - outer loop
        for (int r = 0; r < 9; r++) {
            // Columns - inner loop
            for (int c = 0; c < 9; c++) {
                char current_val = board[r][c];
                
                // If the current cell is not empty ('.'), check for duplicates
                if (current_val != '.') {
                    // Try to add the current value into the HashSet for row, column, and sub-box
                    if (!seen.Add(current_val + " found in row " + r) ||
                        !seen.Add(current_val + " found in column " + c) ||
                        !seen.Add(current_val + " found in sub-box " + (r / 3) + "-" + (c / 3))) {
                        return false; // Duplicate found
                    }
                }
            }
        }
        return true; // No duplicates found, the board is valid
    }
}