using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccConnect", "GNDConnect", "AnalogConnect", "viewAngle", "viewDistance", "targetMask", "hitLight", "lightObject", "light2", "RunOn", "sensorType", "Value", "Ohm", "CustomOhm")]
	public class ES3Type_IllValue : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_IllValue() : base(typeof(IllValue))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (IllValue)obj;
			
			writer.WriteProperty("VccConnect", instance.VccConnect, ES3Type_bool.Instance);
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("AnalogConnect", instance.AnalogConnect, ES3Type_bool.Instance);
			writer.WritePrivateField("viewAngle", instance);
			writer.WritePrivateField("viewDistance", instance);
			writer.WritePrivateField("targetMask", instance);
			writer.WriteProperty("hitLight", instance.hitLight, ES3Type_bool.Instance);
			writer.WritePropertyByRef("lightObject", instance.lightObject);
			writer.WritePropertyByRef("light2", instance.light2);
			writer.WriteProperty("RunOn", instance.RunOn, ES3Type_bool.Instance);
			writer.WriteProperty("sensorType", instance.sensorType);
			writer.WritePrivateField("Value", instance);
			writer.WritePrivateField("Ohm", instance);
			writer.WriteProperty("CustomOhm", instance.CustomOhm, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (IllValue)obj;
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
					case "viewAngle":
					reader.SetPrivateField("viewAngle", reader.Read<System.Single>(), instance);
					break;
					case "viewDistance":
					reader.SetPrivateField("viewDistance", reader.Read<System.Single>(), instance);
					break;
					case "targetMask":
					reader.SetPrivateField("targetMask", reader.Read<UnityEngine.LayerMask>(), instance);
					break;
					case "hitLight":
						instance.hitLight = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "lightObject":
						instance.lightObject = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "light2":
						instance.light2 = reader.Read<UnityEngine.Light>(ES3Type_Light.Instance);
						break;
					case "RunOn":
						instance.RunOn = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "sensorType":
						instance.sensorType = reader.Read<SensorType>();
						break;
					case "Value":
					reader.SetPrivateField("Value", reader.Read<System.Single>(), instance);
					break;
					case "Ohm":
					reader.SetPrivateField("Ohm", reader.Read<System.Single>(), instance);
					break;
					case "CustomOhm":
						instance.CustomOhm = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_IllValueArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_IllValueArray() : base(typeof(IllValue[]), ES3Type_IllValue.Instance)
		{
			Instance = this;
		}
	}
}