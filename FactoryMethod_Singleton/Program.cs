interface INode
{
    void Print();
}

class Node1 : INode
{
    private static Node1 singleton = null;
    private Node1() { }

    /// <summary>
    /// 인스턴스 취득 함수
    /// </summary>
    /// <returns>인스턴스</returns>
    public static Node1 GetInstance()
    {
        if(singleton == null)
        {
            singleton = new Node1();
        }
        return singleton;
    }
    public void Print()
    {
        Console.WriteLine("Node1 Class");
    }
}

class Node2 : INode
{
    private static Node2 singleton = null;
    private Node2() { }

    /// <summary>
    /// 인스턴스 취득 함수
    /// </summary>
    /// <returns>인스턴스</returns>
    public static Node2 GetInstance()
    {
        if (singleton == null)
        {
            singleton = new Node2();
        }
        return singleton;
    }
    public void Print()
    {
        Console.WriteLine("Node2 Class");
    }
}

enum NodeType
{
    Node1,
    Node2,
}

class Program
{
    static INode Factory(NodeType type)
    {
        if(type == NodeType.Node1)
        {
            return Node1.GetInstance();
        }
        else if(type == NodeType.Node2)
        {
            return Node2.GetInstance();
        }
        // 모든 조건 없을시 null 반환
        return null;
    }

    static void Main(string[] args)
    {
        INode node = Factory(NodeType.Node1);
        node.Print();
        node = Factory(NodeType.Node2);
        node.Print();
    }
}