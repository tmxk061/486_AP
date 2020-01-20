using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("toggleTransition", "graphic", "m_Group", "onValueChanged", "m_IsOn", "isOn", "navigation", "transition", "colors", "targetGraphic", "interactable")]
	public class ES3Type_Toggle : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_Toggle() : base(typeof(UnityEngine.UI.Toggle))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Toggle)obj;
			
			writer.WriteProperty("toggleTransition", instance.toggleTransition);
			writer.WritePropertyByRef("graphic", instance.graphic);
			writer.WritePrivateFieldByRef("m_Group", instance);
			writer.WriteProperty("onValueChanged", instance.onValueChanged);
			writer.WritePrivateField("m_IsOn", instance);
			writer.WriteProperty("isOn", instance.isOn, ES3Type_bool.Instance);
			writer.WriteProperty("navigation", instance.navigation);
			writer.WriteProperty("transition", instance.transition);
			writer.WriteProperty("colors", instance.colors);
			writer.WritePropertyByRef("targetGraphic", instance.targetGraphic);
			writer.WriteProperty("interactable", instance.interactable, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Toggle)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "toggleTransition":
						instance.toggleTransition = reader.Read<UnityEngine.UI.Toggle.ToggleTransition>();
						break;
					case "graphic":
						instance.graphic = reader.Read<UnityEngine.UI.Graphic>();
						break;
					case "m_Group":
					reader.SetPrivateField("m_Group", reader.Read<UnityEngine.UI.ToggleGroup>(), instance);
					break;
					case "onValueChanged":
						instance.onValueChanged = reader.Read<UnityEngine.UI.Toggle.ToggleEvent>();
						break;
					case "m_IsOn":
					reader.SetPrivateField("m_IsOn", reader.Read<System.Boolean>(), instance);
					break;
					case "isOn":
						instance.isOn = reader.Read<System.Boolean>(ES3Type_bool.Instance);
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

	public class ES3Type_ToggleArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ToggleArray() : base(typeof(UnityEngine.UI.Toggle[]), ES3Type_Toggle.Instance)
		{
			Instance = this;
		}
	}
}