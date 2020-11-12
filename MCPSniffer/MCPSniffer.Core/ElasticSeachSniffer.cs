using ElasticSeachSDK;
using MCPSniffer.Interface;
using MCPSniffer.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace MCPSniffer.Core
{
	public class ElasticSeachSniffer : ISniffer
	{

		private Dictionary<string, IEnumerable<MCPFileInfo>> SearchResultCache = new Dictionary<string, IEnumerable<MCPFileInfo>>();

		private IElasticSeachClient _elasticSeachClient;


		public ElasticSeachSniffer()
		{
			_elasticSeachClient = new ElasticSeachClient();
		}
		public IEnumerable<MCPFileInfo> GetMCPFileInfosByCondition(string condition)
		{
			var result = GetResultFromCache(condition);

			if (result != null)
				return result;

			//result = new List<MCPFileInfo>(){
			//	new MCPFileInfo() {Id = 1, Name ="Hello Hello", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT.As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT.As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT.As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
			//	new MCPFileInfo() {Id = 2,Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
			//	new MCPFileInfo() {Id = 3, Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
			//	new MCPFileInfo() {Id = 4,Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
			//	new MCPFileInfo() {Id = 5, Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
			//	new MCPFileInfo() {Id = 6, Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
			//	};

			result = _elasticSeachClient.SearchMCPFileInfo(condition);

			SearchResultCache.Add(condition, result);

			return result;
		}

		private IEnumerable<MCPFileInfo> GetResultFromCache(string condition)
		{
			IEnumerable<MCPFileInfo> results = null;
			if (SearchResultCache.TryGetValue(condition, out results))
				return results;

			return null;
		}

		public MCPFileInfo GetResultByIdAndCondition(string condition, int id)
		{
			var results = GetResultFromCache(condition);

			var result = results.FirstOrDefault(it => it.Id == id);
			return result;
		}
	}
}
