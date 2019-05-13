using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static AlgorithmTheory.Primitives;
using static System.Linq.Expressions.Expression;
using static AlgorithmTheory.CreatingDelegates.CompositionCreator;
using AlgorithmTheory;
using AlgorithmTheory.CreatingDelegates;

using fun = System.Func<double, double>;
using fun2 = System.Func<double, double, double>;
using exp = System.Linq.Expressions.Expression<System.Func<int, int>>;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
//using static AlgorithmsTheory.CreatingDelegates.DelegateHelper;


namespace Worker
{
#pragma warning disable IDE0039 // Использовать локальную функцию
#pragma warning disable IDE0051 // Удалите неиспользуемые закрытые члены
#pragma warning disable IDE0060 // Удалите неиспользуемый параметр
#pragma warning disable IDE1006 // Стили именования
    class Program
    {
        static readonly PropertyInfo debug = typeof(Expression).GetProperty("DebugView", (BindingFlags)(-1));

        static void print(Expression expression)
            => Console.WriteLine(debug.GetValue(expression));

        static void PrimesTest()
        {
            var now = DateTime.UtcNow;

            Console.WriteLine(PrimeNumbers.GetPrimeNumber(20000));

            var time = DateTime.UtcNow - now;
            Console.WriteLine(time);
#if DEBUG
            Console.WriteLine("new num(BI) is colled:{0}", Num.BIctor);
            Console.WriteLine("new num(INT) is colled:{0}", Num.INTctor);
            Console.WriteLine("new num(UINT) is colled:{0}", Num.UINTctor);
#endif
        }

        static Expression<Func<T, T>> GetExpression<T>(Expression<Func<T, T>> expr) => expr;

        static Fun2 prim(Fun1 h, Fun3 g)
        {
            Num f(Num x, Num y)
            {
                if (x == Num.Zero)
                    return h(y);
                x -= Num.One;
                return g(x, y, f(x, y));
            }
            return f;
        }

        static Fun2 prim_gt(Fun1 h, Fun3 g)
        {
            Num f(Num counter, Num var1)
            {
                Num temp = counter;
                Num acc = h(var1);
                counter = default;
            start:
                if (temp == counter)
                    goto end;
                acc = g(counter, var1, acc);
                counter += Num.One;
                goto start;
            end:
                return acc;
            }
            return f;
        }

        static Fun2 prim_gt_(Fun1 h, Fun3 g)
        {
            Num f(Num counter, Num var1)
            {
                Num temp = Num.Zero;
                Num acc = h(var1);
            start:
                if (temp == counter)
                    goto end;
                acc = g(temp, var1, acc);
                temp += Num.One;
                goto start;
            end:
                return acc;
            }
            return f;
        }

        static Num H(Num x) => Num.One;

        static Num G(Num x, Num y, Num z) => (x + Num.One) * z;

        delegate object[] Closured(Closure closure);

        static Delegate partial(Delegate d, int i, object o)
        {
            return AlgorithmTheory.CreatingDelegates.DelegateHelper.LockParameter(d, o, i, null);
        }

        static void Main()
        {
            Console.WriteLine(Assembly.GetCallingAssembly().FullName);
            Expression<Func<int, Func<int, int>>> tst = x => z => x + z;
            print(tst);
            tst = (Expression<Func<int, Func<int, int>>>)
                ChangeParametersVisitor.ChangeParameters(
                    tst, (((LambdaExpression)tst.Body).Parameters[0], Parameter(typeof(int), "y")));
            print(tst);
            /*
            var fac = prim(x => Num.One, (a, b, c) => (a + Num.One) * c);
            var fac_gt = prim_gt(x => Num.One, (a, b, c) => (a + Num.One) * c);

            for (var i = Num.Zero; i < 6u; ++i)
            {
                Console.WriteLine("i:{0,2} | {1,5} | {2,5}", i, fac(i, Num.One), fac_gt(i, Num.One));
            }
            */
            Console.ReadLine();
        }

        private static void CompTest()
        {
            Fun1 fac_h = _ => 1u;
            Fun3 fac_g = (n, _, acc) => (n + 1) * acc;
            Fun2 fac_f = prim(fac_h, fac_g);
            Fun1 fac = x => fac_f(x, 0);

            Fun1 sum_h = x => 0u;
            Fun3 sum_g = (n, _, acc) => n + 1 + acc;
            Fun2 sum_f = prim(sum_h, sum_g);
            Fun1 sum = x => sum_f(x, 0);

            Console.WriteLine(" n | sum |    fac ");
            for (int x = 0; x < 10; x++)
                Console.WriteLine("{0,2} | {1,3} | {2,6}", x, sum(x), fac(x));
        }

        private static string GetStr<T>(T[] a)
        {
            return a == null ? "null" : $"[{a.Aggregate("", agg)}]";
        }

        private static string agg<T>(string s, T n) => s == "" ? n.ToString() : s + ", " + n;

        private static void PrintCodesOfInstructions()
        {
            Num[] instr =
            {
                enc(1, 1, 1, 0),   // 1: X1 <- 0
                enc(5, 2)          // 2: stop
                /*
                enc(4, 1, 1, 3, 2),// 1: if X1=0 goto 3 else goto 2
                enc(1, 2, 2, 1),   // 2: X11 <- 1
                enc(5, 3)          // 3: stop
                */
            };
            for (int i = 0; i < instr.Length; i++)
            {
                Console.WriteLine("Instruction #{0}: {1}", i, instr[i]);
            }
            Console.WriteLine("code of URM with this instructions:");
            var sw = Stopwatch.StartNew();
            var cod = enc(instr);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed); sw.Restart();
            Console.WriteLine("DigitCount:{0}", cod.DigitCount);
            Console.WriteLine("Elapsed: {0}", sw.Elapsed); sw.Restart();
            //Console.WriteLine("Code={0}", cod);
            Console.WriteLine("Decode={0}", GetStr(Coder.Decode(cod)));
            Console.WriteLine("Elapsed: {0}", sw.Elapsed); sw.Restart();
        }

        private static void TestPowerOfBigInteger()
        {
            const int pow = int.MaxValue >> 10;
            var sw = new Stopwatch();
            sw.Start();
            var tmp = Num.Pow(2, pow);
            Console.WriteLine("Calc time:{0}", sw.Elapsed);
            sw.Restart();
            Console.WriteLine("2^{0} contains {1} digits", pow, tmp.DigitCount);
            Console.WriteLine("Calc time:{0}", sw.Elapsed);
            sw.Restart();
            var T1 = tmp.ToString();
            Console.WriteLine("ToString()  :: {0}", sw.Elapsed);
            sw.Restart();
            var T2 = tmp.ToStringF();
            Console.WriteLine("ToStringF() :: {0}", sw.Elapsed);
            Console.WriteLine("T1:<{0}>", T1);
            Console.WriteLine("T2:<{0}>", T2);
            Console.ReadLine();
        }

        static string ArgString(int count, string format = "num arg{0}")
        {
            var sb = new StringBuilder().AppendFormat(format, 1);
            for (int i = 2; i <= count; i++)
                sb.Append(", ").AppendFormat(format, i);
            return sb.ToString();
        }

        static void CreateCode(int count, int start = 1, string pattern = "")
        {
            for (int i = start; i < start + count; i++)
            {
                Console.WriteLine(pattern, i);
            }
        }

        static void CreateCode(string format = "public static num Get{0}Out{1}({2}) => arg{1};", string arg = "num arg{{0}}")
        {
            for (int i = 1; i < 9; i++)
                for (int j = 1; j < 9; j++)
                {
                    var args = ArgString(i, string.Format(arg, i, j));
                    Console.WriteLine(format, i, j, args);
                }
        }
    }
#pragma warning restore IDE0039 // Использовать локальную функцию
#pragma warning restore IDE0051 // Удалите неиспользуемые закрытые члены
#pragma warning restore IDE0060 // Удалите неиспользуемый параметр
#pragma warning restore IDE1006 // Стили именования
}