using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("selectnum", "selectSocket", "UpConncet", "DownConnect", "value")]
	public class ES3Type_ServoBlock : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_ServoBlock() : base(typeof(ServoBlock))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ServoBlock)obj;
			
			writer.WriteProperty("selectnum", instance.selectnum, ES3Type_int.Instance);
			writer.WritePropertyByRef("selectSocket", instance.selectSocket);
			writer.WriteProperty("UpConncet", instance.UpConncet, ES3Type_bool.Instance);
			writer.WriteProperty("DownConnect", instance.DownConnect, ES3Type_bool.Instance);
			writer.WriteProperty("value", instance.value, ES3Type_float.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ServoBlock)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "selectnum":
						instance.selectnum = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "selectSocket":
						instance.selectSocket = reader.Read<Socket>();
						break;
					case "UpConncet":
						instance.UpConncet = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "DownConnect":
						instance.DownConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "value":
						instance.value = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_ServoBlockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ServoBlockArray() : base(typeof(ServoBlock[]), ES3Type_ServoBlock.Instance)
		{
			Instance = this;
		}
	}
}