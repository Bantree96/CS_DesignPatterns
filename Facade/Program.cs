class MainApp
{
    public static void Main(string[] args)
    {
        Facade facade = new Facade();
        facade.MethodA();
    }
}

class Facade
{
    private SubSystemOne _one;
    private SubSystemTwo _two;
    private SubSystemThree _three;
    private SubSystemFour _four;

    public Facade()
    {
        _one = new SubSystemOne();
        _two = new SubSystemTwo();
        _three = new SubSystemThree();
        _four = new SubSystemFour();
    }

    public void MethodA()
    {
        _one.Print($"{_one}");
        _two.Print($"{_two}");
        _three.Print($"{_three}");
        _four.Print($"{_four}");
    }

}

internal class SubSystemFour : ConsolePrint
{
}

internal class SubSystemThree : ConsolePrint
{
}

internal class SubSystemTwo : ConsolePrint
{
}

public class SubSystemOne : ConsolePrint
{
}

public class ConsolePrint
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}