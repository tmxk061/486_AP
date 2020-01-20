using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("selectnum", "selectSocket", "canvas", "selectRun", "UpConncet", "DownConnect", "secondCamera")]
	public class ES3Type_DragImage : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_DragImage() : base(typeof(DragImage))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (DragImage)obj;
			
			writer.WriteProperty("selectnum", instance.selectnum, ES3Type_int.Instance);
			writer.WritePropertyByRef("selectSocket", instance.selectSocket);
			writer.WritePropertyByRef("canvas", instance.canvas);
			writer.WriteProperty("selectRun", instance.selectRun, ES3Type_bool.Instance);
			writer.WriteProperty("UpConncet", instance.UpConncet, ES3Type_bool.Instance);
			writer.WriteProperty("DownConnect", instance.DownConnect, ES3Type_bool.Instance);
			writer.WritePropertyByRef("secondCamera", instance.secondCamera);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (DragImage)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "selectnum":
						instance.selectnum = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "selectSocket":
						instance.selectSocket = reader.Read<Socket>();
						break;
					case "canvas":
						instance.canvas = reader.Read<UnityEngine.Canvas>();
						break;
					case "selectRun":
						instance.selectRun = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "UpConncet":
						instance.UpConncet = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "DownConnect":
						instance.DownConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "secondCamera":
						instance.secondCamera = reader.Read<UnityEngine.Camera>(ES3Type_Camera.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_DragImageArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_DragImageArray() : base(typeof(DragImage[]), ES3Type_DragImage.Instance)
		{
			Instance = this;
		}
	}
}