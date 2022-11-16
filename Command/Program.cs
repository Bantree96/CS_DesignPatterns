class Car
{
    public void LeftTurn()
    {
        Console.WriteLine("LeftTurn!");
    }
    public void RightTurn()
    {
        Console.WriteLine("RightTurn!");
    }
    public void Break()
    {
        Console.WriteLine("Break!");
    }
    public void Accelerator()
    {
        Console.WriteLine("Accelerator!");
    }
}

abstract class ACommand
{
    private Car car = new Car();
    public ACommand(Car car)
    {
        // 멤버 변수 설정
        this.car = car;
    }

    // 실행
    public void Execute()
    {
        // 추상 함수 실행
        Run(car);
    }
    // 추상 함수
    protected abstract void Run(Car car);
}

class LeftTurnCommand : ACommand
{
    public LeftTurnCommand(Car car) : base(car){ }
    protected override void Run(Car car)
    {
        car.LeftTurn();
    }
}


class RightTurnCommand : ACommand
{
    public RightTurnCommand(Car car) : base(car) { }

    protected override void Run(Car car)
    {
        car.RightTurn();
    }
}

class AcceleratorCommand : ACommand
{
    public AcceleratorCommand(Car car) : base(car){ }
    protected override void Run(Car car)
    {
        car.Accelerator();
    }
}

class BreakCommand : ACommand
{
    public BreakCommand(Car car) : base (car){ }
    protected override void Run(Car car)
    {
        car.Break();

    }
}


class Driving
{
    // Command List
    private List<ACommand> cmds = new List<ACommand>();
    // 브레이크 커맨드 멤버 변수
    private ACommand breakCmd;

    // 생성자
    public Driving(ACommand breakCmd)
    {
        this.breakCmd = breakCmd;
    }

    /// <summary>
    /// 커맨드 추가 함수
    /// </summary>
    /// <param name="cmd"></param>
    public void AddCommand(ACommand cmd)
    {
        cmds.Add(cmd);
    }
    
    /// <summary>
    /// 출발
    /// </summary>
    public void Start()
    {
        foreach (var cmd in this.cmds)
        {
            cmd.Execute();
            this.breakCmd.Execute();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car();
        Driving driving = new Driving(new BreakCommand(car));
        driving.AddCommand(new AcceleratorCommand(car));
        driving.AddCommand(new LeftTurnCommand(car));
        driving.AddCommand(new RightTurnCommand(car));

        // 출발
        driving.Start();
    }
}