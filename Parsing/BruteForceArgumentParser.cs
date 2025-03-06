using zipcrack.Enums;

namespace zipcrack.Parsing;

public class BruteForceArgumentParser : ArgumentParser
{
    public BruteForceArgumentParser(string[] args) : base(args)
    {
        AttackMethod = AttackMethod.BruteForce;
        _filePath = args[3];
    }
    
}