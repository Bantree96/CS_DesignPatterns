public interface ITarget
{ 
    string GetRequest();
}

class Adaptee
{
    public string GetSpecificRequest() { return "특정한 요청.";  }
}

class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public string GetRequest()
    {
        return $"이것은 '{_adaptee.GetSpecificRequest()}' 입니다.";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);  

        Console.WriteLine(target.GetRequest());
    }
}