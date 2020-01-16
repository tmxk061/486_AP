using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Around", "resi", "Line")]
	public class ES3Type_ResiPin : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_ResiPin() : base(typeof(ResiPin))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ResiPin)obj;
			
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("resi", instance.resi);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ResiPin)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Around":
						instance.Around = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "resi":
						instance.resi = reader.Read<Resist>();
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

	public class ES3Type_ResiPinArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ResiPinArray() : base(typeof(ResiPin[]), ES3Type_ResiPin.Instance)
		{
			Instance = this;
		}
	}
}