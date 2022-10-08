interface INode
{
    void Print();
}

class NodeProxy : INode
{
    private class Node1 : INode
    {
        public void Print()
        {
            Console.WriteLine("Node1 Class");
        }
    }

    private class Node2 : INode
    {
        public void Print()
        {
            Console.WriteLine("Node2 Class");
        }
    }

    private INode node;
    private bool check;


    public NodeProxy(bool check = true)
    {
        this.check = check; 
    }
    public void Print()
    {
        if(node == null)
        {
            // 파라미터 check에 의해 생성되는 인스턴스가 다르다.
            if (check)
            {
                node = new Node1();
            }
            else
            {
                node = new Node2();
            }
        }
        node.Print();
    }
}

class Program
{
    static void Main(string[] args)
    {
        INode node = new NodeProxy();
        node.Print();
        node = new NodeProxy(false);
        node.Print();

    }
}
