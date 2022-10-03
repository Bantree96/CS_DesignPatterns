public interface INode
{
    void Print();
}

public class Node1 : INode
{
    public void Print()
    {
        Console.WriteLine("Node1");
    }
}

public class Node2 : INode
{
    public void Print()
    {
        Console.WriteLine("Node2");
    }
}

public class CompositeNode : List<INode>, INode
{
    public void Print()
    {
        // List에 있는 인스턴스 획득
        foreach(var node in this)
        {
            // 동일한 이름의 함수를 실행
            node.Print();
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // List를 상속 받았기 때문에 List처럼 사용 가능함
        var composite = new CompositeNode();
        composite.Add(new Node1());
        composite.Add(new Node2());
        composite.Print();
    }
}