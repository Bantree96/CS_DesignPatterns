using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Node
    {
        private Type reflectionMemento = typeof(Memento);
        public int Data { get; set; }
        public int State { get; set; }

        public void Print()
        {
            Console.Write($"Data - {Data} State - {State}");
        }

        /// <summary>
        /// 메멘토 인스턴스 취득 함수
        /// </summary>
        /// <returns></returns>
        public object GetMemento()
        {
            // 인스턴스 생성
            Memento memento = new Memento();

            // 변수 설정
            // 멤버 변수가 private로 설정되어 있기 때문에 접근하기 위해서는 Reflection을 이용한다. 
            reflectionMemento.GetField("data", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(memento, Data);
            reflectionMemento.GetField("state", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(memento, State);

            // 인스턴스 리턴
            return memento;
        }

        /// <summary>
        /// 메멘토 인스턴스로 멤버 변수 값 설정
        /// </summary>
        /// <param name="memento"></param>
        /// <exception cref="Exception"></exception>
        public void SetMemento(object memento)
        {
            // 파라미터가 Memento 클래스가 아니면 예외 처리
            if(memento.GetType() != reflectionMemento) 
                throw new Exception("Memento 클래스가 아닙니다.");

            // 값을 취득
            // 멤버 변수가 private로 설정되어 있기 때문에 접근하기 위해서는 Reflection을 이용한다.
            Data = (int)reflectionMemento.GetField("data", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(memento);
            State = (int)reflectionMemento.GetField("state", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(memento);

        }
    }

    internal class Program
    {
        static void WriteMemento(object memento)
        {
            var formatter = new BinaryFormatter();
            using(FileStream stream = new FileStream($"D:\\memento.dat", FileMode.Create, FileAccess.Write))
            {
                // 직렬화
                formatter.Serialize(stream, memento);
            }
        }

        static object ReadMemento()
        {
            var formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("D:\\memento.dat", FileMode.Open, FileAccess.Read))
            {
                // 역직렬화
                return formatter.Deserialize(stream);
            }
        }

        static void Main(string[] args)
        {
            Node node = new Node();

            node.Data = 10;
            node.State = 1;

            node.Print();

            // 메멘토 인스턴스 취득
            object memento = node.GetMemento();

            // 메멘토 인스턴스를 파일로 출력
            WriteMemento(memento);

            // Node 인스턴스의 멤버 변수로 설정
            node.Data = 11;
            node.State = 2;

            node.Print();

            // 메멘토 인스턴스를 파일로 읽어온다.
            memento = ReadMemento();

            // Node 인스턴스에 메멘토 재설정
            node.SetMemento(memento);

            node.Print();

        }
    }
}
