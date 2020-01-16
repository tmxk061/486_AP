using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Around", "Line")]
	public class ES3Type_SoundDigital : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_SoundDigital() : base(typeof(SoundDigital))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (SoundDigital)obj;
			
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (SoundDigital)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
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

	public class ES3Type_SoundDigitalArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_SoundDigitalArray() : base(typeof(SoundDigital[]), ES3Type_SoundDigital.Instance)
		{
			Instance = this;
		}
	}
}