using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Async_ED
    {
        public static void Main(string[] args)
        {
            Task<int> ts = AccessTheWebAsync();
            Console.WriteLine("当前线程：" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("waiting");
            ts.Wait();
            Console.WriteLine("当前线程：" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("返回结果" + ts.Result);
        }

        private static async Task<int> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync("http://baidu.com");
            Console.WriteLine("当前线程:" + Thread.CurrentThread.ManagedThreadId);
            DoIndependWork();
            string urlContentx = await getStringTask;
            Console.WriteLine("当前线程:" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("continue....");
            return urlContentx.Length;
        }

        public static void DoIndependWork()
        {
            Console.WriteLine("do......");
        }
    }
}
