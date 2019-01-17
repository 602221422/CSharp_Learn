using System;
using System.Threading;

namespace ConsoleApp2
{
        public class Async_ED
        {
            public static void Main(string[] args)
            {
                Func<int, int, int> del = Add;
                Console.WriteLine("ID:" + Thread.CurrentThread.ManagedThreadId);
                IAsyncResult iar = del.BeginInvoke(3, 5, null, null);
                Console.WriteLine("ID:" + Thread.CurrentThread.ManagedThreadId);
                int result = del.EndInvoke(iar);//等待Add方法执行完毕，获取返回的结果
                Console.WriteLine(result);
                Console.WriteLine("ID:" + Thread.CurrentThread.ManagedThreadId);
            }
            public static int Add(int x, int y)
            {
                Console.WriteLine("sun......");
                Console.WriteLine("ID:" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
                Console.WriteLine("ID:" + Thread.CurrentThread.ManagedThreadId);
                return x + y;
            }
        }
}
