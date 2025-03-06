using zipcrack.Interfaces;
using zipcrack.Parsing;

namespace zipcrack.AttackMethods;

public class BruteForceAttack : IZipCracker
{
    private BruteForceArgumentParser _args;
    
    public BruteForceAttack(BruteForceArgumentParser argumentParser)
    {
        _args = argumentParser;
    }
    
    public string? GetPassword()
    {
        throw new NotImplementedException();
    }
}