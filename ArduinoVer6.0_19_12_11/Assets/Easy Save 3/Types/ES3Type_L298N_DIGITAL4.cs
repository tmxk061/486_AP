using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Connect", "Around", "Line")]
	public class ES3Type_L298N_DIGITAL4 : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_L298N_DIGITAL4() : base(typeof(L298N_DIGITAL4))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (L298N_DIGITAL4)obj;
			
			writer.WriteProperty("Connect", instance.Connect, ES3Type_bool.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (L298N_DIGITAL4)obj;
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

	public class ES3Type_L298N_DIGITAL4Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_L298N_DIGITAL4Array() : base(typeof(L298N_DIGITAL4[]), ES3Type_L298N_DIGITAL4.Instance)
		{
			Instance = this;
		}
	}
}