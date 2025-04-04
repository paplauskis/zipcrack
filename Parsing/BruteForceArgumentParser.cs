using zipcrack.Enums;
using zipcrack.CharacterSets;

namespace zipcrack.Parsing;

public class BruteForceArgumentParser : ArgumentParser
{
    public int MinChars { get; init; }
    public int MaxChars { get; init; }
    public char[] Characters { get; init; }
    
    public BruteForceArgumentParser(string[] args) : base(args)
    {
        AttackMethod = AttackMethod.BruteForce;
        MinChars = ExtractIntValue(args[1]);
        MaxChars = ExtractIntValue(args[2]);
        Characters = AssignCharArray(args[3]);
        _filePath = args[4];
    }

    private static char[] AssignCharArray(string arg)
    {
        string arrayType = ExtractValue(arg);

        return CharsetSelector.GetCharacterSet(arrayType);
    }
}