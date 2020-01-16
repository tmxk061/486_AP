using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccConnect", "GNDConnect", "DigitalConnect", "power", "parant", "AllObject", "Electro", "lux", "MouseClick")]
	public class ES3Type_LEDManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_LEDManager() : base(typeof(LEDManager))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (LEDManager)obj;
			
			writer.WriteProperty("VccConnect", instance.VccConnect, ES3Type_bool.Instance);
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("DigitalConnect", instance.DigitalConnect, ES3Type_bool.Instance);
			writer.WriteProperty("power", instance.power, ES3Type_int.Instance);
			writer.WritePropertyByRef("parant", instance.parant);
			writer.WritePropertyByRef("AllObject", instance.AllObject);
			writer.WriteProperty("Electro", instance.Electro, ES3Type_float.Instance);
			writer.WritePropertyByRef("lux", instance.lux);
			writer.WriteProperty("MouseClick", instance.MouseClick, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (LEDManager)obj;
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
					case "DigitalConnect":
						instance.DigitalConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "power":
						instance.power = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "parant":
						instance.parant = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "AllObject":
						instance.AllObject = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Electro":
						instance.Electro = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "lux":
						instance.lux = reader.Read<LightScript>();
						break;
					case "MouseClick":
						instance.MouseClick = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_LEDManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_LEDManagerArray() : base(typeof(LEDManager[]), ES3Type_LEDManager.Instance)
		{
			Instance = this;
		}
	}
}