using zipcrack.Helpers;
using zipcrack.Parsing;

namespace zipcrack.AttackMethods;

public class BruteForceAttack : BaseAttack
{
    private readonly int _minPasswordLength;
    private readonly int _maxPasswordLength;
    private readonly char[] _characters;
    
    public BruteForceAttack(BruteForceArgumentParser argumentParser) : base(argumentParser.FilePath, argumentParser.ThreadCount)
    {
        _minPasswordLength = argumentParser.MinChars;
        _maxPasswordLength = argumentParser.MaxChars;
        _characters = argumentParser.Characters;
    }
    
    public override string? GetPassword()
    {
        GenerateStringCombinations();
        return _password;
    }

    private void GenerateStringCombinations(string current = "")
    {
        if (current.Length >= _minPasswordLength)
        {
            Console.WriteLine(current);
        }

        if (current.Length == _maxPasswordLength)
        {
            return;
        }


        foreach (char c in _characters)
        {
            GenerateStringCombinations(current + c);
        }
    }
}