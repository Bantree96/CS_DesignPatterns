using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface INode
    {
        void Print();
    }

    public class Node1 : INode
    {
        public string Name { get; set; }
        public int Data { get;set; }
        public void Print()
        {
            Console.WriteLine($"Node1 - Name = {Name} Data = {Data}");
        }
    }

    public class Node2 : INode
    {
        public string Name { get; set; }
        public int Data { get; set; }
        public void Print()
        {
            Console.WriteLine($"Node2 - Name = {Name} Data = {Data}");
        }
    }

    internal class UseBuilder
    {
        static INode Build(string type, string name, int data)
        {
            // return을 위한 변수
            INode ret = null;

            // type이 Node1일 경우 (대소문자 무시)
            if("Node1".Equals(type, StringComparison.OrdinalIgnoreCase))
            {
                ret = new Node1();
                ((Node1)(ret)).Name = name;
                ((Node1)(ret)).Data = data;
            }

            // type이 Node2일 경우 (대소문자 무시)
            if ("Node2".Equals(type, StringComparison.OrdinalIgnoreCase))
            {
                ret = new Node2();
                ((Node2)(ret)).Name = name;
                ((Node2)(ret)).Data = data;
            }

            return ret;

        }

        static void Main(string[] args)
        {
            var node1 = Build("node1", "Test1", 1);
            node1.Print();

            var node2 = Build("node2", "Test2", 2);
            node2.Print();
        }

    }
}
