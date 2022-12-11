using System;
using System.IO;
using System.Text;

namespace Bns.DSN
{
	public class DsnItem
	{
		#region 构造
		public DsnItem(int ClusterID, string DBText)
		{
			this.ClusterID = ClusterID;
			this.DBText = DBText;
		}
		#endregion


		#region 字段
		public int ClusterID;

		public string DBText;
		#endregion



		#region 方法
		public void Write(BinaryWriter writer)
		{
			writer.Write(ClusterID);

			var TextData = new byte[0x200];
			var CurrentData = Encoding.ASCII.GetBytes(this.DBText);
			Buffer.BlockCopy(CurrentData, 0, TextData, 0, CurrentData.Length);

			writer.Write(TextData);
		}
		#endregion
	}
}
