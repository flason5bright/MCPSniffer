using MCPSniffer.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ElasticSeachSDK
{
	public class ElasticSeachClient : IElasticSeachClient
	{

		public const string ConnectionSting = "http://10.59.235.21:9200/";

		public const string DefaultIndex = "MCPFiles";

		private ElasticClient _client;

		public ElasticSeachClient()
		{
			var settings = new ConnectionSettings(new Uri(ConnectionSting)).DefaultIndex(DefaultIndex);

			_client = new ElasticClient(settings);
		}


		public void SaveMCPFileInfo(IEnumerable<MCPFileInfo> fileInfos)
		{
			foreach (var mcpFile in fileInfos)
			{
				_client.IndexDocument(mcpFile);
			}
		}

		public IEnumerable<MCPFileInfo> SearchMCPFileInfo(string condition)
		{
			List<MCPFileInfo> fileList = new List<MCPFileInfo>();

			var firstTenItemRes = _client.Search<MCPFileInfo>(s => s.From(0).Query(q => q.MultiMatch(m => m.Query(condition))));

			var mcpF = firstTenItemRes.Documents;

			fileList.AddRange(mcpF);

			return fileList;
		}
	}
}
