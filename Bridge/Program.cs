public interface Controller
{
    void Execute(Model model);
}

public interface Model
{
    string GetData();
}

// MVC 형태의 프레임워크에서 Model 클래스(파라미터)
public class ParameterModel : Model
{
    private string data;
    public ParameterModel(string data)
    {
        this.data = data;
    }

    public string GetData()
    {
        return this.data;
    }
}

// MVC 형태의 프레임워크에서 Contoller 클래스
public class MainController : Controller
{
    public void Execute(Model model)
    {
        Console.WriteLine($"Execute - {model.GetData()}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var controller = new MainController();
        // 인스턴스 생성
        var model = new ParameterModel("Hello World");
        // 만들어진 인스턴스로 Controller 사용
        controller.Execute(model);
    }
}