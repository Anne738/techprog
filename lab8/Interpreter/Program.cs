using System;
using System.Collections.Generic;

namespace Interpreter
{
    class Context
    {
        Dictionary<string, int> variables;

        public Context()
        {
            variables = new Dictionary<string, int>();
        }
        public int GetVariable(string name)
        {
            return variables[name];
        }

        public void SetVariable(string name, int value)
        {
            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);
        }
    }

    interface IExpression
    {
        int Interpret(Context context);
    }

    class NumberExpression : IExpression
    {
        string name;

        public NumberExpression(string variableName)
        {
            name = variableName;
        }

        public int Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }

    class MultiplyExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public MultiplyExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) *
                   rightExpression.Interpret(context);
        }
    }

    class DivideExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public DivideExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) /
                   rightExpression.Interpret(context);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            int x = 10;
            int y = 5;
            int z = 2;

            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);


            IExpression expression = new DivideExpression(
                new MultiplyExpression(
                    new NumberExpression("x"),
                    new NumberExpression("y")
                    ),
                new NumberExpression("z")
            );

            int result = expression.Interpret(context);

            Console.WriteLine($"Результат: {result}");
            Console.ReadKey();
        }
    }
}