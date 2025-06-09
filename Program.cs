// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Unicode;
using System.Windows.Media;

using SupportedCharCollection = System.Collections.Concurrent.ConcurrentDictionary<int, bool>;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Stopwatch stopwatch = Stopwatch.StartNew();
SupportedCharCollection supportedChars = new();
ConcurrentDictionary<string, SupportedCharCollection> supportedCharsFontMap = new();

void PrintBlockInfo(SupportedCharCollection supportedChars)
{
    const int decimalPointMultiplier = 1000;
    UnicodeBlock lastUnicodeBlock = default;
    int charCount = 0;
    foreach (int ch in supportedChars.Keys.Order())
    {
        UnicodeBlock currentRange = UnicodeBlock.GetUnicodeBlock(ch);
        if (lastUnicodeBlock != currentRange)
        {
            if (charCount > 0)
            {
                int blockSize = lastUnicodeBlock.Size;
                Console.WriteLine($" - {lastUnicodeBlock.Name}: {charCount} of {blockSize} ({Math.Round((double)charCount / (double)blockSize * 100 * decimalPointMultiplier) / decimalPointMultiplier}%)");
            }
            lastUnicodeBlock = currentRange;
            charCount = 0;
        }
        charCount += 1;
    }
}

const string CALC_TEXT = "Calculating...";
int CALC_TEXT_LENGTH = CALC_TEXT.Length;
string CALC_TEXT_BLANK = new(' ', CALC_TEXT_LENGTH);

bool doCalc = true;
bool doCalcText = false;
bool doFontNameCompare = false;
bool printFontBlockInfo = false;
bool printAnyFontBlockInfo = true;

Console.WriteLine("Enumerating fonts...");
//Note: using Parallel.ForEach here makes it run slower
foreach (FontFamily family in Fonts.SystemFontFamilies)
{
    string familyName = family.Source;
    if (doFontNameCompare)
    {
        var FamilyNames = family.FamilyNames;
        if (FamilyNames.Count > 1 || !FamilyNames.ContainsKey(System.Windows.Markup.XmlLanguage.GetLanguage("en-us")))
        {
            Console.WriteLine(familyName);
            Console.WriteLine(" - " + string.Join(",\n - ", FamilyNames.Select(kv => kv.Key + "=" + kv.Value)));
        }
    }
    if (doCalc)
    {
        Console.Write(familyName + " : ");
        if (doCalcText)
        {
            Console.Write(CALC_TEXT);
        }
        SupportedCharCollection fontSupportedChars = new();

        //Note: using Parallel.ForEach here makes it run slower
        foreach (Typeface typeface in family.GetTypefaces())
        {
            if (typeface.TryGetGlyphTypeface(out GlyphTypeface? glyphTypeface))
            {
                Parallel.ForEach(glyphTypeface.CharacterToGlyphMap.Keys, fontSupportedChar =>
                {
                    supportedChars[fontSupportedChar] = true;
                    fontSupportedChars[fontSupportedChar] = true;
                });
            }
        }
        supportedCharsFontMap[familyName] = fontSupportedChars;
        if (doCalcText)
        {
            Console.CursorLeft -= CALC_TEXT_LENGTH;
            Console.Write(CALC_TEXT_BLANK);
            Console.CursorLeft -= CALC_TEXT_LENGTH;
        }
        Console.WriteLine(fontSupportedChars.Count);
        if (printFontBlockInfo)
        {
            PrintBlockInfo(fontSupportedChars);
        }
    }
}
if (printAnyFontBlockInfo)
{
    Console.WriteLine("Supported glyphs in any font:");
    PrintBlockInfo(supportedChars);
}
Console.WriteLine("Total supported chars: " + supportedChars.Count);
stopwatch.Stop();
Console.WriteLine("Calculation duration: " + stopwatch.ElapsedMilliseconds / 1000f + " seconds");

struct UnicodeBlock 
{
    private static readonly IEnumerable<UnicodeBlock> EveryUnicodeRange = typeof(UnicodeRanges).GetProperties().Where(a => a.PropertyType.Equals(typeof(UnicodeRange)) && a.Name != "All")
    .Select(a => new UnicodeBlock(a.Name, (a.GetValue(null) as UnicodeRange)!));
    static UnicodeBlock()
    {
        EveryUnicodeRange = EveryUnicodeRange.Append(new UnicodeBlock("High Surrogates", 0xD800, 0xDB7F));
        EveryUnicodeRange = EveryUnicodeRange.Append(new UnicodeBlock("High Private Use Surrogates", 0xDB80, 0xDBFF));
        EveryUnicodeRange = EveryUnicodeRange.Append(new UnicodeBlock("Low Surrogates", 0xDC00, 0xDFFF));
        EveryUnicodeRange = EveryUnicodeRange.Append(new UnicodeBlock("Private Use Area", 0xE000, 0xF8FF));
    }

    public static UnicodeBlock GetUnicodeBlock(int codepoint)
    {
        return EveryUnicodeRange.FirstOrDefault(block => {
            return block.Contains(codepoint);
        });
    }

    public readonly string Name;
    public readonly int FirstCodePoint;
    public readonly int LastCodePoint;

    public readonly int Size => LastCodePoint - FirstCodePoint + 1;

    private UnicodeBlock(string name, UnicodeRange range) : this()
    {
        Name = name;
        FirstCodePoint = range.FirstCodePoint;
        LastCodePoint = range.FirstCodePoint + range.Length - 1;
    }
    private UnicodeBlock(string name, int firstCodePoint, int lastCodePoint) : this()
    {
        Name = name;
        FirstCodePoint = firstCodePoint;
        LastCodePoint = lastCodePoint;
    }
    public readonly bool Contains(int codepoint)
    {
        return FirstCodePoint <= codepoint
            && LastCodePoint >= codepoint;
    }
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj != null
                && obj.GetType().Equals(typeof(UnicodeBlock))
                && ((UnicodeBlock)obj).Name == Name;
    }
    public static bool operator ==(UnicodeBlock first, UnicodeBlock second)
    {
        return Equals(first, second);
    }
    public static bool operator !=(UnicodeBlock first, UnicodeBlock second)
    {
        return !(first == second);
    }
}