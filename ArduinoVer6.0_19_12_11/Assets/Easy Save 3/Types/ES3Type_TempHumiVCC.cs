using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Electro", "Around", "Line")]
	public class ES3Type_TempHumiVCC : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_TempHumiVCC() : base(typeof(TempHumiVCC))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TempHumiVCC)obj;
			
			writer.WriteProperty("Electro", instance.Electro, ES3Type_float.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TempHumiVCC)obj;
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

	public class ES3Type_TempHumiVCCArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_TempHumiVCCArray() : base(typeof(TempHumiVCC[]), ES3Type_TempHumiVCC.Instance)
		{
			Instance = this;
		}
	}
}