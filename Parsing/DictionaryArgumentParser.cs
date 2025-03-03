using zipcrack.Enums;

namespace zipcrack;

public class DictionaryArgumentParser : ArgumentParser
{
    public DictionaryArgumentParser(string[] args) : base(args)
    {
        AttackMethod = AttackMethod.Dictionary;
        _filePath = args[1];
    }
}