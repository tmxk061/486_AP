using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_IgnoreReversedGraphics", "m_BlockingObjects", "m_BlockingMask", "m_Canvas", "ignoreReversedGraphics", "blockingObjects")]
	public class ES3Type_GraphicRaycaster : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_GraphicRaycaster() : base(typeof(UnityEngine.UI.GraphicRaycaster))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.GraphicRaycaster)obj;
			
			writer.WritePrivateField("m_IgnoreReversedGraphics", instance);
			writer.WritePrivateField("m_BlockingObjects", instance);
			writer.WritePrivateField("m_BlockingMask", instance);
			writer.WritePrivateFieldByRef("m_Canvas", instance);
			writer.WriteProperty("ignoreReversedGraphics", instance.ignoreReversedGraphics, ES3Type_bool.Instance);
			writer.WriteProperty("blockingObjects", instance.blockingObjects);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.GraphicRaycaster)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_IgnoreReversedGraphics":
					reader.SetPrivateField("m_IgnoreReversedGraphics", reader.Read<System.Boolean>(), instance);
					break;
					case "m_BlockingObjects":
					reader.SetPrivateField("m_BlockingObjects", reader.Read<UnityEngine.UI.GraphicRaycaster.BlockingObjects>(), instance);
					break;
					case "m_BlockingMask":
					reader.SetPrivateField("m_BlockingMask", reader.Read<UnityEngine.LayerMask>(), instance);
					break;
					case "m_Canvas":
					reader.SetPrivateField("m_Canvas", reader.Read<UnityEngine.Canvas>(), instance);
					break;
					case "ignoreReversedGraphics":
						instance.ignoreReversedGraphics = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "blockingObjects":
						instance.blockingObjects = reader.Read<UnityEngine.UI.GraphicRaycaster.BlockingObjects>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_GraphicRaycasterArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_GraphicRaycasterArray() : base(typeof(UnityEngine.UI.GraphicRaycaster[]), ES3Type_GraphicRaycaster.Instance)
		{
			Instance = this;
		}
	}
}