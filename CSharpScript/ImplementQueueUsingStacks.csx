public class MyQueue {
    private Stack<int> rearEnded = new Stack<int>();
    private Stack<int> headEnded = new Stack<int>();

    public MyQueue() {
        
    }
    
    public void Push(int x) {
        if(!rearEnded.Any()) {
            Invert();
        }

        rearEnded.Push(x);
    }
    
    public int Pop() {
        if(!headEnded.Any()) {
            Invert();
        }

        return headEnded.Pop();
    }
    
    public int Peek() {
        if(!headEnded.Any()) {
            Invert();
        }

        return headEnded.Peek();
    }
    
    public bool Empty() {
        return !headEnded.Any() && !rearEnded.Any();
    }

    private void Invert() {
        if(rearEnded.Any()) {
            while(rearEnded.Any()) {
                headEnded.Push(rearEnded.Pop());
            }
        } else {
            while(headEnded.Any()) {
                rearEnded.Push(headEnded.Pop());
            }
        }
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */