using zipcrack.Interfaces;
using zipcrack.Parsing;

namespace zipcrack.AttackMethods;

public class BruteForceAttack : BaseAttack
{
    private readonly int _minPasswordLength;
    private readonly int _maxPasswordLength;
    private readonly char[] _characters;
    
    public BruteForceAttack(BruteForceArgumentParser argumentParser) : base(argumentParser.FilePath)
    {
        _minPasswordLength = argumentParser.MinChars;
        _maxPasswordLength = argumentParser.MaxChars;
        _characters = argumentParser.Characters;
    }
    
    public override string? GetPassword()
    {
        throw new NotImplementedException();
    }
}