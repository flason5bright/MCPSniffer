using System;
using System.Diagnostics.Tracing;

namespace MCPFileCollector
{
	class Program
	{
		static void Main(string[] args)
		{
			GetMCPFiles fileCollector = new GetMCPFiles(@"Y:\");

			try
			{
				Console.WriteLine("Start Read files");
				fileCollector.GetAllFromMCP();

				var list = fileCollector.allFilesOnMCP;
			}catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
		}
	}
}
