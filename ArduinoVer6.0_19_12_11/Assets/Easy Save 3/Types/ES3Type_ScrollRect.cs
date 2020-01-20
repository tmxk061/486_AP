using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("content", "horizontal", "vertical", "movementType", "inertia", "decelerationRate", "scrollSensitivity", "viewport", "horizontalScrollbar", "onValueChanged")]
	public class ES3Type_ScrollRect : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_ScrollRect() : base(typeof(UnityEngine.UI.ScrollRect))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.ScrollRect)obj;
			
			writer.WritePropertyByRef("content", instance.content);
			writer.WriteProperty("horizontal", instance.horizontal, ES3Type_bool.Instance);
			writer.WriteProperty("vertical", instance.vertical, ES3Type_bool.Instance);
			writer.WriteProperty("movementType", instance.movementType);
			writer.WriteProperty("inertia", instance.inertia, ES3Type_bool.Instance);
			writer.WriteProperty("decelerationRate", instance.decelerationRate, ES3Type_float.Instance);
			writer.WriteProperty("scrollSensitivity", instance.scrollSensitivity, ES3Type_float.Instance);
			writer.WritePropertyByRef("viewport", instance.viewport);
			writer.WritePropertyByRef("horizontalScrollbar", instance.horizontalScrollbar);
			writer.WriteProperty("onValueChanged", instance.onValueChanged);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.ScrollRect)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "content":
						instance.content = reader.Read<UnityEngine.RectTransform>(ES3Type_RectTransform.Instance);
						break;
					case "horizontal":
						instance.horizontal = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "vertical":
						instance.vertical = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "movementType":
						instance.movementType = reader.Read<UnityEngine.UI.ScrollRect.MovementType>();
						break;
					case "inertia":
						instance.inertia = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "decelerationRate":
						instance.decelerationRate = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "scrollSensitivity":
						instance.scrollSensitivity = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "viewport":
						instance.viewport = reader.Read<UnityEngine.RectTransform>(ES3Type_RectTransform.Instance);
						break;
					case "horizontalScrollbar":
						instance.horizontalScrollbar = reader.Read<UnityEngine.UI.Scrollbar>(ES3Type_Scrollbar.Instance);
						break;
					case "onValueChanged":
						instance.onValueChanged = reader.Read<UnityEngine.UI.ScrollRect.ScrollRectEvent>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_ScrollRectArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ScrollRectArray() : base(typeof(UnityEngine.UI.ScrollRect[]), ES3Type_ScrollRect.Instance)
		{
			Instance = this;
		}
	}
}