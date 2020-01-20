using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("RepeatText")]
	public class ES3Type_whileBar : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_whileBar() : base(typeof(whileBar))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (whileBar)obj;
			
			writer.WritePrivateFieldByRef("RepeatText", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (whileBar)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "RepeatText":
					reader.SetPrivateField("RepeatText", reader.Read<UnityEngine.UI.Text>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_whileBarArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_whileBarArray() : base(typeof(whileBar[]), ES3Type_whileBar.Instance)
		{
			Instance = this;
		}
	}
}