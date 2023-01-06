using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using _23_Expression.CustomExpressionVisitor;
using _23_Expression.Entity;
using _23_Expression.ExpressionExtensions;
using _23_Expression.Mapper;

namespace _23_Expression;

public class Program
{
    public static void Main(string[] args)
    {
        #region Test

//         
//
//         // 创建了两个常数的表达式节点
//         ConstantExpression left = Expression.Constant(123, typeof(int));
//         ConstantExpression right = Expression.Constant(234, typeof(int));
//
//         // 将两个表达式创建加法关系
//         var expression = Expression.Add(left, right);
//
//         // 将表达式表示为Lambda表达式的形式以便于转换为Func委托
//         var lambdaExp = Expression.Lambda<Func<int>>(expression, new ParameterExpression[0]);
//
//         // 以下两行可以简写为：var result = lambdaExp.Compile()();
//         var sumDelegate = lambdaExp.Compile();
//
//         // 返回的结果即是123 + 234的结果
//         var result = sumDelegate.Invoke();
//
//         Console.WriteLine(result);
//
//         /*
//         ParameterExpression m = Expression.Parameter(typeof(int), "m");
//         ParameterExpression n = Expression.Parameter(typeof(int), "n");
//         ConstantExpression constPara = Expression.Constant(2, typeof(int));
//
//         // left = (m * n)
//         var left = Expression.Multiply(m, n);
//
//         // left = ((m * n) + m)
//         left = Expression.Add(left, m);
//
//         // right = (n + 2)
//         var right = Expression.Add(n, constPara);
//
//         // result = (((m * n) + m) + (n + 2))
//         var result = Expression.Add(left, right);
//
//         var lambdaExp = Expression.Lambda<Func<int, int, int>>(result, m, n);
//
//         var resultValue = lambdaExp.Compile()(10, 10);
//
//         Console.WriteLine($"{resultValue}");
//         */
//
//         //    CallMethodExpression();
//         /
//         /
//         /
//
//          ExpressionVisitorTest();

        #endregion

        Console.WriteLine("********And********");
        AndExpressionTest();

        Console.WriteLine("*********Or**********");
        OrExpressionTest();
    }


    public static void CallMethodExpression()
    {
        var people = new List<People>()
        {
            new People() { Id = 1, Name = "Apple" },
            new People() { Id = 2, Name = "Banana" },
            new People() { Id = 3, Name = "Orange" },
            new People() { Id = 4, Name = "Peach" },
            new People() { Id = 5, Name = "PineApple" }
        };

        var person = people.FirstOrDefault(p => p.Id.ToString().Equals("5"));
        Console.WriteLine(person);


        var p = Expression.Parameter(typeof(People), "p");

        var propInfo = typeof(People).GetProperty("Id");

        var memberExp = Expression.Property(p, propInfo);

        var toStringExp = Expression.Call(memberExp, typeof(int).GetMethod("ToString", new Type[0]));

        var constStr = Expression.Constant("5");

        var equalsMethod = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });

        var equalsExp = Expression.Call(toStringExp, equalsMethod, constStr);

        var lambdaExp = Expression.Lambda<Func<People, bool>>(equalsExp, p);

        var func = lambdaExp.Compile();

        var flag = func.Invoke(new People() { Id = 5, Name = "PineApple" });

        var another = people.Where(func).FirstOrDefault();

        Console.WriteLine($"Person = {person}, Flag = {flag}, Another = {another}");
    }

    public static void ExpressionAssign()
    {
        var watch = new Stopwatch();

        var p = new People()
        {
            Id = 5,
            Name = "PineApple"
        };

        Man person = null;

        watch.Start();
        var result = Parallel.For(1, 100_000_000, (state) =>
        {
            person = new Man()
            {
                Id = p.Id,
                Name = p.Name
            };
        });
        watch.Stop();
        Console.WriteLine($"Result:{result.IsCompleted}, Code：{watch.ElapsedMilliseconds}");

        watch.Restart();
        result = Parallel.For(1, 100_000_000, (state) => { person = MapperUtil<People, Man>.ExpressionMapTo(p); });
        watch.Stop();
        Console.WriteLine($"Result:{result.IsCompleted}, Expression：{watch.ElapsedMilliseconds}");

        watch.Restart();
        result = Parallel.For(1, 100_000_000, (state) => { person = MapperUtil<People, Man>.ExpressionMapTo(p); });
        watch.Stop();
        Console.WriteLine($"Result:{result.IsCompleted}, Reflection：{watch.ElapsedMilliseconds}");
    }


    public static void ExpressionVisitorTest()
    {
        Expression<Func<int, int, int>> exp = (m, n) => (m * m) + (2 * m * n) + (n * n);

        OperationExpressionVisitor visitor = new();
        var expression = visitor.Visit(exp) as Expression<Func<int, int, int>>;
        var result = expression.Compile().Invoke(10, 10);

        Console.WriteLine(result);
    }

    public static List<People> People => new List<People>()
    {
        new() { Id = 1, Name = "Apple" },
        new() { Id = 2, Name = "Banana" },
        new() { Id = 3, Name = "Orange" },
        new() { Id = 4, Name = "Peach" },
        new() { Id = 5, Name = "PineApple" }
    };

    public static void AndExpressionTest()
    {
        Expression<Func<People, bool>> expression = p => p.Name.Contains("e");
        Expression<Func<People, bool>> predicate = p => p.Id >= 3;

        expression = expression.AndAlso(predicate);

        var persons = People.Where(expression.Compile());
        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }

    public static void OrExpressionTest()
    {
        Expression<Func<People, bool>> expression = p => p.Name.Contains("e");
        Expression<Func<People, bool>> predicate = p => p.Id >= 3;

        expression = expression.Or(predicate);

        var persons = People.Where(expression.Compile());
        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }


    public class Man
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public override string ToString() => $"Id={Id},Name={Name}";
    }
}