using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("<isMask>k__BackingField")]
	public class ES3Type_CanvasRenderer : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_CanvasRenderer() : base(typeof(UnityEngine.CanvasRenderer))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.CanvasRenderer)obj;
			
			writer.WritePrivateField("<isMask>k__BackingField", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.CanvasRenderer)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "<isMask>k__BackingField":
					reader.SetPrivateField("<isMask>k__BackingField", reader.Read<System.Boolean>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_CanvasRendererArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_CanvasRendererArray() : base(typeof(UnityEngine.CanvasRenderer[]), ES3Type_CanvasRenderer.Instance)
		{
			Instance = this;
		}
	}
}