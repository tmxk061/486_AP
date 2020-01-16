using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccConnect", "GNDConnect", "DigitalConnect", "MouseClick")]
	public class ES3Type_ServoManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_ServoManager() : base(typeof(ServoManager))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ServoManager)obj;
			
			writer.WriteProperty("VccConnect", instance.VccConnect, ES3Type_bool.Instance);
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("DigitalConnect", instance.DigitalConnect, ES3Type_bool.Instance);
			writer.WriteProperty("MouseClick", instance.MouseClick, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ServoManager)obj;
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

	public class ES3Type_ServoManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ServoManagerArray() : base(typeof(ServoManager[]), ES3Type_ServoManager.Instance)
		{
			Instance = this;
		}
	}
}