class Node1
{
    public string Name { get; set; }
    public int Data { get; set; }
    public void Print()
    {
        Console.WriteLine($"Node1 - Name = {Name} Data = {Data}");
    }
}

class Node2
{
    public string Name { get; set; }
    public int Data { get; set; }
    public void Print()
    {
        Console.WriteLine($"Node2 - Name = {Name} Data = {Data}");
    }
}

/*
class NotUseBuilder
{
    static void Main(string[] args)
    {
        var node1 = new Node1();
        node1.Name = "Test1";
        node1.Data = 1;
        node1.Print();

        var node2 = new Node2();
        node2.Name = "Test2";
        node2.Data = 2;
        node2.Print();
    }
}
*/