using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("array")]
	public class ES3Type_LineArray : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_LineArray() : base(typeof(LineArray))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (LineArray)obj;
			
			writer.WriteProperty("array", instance.array);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (LineArray)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "array":
						instance.array = reader.Read<System.Collections.Generic.List<UnityEngine.GameObject>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_LineArrayArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_LineArrayArray() : base(typeof(LineArray[]), ES3Type_LineArray.Instance)
		{
			Instance = this;
		}
	}
}