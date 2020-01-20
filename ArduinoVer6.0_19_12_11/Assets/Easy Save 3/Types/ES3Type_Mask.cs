using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_ShowMaskGraphic")]
	public class ES3Type_Mask : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_Mask() : base(typeof(UnityEngine.UI.Mask))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Mask)obj;
			
			writer.WritePrivateField("m_ShowMaskGraphic", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Mask)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_ShowMaskGraphic":
					reader.SetPrivateField("m_ShowMaskGraphic", reader.Read<System.Boolean>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_MaskArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_MaskArray() : base(typeof(UnityEngine.UI.Mask[]), ES3Type_Mask.Instance)
		{
			Instance = this;
		}
	}
}