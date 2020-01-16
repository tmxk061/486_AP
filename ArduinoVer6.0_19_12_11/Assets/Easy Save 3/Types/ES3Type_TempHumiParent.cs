using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("GNDConnect", "VCCConnect", "StartRun", "Parent", "temperToggle", "rainscript", "temperature", "temp", "Data", "MouseClick", "tempminval", "tempmaxval", "dataminval", "datamaxval")]
	public class ES3Type_TempHumiParent : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_TempHumiParent() : base(typeof(TempHumiParent))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TempHumiParent)obj;
			
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("VCCConnect", instance.VCCConnect, ES3Type_bool.Instance);
			writer.WriteProperty("StartRun", instance.StartRun, ES3Type_bool.Instance);
			writer.WritePropertyByRef("Parent", instance.Parent);
			writer.WriteProperty("temperToggle", instance.temperToggle);
			writer.WritePropertyByRef("rainscript", instance.rainscript);
			writer.WriteProperty("temperature", instance.temperature, ES3Type_float.Instance);
			writer.WriteProperty("temp", instance.temp, ES3Type_float.Instance);
			writer.WriteProperty("Data", instance.Data, ES3Type_float.Instance);
			writer.WriteProperty("MouseClick", instance.MouseClick, ES3Type_bool.Instance);
			writer.WriteProperty("tempminval", instance.tempminval, ES3Type_int.Instance);
			writer.WriteProperty("tempmaxval", instance.tempmaxval, ES3Type_int.Instance);
			writer.WriteProperty("dataminval", instance.dataminval, ES3Type_int.Instance);
			writer.WriteProperty("datamaxval", instance.datamaxval, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TempHumiParent)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "GNDConnect":
						instance.GNDConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "VCCConnect":
						instance.VCCConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "StartRun":
						instance.StartRun = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Parent":
						instance.Parent = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "temperToggle":
						instance.temperToggle = reader.Read<TemperToggle>();
						break;
					case "rainscript":
						instance.rainscript = reader.Read<DropDownMenu>();
						break;
					case "temperature":
						instance.temperature = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "temp":
						instance.temp = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Data":
						instance.Data = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "MouseClick":
						instance.MouseClick = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "tempminval":
						instance.tempminval = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "tempmaxval":
						instance.tempmaxval = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "dataminval":
						instance.dataminval = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "datamaxval":
						instance.datamaxval = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_TempHumiParentArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_TempHumiParentArray() : base(typeof(TempHumiParent[]), ES3Type_TempHumiParent.Instance)
		{
			Instance = this;
		}
	}
}