public class Solution {
    public bool IsValid(string s) {
        Dictionary<char, char> matches = new();
        matches.Add('(', ')');
        matches.Add('[', ']');
        matches.Add('{', '}');

        // stack = LIFO data structure (Last-In Last-Out)
        //         stores object into a sort of "vertical tower"
        //         push() to add to the top
        //         pop() to remove from the top
        Stack<char> stack = new();

        // loops through the string 's'
        foreach (char c in s){
            // if 'c' conatains a parentheses value from the dictionary, it will add the value to the stack
            if(matches.ContainsKey(c)){
                stack.Push(c);
            }
            // when the current 'c' is not an opening parenthesis/bracket
            else {
                // checking if the count is empty, if empty it will return false.
                // empty = no opening brackets left to match with this closing bracket, which makes the string invalid.
                if(stack.Count == 0){
                    return false;
                }
                // the stack isnt empty and it pops the topElement from the stack
                // removing the latest opening bracket that was added to the stack.
                // topElement (opening bracket) is expecting to match with the current 'c' (closing bracket) 
                char topElement = stack.Pop();

                //checks if the popped topElement(opening bracket) macthes with the current 'c' using the matches dictionary. 
                // return false if topElement and 'c' doesnt match.
                if(matches[topElement] != c){
                    return false;
                }
            }
        }
        // if the stack is empty, then it means all the start parentheses had a matching closing parentheses and it will return true
        // If the stack is not empty (there are still unmatched opening brackets), it returns false.
        return stack.Count == 0;
    }
}
