using MCPSniffer.Model;
using System.Collections.Generic;

namespace ElasticSeachSDK
{
	public interface IElasticSeachClient
	{
		void SaveMCPFileInfos(IEnumerable<MCPFileInfo> fileInfos);

		void SaveMCPFileInfo(MCPFileInfo fileInfo);

		IEnumerable<MCPFileInfo> SearchMCPFileInfo(string condition);
	}
}
