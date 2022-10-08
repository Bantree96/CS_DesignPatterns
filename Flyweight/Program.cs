interface IDao
{
    void Select();
}

class ADao : IDao
{
    public void Select()
    {
        Console.WriteLine("ADao was selected!");
    }
}

class BDao : IDao
{
    public void Select()
    {
        Console.WriteLine("BDao was selected!");
    }
}

class FactoryDao
{
    // Flywweight 패턴 Dict
    private Dictionary<Type, IDao> flyweight = new Dictionary<Type, IDao>();
    public T GetDao<T>() where T : IDao
    {
        // 제네릭 타입으로 flyweight dict에 인스턴스가 있는지 확인
        if (!flyweight.ContainsKey(typeof(T)))
        { 
            // 없으면 Reflection 기능을 이용해 인스턴스 생성
            flyweight.Add(typeof(T), (IDao)Activator.CreateInstance(typeof(T)));
        }
        // 인스턴스 반환
        return (T)flyweight[typeof(T)];
    }
}

class Program
{
    static void Main(string[] args)
    {
        var factory = new FactoryDao();
        // 새로 생성된 인스턴스
        factory.GetDao<ADao>().Select();
        factory.GetDao<BDao>().Select();
        // 기존에 있던 인스턴스
        factory.GetDao<BDao>().Select();
        factory.GetDao<BDao>().Select();
    }
}