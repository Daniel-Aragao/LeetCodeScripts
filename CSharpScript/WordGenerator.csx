#!/usr/bin/env dotnet-script
#r "nuget: TextCopy, 6.2.1"

using TextCopy;

public class WordGenerator {
    public int PrintingLimitChars { get; set; } = 400;
    public int WordCount { get; set; } = 1;
    public int WordSize { get; set; } = 1000;
    public char MinChar { get; set; } = 'a';
    public char MaxChar { get; set; } = 'z';

    private string GenerateWord()
    {
        var random = new Random();
        var size = random.Next(1, WordSize);
        var word = "";

        for(var i = 0; i < size; i++)
        {
            word += (char) random.Next((int)MinChar, (int)MaxChar + 1);
        }

        return word;
    }

    public string GeneratePhrase() {
        var str = "";

        for(var i = 0; i < WordCount; i++)
        {
            str += GenerateWord();

            if(i < WordCount-1) str += " ";
        }

        return str;
    }
}

// var generator = new WordGenerator() {
//     PrintingLimitChars = 400,
//     WordCount = 1,
//     WordSize = 1000,
//     MinChar = 'a',
//     MaxChar = 'z',
// };

// var str = generator.GeneratePhrase();

// if(str.Length > generator.PrintingLimitChars) {
//     TextCopy.ClipboardService.SetText(str);
//     Console.WriteLine("Copied to clipboard!");
// } else {
//     Console.WriteLine(str);
// }
