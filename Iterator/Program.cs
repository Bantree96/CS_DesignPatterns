using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> iter = new LinkedList<int>();
            iter.Add(1);
            iter.Add(2);
            iter.Add(3);
            iter.Add(4);
            iter.Add(5);

            // MoveNext()를 호출하고 true면 Current를 호출한다.
            // 결과는 1,2,3,4,5
            foreach(var data in iter)
            {
                Console.WriteLine(data);
            }

        }
    }

    // T : 어떤 자료형이 올지 모름
    // IEnumerable<T>가 없다면 foreach문에 넣을 수 없다.
    public class LinkedList<T> : IEnumerable<T>
    {
        // 연결 리스트의 앞쪽 인스턴스 포인터
        private Node first = null;
        // 연결 리스트의 뒤쪽 인스턴스 포인터
        private Node end = null;

        // 연결 리스트 알고리즘을 위한 인스턴스 클래스
        class Node
        {
            // 리스트에 있는 값
            public T Data { get; set; }
            // 연결 리스트의 다음 인스턴스 포인터
            public Node Next { get; set; }
        }

       
        /// <summary>
        /// 값 추가 함수
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            // 인스턴스 생성
            Node node = new Node() { Data = data };

            // 리스트가 비어있을 경우
            if (first == null)
            {
                first = node;
                end = node;
                return;
            }

            // 리스트가 비어있지 않을 경우 -> 가장 뒤에 연결
            end.Next = node;
            // 뒤쪽 인스턴스 변경
            end = node;
        }

        // Iterator 패턴 클래스의 인스턴스 리턴
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(first);
        }

        // GetEnumerator 함수와 동일
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class Enumerator : IEnumerator<T>
        {

            // Reset함수를 위한 리스트의 앞쪽 변수
            private Node first;
            // 현재 위치 변수
            private Node current;
            public Enumerator(Node first)
            {
                this.first = first;
                this.current = first;
            }

            // 현재 위치 값 반환
            public T Current
            {
                get
                {
                    // 리턴 값을 취득
                    T ret = current.Data;
                    // 포인터 이동
                    current = current.Next;
                    // 값 리턴
                    return ret;
                }
            }

            // Current의 값과 동일
            object IEnumerator.Current => Current;
            public void Dispose()
            {
                // 만약 리소스를 사용할 경우, 즉 IO나 Socket이 사용된 경우에는 커넥션을 종료한다.
            }

            // 다음 인스턴스가 있는 여부
            public bool MoveNext()
            {
                // 없으면 false, 있으면 true
                return current != null;
            }

            // Iterator 패턴 초기화 -> 사용되지 않음
            public void Reset()
            {
                current = first;
            }
        }
    }
}
