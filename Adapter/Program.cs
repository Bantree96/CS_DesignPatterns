public interface INode
{
    void Print();
}

public class Node1
{
    public string Output()
    {
        return "Node1 - Output()";
    }
}

public class Node2 : INode
{
    public void Print()
    {
        Console.WriteLine("Node2 - Print()");
    }
}

// 상속을 통해 Adapter 구현
public class Adapter : Node1, INode
{
    public void Print()
    {
        // base = Node1
        Console.WriteLine(base.Output());
    }
}

class Program
{
    static void Main(string[] args)
    {
        var list = new List<INode>();
        list.Add(new Node2());
        list.Add(new Adapter());
        foreach(var node in list)
        {
            node.Print();
        }
    }
}