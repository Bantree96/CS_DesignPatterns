using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Delegate
{
    // Delegate
    public delegate void Callback(string sender);

    class Controller
    {
        // Delegate 형식의 이벤트를 생성
        public event Callback callbackEvent;
        
        private string _data = "Hello world";

        public void Execute(Action<string> observer)
        {
            // 이벤트 형식의 옵저버 패턴
            callbackEvent(_data);

            // 람다 형식의 옵저버 패턴
            observer(_data);
        }
    }

    class Observer
    {
        private Controller _controller = new Controller();

        public void Run()
        {
            // 이벤트 식의 옵저버 패턴
            _controller.callbackEvent += (data) => { Console.WriteLine(data); };

            // 람다 식의 옵저버 패턴
            _controller.Execute((data) =>
            {
                Console.WriteLine(data);
            });
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var ob = new Observer();
            ob.Run();
        }
    }
}
