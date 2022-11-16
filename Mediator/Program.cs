using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    interface IMediator
    {
        void AddAction(IAction action);
        void AddController(IController controller);
        void Connect();
        void Draw();
    }

    // 중재자 클래스 안에 Controller 클래스와 Action 클래스를 받을 수 있게 한다.
    class Mediator : IMediator
    {
        private IAction _action = null;
        private IController _controller = null;

        public void AddAction(IAction action)
        {
            _action = action;
        }

        public void AddController(IController controller)
        {
            _controller = controller;
        }

        public void Connect()
        {
            _controller.OnConnected();
        }

        public void Draw()
        {
            _action.Draw();
        }
    }

    class Controller : IController
    {
        private IMediator _mediator;
        public Controller(IMediator mediator)
        {
            // 중재자 클래스에 설정
            _mediator = mediator;
            _mediator.AddController(this);
        }

        public void OnConnected()
        {
            Console.WriteLine("Connected!!");
        }

        public void Run()
        {
            // Run을 부르면 중재자 클래스의 Draw 함수 호출
            _mediator.Draw();
        }
    }

    class Action : IAction
    {
        private IMediator _mediator;
        public Action(IMediator mediator)
        {
            // 중재자 클래스에 설정
            _mediator = mediator;
            _mediator.AddAction(this);
        }

        public void Draw()
        {
            // Draw 함수 호출시 중재자 클래스의 Connect 함수 호출
            _mediator.Connect();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var mediator = new Mediator();
            var controller = new Controller(mediator);
            var action = new Action(mediator);

            controller.Run();

        }
    }


}
