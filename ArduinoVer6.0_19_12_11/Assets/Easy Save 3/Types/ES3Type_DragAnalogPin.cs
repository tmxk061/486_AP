using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("drop", "image")]
	public class ES3Type_DragAnalogPin : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_DragAnalogPin() : base(typeof(DragAnalogPin))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (DragAnalogPin)obj;
			
			writer.WritePropertyByRef("drop", instance.drop);
			writer.WritePropertyByRef("image", instance.image);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (DragAnalogPin)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "drop":
						instance.drop = reader.Read<UnityEngine.UI.Dropdown>(ES3Type_Dropdown.Instance);
						break;
					case "image":
						instance.image = reader.Read<AnalogRead>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_DragAnalogPinArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_DragAnalogPinArray() : base(typeof(DragAnalogPin[]), ES3Type_DragAnalogPin.Instance)
		{
			Instance = this;
		}
	}
}