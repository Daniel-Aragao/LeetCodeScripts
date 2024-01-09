public class Solution {
    public static bool IsValid(string s) {
        var stack = new Stack<char>();

        var pairs = new List<(char, char)>() 
        {
            ('(',')'),
            ('[',']'),
            ('{','}')
        };

        foreach(char charac in s)
        {
            var isOpening = pairs.Where(p => p.Item1 == charac).FirstOrDefault() != default;

            if(isOpening) {
                stack.Push(charac);
            } else {
                var tuple = pairs.Where(p => p.Item2 == charac).First();
                var isClosed = stack.Count > 0 && tuple.Item1 == stack.Pop();

                if(!isClosed)
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}

var result = Solution.IsValid("[()]");

Console.WriteLine(result);