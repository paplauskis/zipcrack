namespace zipcrack.CharacterSets;

public static class PasswordCharacters
{
    private static readonly char[] _lowercaseChars = new char[]
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
    };

    private static readonly char[] _uppercaseChars = new char[]
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };
    
    private static readonly char[] _numbers = new char[]
    {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };
    
    public static char[] LowercaseLetters => _lowercaseChars;
    
    public static char[] UppercaseLetters => _uppercaseChars;
    
    public static char[] Numbers => _numbers;
    
    public static char[] AllLetters => _lowercaseChars.Concat(_uppercaseChars).ToArray();
    
    public static char[] AllCharacters => _lowercaseChars.Concat(_uppercaseChars).Concat(_numbers).ToArray();
}