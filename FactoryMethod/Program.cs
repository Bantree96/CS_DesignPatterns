interface INode
{
    void Print();
}

class Node1 : INode
{

    public void Print()
    {
        Console.WriteLine("Node1 Class");
    }
}

class Node2 : INode
{

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
    // 팩토리 메서드 패턴의 함수
    static INode Factory(NodeType type)
    {
        if(type == NodeType.Node1)
        {
            return new Node1();
        }
        else if(type == NodeType.Node2)
        {
            return new Node2();
        }
        return null;
    }

    static void Main(string[] args)
    {
        // 팩토리 메서드에 Enum타입을 넣으면 해당 Class가 생성된다.
        INode node = Factory(NodeType.Node1);
        node.Print();
        node = Factory(NodeType.Node2);
        node.Print();
    }
}