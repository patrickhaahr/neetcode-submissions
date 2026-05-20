public class Solution {
    public bool IsValid(string s) {
        Dictionary<char, char> matches = new();
        matches.Add('(', ')');
        matches.Add('[', ']');
        matches.Add('(', '}');

        // stack = LIFO data structure (Last-In Last-Out)
        //         stores object into a sort of "vertical tower"
        //         push() to add to the top
        //         pop() to remove from the top
        Stack<char> stack = new();

        foreach (char c in s){
            if(matches.ConatainsKey(c)){
                stack.Push(c);
            }
            else {
                if(stack.Count == 0){
                    return false;
                }
                char topElement = stack.Pop();
                if(matches{topElement} != c){
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
}
