using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("outlist", "MouseClick")]
	public class ES3Type_L298N_MANAGER : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_L298N_MANAGER() : base(typeof(L298N_MANAGER))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (L298N_MANAGER)obj;
			
			writer.WriteProperty("outlist", instance.outlist);
			writer.WriteProperty("MouseClick", instance.MouseClick, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (L298N_MANAGER)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "outlist":
						instance.outlist = reader.Read<System.Collections.Generic.List<L298NOUT4>>();
						break;
					case "MouseClick":
						instance.MouseClick = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_L298N_MANAGERArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_L298N_MANAGERArray() : base(typeof(L298N_MANAGER[]), ES3Type_L298N_MANAGER.Instance)
		{
			Instance = this;
		}
	}
}