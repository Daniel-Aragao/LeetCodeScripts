public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();

        var pairs = new List<(char, char)>() 
        {
            ('(',')'),
            ('[',']'),
            ('{','}')
        };

        foreach(char charac in s)
        {
            if(pairs.Where(p => p.Item1 == charac) != null) {
                stack.Push(charac);
            } else {
                var tuple = pairs.Where(p => p.Item2 == charac).First();

                if(tuple.Item1 != stack.Peek())
                {
                    return false;
                }
            }
        }

        return true;
    }
}

Console.WriteLine(IsValid("(])"));