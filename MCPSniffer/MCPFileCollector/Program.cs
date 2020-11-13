using System;
using System.Diagnostics.Tracing;

namespace MCPFileCollector
{
	class Program
	{
		static void Main(string[] args)
		{
			GetMCPFiles fileCollector = new GetMCPFiles(@"M:\");

			try
			{
				Console.WriteLine("Start collect MCP files");

				fileCollector.GetAllFromMCP();

				Console.WriteLine("Collect all MCP files complete");

			}catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
		}
	}
}
