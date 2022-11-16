using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Controller
    {
        private string _data = "Hello world";
        public void Execute(IObserver observer)
        {
            observer.Callback(_data);
        }
    }

    class Observer : IObserver
    {
        private Controller _controller = new Controller();

        public void Run()
        {
            _controller.Execute(this);
        }

        // 위 Excute함수가 호출되면 아래의 Callback함수가 호출된다.
        public void Callback(string data)
        {
            Console.WriteLine(data);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var ob = new Observer();
            // 결과 : Hello world
            ob.Run();
        }
    }
}
