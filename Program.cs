// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Windows.Media;

Stopwatch stopwatch = Stopwatch.StartNew();
ConcurrentDictionary<int, bool> supportedChars = new();
ICollection<FontFamily> families = Fonts.SystemFontFamilies;
const string CALC_TEXT = "Calculating...";
int CALC_TEXT_LENGTH = CALC_TEXT.Length;
string CALC_TEXT_BLANK = new(' ', CALC_TEXT_LENGTH);

//Note: using Parallel.ForEach here makes it run slower
foreach (FontFamily? family in families)
{
    Console.Write(family.Source + " : " + CALC_TEXT);
    ConcurrentDictionary<int, bool> fontSupportedChars = new();

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
    Console.CursorLeft -= CALC_TEXT_LENGTH;
    Console.Write(CALC_TEXT_BLANK);
    Console.CursorLeft -= CALC_TEXT_LENGTH;
    Console.WriteLine(fontSupportedChars.Count);
}
Console.WriteLine("Total supported chars: " + supportedChars.Count);
stopwatch.Stop();
Console.WriteLine("Calculation duration: " + stopwatch.ElapsedMilliseconds / 1000f + " seconds");
