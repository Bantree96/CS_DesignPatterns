// 최상위 문 사용
Client client = new Client();
Abstraction abstraction = new Abstraction(new ConcreteImplementationA());
client.ClientCode(abstraction);

Console.WriteLine();

abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
client.ClientCode(abstraction);

// 추상화는 2의 "제어"부의 인터페이스를 정의합니다.
// 클래스 계층 계층그것은 그 개체의 개체에 참조를 유지합니다.
// 이러한 모든 실제 작업 계층 및 딜러들의 구현 계층 및 딜러들
// 객체
class Abstraction
{
    protected IImplementation _implementation;

    public Abstraction(IImplementation implementation)
    {
        _implementation = implementation;
    }

    public virtual string Operation()
    {
        return $"추상화 : Base operation with : \n {_implementation.OperationImplementation()}";
    }
}

class ExtendedAbstraction : Abstraction
{
    public ExtendedAbstraction(IImplementation implementation) : base(implementation)
    {

    }

    public override string Operation()
    {
        return $"ExtendedAbstraction: Extended operation with:\n {_implementation.OperationImplementation()} ";
    }
}

// 구현은 모든 구현 클래스에 대한 인터페이스를 정의합니다.
// 추상화의 인터페이스와 일치할 필요는 없습니다. 사실, 그 둘은
// 인터페이스는 완전히 다를 수 있습니다. 일반적으로 구현
// 인터페이스는 기본 연산만 제공하는 반면, 추상화는
// 에서는 이러한 기본 요소를 기반으로 더 높은 수준의 작업을 정의합니다.
internal interface IImplementation
{
    string OperationImplementation();
}

// 각 콘크리트 구현은 특정 플랫폼에서 해당합니다.
// 플랫폼 API를 사용하여 구현 인터페이스를 구현합니다.
class ConcreteImplementationA : IImplementation
{
    public string OperationImplementation()
    {
        return "ConcreteImplementationA: The result in platform A.\n";
    }
}
class ConcreteImplementationB : IImplementation
{
    public string OperationImplementation()
    {
        return "ConcreteImplementationA: The result in platform B.\n";
    }
}

// Abstraction 개체가 다음과 같은 초기화 단계를 제외하고
// 특정 구현 개체와 연결된 클라이언트 코드는 다음과 같습니다.
// 추상화 클래스에만 의존합니다. 이런 식으로 클라이언트 코드는
// 추상화와 변환의 조합을 지원합니다.
class Client
{
    public void ClientCode(Abstraction abstraction)
    {
        Console.WriteLine(abstraction.Operation());
    }
}

