// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using System.Collections.ObjectModel;

internal enum ProgramMode
{
    CalculateGlyphs = 1,
    FontNameCompare = 2,
}

[Flags]
internal enum ProgramFlags
{
    [ProgramFlagsModeConstraint()]
    None = 0,
    [ProgramFlagsModeConstraint(ProgramMode.CalculateGlyphs)]
    FontBlockInfo = 1,
    [ProgramFlagsModeConstraint(ProgramMode.CalculateGlyphs)]
    AnyFontBlockInfo = 2,
    [ProgramFlagsModeConstraint(ProgramMode.CalculateGlyphs)]
    CalcWaitText = 4,
    [ProgramFlagsModeConstraint(ProgramMode.CalculateGlyphs, ProgramMode.FontNameCompare)]
    OnlyBasicMultilingualPlane = 8,
}

[AttributeUsage(AttributeTargets.Field)]
internal class ProgramFlagsModeConstraintAttribute(params ProgramMode[] modeContraints) : Attribute
{
    public readonly ReadOnlyCollection<ProgramMode> ModeContraints = modeContraints.AsReadOnly();
}