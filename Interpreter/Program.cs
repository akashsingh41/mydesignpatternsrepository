using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public interface IExpression
    {   
        int Interpret(); 
    }

    public class LiteralExpression : IExpression
    {
        int number;
        public LiteralExpression(int i)
        {
            number = i;
        }
        int IExpression.Interpret()
        {
            return number;
        }
    }

    public class AdditionExpression : IExpression
    {
        IExpression leftExpression, rightExpression;
        public AdditionExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        int IExpression.Interpret()
        {
            return leftExpression.Interpret() + rightExpression.Interpret();
        }
    }

    public class SubtractExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public SubtractExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        int IExpression.Interpret()
        {
            return leftExpression.Interpret() - rightExpression.Interpret();
        }
    }

    public class Utility
    {
        public static bool isOperator(String s)
        {
            if (s.Equals("+") || s.Equals("-"))
                return true;
            else
                return false;
        }

        public static IExpression getOperator(String s, IExpression left, IExpression right)
        {
            switch (s)
            {
                case "+":
                    return new AdditionExpression(left, right);
                case "-":
                    return new SubtractExpression(left, right);
            }
            return null;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            String tokenString = "7 3 - 2 1 + -";
            Stack<IExpression> stack = new Stack<IExpression>();

            String[] tokens = tokenString.Split(' ');

            foreach (String x in tokens)
            {
                if (Utility.isOperator(x))
                {
                    IExpression rightExp = stack.Pop();
                    IExpression leftExp = stack.Pop();
                    IExpression operation = Utility.getOperator(x, leftExp, rightExp);
                    int result = operation.Interpret();
                    stack.Push(new LiteralExpression(result));
                }
                else
                {
                    IExpression i = new LiteralExpression(int.Parse(x));
                    stack.Push(i);
                }
            }

            Console.WriteLine("(" + tokenString + "): " + stack.Pop().Interpret());
            Console.ReadLine();
        }
    }
}
