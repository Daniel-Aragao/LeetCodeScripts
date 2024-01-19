#!/usr/bin/env dotnet-script
#load "WordGenerator.csx"

/*
Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the 
letters from magazine and false otherwise.

Each letter in magazine can only be used once in ransomNote.

Example 1:
Input: ransomNote = "a", magazine = "b"
Output: false

Example 2:
Input: ransomNote = "aa", magazine = "ab"
Output: false

Example 3:
Input: ransomNote = "aa", magazine = "aab"
Output: true
 
Constraints:
1 <= ransomNote.length, magazine.length <= 105
ransomNote and magazine consist of lowercase English letters.
*/

public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var magazineDict = new Dictionary<char, int>();
        var magazineCursor = 0;

        for(var i = 0; i < ransomNote.Length; i++)
        {
            char noteChar = ransomNote[i];

            if(magazineDict.ContainsKey(noteChar) && 
                magazineDict[noteChar] > 0)
            {
                magazineDict[noteChar]--;
            } else 
            {
                var magazineChar = '\n';

                while(magazineCursor < magazine.Length)
                {
                    magazineChar = magazine[magazineCursor];
                    magazineCursor++;

                    if(!magazineDict.ContainsKey(magazineChar))
                    {
                        magazineDict.Add(magazineChar, 0);
                    }


                    if(magazineChar == noteChar) {
                        break;
                    }

                    magazineDict[magazineChar]++;
                }

                if(magazineChar != noteChar) {
                    return false;
                }
            }
        }

        return true;
    }

    public bool CanConstruct2(string ransomNote, string magazine) {
        var ransomNoteChars = new int['z'-'a' + 1];

        foreach(var c in ransomNote)
        {
            ransomNoteChars[c - 'a']++;
        }

        foreach(var c in magazine)
        {
            ransomNoteChars[c - 'a']--;
        }

        return !ransomNoteChars.Any(c => c > 0);
    }

    public bool CanConstruct3(string ransomNote, string magazine) {
        var ransomNoteChars = new int['z'-'a' + 1];
        var cursor = 0;

        foreach(var c in ransomNote)
        {
            ransomNoteChars[c - 'a']++;
        }

        for(var i = 0; i < ransomNoteChars.Length; i++) {
            if(ransomNoteChars[i] <= 0) continue;

            while(cursor < magazine.Length)
            {
                int j = magazine[cursor] - 'a';
                cursor++;

                ransomNoteChars[j]--;

                if(ransomNoteChars[i] <= 0) break;
            }

            if(ransomNoteChars[i] > 0) return false;
        }

        return true;
    }
}

var ransomNotesGenerator = new WordGenerator() {
    WordCount = 1,
    WordSize = 1000,
    MinChar = 'a',
    MaxChar = 'z',
};

var magazinesGenerator = new WordGenerator() {
    WordCount = 1,
    WordSize = 10000,
    MinChar = 'a',
    MaxChar = 'z',
};

var nWords = 1000;
var magazines = new string[nWords];
var ransomNotes = new string[nWords];

Console.WriteLine("Generate Ransom note {0} words of size limite {1}", nWords, ransomNotesGenerator.WordSize);
Console.WriteLine("Generate Magazine    {0} words of size limite {1}", nWords, magazinesGenerator.WordSize);

for(var i = 0; i < nWords; i++)
{
    magazines[i] = magazinesGenerator.GeneratePhrase();
    ransomNotes[i] = ransomNotesGenerator.GeneratePhrase();
}

Console.WriteLine("Words generated");

var sol = new Solution();

public (double, double) AverageTime(Func<string, string, bool> construct)
{
    var time = 0L;

    var watch = System.Diagnostics.Stopwatch.StartNew();
    var hit = 0d;

    for(var i = 0; i < nWords; i++)
    {
        watch.Restart();
        hit += construct(ransomNotes[i], magazines[i]) ? 1: 0;

        watch.Stop();
        time += watch.ElapsedTicks;
    }

    return (TicksToNano(time) / (double)nWords, hit * 100 /nWords);
}

public double TicksToNano(long ticks) {
    return ticks * 1000000000 / Stopwatch.Frequency;
}

Console.WriteLine("Running Avg1");
var avg1 = AverageTime(sol.CanConstruct);

Console.WriteLine("Running Avg2");
var avg2 = AverageTime(sol.CanConstruct2);

Console.WriteLine("Running Avg3");
var avg3 = AverageTime(sol.CanConstruct3);

Console.WriteLine("\nRansom notes with {0} words of size limit {1}", nWords, ransomNotesGenerator.WordSize);
Console.WriteLine("\nMagazines with    {0} words of size limit {1}", nWords, magazinesGenerator.WordSize);
Console.WriteLine("Construct1 avg run time |{0,10:0.00}| ns Accuracy |{1,6:0.00}%|", avg1.Item1, avg1.Item2);
Console.WriteLine("Construct2 avg run time |{0,10:0.00}| ns Accuracy |{1,6:0.00}%|", avg2.Item1, avg2.Item2);
Console.WriteLine("Construct3 avg run time |{0,10:0.00}| ns Accuracy |{1,6:0.00}%|", avg3.Item1, avg3.Item2);
