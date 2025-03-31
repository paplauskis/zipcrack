using zipcrack.Parsing;

namespace zipcrack.AttackMethods;

public class BruteForceAttack : BaseAttack
{
    private readonly int _minPasswordLength;
    private readonly int _maxPasswordLength;
    private readonly char[] _characters;
    private readonly object _lock = new();
    
    public BruteForceAttack(BruteForceArgumentParser argumentParser) : base(argumentParser.FilePath, argumentParser.ThreadCount)
    {
        _minPasswordLength = argumentParser.MinChars;
        _maxPasswordLength = argumentParser.MaxChars;
        _characters = argumentParser.Characters;
    }
    
    public override string? GetPassword()
    {
        Parallel.ForEach(_characters, new ParallelOptions { MaxDegreeOfParallelism = _threadCount }, ch =>
        {
            GenerateStringCombinations(ch.ToString());
        });
        
        return _password;
    }

    private void GenerateStringCombinations(string current)
    {
        if (current.Length >= _minPasswordLength && _passwordChecker.IsValid(current))
        {
            _password = current;
            return;
        }
        
        if (current.Length == _maxPasswordLength)
        {
            return;
        }
        
        foreach (char c in _characters)
        {
            if (_password != null) break;
            
            GenerateStringCombinations(current + c);
        }
    }
}
