using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    interface IIterator
    {
        object First();
        object Next();
        object Current();
        bool IsEnd();
    }

    class IterationUtility : IIterator
    {
        public List<object> collection;

        private int _currentIndex = 0;
        public object Current()
        {
            return collection[_currentIndex];
        }

        public object First()
        {
            return collection[0];
        }

        public object Next()
        {
            if (_currentIndex < collection.Count - 1)
                return collection[++_currentIndex];
            else
                ++_currentIndex;
                return null;
        }

        public bool IsEnd()
        {
            return _currentIndex >= collection.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IterationUtility i = new IterationUtility();
            i.collection = new List<object>();
            i.collection.Add(23);
            i.collection.Add("23");
            i.collection.Add("twenty three");
            i.collection.Add("XXIII");

            for (object x = i.First();  !i.IsEnd(); x = i.Next())
            {
                Console.WriteLine(x);
            }

            Console.ReadLine();
        }
    }
}
