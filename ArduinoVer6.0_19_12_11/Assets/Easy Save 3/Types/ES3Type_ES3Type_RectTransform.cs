using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3Type_ES3Type_RectTransform : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_ES3Type_RectTransform() : base(typeof(ES3Types.ES3Type_RectTransform)){ Instance = this; }

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (ES3Types.ES3Type_RectTransform)obj;
			
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (ES3Types.ES3Type_RectTransform)obj;
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

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new ES3Types.ES3Type_RectTransform();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}

	public class ES3Type_ES3Type_RectTransformArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ES3Type_RectTransformArray() : base(typeof(ES3Types.ES3Type_RectTransform[]), ES3Type_ES3Type_RectTransform.Instance)
		{
			Instance = this;
		}
	}
}