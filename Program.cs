// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Unicode;
using System.Windows.Documents;
using System.Windows.Media;

using SupportedCharCollection = System.Collections.Concurrent.ConcurrentDictionary<int, bool>;

Console.OutputEncoding = System.Text.Encoding.UTF8;

SupportedCharCollection supportedChars = new();
ConcurrentDictionary<string, SupportedCharCollection> supportedCharsFontMap = new();

const string CALC_TEXT = "Calculating...";
int CALC_TEXT_LENGTH = CALC_TEXT.Length;
string CALC_TEXT_BLANK = new(' ', CALC_TEXT_LENGTH);

//TODO add options/flags/commands for these
ProgramMode mode = ProgramMode.CalculateGlyphs;
ProgramFlags flags = ProgramFlags.FontBlockInfo | ProgramFlags.AnyFontBlockInfo;

IEnumerable<(string Name, IEnumerable<ProgramMode> Contraints)> flagsAndConstraints = typeof(ProgramFlags).GetMembers()
    .Where(m => m.DeclaringType == typeof(ProgramFlags))
    .Select(a =>
        (a.Name,
        Contraints: a.GetCustomAttributes(typeof(ProgramFlagsModeConstraintAttribute), false)
        )
    )
    .Where(a =>
        a.Contraints.Length > 0
    )
    .Select(a => 
        (a.Name,
        Contraints: ((ProgramFlagsModeConstraintAttribute)a.Contraints.First()).ModeContraints as IEnumerable<ProgramMode>
        )
    ).Where(a =>
        a.Contraints.Any()
    );

foreach (var (Name, Contraints) in flagsAndConstraints)
{
    Console.WriteLine($"{Name}: {string.Join(", ", Contraints)}");
}

bool doCalcText = flags.HasFlag(ProgramFlags.CalcWaitText);
bool printFontBlockInfo = flags.HasFlag(ProgramFlags.FontBlockInfo);
bool printAnyFontBlockInfo = flags.HasFlag(ProgramFlags.AnyFontBlockInfo);
bool onlyDoBasicMultilingualPlane = flags.HasFlag(ProgramFlags.OnlyBasicMultilingualPlane);

const bool doPrintUnknownCodepoints = true;
const int decimalPointMultiplier = 1000;

void PrintBlockInfo(SupportedCharCollection supportedChars)
{
    UnicodeBlock lastUnicodeBlock = default;
    int charCount = 0;
    List<int> blockCodepoints = [];
    void WriteBlockInfo()
    {
        if (charCount > 0)
        {
            if (lastUnicodeBlock.Equals(default(UnicodeBlock)))
            {
                Console.WriteLine($" - Unknown Block: {charCount} codepoints");
                if (doPrintUnknownCodepoints)
                {
                    Console.WriteLine($" - Warning! [{blockCodepoints[0].ToUHex()} to {blockCodepoints[charCount - 1].ToUHex()}] Unknown Codepoints: {string.Join(", ", blockCodepoints.Select(a => a.ToUHex()))}");
                }
            }
            else
            {
                int blockSize = lastUnicodeBlock.Size;
                Console.WriteLine($" - [{lastUnicodeBlock.FirstCodePoint.ToUHex()} to {lastUnicodeBlock.LastCodePoint.ToUHex()}] {lastUnicodeBlock.Name}: {charCount} of {blockSize} ({Math.Round((double)charCount / (double)blockSize * 100 * decimalPointMultiplier) / decimalPointMultiplier}%)");
            }
        }
    }
    foreach (int ch in supportedChars.Keys.Order())
    {
        UnicodeBlock currentRange = UnicodeBlock.GetUnicodeBlock(ch);
        if (!currentRange.Equals(lastUnicodeBlock))
        {
            WriteBlockInfo();
            lastUnicodeBlock = currentRange;
            charCount = 0;
            blockCodepoints = [];
        }
        blockCodepoints.Add(ch);
        charCount += 1;
    }
    WriteBlockInfo();
}
Stopwatch stopwatch = Stopwatch.StartNew();
Console.WriteLine("Calculating maximum number of printable glyphs...");
int maxDrawableCharacters = 0;
int maxCodepoint = 0x10FFFF;
if (onlyDoBasicMultilingualPlane)
{
    maxCodepoint = 0xFFFF;
}
for (int i = 0; i <= maxCodepoint; ++i)
{
    var cat = CharUnicodeInfo.GetUnicodeCategory(i);
    switch (cat)
    {
    case UnicodeCategory.SpaceSeparator:
    case UnicodeCategory.LineSeparator:
    case UnicodeCategory.ParagraphSeparator:
    case UnicodeCategory.Control:
    case UnicodeCategory.Format:
    case UnicodeCategory.Surrogate:
    case UnicodeCategory.PrivateUse:
    case UnicodeCategory.OtherNotAssigned:
        break;
    default:
        maxDrawableCharacters += 1;
        break;
    }
}
Console.WriteLine("Calculation duration: " + stopwatch.ElapsedMilliseconds + " ms");
stopwatch.Restart();

Console.WriteLine("Enumerating fonts...");
//Note: using Parallel.ForEach here makes it run slower
foreach (FontFamily family in Fonts.SystemFontFamilies)
{
    if (supportedCharsFontMap.Count > 30) break;

    string familyName = family.Source;
    switch (mode)
    {
    case ProgramMode.FontNameCompare:
        {
            var FamilyNames = family.FamilyNames;
            if (FamilyNames.Count > 1 || !FamilyNames.ContainsKey(System.Windows.Markup.XmlLanguage.GetLanguage("en-us")))
            {
                Console.WriteLine(familyName);
                Console.WriteLine(" - " + string.Join(",\n - ", FamilyNames.Select(kv => kv.Key + "=" + kv.Value)));
            }
        }
        break;
    case ProgramMode.CalculateGlyphs:
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
                        if (!onlyDoBasicMultilingualPlane || (0 <= fontSupportedChar && fontSupportedChar <= 0xFFFF))
                        {
                            supportedChars[fontSupportedChar] = true;
                            fontSupportedChars[fontSupportedChar] = true;
                        }
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
        break;
    }
}
Console.WriteLine();
if (printAnyFontBlockInfo)
{
    Console.WriteLine("Supported glyphs in any font:");
    PrintBlockInfo(supportedChars);
}
if (mode == ProgramMode.CalculateGlyphs)
{
    Console.Write("Total supported chars: " + supportedChars.Count);
    int charCount = supportedChars.Count;
    Console.WriteLine($" of {maxDrawableCharacters} ({Math.Round((double)charCount / (double)maxDrawableCharacters * 100 * decimalPointMultiplier) / decimalPointMultiplier}%)");
}
stopwatch.Stop();
Console.WriteLine("Calculation duration: " + stopwatch.ElapsedMilliseconds / 1000f + " seconds");

