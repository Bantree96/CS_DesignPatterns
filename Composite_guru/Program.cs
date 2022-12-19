Client client = new Client();
Leaf leaf = new Leaf();
Console.WriteLine($"Client : I get a simple component : ");
client.ClientCode(leaf);

Composite tree = new Composite();
Composite branch1 = new Composite();
branch1.Add(new Leaf());
branch1.Add(new Leaf());

Composite branch2 = new Composite();
branch2.Add(new Leaf());

tree.Add(branch1);
tree.Add(branch2);

Console.WriteLine($"Client : Now I've got a compsite tree : ");
client.ClientCode(tree);

client.ClientCode2(tree, leaf);



abstract class Component
{
    public Component() { }

    public abstract string Operation();

    public virtual void Add(Component component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Component component)
    {
        throw new NotImplementedException();
    }

    public virtual bool IsComposite()
    {
        return true;
    }
}

// Leaf 클래스는 구성의 끝 객체를 나타냅니다. 나뭇잎은 할 수 없다.
// 자식이 없다
//
// 일반적으로 실제 작업을 수행하는 것은 리프 개체인 반면, 컴포지트입니다.
// 개체는 하위 구성 요소에만 위임됩니다.
class Leaf : Component
{
    public override string Operation()
    {
        return "Leaf";
    }

    public override bool IsComposite()
    {
        return false;
    }
}

class Composite : Component
{
    protected List<Component> _children = new List<Component>();

    public override void Add(Component component)
    {
        _children.Add(component);
    }

    public override void Remove(Component component)
    {
        _children.Remove(component);
    }

    public override string Operation()
    {
        int i = 0;
        string result = "Branch(";

        foreach (Component component in _children)
        {
            result += component.Operation();
            if(i != _children.Count - 1)
            {
                result += "+";
            }
            i++;
        }

        return result + ")";
    }
}


class Client
{
    public void ClientCode(Component leaf)
    {
        Console.WriteLine($"RESULT : {leaf.Operation()}\n");
    }

    public void ClientCode2(Component component1, Component component2)
    {
        if (component1.IsComposite())
        {
            component1.Add(component2);
        }

        Console.WriteLine($"RESULT : {component1.Operation()}");
    }
}