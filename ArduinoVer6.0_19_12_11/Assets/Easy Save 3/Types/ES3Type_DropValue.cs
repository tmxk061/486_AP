using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("drop", "ifblock")]
	public class ES3Type_DropValue : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_DropValue() : base(typeof(DropValue))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (DropValue)obj;
			
			writer.WritePropertyByRef("drop", instance.drop);
			writer.WritePropertyByRef("ifblock", instance.ifblock);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (DropValue)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "drop":
						instance.drop = reader.Read<UnityEngine.UI.Dropdown>(ES3Type_Dropdown.Instance);
						break;
					case "ifblock":
						instance.ifblock = reader.Read<ifBlock>(ES3Type_ifBlock.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_DropValueArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_DropValueArray() : base(typeof(DropValue[]), ES3Type_DropValue.Instance)
		{
			Instance = this;
		}
	}
}