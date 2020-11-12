using System;

namespace MCPSniffer.Model
{
	public class MCPFileInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime LastModifyTime { get; set; }
		public string Size { get; set; }

		public string Directory { get; set; }

		public string Content { get; set; }
	}
}
