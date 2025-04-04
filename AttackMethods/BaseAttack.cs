using zipcrack.Helpers;
using zipcrack.Interfaces;

namespace zipcrack.AttackMethods;

public abstract class BaseAttack : IZipCracker
{
    protected readonly string _zipFilePath;
    protected readonly int _threadCount;
    protected readonly ZipPasswordChecker _passwordChecker;
    protected string? _password;

    protected BaseAttack(string filePath, int threadCount)
    {
        _zipFilePath = filePath;
        _threadCount = threadCount;
        _passwordChecker = new ZipPasswordChecker(filePath);
    }

    public abstract string? GetPassword();
}