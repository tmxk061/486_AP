using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccConnect", "GNDConnect", "DigitalConnect", "pinlist")]
	public class ES3Type_PlusGroup : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_PlusGroup() : base(typeof(PlusGroup))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PlusGroup)obj;
			
			writer.WriteProperty("VccConnect", instance.VccConnect, ES3Type_bool.Instance);
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("DigitalConnect", instance.DigitalConnect, ES3Type_bool.Instance);
			writer.WriteProperty("pinlist", instance.pinlist);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PlusGroup)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "VccConnect":
						instance.VccConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "GNDConnect":
						instance.GNDConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "DigitalConnect":
						instance.DigitalConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "pinlist":
						instance.pinlist = reader.Read<System.Collections.Generic.List<BreadBoardPin>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_PlusGroupArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_PlusGroupArray() : base(typeof(PlusGroup[]), ES3Type_PlusGroup.Instance)
		{
			Instance = this;
		}
	}
}