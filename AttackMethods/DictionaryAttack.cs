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
        Thread[] threads = new Thread[_threadCount];
        
        for (int i = 1; i <= _threadCount; i++)
        {
            int temp = i;
            var thread = new Thread(() =>
            {
                string? value;
                
                if (temp == 1)
                {
                    value = SearchForPassword(0, lineCountPerThread);
                    if (value != null) password = value;
                    return;
                }
        
                if (temp == _threadCount)
                {
                    value = SearchForPassword(lineCountPerThread * (temp - 1), fileLineCount);
                    if (value != null) password = value;
                    return;
                }

                value = SearchForPassword(lineCountPerThread * (temp - 1), lineCountPerThread * temp);
                if (value != null) password = value;
            });

            threads[i - 1] = thread;
            thread.Start();
        }
        
        foreach (var t in threads)
        {
            t.Join();
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