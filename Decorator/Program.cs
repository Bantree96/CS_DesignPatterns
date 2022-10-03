interface INode
{
    int output();
}

class Node : INode
{
    private int data;

    public Node(int data)
    {
        this.data = data;
    }
    
    public int output()
    {
        return this.data;
    }

    public override string ToString()
    {
        return this.output().ToString();
    }
}

// INode 인터페이스를 상속받은 데코레이터 추상 클래스
abstract class ANodeDecorator : INode
{
    private INode node;
    public ANodeDecorator(INode node)
    {
        this.node = node;
    }
    
    protected INode getNode()
    {
        return this.node;
    }

    /// <summary>
    /// ToString 재정의
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.output().ToString();
    }

    /// <summary>
    /// 인터페이스의 output 함수 추상화
    /// </summary>
    /// <returns></returns>
    public abstract int output();   
}

class MultiplyDecorator : ANodeDecorator, INode
{
    /// <summary>
    /// 생성자에서 INode의 인스턴스 설정
    /// </summary>
    /// <param name="node"></param>
    public MultiplyDecorator(INode node) : base(node) { }

    /// <summary>
    /// 함수 재 정의
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override int output()
    {
        // 값 * 10
        return base.getNode().output() * 10;
    }
}

class DivisionDecorator : ANodeDecorator, INode
{
    // Base 클래스의 생성자로 초기화하여 인스턴스를 생성한다.
    public DivisionDecorator(INode node) : base(node) { }
    
    public override int output()
    {
        return base.getNode().output() / 10;
    }
}

class Program
{
    enum CalType
    {
        Multiply,
        Division
    }

    static INode GetNodeFactory(int data, CalType? calType = null)
    {
        INode node = new Node(data);
        switch (calType)
        {
            case CalType.Multiply:
                node = new MultiplyDecorator(node);
                break;
            case CalType.Division:
                node = new DivisionDecorator(node);
                break;
            default:
                break;
        }
        return node;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GetNodeFactory(100));
        Console.WriteLine(GetNodeFactory(100, CalType.Multiply));
        Console.WriteLine(GetNodeFactory(100, CalType.Division));
    }
}