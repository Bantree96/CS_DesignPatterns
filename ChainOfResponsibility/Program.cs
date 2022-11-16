abstract class ALogger
{
    protected ALogger Next { get; private set; }
    
    // 다음 포인터 Logger 설정
    public ALogger SetNextLogger(ALogger logger)
    {
        // Property에 인스턴스 설정
        Next = logger;
        // 인스턴스 return
        return logger;
    }

    // 다음 인스턴스에 write함수 호출
    public virtual void Write(string data)
    {
        if(Next != null)
        {
            Next.Write(data);
        }
    }
}

class ConsoleLogger : ALogger
{
    public override void Write(string data)
    {
        Console.WriteLine($"ConsoleLogger - {data}");
        // 다음 포인터 인스턴스의 함수 호출
        base.Write(data);
    }
}

class FileLogger : ALogger
{
    public override void Write(string data)
    {
        Console.WriteLine($"FileLogger - {data}");
        // 다음 포인터 인스턴스의 함수 호출
        base.Write(data);
    }
}

class MailLogger : ALogger
{
    public override void Write(string data)
    {
        Console.WriteLine($"MailLogger - {data}");
        // 다음 포인터 인스턴스의 함수 호출
        base.Write(data);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var logger = new ConsoleLogger();
        logger.SetNextLogger(new FileLogger())
              .SetNextLogger(new MailLogger());

        logger.Write("Hello World");
    }
}
