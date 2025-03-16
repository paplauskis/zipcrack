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

    private static int ExtractIntValue(string arg)
    {
        arg = ExtractValue(arg);

        if (int.TryParse(arg, out int result))
        {
            return result;
        }
        
        throw new ArgumentException("argument is not an integer");
    }

    private static string ExtractValue(string arg)
    {
        int equalSignIndex = arg.IndexOf('=');
        arg = arg.Substring(equalSignIndex + 1, arg.Length - equalSignIndex - 1);
        
        return arg;
    }

    private static char[] AssignCharArray(string arg)
    {
        string arrayType = ExtractValue(arg);

        return CharsetSelector.GetCharacterSet(arrayType);
    }
}