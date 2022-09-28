using System;

namespace AbstractFactory
{
    interface IDao
    {
        void Print();
    }

    interface IFactory
    {
        IDao GetTypeDao();
    }

    // 
    class ATypeDao : IDao
    {
        public void Print()
        {
            Console.WriteLine("AtypeDao -  GetData()");
        }
    }

    class BTypeDao : IDao
    {
        public void Print()
        {
            Console.WriteLine("BtypeDao -  GetData()");
        }
    }

    class AFactory : IFactory
    {
        public IDao GetTypeDao()
        {
            return new ATypeDao();
        }
    }

    class BFactory : IFactory
    {
        public IDao GetTypeDao()
        {
            return new BTypeDao();
        }

    }
    public class Program
    {
        private static IFactory GetFactory(string type)
        {
            if ("A".Equals(type, StringComparison.OrdinalIgnoreCase))
            {
                return new AFactory();
            }
            else if ("B".Equals(type, StringComparison.OrdinalIgnoreCase))
            {
                return new BFactory();
            }
            return null;
        }

        static void Main(string[] args)
        {
            var factory = GetFactory("A");
            factory.GetTypeDao().Print();
            factory = GetFactory("B");
            factory.GetTypeDao().Print();

        }
    }
}
