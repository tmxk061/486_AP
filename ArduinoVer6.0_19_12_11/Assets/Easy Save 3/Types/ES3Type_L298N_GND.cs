using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Connect", "Around", "Line")]
	public class ES3Type_L298N_GND : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_L298N_GND() : base(typeof(L298N_GND))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (L298N_GND)obj;
			
			writer.WriteProperty("Connect", instance.Connect, ES3Type_bool.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (L298N_GND)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Connect":
						instance.Connect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
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

	public class ES3Type_L298N_GNDArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_L298N_GNDArray() : base(typeof(L298N_GND[]), ES3Type_L298N_GND.Instance)
		{
			Instance = this;
		}
	}
}