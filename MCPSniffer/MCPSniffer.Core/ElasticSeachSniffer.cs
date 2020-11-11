using MCPSniffer.Interface;
using MCPSniffer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCPSniffer.Core
{
	public class ElasticSeachSniffer : ISniffer
	{
		public IEnumerable<MCPFileInfo> GetMCPFileInfosByCondition(string condition)
		{
			var result = new List<MCPFileInfo>(){
				new MCPFileInfo() { Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
				new MCPFileInfo() { Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
				new MCPFileInfo() { Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
				new MCPFileInfo() { Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
				new MCPFileInfo() { Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
				new MCPFileInfo() { Name ="Hello World", Content= "As a DE Runtime user, I want to transform data from DMS Group and Occurs data structures into the supported SQL Server data structure or types in a BDT."},
				};
		}
	}
}
