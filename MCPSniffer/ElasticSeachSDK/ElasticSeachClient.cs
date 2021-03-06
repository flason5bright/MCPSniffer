﻿using MCPSniffer.Model;
using Nest;
using System;
using System.Collections.Generic;

namespace ElasticSeachSDK
{
	public class ElasticSeachClient : IElasticSeachClient
	{

		public const string ConnectionSting = "http://10.59.235.21:9200/";

		public const string DefaultIndex = "mcpfiles";

		private ElasticClient _client;

		public ElasticSeachClient()
		{
			var settings = new ConnectionSettings(new Uri(ConnectionSting)).DefaultIndex(DefaultIndex);

			_client = new ElasticClient(settings);
		}

		public void CreateIndex(string indexName)
		{
			_client.Indices
				.Create(indexName, s => s
				.Settings(se => se
				.NumberOfReplicas(1)
				.NumberOfShards(1)
				.Setting("merge.policy.merge_factor", "10")));
		}

		public void DeleteIndex(string indexName)
		{
			_client.Indices.Delete(indexName);
		}

		public void SaveMCPFileInfo(MCPFileInfo fileInfo)
		{
			var response = _client.IndexDocument(fileInfo);
			//Console.WriteLine(response.DebugInformation);
		}

		public void SaveMCPFileInfos(IEnumerable<MCPFileInfo> fileInfos)
		{
			foreach (var mcpFile in fileInfos)
			{
				var response = _client.IndexDocument(mcpFile);
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
