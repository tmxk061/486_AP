using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Around", "Line")]
	public class ES3Type_TempHumiDigital : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_TempHumiDigital() : base(typeof(TempHumiDigital))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TempHumiDigital)obj;
			
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TempHumiDigital)obj;
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

	public class ES3Type_TempHumiDigitalArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_TempHumiDigitalArray() : base(typeof(TempHumiDigital[]), ES3Type_TempHumiDigital.Instance)
		{
			Instance = this;
		}
	}
}