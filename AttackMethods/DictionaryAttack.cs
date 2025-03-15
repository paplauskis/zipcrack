using System.Diagnostics;
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
        var fileLineCount = File.ReadLines(TxtFilePath).Count();
        var lineCountPerThread = fileLineCount / _threadCount + 1;
        string? password = null;
        
        for (int i = 1; i <= _threadCount; i++)
        {
            if (i == 1)
            {
                password = SearchForPassword(0, lineCountPerThread);
                continue;
            }
        
            if (i == _threadCount)
            {
                password = SearchForPassword(lineCountPerThread * (i - 1), fileLineCount);
                continue;
            }
            
            password = SearchForPassword(lineCountPerThread * (i - 1), lineCountPerThread * i);
        }
        
        return password;
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