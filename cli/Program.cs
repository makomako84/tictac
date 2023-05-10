using MakoSystems.TicTac.Core;
using MakoSystems.TicTac.Tests;

public class Program
{
    public static void Main()
    {
        new CoreTests(new Session()).Check1();
        new CoreTests(new Session()).Check2();
        new CoreTests(new Session()).Check3();
        new CoreTests(new Session()).Check4();

    }
}