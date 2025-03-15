using zipcrack.Helpers;
using zipcrack.Interfaces;
using zipcrack.Parsing;

namespace zipcrack.AttackMethods;

public class DictionaryAttack : IZipCracker
{
    private readonly string _zipFilePath;
    private readonly int _threadCount;
    private const string TxtFilePath = "TEST.txt"; 
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
    
    private string? SearchForPassword(int lineFrom, int lineTo)
    {
        var words = File.ReadLines(TxtFilePath).Skip(lineFrom - 1).Take(lineTo - lineFrom + 1);

        foreach (var word in words)
        {
            if (_passwordChecker.IsValid(word))
            {
                return word;
            }
        }

        return null;
    }
}