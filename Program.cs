using zipcrack.AttackMethods;
using zipcrack.Context;
using zipcrack.Enums;
using zipcrack.Helpers;
using zipcrack.Parsing;

namespace zipcrack;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            ConsoleLogger.LogUsage();
            return;
        }

        string? password = null;
        AttackContext context;
        var attackMethod = ArgumentParser.ParseAttackMethod(args[0]);

        if (attackMethod == AttackMethod.Dictionary)
        {
            context = new AttackContext(new DictionaryAttack(new DictionaryArgumentParser(args)));
            password = context.Run();
        }

        if (attackMethod == AttackMethod.BruteForce)
        {
            context = new AttackContext(new BruteForceAttack(new BruteForceArgumentParser(args)));
            password = context.Run();
        }

        if (password == null)
        {
            ConsoleLogger.LogPasswordNotFound();
            
        }
        else
        {
            ConsoleLogger.LogPasswordFound(password);
        }
    }
}