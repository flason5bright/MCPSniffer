using MCPSniffer.Model;
using System.Collections.Generic;

namespace ElasticSeachSDK
{
	public interface IElasticSeach
	{
		void SaveMCPFileInfo(IEnumerable<MCPFileInfo> fileInfos);

		IEnumerable<MCPFileInfo> SearchMCPFileInfo(string condition);
	}
}
