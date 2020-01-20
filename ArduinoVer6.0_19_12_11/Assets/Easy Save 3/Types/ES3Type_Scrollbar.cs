using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_HandleRect", "m_Direction", "m_Value", "m_Size", "m_NumberOfSteps", "m_OnValueChanged", "m_ContainerRect", "m_Offset", "m_Tracker", "isPointerDownAndNotDragging", "handleRect", "direction", "value", "size", "numberOfSteps", "onValueChanged", "navigation", "transition", "colors", "targetGraphic", "interactable")]
	public class ES3Type_Scrollbar : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_Scrollbar() : base(typeof(UnityEngine.UI.Scrollbar))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Scrollbar)obj;
			
			writer.WritePrivateFieldByRef("m_HandleRect", instance);
			writer.WritePrivateField("m_Direction", instance);
			writer.WritePrivateField("m_Value", instance);
			writer.WritePrivateField("m_Size", instance);
			writer.WritePrivateField("m_NumberOfSteps", instance);
			writer.WritePrivateField("m_OnValueChanged", instance);
			writer.WritePrivateFieldByRef("m_ContainerRect", instance);
			writer.WritePrivateField("m_Offset", instance);
			writer.WritePrivateField("m_Tracker", instance);
			writer.WritePrivateField("isPointerDownAndNotDragging", instance);
			writer.WritePropertyByRef("handleRect", instance.handleRect);
			writer.WriteProperty("direction", instance.direction);
			writer.WriteProperty("value", instance.value, ES3Type_float.Instance);
			writer.WriteProperty("size", instance.size, ES3Type_float.Instance);
			writer.WriteProperty("numberOfSteps", instance.numberOfSteps, ES3Type_int.Instance);
			writer.WriteProperty("onValueChanged", instance.onValueChanged);
			writer.WriteProperty("navigation", instance.navigation);
			writer.WriteProperty("transition", instance.transition);
			writer.WriteProperty("colors", instance.colors);
			writer.WritePropertyByRef("targetGraphic", instance.targetGraphic);
			writer.WriteProperty("interactable", instance.interactable, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Scrollbar)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_HandleRect":
					reader.SetPrivateField("m_HandleRect", reader.Read<UnityEngine.RectTransform>(), instance);
					break;
					case "m_Direction":
					reader.SetPrivateField("m_Direction", reader.Read<UnityEngine.UI.Scrollbar.Direction>(), instance);
					break;
					case "m_Value":
					reader.SetPrivateField("m_Value", reader.Read<System.Single>(), instance);
					break;
					case "m_Size":
					reader.SetPrivateField("m_Size", reader.Read<System.Single>(), instance);
					break;
					case "m_NumberOfSteps":
					reader.SetPrivateField("m_NumberOfSteps", reader.Read<System.Int32>(), instance);
					break;
					case "m_OnValueChanged":
					reader.SetPrivateField("m_OnValueChanged", reader.Read<UnityEngine.UI.Scrollbar.ScrollEvent>(), instance);
					break;
					case "m_ContainerRect":
					reader.SetPrivateField("m_ContainerRect", reader.Read<UnityEngine.RectTransform>(), instance);
					break;
					case "m_Offset":
					reader.SetPrivateField("m_Offset", reader.Read<UnityEngine.Vector2>(), instance);
					break;
					case "m_Tracker":
					reader.SetPrivateField("m_Tracker", reader.Read<UnityEngine.DrivenRectTransformTracker>(), instance);
					break;
					case "isPointerDownAndNotDragging":
					reader.SetPrivateField("isPointerDownAndNotDragging", reader.Read<System.Boolean>(), instance);
					break;
					case "handleRect":
						instance.handleRect = reader.Read<UnityEngine.RectTransform>(ES3Type_RectTransform.Instance);
						break;
					case "direction":
						instance.direction = reader.Read<UnityEngine.UI.Scrollbar.Direction>();
						break;
					case "value":
						instance.value = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "size":
						instance.size = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "numberOfSteps":
						instance.numberOfSteps = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "onValueChanged":
						instance.onValueChanged = reader.Read<UnityEngine.UI.Scrollbar.ScrollEvent>();
						break;
					case "navigation":
						instance.navigation = reader.Read<UnityEngine.UI.Navigation>();
						break;
					case "transition":
						instance.transition = reader.Read<UnityEngine.UI.Selectable.Transition>();
						break;
					case "colors":
						instance.colors = reader.Read<UnityEngine.UI.ColorBlock>();
						break;
					case "targetGraphic":
						instance.targetGraphic = reader.Read<UnityEngine.UI.Graphic>();
						break;
					case "interactable":
						instance.interactable = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_ScrollbarArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ScrollbarArray() : base(typeof(UnityEngine.UI.Scrollbar[]), ES3Type_Scrollbar.Instance)
		{
			Instance = this;
		}
	}
}