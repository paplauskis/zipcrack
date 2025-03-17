using System.Diagnostics;
using zipcrack.Helpers;
using zipcrack.Interfaces;
using zipcrack.Parsing;

namespace zipcrack.AttackMethods;

public class DictionaryAttack : BaseAttack
{
    private const string TxtFilePath = "TEST.txt"; 
    
    public DictionaryAttack(DictionaryArgumentParser argumentParser) : base(argumentParser.FilePath) {}
    
    public override string? GetPassword()
    {
        var fileLineCount = File.ReadLines(TxtFilePath).Count();
        var lineCountPerThread = fileLineCount / _threadCount + 1;
        string? password = null;
        Thread[] threads = new Thread[_threadCount];
        
        for (int i = 1; i <= _threadCount; i++)
        {
            int temp = i; //temporary variable, because 'i' value can change during thread execution

            var thread = new Thread(() =>
            {
                string? value = SearchForPassword(lineCountPerThread * (temp - 1), lineCountPerThread * temp);
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