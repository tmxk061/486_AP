using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("shouldHideMobileInput", "text", "caretBlinkRate", "caretWidth", "textComponent", "placeholder", "caretColor", "customCaretColor", "selectionColor", "onEndEdit", "onValueChanged", "characterLimit", "contentType", "lineType", "inputType", "keyboardType", "characterValidation", "readOnly", "asteriskChar", "caretPositionInternal", "caretSelectPositionInternal", "caretPosition", "selectionAnchorPosition", "selectionFocusPosition", "navigation", "transition", "colors", "spriteState", "targetGraphic", "interactable", "image", "useGUILayout", "runInEditMode", "enabled", "hideFlags")]
	public class ES3Type_InputField : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_InputField() : base(typeof(UnityEngine.UI.InputField))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.InputField)obj;
			
			writer.WriteProperty("shouldHideMobileInput", instance.shouldHideMobileInput, ES3Type_bool.Instance);
			writer.WriteProperty("text", instance.text, ES3Type_string.Instance);
			writer.WriteProperty("caretBlinkRate", instance.caretBlinkRate, ES3Type_float.Instance);
			writer.WriteProperty("caretWidth", instance.caretWidth, ES3Type_int.Instance);
			writer.WritePropertyByRef("textComponent", instance.textComponent);
			writer.WritePropertyByRef("placeholder", instance.placeholder);
			writer.WriteProperty("caretColor", instance.caretColor, ES3Type_Color.Instance);
			writer.WriteProperty("customCaretColor", instance.customCaretColor, ES3Type_bool.Instance);
			writer.WriteProperty("selectionColor", instance.selectionColor, ES3Type_Color.Instance);
			writer.WriteProperty("onEndEdit", instance.onEndEdit);
			writer.WriteProperty("onValueChanged", instance.onValueChanged);
			writer.WriteProperty("characterLimit", instance.characterLimit, ES3Type_int.Instance);
			writer.WriteProperty("contentType", instance.contentType);
			writer.WriteProperty("lineType", instance.lineType);
			writer.WriteProperty("inputType", instance.inputType);
			writer.WriteProperty("keyboardType", instance.keyboardType);
			writer.WriteProperty("characterValidation", instance.characterValidation);
			writer.WriteProperty("readOnly", instance.readOnly, ES3Type_bool.Instance);
			writer.WriteProperty("asteriskChar", instance.asteriskChar, ES3Type_char.Instance);
			writer.WritePrivateProperty("caretPositionInternal", instance);
			writer.WritePrivateProperty("caretSelectPositionInternal", instance);
			writer.WriteProperty("caretPosition", instance.caretPosition, ES3Type_int.Instance);
			writer.WriteProperty("selectionAnchorPosition", instance.selectionAnchorPosition, ES3Type_int.Instance);
			writer.WriteProperty("selectionFocusPosition", instance.selectionFocusPosition, ES3Type_int.Instance);
			writer.WriteProperty("navigation", instance.navigation);
			writer.WriteProperty("transition", instance.transition, ES3Type_enum.Instance);
			writer.WriteProperty("colors", instance.colors);
			writer.WriteProperty("spriteState", instance.spriteState);
			writer.WritePropertyByRef("targetGraphic", instance.targetGraphic);
			writer.WriteProperty("interactable", instance.interactable, ES3Type_bool.Instance);
			writer.WritePropertyByRef("image", instance.image);
			writer.WriteProperty("useGUILayout", instance.useGUILayout, ES3Type_bool.Instance);
			writer.WriteProperty("runInEditMode", instance.runInEditMode, ES3Type_bool.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("hideFlags", instance.hideFlags, ES3Type_enum.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.InputField)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "shouldHideMobileInput":
						instance.shouldHideMobileInput = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "text":
						instance.text = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "caretBlinkRate":
						instance.caretBlinkRate = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "caretWidth":
						instance.caretWidth = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "textComponent":
						instance.textComponent = reader.Read<UnityEngine.UI.Text>(ES3Type_Text.Instance);
						break;
					case "placeholder":
						instance.placeholder = reader.Read<UnityEngine.UI.Graphic>();
						break;
					case "caretColor":
						instance.caretColor = reader.Read<UnityEngine.Color>(ES3Type_Color.Instance);
						break;
					case "customCaretColor":
						instance.customCaretColor = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "selectionColor":
						instance.selectionColor = reader.Read<UnityEngine.Color>(ES3Type_Color.Instance);
						break;
					case "onEndEdit":
						instance.onEndEdit = reader.Read<UnityEngine.UI.InputField.SubmitEvent>();
						break;
					case "onValueChanged":
						instance.onValueChanged = reader.Read<UnityEngine.UI.InputField.OnChangeEvent>();
						break;
					case "characterLimit":
						instance.characterLimit = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "contentType":
						instance.contentType = reader.Read<UnityEngine.UI.InputField.ContentType>();
						break;
					case "lineType":
						instance.lineType = reader.Read<UnityEngine.UI.InputField.LineType>();
						break;
					case "inputType":
						instance.inputType = reader.Read<UnityEngine.UI.InputField.InputType>();
						break;
					case "keyboardType":
						instance.keyboardType = reader.Read<UnityEngine.TouchScreenKeyboardType>();
						break;
					case "characterValidation":
						instance.characterValidation = reader.Read<UnityEngine.UI.InputField.CharacterValidation>();
						break;
					case "readOnly":
						instance.readOnly = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "asteriskChar":
						instance.asteriskChar = reader.Read<System.Char>(ES3Type_char.Instance);
						break;
					case "caretPositionInternal":
					reader.SetPrivateProperty("caretPositionInternal", reader.Read<System.Int32>(), instance);
					break;
					case "caretSelectPositionInternal":
					reader.SetPrivateProperty("caretSelectPositionInternal", reader.Read<System.Int32>(), instance);
					break;
					case "caretPosition":
						instance.caretPosition = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "selectionAnchorPosition":
						instance.selectionAnchorPosition = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "selectionFocusPosition":
						instance.selectionFocusPosition = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "navigation":
						instance.navigation = reader.Read<UnityEngine.UI.Navigation>();
						break;
					case "transition":
						instance.transition = reader.Read<UnityEngine.UI.Selectable.Transition>(ES3Type_enum.Instance);
						break;
					case "colors":
						instance.colors = reader.Read<UnityEngine.UI.ColorBlock>();
						break;
					case "spriteState":
						instance.spriteState = reader.Read<UnityEngine.UI.SpriteState>();
						break;
					case "targetGraphic":
						instance.targetGraphic = reader.Read<UnityEngine.UI.Graphic>();
						break;
					case "interactable":
						instance.interactable = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "image":
						instance.image = reader.Read<UnityEngine.UI.Image>(ES3Type_Image.Instance);
						break;
					case "useGUILayout":
						instance.useGUILayout = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "runInEditMode":
						instance.runInEditMode = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "hideFlags":
						instance.hideFlags = reader.Read<UnityEngine.HideFlags>(ES3Type_enum.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_InputFieldArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_InputFieldArray() : base(typeof(UnityEngine.UI.InputField[]), ES3Type_InputField.Instance)
		{
			Instance = this;
		}
	}
}