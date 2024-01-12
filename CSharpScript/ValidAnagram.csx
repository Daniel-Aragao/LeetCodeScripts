
public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        var letterCounter = new Dictionary<char, int>();

        foreach (char letter in s)
        {
            if (!letterCounter.ContainsKey(letter))
            {
                letterCounter.Add(letter, 0);
            }

            letterCounter[letter]++;
        }

        foreach(char letter in t)
        {
            if(!letterCounter.ContainsKey(letter) || letterCounter[letter] == 0) {
                return false;
            }

            letterCounter[letter]--;
        }

        foreach(KeyValuePair<char, int> pair in letterCounter)
        {
            if(pair.Value > 0) {
                return false;
            }
        }


        return true;
    }
}

Console.WriteLine(new Solution().IsAnagram("rat", "car"));
Console.WriteLine(new Solution().IsAnagram("anagram", "nagaram"));