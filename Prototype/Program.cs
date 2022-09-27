using System.Security.Cryptography.X509Certificates;

class Node
{
    private int data;
    public Node(int data)
    {
        this.data = data;
    }

    public void Print()
    {
        Console.WriteLine("data = " + this.data);
    }

    // 프로토타입의 메모리 복사
    public Node Clone()
    {
        // Object 클래스에 protected 형태로 존재한다.
        return this.MemberwiseClone() as Node;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var node = new Node(1);
        var nodeClone = node.Clone();

        // 출력 함수 호출
        node.Print();
        nodeClone.Print();

        // 메모리 주소 출력
        Console.WriteLine(node.GetHashCode());
        Console.WriteLine(nodeClone.GetHashCode());

    }
}