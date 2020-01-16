using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("value", "MouseClick")]
	public class ES3Type_lightSensor : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_lightSensor() : base(typeof(lightSensor))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (lightSensor)obj;
			
			writer.WritePropertyByRef("value", instance.value);
			writer.WriteProperty("MouseClick", instance.MouseClick, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (lightSensor)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "value":
						instance.value = reader.Read<IllValue>();
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

	public class ES3Type_lightSensorArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_lightSensorArray() : base(typeof(lightSensor[]), ES3Type_lightSensor.Instance)
		{
			Instance = this;
		}
	}
}