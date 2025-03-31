namespace zipcrack.CharacterSets;

public static class CharsetSelector
{
    private static readonly Dictionary<string, char[]> CharSetSelectors = new()
    {
        { "l", PasswordCharacters.LowercaseLetters },
        { "u", PasswordCharacters.UppercaseLetters },
        { "n", PasswordCharacters.Numbers },
        { "lu", PasswordCharacters.AllLetters },
        { "lun", PasswordCharacters.AllLettersAndNumbers },
        { "luns", PasswordCharacters.AllCharacters }
    };

    public static char[] GetCharacterSet(string value)
    {
        if (CharSetSelectors.TryGetValue(value, out var selector))
        {
            return selector;
        }

        throw new ArgumentException("Argument is not valid", nameof(value));
    }
}