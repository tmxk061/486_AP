using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("ThirdSel", "FirstSel", "SecondSel", "UnderBar", "barrect", "barlocation", "region", "FirstAnchoredPosition")]
	public class ES3Type_ifBlock : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_ifBlock() : base(typeof(ifBlock))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ifBlock)obj;
			
			writer.WriteProperty("ThirdSel", instance.ThirdSel, ES3Type_int.Instance);
			writer.WriteProperty("FirstSel", instance.FirstSel, ES3Type_int.Instance);
			writer.WriteProperty("SecondSel", instance.SecondSel, ES3Type_int.Instance);
			writer.WritePropertyByRef("UnderBar", instance.UnderBar);
			writer.WritePropertyByRef("barrect", instance.barrect);
			writer.WritePropertyByRef("barlocation", instance.barlocation);
			writer.WritePropertyByRef("region", instance.region);
			writer.WriteProperty("FirstAnchoredPosition", instance.FirstAnchoredPosition, ES3Type_Vector2.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ifBlock)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "ThirdSel":
						instance.ThirdSel = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "FirstSel":
						instance.FirstSel = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "SecondSel":
						instance.SecondSel = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "UnderBar":
						instance.UnderBar = reader.Read<ifBar>();
						break;
					case "barrect":
						instance.barrect = reader.Read<UnityEngine.RectTransform>(ES3Type_RectTransform.Instance);
						break;
					case "barlocation":
						instance.barlocation = reader.Read<UnityEngine.RectTransform>(ES3Type_RectTransform.Instance);
						break;
					case "region":
						instance.region = reader.Read<ifbarRegion>();
						break;
					case "FirstAnchoredPosition":
						instance.FirstAnchoredPosition = reader.Read<UnityEngine.Vector2>(ES3Type_Vector2.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_ifBlockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ifBlockArray() : base(typeof(ifBlock[]), ES3Type_ifBlock.Instance)
		{
			Instance = this;
		}
	}
}