using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Bns.DSN
{
	public class Program
	{
		public static void Main(string[] args)
		{
			XmlDocument xmlDoc = new();
			xmlDoc.Load(Environment.CurrentDirectory + "\\dsn-list.xml");


			Dictionary<DsnType, DsnDat> dsns = new();
			foreach (XmlNode Gamed in xmlDoc.DocumentElement.SelectNodes("./cluster"))
			{
				int ClusterID = int.Parse(Gamed.Attributes["cluster-id"].Value);

				if(!Enum.TryParse(Gamed.Attributes["type"]?.Value, out DsnType DsnType))
					throw new Exception("请定义dsn类型");

				string DsnText = Gamed.Attributes["dsn"]?.Value;
				if (string.IsNullOrWhiteSpace(DsnText)) 
					throw new Exception("dsn信息不能为空");


				if (!dsns.ContainsKey(DsnType))
					dsns.Add(DsnType, new DsnDat());

				dsns[DsnType].Add(new DsnItem(ClusterID, DsnText));
			}

			foreach(var dsn in dsns) dsn.Value.Save(Environment.CurrentDirectory + $"\\infogate_{dsn.Key}db_dsn.dat");
		}
	}
}
