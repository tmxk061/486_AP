using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("count")]
	public class ES3Type_ifbarRegion : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_ifbarRegion() : base(typeof(ifbarRegion))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ifbarRegion)obj;
			
			writer.WriteProperty("count", instance.count, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ifbarRegion)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "count":
						instance.count = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_ifbarRegionArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ifbarRegionArray() : base(typeof(ifbarRegion[]), ES3Type_ifbarRegion.Instance)
		{
			Instance = this;
		}
	}
}