using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("TimeForWait")]
	public class ES3Type_ifBar : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_ifBar() : base(typeof(ifBar))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ifBar)obj;
			
			writer.WriteProperty("TimeForWait", instance.TimeForWait, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ifBar)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "TimeForWait":
						instance.TimeForWait = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_ifBarArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ifBarArray() : base(typeof(ifBar[]), ES3Type_ifBar.Instance)
		{
			Instance = this;
		}
	}
}