using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("pixelPerfect", "overrideSorting", "additionalShaderChannels")]
	public class ES3Type_Canvas : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_Canvas() : base(typeof(UnityEngine.Canvas))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.Canvas)obj;
			
			writer.WriteProperty("pixelPerfect", instance.pixelPerfect, ES3Type_bool.Instance);
			writer.WriteProperty("overrideSorting", instance.overrideSorting, ES3Type_bool.Instance);
			writer.WriteProperty("additionalShaderChannels", instance.additionalShaderChannels);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.Canvas)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "pixelPerfect":
						instance.pixelPerfect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "overrideSorting":
						instance.overrideSorting = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "additionalShaderChannels":
						instance.additionalShaderChannels = reader.Read<UnityEngine.AdditionalCanvasShaderChannels>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_CanvasArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_CanvasArray() : base(typeof(UnityEngine.Canvas[]), ES3Type_Canvas.Instance)
		{
			Instance = this;
		}
	}
}