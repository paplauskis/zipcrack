using zipcrack.Enums;

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
            password = context.Execute();
        }

        if (attackMethod == AttackMethod.BruteForce)
        {
            context = new AttackContext(new BruteForceAttack(new BruteForceArgumentParser(args)));
            password = context.Execute();
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