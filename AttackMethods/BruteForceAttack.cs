using zipcrack.Interfaces;
using zipcrack.Parsing;

namespace zipcrack.AttackMethods;

public class BruteForceAttack : IZipCracker
{
    private readonly int _minPasswordLength;
    private readonly int _maxPasswordLength;
    private readonly char[] _characters;
    private readonly string _filePath;
    
    public BruteForceAttack(BruteForceArgumentParser argumentParser)
    {
        _minPasswordLength = argumentParser.MinChars;
        _maxPasswordLength = argumentParser.MaxChars;
        _characters = argumentParser.Characters;
        _filePath = argumentParser.FilePath;
    }
    
    public string? GetPassword()
    {
        throw new NotImplementedException();
    }
}