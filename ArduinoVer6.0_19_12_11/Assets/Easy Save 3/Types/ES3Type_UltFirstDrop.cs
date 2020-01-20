using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("dropdown")]
	public class ES3Type_UltFirstDrop : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_UltFirstDrop() : base(typeof(UltFirstDrop))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UltFirstDrop)obj;
			
			writer.WritePrivateFieldByRef("dropdown", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UltFirstDrop)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "dropdown":
					reader.SetPrivateField("dropdown", reader.Read<UnityEngine.UI.Dropdown>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_UltFirstDropArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_UltFirstDropArray() : base(typeof(UltFirstDrop[]), ES3Type_UltFirstDrop.Instance)
		{
			Instance = this;
		}
	}
}