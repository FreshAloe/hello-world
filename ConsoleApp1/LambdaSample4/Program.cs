using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LambdaSample4
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int, int>> exp = ((a, b) => a + b);

            BinaryExpression opPlus = exp.Body as BinaryExpression;
            Console.WriteLine(opPlus.NodeType);

            ParameterExpression leftParam = opPlus.Left as ParameterExpression;
            Console.WriteLine(leftParam.NodeType + ": " + leftParam.Name);

            ParameterExpression rightParam = opPlus.Right as ParameterExpression;
            Console.WriteLine(rightParam.NodeType + ": " + rightParam.Name);

            Func<int, int, int> func = exp.Compile();
            Console.WriteLine(func(10, 2));
        }
    }
}
