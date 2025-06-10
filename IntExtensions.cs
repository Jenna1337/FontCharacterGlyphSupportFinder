// See https://aka.ms/new-console-template for more information

public static class IntExtensions
{
    public static string ToUHex(this int codePoint)
    {
        return "U+" + codePoint.ToString("X").PadLeft(4, '0');
    }
}