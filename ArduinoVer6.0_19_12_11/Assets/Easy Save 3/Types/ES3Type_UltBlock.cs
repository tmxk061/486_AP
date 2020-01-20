using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("selectnum", "selectnum2", "selectSocket", "selectSocket2", "selectRun")]
	public class ES3Type_UltBlock : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_UltBlock() : base(typeof(UltBlock))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UltBlock)obj;
			
			writer.WriteProperty("selectnum", instance.selectnum, ES3Type_int.Instance);
			writer.WriteProperty("selectnum2", instance.selectnum2, ES3Type_int.Instance);
			writer.WritePropertyByRef("selectSocket", instance.selectSocket);
			writer.WritePropertyByRef("selectSocket2", instance.selectSocket2);
			writer.WriteProperty("selectRun", instance.selectRun, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UltBlock)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "selectnum":
						instance.selectnum = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "selectnum2":
						instance.selectnum2 = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "selectSocket":
						instance.selectSocket = reader.Read<Socket>();
						break;
					case "selectSocket2":
						instance.selectSocket2 = reader.Read<Socket>();
						break;
					case "selectRun":
						instance.selectRun = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_UltBlockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_UltBlockArray() : base(typeof(UltBlock[]), ES3Type_UltBlock.Instance)
		{
			Instance = this;
		}
	}
}