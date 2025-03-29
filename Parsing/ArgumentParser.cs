using zipcrack.Enums;
using zipcrack.Helpers;

namespace zipcrack.Parsing;

public class ArgumentParser
{
    protected readonly string[] _argsArray;
    protected string? _filePath;

    public AttackMethod AttackMethod { get; protected set; }

    public string FilePath
    {
        get => _filePath;
        set
        {
            if (!value.Contains(".zip"))            {
                throw new ArgumentException($"Invalid file: {value}");
            }
            
            _filePath = value;
        }
    }

    protected ArgumentParser(string[] args)
    {
        _argsArray = args;
        RemoveHyphens();
        SetFilePath();
        
        if (!ZipFileChecker.IsFileZip(_filePath))
        {
            throw new ArgumentException($"File is not a ZIP file: {_filePath}");
        }
    }

    public static AttackMethod ParseAttackMethod(string method)
    {
        return method == "--dict" ? AttackMethod.Dictionary : AttackMethod.BruteForce;
    }

    private void RemoveHyphens()
    {
        for (int i = 0; i < _argsArray.Length; i++)
        {
            _argsArray[i] = _argsArray[i].Replace("-", "");
        }
    }
    
    protected static int ExtractIntValue(string arg)
    {
        arg = ExtractValue(arg);

        if (int.TryParse(arg, out int result))
        {
            return result;
        }
        
        throw new ArgumentException("argument is not an integer");
    }

    protected static string ExtractValue(string arg)
    {
        int equalSignIndex = arg.IndexOf('=');
        arg = arg.Substring(equalSignIndex + 1, arg.Length - equalSignIndex - 1);
        
        return arg;
    }

    private void SetFilePath()
    {
        _filePath = Array.Find(_argsArray, t => t.Contains(".zip"));

        if (_filePath == null)
        {
            throw new ArgumentException($"ZIP file not specified: {_filePath}");
        }
    }
}