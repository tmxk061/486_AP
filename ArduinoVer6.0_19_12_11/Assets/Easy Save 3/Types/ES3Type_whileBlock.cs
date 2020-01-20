using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("InputField", "UnderBar", "region")]
	public class ES3Type_whileBlock : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_whileBlock() : base(typeof(whileBlock))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (whileBlock)obj;
			
			writer.WritePrivateFieldByRef("InputField", instance);
			writer.WritePrivateFieldByRef("UnderBar", instance);
			writer.WritePrivateFieldByRef("region", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (whileBlock)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "InputField":
					reader.SetPrivateField("InputField", reader.Read<UnityEngine.UI.InputField>(), instance);
					break;
					case "UnderBar":
					reader.SetPrivateField("UnderBar", reader.Read<whileBar>(), instance);
					break;
					case "region":
					reader.SetPrivateField("region", reader.Read<ifbarRegion>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_whileBlockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_whileBlockArray() : base(typeof(whileBlock[]), ES3Type_whileBlock.Instance)
		{
			Instance = this;
		}
	}
}