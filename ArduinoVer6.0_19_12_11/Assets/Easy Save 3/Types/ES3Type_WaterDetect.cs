using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3Type_WaterDetect : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_WaterDetect() : base(typeof(WaterDetect))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WaterDetect)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WaterDetect)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_WaterDetectArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_WaterDetectArray() : base(typeof(WaterDetect[]), ES3Type_WaterDetect.Instance)
		{
			Instance = this;
		}
	}
}