using MCPSniffer.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace MCPSniffer.Interface
{
	public interface ISniffer
	{
		IEnumerable<MCPFileInfo> GetMCPFileInfosByCondition(string condition);
		MCPFileInfo GetResultByIdAndCondition(string condition, int id);
	}
}
