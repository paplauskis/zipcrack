using zipcrack.Interfaces;

namespace zipcrack.Context;

public class AttackContext
{
    private IZipCracker _zipCracker;
    
    public AttackContext(IZipCracker cracker)
    {
        _zipCracker = cracker;
    }

    public string? Run()
    {
        return _zipCracker.GetPassword();
    }
}