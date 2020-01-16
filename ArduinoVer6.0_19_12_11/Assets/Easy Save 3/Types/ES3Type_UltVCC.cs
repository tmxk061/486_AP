using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccPower", "Connect", "Electro", "Around", "Line")]
	public class ES3Type_UltVCC : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_UltVCC() : base(typeof(UltVCC))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UltVCC)obj;
			
			writer.WriteProperty("VccPower", instance.VccPower, ES3Type_float.Instance);
			writer.WriteProperty("Connect", instance.Connect, ES3Type_bool.Instance);
			writer.WriteProperty("Electro", instance.Electro, ES3Type_float.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UltVCC)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "VccPower":
						instance.VccPower = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Connect":
						instance.Connect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Electro":
						instance.Electro = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Around":
						instance.Around = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Line":
						instance.Line = reader.Read<LineManager>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_UltVCCArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_UltVCCArray() : base(typeof(UltVCC[]), ES3Type_UltVCC.Instance)
		{
			Instance = this;
		}
	}
}