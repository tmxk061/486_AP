using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("CheckRun")]
	public class ES3Type_LightScript : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_LightScript() : base(typeof(LightScript))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (LightScript)obj;
			
			writer.WriteProperty("CheckRun", instance.CheckRun, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (LightScript)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "CheckRun":
						instance.CheckRun = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_LightScriptArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_LightScriptArray() : base(typeof(LightScript[]), ES3Type_LightScript.Instance)
		{
			Instance = this;
		}
	}
}