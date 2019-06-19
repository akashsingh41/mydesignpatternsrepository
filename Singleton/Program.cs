using System;

namespace Singleton
{

    sealed class SingletonClass
    {
        private int counter = 0;
        private static SingletonClass Instance;
        private SingletonClass()
        {
            counter++;
            Console.WriteLine("Counter Value : " + counter);
        }
        public static SingletonClass GetInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new SingletonClass();

                return Instance;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            SingletonClass a = SingletonClass.GetInstance;
            SingletonClass b = SingletonClass.GetInstance;
            SingletonClass c = SingletonClass.GetInstance;
            Console.ReadLine();
        }
    }
}

