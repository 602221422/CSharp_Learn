# 记录学习C#的过程

## Lambda 表达式
- 是一个匿名函数，简化匿名委托的使用，减少代码量。
- Lambda的运算符 => ，读作goes to, 运算符左侧为输入参数，右侧为表达式。x=>x*x，表示为 x goes to x times x。 
Lambda表达式能把“一块代码”赋给了一个变量。而“这块代码”，或者说“这个被赋给一个变量的函数”，就是一个Lambda表达式。
<pre><code>
using System;  
namespace Test1  
{  
	delegate int Test(int x);  
	class Program{  
		static void Main(){  
			Test t1=delegate(int x){ return x+1;};  
			Test t2=x=>x+1;  
			Console.WriteLine("{0}",t1(1));  
			Console.WriteLine("{0}",t2(2));  
		}  
	}  
}  
</code></pre>
## delegate 委托
- 实例：调用带返回值的委托（实参引参）
<pre><code>
using System;
namespace test2
{
	delegate int Test(int x); //实参
	delegate void Test2(ref int x);//引用参数
	class Myclass{
		public int Add2(int a){a+=2;return a;}
		public int Add3(int a){a+=3;return a;}
		public int Add4(int a){a+=4;return a;}
	}
	class Myclass2{
		public void Add2(ref int a){a+=2;}
		public void Add3(ref int a){a+=3;}
		public void Add4(ref int a){a+=4;}
	}
	class Program{
		static void Main(){
			Myclass mc=new Myclass();
			Myclass2 mc2 =new Myclass2();
			Test t1=mc.Add2;
			t1 += mc.Add3;
			t1 += mc.Add4;
			Test2 t2=mc2.Add2;
			t2 += mc2.Add3;
			t2 += mc2.Add4;
			int x=5,y=5;
			t1(y);
			t2(ref x);
			Console.WriteLine("t1(y):{0}",t1(y));//调用带返回值的委托，返回最后一个方法的值
			Console.WriteLine("t1:{0}",y);//实参传递不改变参数值
			Console.WriteLine("t2:{0}",x);//引用传递改变原始参数值
		}
	}
	</code></pre>
## 使用泛型的事件
<pre><code>
	namespace test2
{
	public class MyEventArgs: EventArgs{
		public int IterationCount{get;set;}
	}
	class Publisher{
		public event EventHandler<MyEventArgs> CountedDozen; 
		public void DoCount(){
			MyEventArgs args = new MyEventArgs();
			for(int i=1;i<100;i++)
				if(i%12==0 && CountedDozen!=null){
					args.IterationCount=i;
					CountedDozen(this,args);
				}
		}
	}
	class Subscriber{
		public int DozensCount{get;private set;}
		public Subscriber(Publisher publisher){
			DozensCount=0;
			publisher.CountedDozen += PublisherDozensCount;
		}
		void PublisherDozensCount(object source, MyEventArgs e){
			DozensCount++;
			Console.WriteLine("{0}in{1}",e.IterationCount,source.ToString());
		}
	}
	class program{
		static void Main(){
			Publisher publisher=new Publisher();
			Subscriber subscriber=new Subscriber(publisher);
			publisher.DoCount();
			Console.WriteLine("Number of dozens = {0} ",subscriber.DozensCount);
		}
	}
}
</code></pre>
