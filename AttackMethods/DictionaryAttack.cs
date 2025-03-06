using zipcrack.Helpers;
using zipcrack.Interfaces;
using zipcrack.Parsing;

namespace zipcrack.AttackMethods;

public class DictionaryAttack : IZipCracker
{
    private readonly string _zipFilePath;
    private readonly int _threadCount;
    private const string TxtFilePath = "TestStrategy.txt"; 
    private readonly ZipPasswordChecker _passwordChecker;
    
    public DictionaryAttack(DictionaryArgumentParser argumentParser)
    {
        _zipFilePath = argumentParser.FilePath;
        _threadCount = Environment.ProcessorCount;
        _passwordChecker = new ZipPasswordChecker(_zipFilePath);
    }
    
    public string? GetPassword()
    {
        return null;
    }

    private string? SearchPartOfFile(int lineFrom, int lineTo)
    {
        throw new NotImplementedException();
    }
}