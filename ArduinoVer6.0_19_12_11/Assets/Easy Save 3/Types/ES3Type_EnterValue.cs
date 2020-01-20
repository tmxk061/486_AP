using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("text", "ifblock", "val")]
	public class ES3Type_EnterValue : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_EnterValue() : base(typeof(EnterValue))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (EnterValue)obj;
			
			writer.WritePropertyByRef("text", instance.text);
			writer.WritePropertyByRef("ifblock", instance.ifblock);
			writer.WriteProperty("val", instance.val, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (EnterValue)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "text":
						instance.text = reader.Read<UnityEngine.UI.InputField>(ES3Type_InputField.Instance);
						break;
					case "ifblock":
						instance.ifblock = reader.Read<ifBlock>(ES3Type_ifBlock.Instance);
						break;
					case "val":
						instance.val = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_EnterValueArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_EnterValueArray() : base(typeof(EnterValue[]), ES3Type_EnterValue.Instance)
		{
			Instance = this;
		}
	}
}