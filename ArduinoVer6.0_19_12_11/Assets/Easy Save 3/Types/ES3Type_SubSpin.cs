using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccConnect", "GNDConnect", "DigitalConnect", "parent", "VccPower", "direction", "speed", "work")]
	public class ES3Type_SubSpin : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_SubSpin() : base(typeof(SubSpin))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (SubSpin)obj;
			
			writer.WriteProperty("VccConnect", instance.VccConnect, ES3Type_bool.Instance);
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("DigitalConnect", instance.DigitalConnect, ES3Type_bool.Instance);
			writer.WritePropertyByRef("parent", instance.parent);
			writer.WriteProperty("VccPower", instance.VccPower, ES3Type_int.Instance);
			writer.WriteProperty("direction", instance.direction, ES3Type_float.Instance);
			writer.WriteProperty("speed", instance.speed, ES3Type_float.Instance);
			writer.WriteProperty("work", instance.work, ES3Type_float.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (SubSpin)obj;
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
					case "parent":
						instance.parent = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "VccPower":
						instance.VccPower = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "direction":
						instance.direction = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "speed":
						instance.speed = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "work":
						instance.work = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_SubSpinArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_SubSpinArray() : base(typeof(SubSpin[]), ES3Type_SubSpin.Instance)
		{
			Instance = this;
		}
	}
}