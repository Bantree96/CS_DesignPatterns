class Node
{
    // 싱글톤 변수 설정
    private static Node _singleton;
    
    // 생성자를 Private로 설정, 즉 외부 클래스에서는 인스턴스 생성이 안됨
    private Node() { }
    
    /// <summary>
    /// 인스턴스 취득 함수
    /// </summary>
    /// <returns></returns>
    public static Node GetInstance()
    {
        if(_singleton == null)
        {
            // 인스턴스 생성
            _singleton = new Node();
        }
        return _singleton;
    }

    /// <summary>
    /// 출력 함수
    /// </summary>
    public void Print()
    {
        Console.WriteLine("Hello World!");
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        Node node1 = Node.GetInstance();
        Node node2 = Node.GetInstance();
        node1.Print();
        node2.Print();

        if (node2.Equals(node1))
        {
            Console.WriteLine("TRUE");
        }

        // 두 메모리 주소가 같은걸 확인 가능
        Console.WriteLine(node1.GetHashCode());
        Console.WriteLine(node2.GetHashCode());
    }

}