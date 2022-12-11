using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bns.DSN
{
	public class DsnDat
	{
		#region 字段
		public List<DsnItem> DsnItems = new();
		#endregion



		#region 方法
		public void Add(DsnItem item) => this.DsnItems.Add(item);

		/// <summary>
		/// 存储文件
		/// </summary>
		/// <param name="Path"></param>
		public void Save(string Path)
		{
			if (DsnItems.Count == 0) throw new Exception("未定义任何 cluster");

			var writer = new BinaryWriter(new FileStream(Path, FileMode.Create));
			DsnItems.ForEach(item => item.Write(writer));

			writer.Write(0);
		}
		#endregion
	}
}
