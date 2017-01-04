using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字符二进制转换
{
	class Program
	{
		static void Main(string[] args)
		{
			string data = "1F4EF698586B410C";
			//8个字节
			string key = "jackie11";  
			//string jiema = Change.bianma(data);
			//Console.WriteLine(Change.jiema(jiema));
			string one = Change.EncryptString(data, key);
			Console.WriteLine(one);

			string two = Change.DecryptString(one, key);
			Console.WriteLine(two);
			Console.WriteLine(Change.bianma(one));
			Console.ReadKey();
		}
	}
}
