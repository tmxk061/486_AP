using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("selectnum", "drop")]
	public class ES3Type_ServoSelectPin : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_ServoSelectPin() : base(typeof(ServoSelectPin))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ServoSelectPin)obj;
			
			writer.WriteProperty("selectnum", instance.selectnum, ES3Type_int.Instance);
			writer.WritePrivateFieldByRef("drop", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ServoSelectPin)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "selectnum":
						instance.selectnum = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "drop":
					reader.SetPrivateField("drop", reader.Read<UnityEngine.UI.Dropdown>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_ServoSelectPinArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ServoSelectPinArray() : base(typeof(ServoSelectPin[]), ES3Type_ServoSelectPin.Instance)
		{
			Instance = this;
		}
	}
}