using ElasticSeachSDK;
using MCPSniffer.Model;
using System;

namespace ElasticSearchClientDemo
{
	class Program
	{
		static void Main(string[] args)
		{

			IElasticSeachClient client = new ElasticSeachClient();



			client.SaveMCPFileInfo(
				new MCPFileInfo()
				{
					Id = 1,
					Name = "Test File.txt",
					Content = "File Content",
					LastModifyTime = DateTime.Now
				}
			);

			var result = client.SearchMCPFileInfo("Test");

			Console.WriteLine("Hello World!");
		}
	}
}
