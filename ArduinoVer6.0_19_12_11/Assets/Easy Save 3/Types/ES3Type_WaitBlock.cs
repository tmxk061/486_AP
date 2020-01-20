using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("InputField", "TimeForWait")]
	public class ES3Type_WaitBlock : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_WaitBlock() : base(typeof(WaitBlock))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WaitBlock)obj;
			
			writer.WritePrivateFieldByRef("InputField", instance);
			writer.WriteProperty("TimeForWait", instance.TimeForWait, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WaitBlock)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "InputField":
					reader.SetPrivateField("InputField", reader.Read<UnityEngine.UI.InputField>(), instance);
					break;
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

	public class ES3Type_WaitBlockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_WaitBlockArray() : base(typeof(WaitBlock[]), ES3Type_WaitBlock.Instance)
		{
			Instance = this;
		}
	}
}