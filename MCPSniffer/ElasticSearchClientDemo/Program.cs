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

			client.DeleteIndex(ElasticSeachClient.DefaultIndex);

			client.CreateIndex(ElasticSeachClient.DefaultIndex);

			Console.WriteLine($"Clean up the ES Index: {ElasticSeachClient.DefaultIndex}");


			//client.SaveMCPFileInfo(
			//	new MCPFileInfo()
			//	{
			//		Id = 1,
			//		Name = "Test File.txt",
			//		Content = "File Content",
			//		LastModifyTime = DateTime.Now
			//	}
			//);

			//var result = client.SearchMCPFileInfo("Test");

			Console.ReadLine();
		}
	}
}
