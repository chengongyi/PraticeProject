using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace LINQTest018_ExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowExpressionTree();


            ShowAlreadyExpressionThree();
        }

        private static void ShowAlreadyExpressionThree()
        {
            Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;

            Console.WriteLine("Expression: {0}", isTeenAgerExpr);

            Console.WriteLine("Expression Type: {0}", isTeenAgerExpr.NodeType);

            var parameters = isTeenAgerExpr.Parameters;

            foreach (var param in parameters)
            {
                Console.WriteLine("Parameter Name: {0}", param.Name);
                Console.WriteLine("Parameter Type: {0}", param.Type.Name);
            }
            var bodyExpr = isTeenAgerExpr.Body as BinaryExpression;

            Console.WriteLine("Left side of body expression: {0}", bodyExpr.Left);
            Console.WriteLine("Binary Expression Type: {0}", bodyExpr.NodeType);
            Console.WriteLine("Right side of body expression: {0}", bodyExpr.Right);
            Console.WriteLine("Return Type: {0}", isTeenAgerExpr.ReturnType);
        }

        private static void ShowExpressionTree()
        {
            //表示命名的参数表达式
            ParameterExpression pe = Expression.Parameter(typeof(Student), "s");

            //表示访问字段或属性
            MemberExpression me = Expression.Property(pe, "Age");

            //表示具有常量值的表达式
            ConstantExpression constant = Expression.Constant(18, typeof(int));

            //属性，大于常量
            BinaryExpression body = Expression.GreaterThanOrEqual(me, constant);

            var ExpressionTree = Expression.Lambda<Func<Student, bool>>(body, new[] {pe});

            Console.WriteLine("Expression Tree: {0}", ExpressionTree);

            Console.WriteLine("Expression Tree Body: {0}", ExpressionTree.Body);

            Console.WriteLine("Number of Parameters in Expression Tree: {0}",
                ExpressionTree.Parameters.Count);

            Console.WriteLine("Parameters in Expression Tree: {0}", ExpressionTree.Parameters[0]);


            Console.WriteLine(body.Left);
            Console.WriteLine(body.Right);

        }
    }
}
