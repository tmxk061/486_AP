using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("rotationSpeed", "lerpSpeed")]
	public class ES3Type_SpinModules : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_SpinModules() : base(typeof(SpinModules))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (SpinModules)obj;
			
			writer.WriteProperty("rotationSpeed", instance.rotationSpeed, ES3Type_float.Instance);
			writer.WriteProperty("lerpSpeed", instance.lerpSpeed, ES3Type_float.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (SpinModules)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "rotationSpeed":
						instance.rotationSpeed = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "lerpSpeed":
						instance.lerpSpeed = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_SpinModulesArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_SpinModulesArray() : base(typeof(SpinModules[]), ES3Type_SpinModules.Instance)
		{
			Instance = this;
		}
	}
}