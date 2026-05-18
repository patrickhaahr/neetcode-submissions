public class MinStack {

    // initiate 2 stacks that holds the value stack and the min value 
    Stack<int> stack = new();
    Stack<int> min_vals = new();
    
    public void Push(int val) {
        stack.Push(val);
        val = Math.Min(val, min_vals.Count == 0 ? val : min_vals.Peek());
        min_vals.Push(val);
    }
    
    public void Pop() {
        stack.Pop();
        min_vals.Pop();
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        return min_vals.Peek();
    }
}
