using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("navigation", "transition", "interactable")]
	public class ES3Type_Dropdown : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_Dropdown() : base(typeof(UnityEngine.UI.Dropdown))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Dropdown)obj;
			
			writer.WriteProperty("navigation", instance.navigation);
			writer.WriteProperty("transition", instance.transition);
			writer.WriteProperty("interactable", instance.interactable, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Dropdown)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "navigation":
						instance.navigation = reader.Read<UnityEngine.UI.Navigation>();
						break;
					case "transition":
						instance.transition = reader.Read<UnityEngine.UI.Selectable.Transition>();
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

	public class ES3Type_DropdownArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_DropdownArray() : base(typeof(UnityEngine.UI.Dropdown[]), ES3Type_Dropdown.Instance)
		{
			Instance = this;
		}
	}
}