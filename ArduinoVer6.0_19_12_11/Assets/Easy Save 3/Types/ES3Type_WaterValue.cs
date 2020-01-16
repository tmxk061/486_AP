using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccConnect", "GNDConnect", "AnalogConnect", "Waterobject", "RunOn", "MouseClick", "value", "Waterdetect", "WaterLevelText", "WaterLevelText2")]
	public class ES3Type_WaterValue : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_WaterValue() : base(typeof(WaterValue))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WaterValue)obj;
			
			writer.WriteProperty("VccConnect", instance.VccConnect, ES3Type_bool.Instance);
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("AnalogConnect", instance.AnalogConnect, ES3Type_bool.Instance);
			writer.WritePropertyByRef("Waterobject", instance.Waterobject);
			writer.WriteProperty("RunOn", instance.RunOn, ES3Type_bool.Instance);
			writer.WriteProperty("MouseClick", instance.MouseClick, ES3Type_bool.Instance);
			writer.WriteProperty("value", instance.value, ES3Type_int.Instance);
			writer.WriteProperty("Waterdetect", instance.Waterdetect);
			writer.WritePropertyByRef("WaterLevelText", instance.WaterLevelText);
			writer.WritePropertyByRef("WaterLevelText2", instance.WaterLevelText2);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WaterValue)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "VccConnect":
						instance.VccConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "GNDConnect":
						instance.GNDConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "AnalogConnect":
						instance.AnalogConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Waterobject":
						instance.Waterobject = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "RunOn":
						instance.RunOn = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "MouseClick":
						instance.MouseClick = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "value":
						instance.value = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "Waterdetect":
						instance.Waterdetect = reader.Read<WaterDetect[]>();
						break;
					case "WaterLevelText":
						instance.WaterLevelText = reader.Read<UnityEngine.TextMesh>();
						break;
					case "WaterLevelText2":
						instance.WaterLevelText2 = reader.Read<UnityEngine.TextMesh>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_WaterValueArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_WaterValueArray() : base(typeof(WaterValue[]), ES3Type_WaterValue.Instance)
		{
			Instance = this;
		}
	}
}