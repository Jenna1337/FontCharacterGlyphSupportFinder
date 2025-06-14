﻿// See https://aka.ms/new-console-template for more information

internal readonly struct UnicodeBlock
{
    //private static readonly List<UnicodeBlock> EveryUnicodeRange = typeof(UnicodeRanges).GetProperties().Where(a => a.PropertyType.Equals(typeof(UnicodeRange)) && a.Name != "All").Select(a => new UnicodeBlock(a.Name, (a.GetValue(null) as UnicodeRange)!));
    /// <remarks>
    /// generated from <see href="https://unicode.org/Public/UNIDATA/Blocks.txt" />
    /// by excluding commented or blank lines
    /// and replacing the regex <c>/([A-F0-9]+)\.\.([A-f0-9]+); (.*?)$/gmi</c>
    /// with <c>new(0x$1, 0x$2, "$3"),</c>
    /// </remarks>
    private static readonly List<UnicodeBlock> EveryUnicodeRange = [
new(0x0000, 0x007F, "Basic Latin"),
new(0x0080, 0x00FF, "Latin-1 Supplement"),
new(0x0100, 0x017F, "Latin Extended-A"),
new(0x0180, 0x024F, "Latin Extended-B"),
new(0x0250, 0x02AF, "IPA Extensions"),
new(0x02B0, 0x02FF, "Spacing Modifier Letters"),
new(0x0300, 0x036F, "Combining Diacritical Marks"),
new(0x0370, 0x03FF, "Greek and Coptic"),
new(0x0400, 0x04FF, "Cyrillic"),
new(0x0500, 0x052F, "Cyrillic Supplement"),
new(0x0530, 0x058F, "Armenian"),
new(0x0590, 0x05FF, "Hebrew"),
new(0x0600, 0x06FF, "Arabic"),
new(0x0700, 0x074F, "Syriac"),
new(0x0750, 0x077F, "Arabic Supplement"),
new(0x0780, 0x07BF, "Thaana"),
new(0x07C0, 0x07FF, "NKo"),
new(0x0800, 0x083F, "Samaritan"),
new(0x0840, 0x085F, "Mandaic"),
new(0x0860, 0x086F, "Syriac Supplement"),
new(0x0870, 0x089F, "Arabic Extended-B"),
new(0x08A0, 0x08FF, "Arabic Extended-A"),
new(0x0900, 0x097F, "Devanagari"),
new(0x0980, 0x09FF, "Bengali"),
new(0x0A00, 0x0A7F, "Gurmukhi"),
new(0x0A80, 0x0AFF, "Gujarati"),
new(0x0B00, 0x0B7F, "Oriya"),
new(0x0B80, 0x0BFF, "Tamil"),
new(0x0C00, 0x0C7F, "Telugu"),
new(0x0C80, 0x0CFF, "Kannada"),
new(0x0D00, 0x0D7F, "Malayalam"),
new(0x0D80, 0x0DFF, "Sinhala"),
new(0x0E00, 0x0E7F, "Thai"),
new(0x0E80, 0x0EFF, "Lao"),
new(0x0F00, 0x0FFF, "Tibetan"),
new(0x1000, 0x109F, "Myanmar"),
new(0x10A0, 0x10FF, "Georgian"),
new(0x1100, 0x11FF, "Hangul Jamo"),
new(0x1200, 0x137F, "Ethiopic"),
new(0x1380, 0x139F, "Ethiopic Supplement"),
new(0x13A0, 0x13FF, "Cherokee"),
new(0x1400, 0x167F, "Unified Canadian Aboriginal Syllabics"),
new(0x1680, 0x169F, "Ogham"),
new(0x16A0, 0x16FF, "Runic"),
new(0x1700, 0x171F, "Tagalog"),
new(0x1720, 0x173F, "Hanunoo"),
new(0x1740, 0x175F, "Buhid"),
new(0x1760, 0x177F, "Tagbanwa"),
new(0x1780, 0x17FF, "Khmer"),
new(0x1800, 0x18AF, "Mongolian"),
new(0x18B0, 0x18FF, "Unified Canadian Aboriginal Syllabics Extended"),
new(0x1900, 0x194F, "Limbu"),
new(0x1950, 0x197F, "Tai Le"),
new(0x1980, 0x19DF, "New Tai Lue"),
new(0x19E0, 0x19FF, "Khmer Symbols"),
new(0x1A00, 0x1A1F, "Buginese"),
new(0x1A20, 0x1AAF, "Tai Tham"),
new(0x1AB0, 0x1AFF, "Combining Diacritical Marks Extended"),
new(0x1B00, 0x1B7F, "Balinese"),
new(0x1B80, 0x1BBF, "Sundanese"),
new(0x1BC0, 0x1BFF, "Batak"),
new(0x1C00, 0x1C4F, "Lepcha"),
new(0x1C50, 0x1C7F, "Ol Chiki"),
new(0x1C80, 0x1C8F, "Cyrillic Extended-C"),
new(0x1C90, 0x1CBF, "Georgian Extended"),
new(0x1CC0, 0x1CCF, "Sundanese Supplement"),
new(0x1CD0, 0x1CFF, "Vedic Extensions"),
new(0x1D00, 0x1D7F, "Phonetic Extensions"),
new(0x1D80, 0x1DBF, "Phonetic Extensions Supplement"),
new(0x1DC0, 0x1DFF, "Combining Diacritical Marks Supplement"),
new(0x1E00, 0x1EFF, "Latin Extended Additional"),
new(0x1F00, 0x1FFF, "Greek Extended"),
new(0x2000, 0x206F, "General Punctuation"),
new(0x2070, 0x209F, "Superscripts and Subscripts"),
new(0x20A0, 0x20CF, "Currency Symbols"),
new(0x20D0, 0x20FF, "Combining Diacritical Marks for Symbols"),
new(0x2100, 0x214F, "Letterlike Symbols"),
new(0x2150, 0x218F, "Number Forms"),
new(0x2190, 0x21FF, "Arrows"),
new(0x2200, 0x22FF, "Mathematical Operators"),
new(0x2300, 0x23FF, "Miscellaneous Technical"),
new(0x2400, 0x243F, "Control Pictures"),
new(0x2440, 0x245F, "Optical Character Recognition"),
new(0x2460, 0x24FF, "Enclosed Alphanumerics"),
new(0x2500, 0x257F, "Box Drawing"),
new(0x2580, 0x259F, "Block Elements"),
new(0x25A0, 0x25FF, "Geometric Shapes"),
new(0x2600, 0x26FF, "Miscellaneous Symbols"),
new(0x2700, 0x27BF, "Dingbats"),
new(0x27C0, 0x27EF, "Miscellaneous Mathematical Symbols-A"),
new(0x27F0, 0x27FF, "Supplemental Arrows-A"),
new(0x2800, 0x28FF, "Braille Patterns"),
new(0x2900, 0x297F, "Supplemental Arrows-B"),
new(0x2980, 0x29FF, "Miscellaneous Mathematical Symbols-B"),
new(0x2A00, 0x2AFF, "Supplemental Mathematical Operators"),
new(0x2B00, 0x2BFF, "Miscellaneous Symbols and Arrows"),
new(0x2C00, 0x2C5F, "Glagolitic"),
new(0x2C60, 0x2C7F, "Latin Extended-C"),
new(0x2C80, 0x2CFF, "Coptic"),
new(0x2D00, 0x2D2F, "Georgian Supplement"),
new(0x2D30, 0x2D7F, "Tifinagh"),
new(0x2D80, 0x2DDF, "Ethiopic Extended"),
new(0x2DE0, 0x2DFF, "Cyrillic Extended-A"),
new(0x2E00, 0x2E7F, "Supplemental Punctuation"),
new(0x2E80, 0x2EFF, "CJK Radicals Supplement"),
new(0x2F00, 0x2FDF, "Kangxi Radicals"),
new(0x2FF0, 0x2FFF, "Ideographic Description Characters"),
new(0x3000, 0x303F, "CJK Symbols and Punctuation"),
new(0x3040, 0x309F, "Hiragana"),
new(0x30A0, 0x30FF, "Katakana"),
new(0x3100, 0x312F, "Bopomofo"),
new(0x3130, 0x318F, "Hangul Compatibility Jamo"),
new(0x3190, 0x319F, "Kanbun"),
new(0x31A0, 0x31BF, "Bopomofo Extended"),
new(0x31C0, 0x31EF, "CJK Strokes"),
new(0x31F0, 0x31FF, "Katakana Phonetic Extensions"),
new(0x3200, 0x32FF, "Enclosed CJK Letters and Months"),
new(0x3300, 0x33FF, "CJK Compatibility"),
new(0x3400, 0x4DBF, "CJK Unified Ideographs Extension A"),
new(0x4DC0, 0x4DFF, "Yijing Hexagram Symbols"),
new(0x4E00, 0x9FFF, "CJK Unified Ideographs"),
new(0xA000, 0xA48F, "Yi Syllables"),
new(0xA490, 0xA4CF, "Yi Radicals"),
new(0xA4D0, 0xA4FF, "Lisu"),
new(0xA500, 0xA63F, "Vai"),
new(0xA640, 0xA69F, "Cyrillic Extended-B"),
new(0xA6A0, 0xA6FF, "Bamum"),
new(0xA700, 0xA71F, "Modifier Tone Letters"),
new(0xA720, 0xA7FF, "Latin Extended-D"),
new(0xA800, 0xA82F, "Syloti Nagri"),
new(0xA830, 0xA83F, "Common Indic Number Forms"),
new(0xA840, 0xA87F, "Phags-pa"),
new(0xA880, 0xA8DF, "Saurashtra"),
new(0xA8E0, 0xA8FF, "Devanagari Extended"),
new(0xA900, 0xA92F, "Kayah Li"),
new(0xA930, 0xA95F, "Rejang"),
new(0xA960, 0xA97F, "Hangul Jamo Extended-A"),
new(0xA980, 0xA9DF, "Javanese"),
new(0xA9E0, 0xA9FF, "Myanmar Extended-B"),
new(0xAA00, 0xAA5F, "Cham"),
new(0xAA60, 0xAA7F, "Myanmar Extended-A"),
new(0xAA80, 0xAADF, "Tai Viet"),
new(0xAAE0, 0xAAFF, "Meetei Mayek Extensions"),
new(0xAB00, 0xAB2F, "Ethiopic Extended-A"),
new(0xAB30, 0xAB6F, "Latin Extended-E"),
new(0xAB70, 0xABBF, "Cherokee Supplement"),
new(0xABC0, 0xABFF, "Meetei Mayek"),
new(0xAC00, 0xD7AF, "Hangul Syllables"),
new(0xD7B0, 0xD7FF, "Hangul Jamo Extended-B"),
new(0xD800, 0xDB7F, "High Surrogates"),
new(0xDB80, 0xDBFF, "High Private Use Surrogates"),
new(0xDC00, 0xDFFF, "Low Surrogates"),
new(0xE000, 0xF8FF, "Private Use Area"),
new(0xF900, 0xFAFF, "CJK Compatibility Ideographs"),
new(0xFB00, 0xFB4F, "Alphabetic Presentation Forms"),
new(0xFB50, 0xFDFF, "Arabic Presentation Forms-A"),
new(0xFE00, 0xFE0F, "Variation Selectors"),
new(0xFE10, 0xFE1F, "Vertical Forms"),
new(0xFE20, 0xFE2F, "Combining Half Marks"),
new(0xFE30, 0xFE4F, "CJK Compatibility Forms"),
new(0xFE50, 0xFE6F, "Small Form Variants"),
new(0xFE70, 0xFEFF, "Arabic Presentation Forms-B"),
new(0xFF00, 0xFFEF, "Halfwidth and Fullwidth Forms"),
new(0xFFF0, 0xFFFF, "Specials"),
new(0x10000, 0x1007F, "Linear B Syllabary"),
new(0x10080, 0x100FF, "Linear B Ideograms"),
new(0x10100, 0x1013F, "Aegean Numbers"),
new(0x10140, 0x1018F, "Ancient Greek Numbers"),
new(0x10190, 0x101CF, "Ancient Symbols"),
new(0x101D0, 0x101FF, "Phaistos Disc"),
new(0x10280, 0x1029F, "Lycian"),
new(0x102A0, 0x102DF, "Carian"),
new(0x102E0, 0x102FF, "Coptic Epact Numbers"),
new(0x10300, 0x1032F, "Old Italic"),
new(0x10330, 0x1034F, "Gothic"),
new(0x10350, 0x1037F, "Old Permic"),
new(0x10380, 0x1039F, "Ugaritic"),
new(0x103A0, 0x103DF, "Old Persian"),
new(0x10400, 0x1044F, "Deseret"),
new(0x10450, 0x1047F, "Shavian"),
new(0x10480, 0x104AF, "Osmanya"),
new(0x104B0, 0x104FF, "Osage"),
new(0x10500, 0x1052F, "Elbasan"),
new(0x10530, 0x1056F, "Caucasian Albanian"),
new(0x10570, 0x105BF, "Vithkuqi"),
new(0x105C0, 0x105FF, "Todhri"),
new(0x10600, 0x1077F, "Linear A"),
new(0x10780, 0x107BF, "Latin Extended-F"),
new(0x10800, 0x1083F, "Cypriot Syllabary"),
new(0x10840, 0x1085F, "Imperial Aramaic"),
new(0x10860, 0x1087F, "Palmyrene"),
new(0x10880, 0x108AF, "Nabataean"),
new(0x108E0, 0x108FF, "Hatran"),
new(0x10900, 0x1091F, "Phoenician"),
new(0x10920, 0x1093F, "Lydian"),
new(0x10980, 0x1099F, "Meroitic Hieroglyphs"),
new(0x109A0, 0x109FF, "Meroitic Cursive"),
new(0x10A00, 0x10A5F, "Kharoshthi"),
new(0x10A60, 0x10A7F, "Old South Arabian"),
new(0x10A80, 0x10A9F, "Old North Arabian"),
new(0x10AC0, 0x10AFF, "Manichaean"),
new(0x10B00, 0x10B3F, "Avestan"),
new(0x10B40, 0x10B5F, "Inscriptional Parthian"),
new(0x10B60, 0x10B7F, "Inscriptional Pahlavi"),
new(0x10B80, 0x10BAF, "Psalter Pahlavi"),
new(0x10C00, 0x10C4F, "Old Turkic"),
new(0x10C80, 0x10CFF, "Old Hungarian"),
new(0x10D00, 0x10D3F, "Hanifi Rohingya"),
new(0x10D40, 0x10D8F, "Garay"),
new(0x10E60, 0x10E7F, "Rumi Numeral Symbols"),
new(0x10E80, 0x10EBF, "Yezidi"),
new(0x10EC0, 0x10EFF, "Arabic Extended-C"),
new(0x10F00, 0x10F2F, "Old Sogdian"),
new(0x10F30, 0x10F6F, "Sogdian"),
new(0x10F70, 0x10FAF, "Old Uyghur"),
new(0x10FB0, 0x10FDF, "Chorasmian"),
new(0x10FE0, 0x10FFF, "Elymaic"),
new(0x11000, 0x1107F, "Brahmi"),
new(0x11080, 0x110CF, "Kaithi"),
new(0x110D0, 0x110FF, "Sora Sompeng"),
new(0x11100, 0x1114F, "Chakma"),
new(0x11150, 0x1117F, "Mahajani"),
new(0x11180, 0x111DF, "Sharada"),
new(0x111E0, 0x111FF, "Sinhala Archaic Numbers"),
new(0x11200, 0x1124F, "Khojki"),
new(0x11280, 0x112AF, "Multani"),
new(0x112B0, 0x112FF, "Khudawadi"),
new(0x11300, 0x1137F, "Grantha"),
new(0x11380, 0x113FF, "Tulu-Tigalari"),
new(0x11400, 0x1147F, "Newa"),
new(0x11480, 0x114DF, "Tirhuta"),
new(0x11580, 0x115FF, "Siddham"),
new(0x11600, 0x1165F, "Modi"),
new(0x11660, 0x1167F, "Mongolian Supplement"),
new(0x11680, 0x116CF, "Takri"),
new(0x116D0, 0x116FF, "Myanmar Extended-C"),
new(0x11700, 0x1174F, "Ahom"),
new(0x11800, 0x1184F, "Dogra"),
new(0x118A0, 0x118FF, "Warang Citi"),
new(0x11900, 0x1195F, "Dives Akuru"),
new(0x119A0, 0x119FF, "Nandinagari"),
new(0x11A00, 0x11A4F, "Zanabazar Square"),
new(0x11A50, 0x11AAF, "Soyombo"),
new(0x11AB0, 0x11ABF, "Unified Canadian Aboriginal Syllabics Extended-A"),
new(0x11AC0, 0x11AFF, "Pau Cin Hau"),
new(0x11B00, 0x11B5F, "Devanagari Extended-A"),
new(0x11BC0, 0x11BFF, "Sunuwar"),
new(0x11C00, 0x11C6F, "Bhaiksuki"),
new(0x11C70, 0x11CBF, "Marchen"),
new(0x11D00, 0x11D5F, "Masaram Gondi"),
new(0x11D60, 0x11DAF, "Gunjala Gondi"),
new(0x11EE0, 0x11EFF, "Makasar"),
new(0x11F00, 0x11F5F, "Kawi"),
new(0x11FB0, 0x11FBF, "Lisu Supplement"),
new(0x11FC0, 0x11FFF, "Tamil Supplement"),
new(0x12000, 0x123FF, "Cuneiform"),
new(0x12400, 0x1247F, "Cuneiform Numbers and Punctuation"),
new(0x12480, 0x1254F, "Early Dynastic Cuneiform"),
new(0x12F90, 0x12FFF, "Cypro-Minoan"),
new(0x13000, 0x1342F, "Egyptian Hieroglyphs"),
new(0x13430, 0x1345F, "Egyptian Hieroglyph Format Controls"),
new(0x13460, 0x143FF, "Egyptian Hieroglyphs Extended-A"),
new(0x14400, 0x1467F, "Anatolian Hieroglyphs"),
new(0x16100, 0x1613F, "Gurung Khema"),
new(0x16800, 0x16A3F, "Bamum Supplement"),
new(0x16A40, 0x16A6F, "Mro"),
new(0x16A70, 0x16ACF, "Tangsa"),
new(0x16AD0, 0x16AFF, "Bassa Vah"),
new(0x16B00, 0x16B8F, "Pahawh Hmong"),
new(0x16D40, 0x16D7F, "Kirat Rai"),
new(0x16E40, 0x16E9F, "Medefaidrin"),
new(0x16F00, 0x16F9F, "Miao"),
new(0x16FE0, 0x16FFF, "Ideographic Symbols and Punctuation"),
new(0x17000, 0x187FF, "Tangut"),
new(0x18800, 0x18AFF, "Tangut Components"),
new(0x18B00, 0x18CFF, "Khitan Small Script"),
new(0x18D00, 0x18D7F, "Tangut Supplement"),
new(0x1AFF0, 0x1AFFF, "Kana Extended-B"),
new(0x1B000, 0x1B0FF, "Kana Supplement"),
new(0x1B100, 0x1B12F, "Kana Extended-A"),
new(0x1B130, 0x1B16F, "Small Kana Extension"),
new(0x1B170, 0x1B2FF, "Nushu"),
new(0x1BC00, 0x1BC9F, "Duployan"),
new(0x1BCA0, 0x1BCAF, "Shorthand Format Controls"),
new(0x1CC00, 0x1CEBF, "Symbols for Legacy Computing Supplement"),
new(0x1CF00, 0x1CFCF, "Znamenny Musical Notation"),
new(0x1D000, 0x1D0FF, "Byzantine Musical Symbols"),
new(0x1D100, 0x1D1FF, "Musical Symbols"),
new(0x1D200, 0x1D24F, "Ancient Greek Musical Notation"),
new(0x1D2C0, 0x1D2DF, "Kaktovik Numerals"),
new(0x1D2E0, 0x1D2FF, "Mayan Numerals"),
new(0x1D300, 0x1D35F, "Tai Xuan Jing Symbols"),
new(0x1D360, 0x1D37F, "Counting Rod Numerals"),
new(0x1D400, 0x1D7FF, "Mathematical Alphanumeric Symbols"),
new(0x1D800, 0x1DAAF, "Sutton SignWriting"),
new(0x1DF00, 0x1DFFF, "Latin Extended-G"),
new(0x1E000, 0x1E02F, "Glagolitic Supplement"),
new(0x1E030, 0x1E08F, "Cyrillic Extended-D"),
new(0x1E100, 0x1E14F, "Nyiakeng Puachue Hmong"),
new(0x1E290, 0x1E2BF, "Toto"),
new(0x1E2C0, 0x1E2FF, "Wancho"),
new(0x1E4D0, 0x1E4FF, "Nag Mundari"),
new(0x1E5D0, 0x1E5FF, "Ol Onal"),
new(0x1E7E0, 0x1E7FF, "Ethiopic Extended-B"),
new(0x1E800, 0x1E8DF, "Mende Kikakui"),
new(0x1E900, 0x1E95F, "Adlam"),
new(0x1EC70, 0x1ECBF, "Indic Siyaq Numbers"),
new(0x1ED00, 0x1ED4F, "Ottoman Siyaq Numbers"),
new(0x1EE00, 0x1EEFF, "Arabic Mathematical Alphabetic Symbols"),
new(0x1F000, 0x1F02F, "Mahjong Tiles"),
new(0x1F030, 0x1F09F, "Domino Tiles"),
new(0x1F0A0, 0x1F0FF, "Playing Cards"),
new(0x1F100, 0x1F1FF, "Enclosed Alphanumeric Supplement"),
new(0x1F200, 0x1F2FF, "Enclosed Ideographic Supplement"),
new(0x1F300, 0x1F5FF, "Miscellaneous Symbols and Pictographs"),
new(0x1F600, 0x1F64F, "Emoticons"),
new(0x1F650, 0x1F67F, "Ornamental Dingbats"),
new(0x1F680, 0x1F6FF, "Transport and Map Symbols"),
new(0x1F700, 0x1F77F, "Alchemical Symbols"),
new(0x1F780, 0x1F7FF, "Geometric Shapes Extended"),
new(0x1F800, 0x1F8FF, "Supplemental Arrows-C"),
new(0x1F900, 0x1F9FF, "Supplemental Symbols and Pictographs"),
new(0x1FA00, 0x1FA6F, "Chess Symbols"),
new(0x1FA70, 0x1FAFF, "Symbols and Pictographs Extended-A"),
new(0x1FB00, 0x1FBFF, "Symbols for Legacy Computing"),
new(0x20000, 0x2A6DF, "CJK Unified Ideographs Extension B"),
new(0x2A700, 0x2B73F, "CJK Unified Ideographs Extension C"),
new(0x2B740, 0x2B81F, "CJK Unified Ideographs Extension D"),
new(0x2B820, 0x2CEAF, "CJK Unified Ideographs Extension E"),
new(0x2CEB0, 0x2EBEF, "CJK Unified Ideographs Extension F"),
new(0x2EBF0, 0x2EE5F, "CJK Unified Ideographs Extension I"),
new(0x2F800, 0x2FA1F, "CJK Compatibility Ideographs Supplement"),
new(0x30000, 0x3134F, "CJK Unified Ideographs Extension G"),
new(0x31350, 0x323AF, "CJK Unified Ideographs Extension H"),
new(0xE0000, 0xE007F, "Tags"),
new(0xE0100, 0xE01EF, "Variation Selectors Supplement"),
new(0xF0000, 0xFFFFF, "Supplementary Private Use Area-A"),
new(0x100000, 0x10FFFF, "Supplementary Private Use Area-B"),
    ];
    static UnicodeBlock()
    {
    }

    public static UnicodeBlock GetUnicodeBlock(int codepoint)
    {
        return EveryUnicodeRange.FirstOrDefault(block =>
        {
            return block.Contains(codepoint);
        });
    }

    public readonly string Name;
    public readonly int FirstCodePoint;
    public readonly int LastCodePoint;

    public readonly int Size => LastCodePoint - FirstCodePoint + 1;

    private UnicodeBlock(string name, int firstCodePoint, int lastCodePoint) : this()
    {
        Name = name;
        FirstCodePoint = firstCodePoint;
        LastCodePoint = lastCodePoint;
    }
    private UnicodeBlock(int firstCodePoint, int lastCodePoint, string name) : this(name, firstCodePoint, lastCodePoint)
    {
    }
    public readonly bool Contains(int codepoint)
    {
        return FirstCodePoint <= codepoint
            && LastCodePoint >= codepoint;
    }
    public static IEnumerable<UnicodeBlock> BlocksWhere(Func<UnicodeBlock, bool> predicate)
    {
        return EveryUnicodeRange.Where(predicate);
    }
}
