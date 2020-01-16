using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Electro", "Around", "Line")]
	public class ES3Type_SoundVCC : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_SoundVCC() : base(typeof(SoundVCC))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (SoundVCC)obj;
			
			writer.WriteProperty("Electro", instance.Electro, ES3Type_float.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (SoundVCC)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
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

	public class ES3Type_SoundVCCArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_SoundVCCArray() : base(typeof(SoundVCC[]), ES3Type_SoundVCC.Instance)
		{
			Instance = this;
		}
	}
}