using zipcrack.Interfaces;
using zipcrack.Parsing;

namespace zipcrack.AttackMethods;

public class DictionaryAttack : IZipCracker
{
    private readonly string _filePath;
    private readonly int _threadCount;
    
    public DictionaryAttack(DictionaryArgumentParser argumentParser)
    {
        _filePath = argumentParser.FilePath;
        _threadCount = Environment.ProcessorCount;
    }
    
    public string? GetPassword()
    {
        return null;
    }
}