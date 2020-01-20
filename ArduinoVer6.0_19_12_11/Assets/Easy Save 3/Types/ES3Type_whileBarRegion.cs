using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3Type_whileBarRegion : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_whileBarRegion() : base(typeof(whileBarRegion))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (whileBarRegion)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (whileBarRegion)obj;
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

	public class ES3Type_whileBarRegionArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_whileBarRegionArray() : base(typeof(whileBarRegion[]), ES3Type_whileBarRegion.Instance)
		{
			Instance = this;
		}
	}
}