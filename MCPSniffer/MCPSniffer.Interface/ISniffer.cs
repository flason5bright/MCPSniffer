using MCPSniffer.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace MCPSniffer.Interface
{
	public interface ISniffer
	{
		public IEnumerable<MCPFileInfo> GetMCPFileInfosByCondition(string condition);
	}
}
