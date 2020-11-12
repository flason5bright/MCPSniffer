using ElasticSeachSDK;
using MCPSniffer.Model;
using System;
using System.Collections.Generic;

namespace ElasticSearchClientDemo
{
	class Program
	{
		static void Main(string[] args)
		{

			IElasticSeachClient client = new ElasticSeachClient();



			//client.SaveMCPFileInfo(new List<MCPFileInfo>()
			//{
			//	new MCPFileInfo()
			//	{
			//		Id = 1,
			//		Name = "Test File.txt",
			//		Content = "File Content",
			//		LastModifyTime = DateTime.Now
			//	}
			//});


			var result = client.SearchMCPFileInfo("Test");

			Console.WriteLine("Hello World!");
		}
	}
}
