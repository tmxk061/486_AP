using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("drop", "image")]
	public class ES3Type_HighLow : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_HighLow() : base(typeof(HighLow))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (HighLow)obj;
			
			writer.WritePropertyByRef("drop", instance.drop);
			writer.WritePropertyByRef("image", instance.image);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (HighLow)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "drop":
						instance.drop = reader.Read<UnityEngine.UI.Dropdown>(ES3Type_Dropdown.Instance);
						break;
					case "image":
						instance.image = reader.Read<DragImage>(ES3Type_DragImage.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_HighLowArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_HighLowArray() : base(typeof(HighLow[]), ES3Type_HighLow.Instance)
		{
			Instance = this;
		}
	}
}