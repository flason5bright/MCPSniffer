using MCPSniffer.Model;
using System.Collections.Generic;

namespace ElasticSeachSDK
{
	public interface IElasticSeachClient
	{
		void SaveMCPFileInfo(IEnumerable<MCPFileInfo> fileInfos);

		IEnumerable<MCPFileInfo> SearchMCPFileInfo(string condition);
	}
}
