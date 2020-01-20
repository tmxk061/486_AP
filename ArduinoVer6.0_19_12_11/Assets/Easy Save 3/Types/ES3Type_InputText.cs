using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("text", "enabled")]
	public class ES3Type_InputText : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_InputText() : base(typeof(InputText))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (InputText)obj;
			
			writer.WritePrivateFieldByRef("text", instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (InputText)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "text":
					reader.SetPrivateField("text", reader.Read<UnityEngine.UI.InputField>(), instance);
					break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_InputTextArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_InputTextArray() : base(typeof(InputText[]), ES3Type_InputText.Instance)
		{
			Instance = this;
		}
	}
}