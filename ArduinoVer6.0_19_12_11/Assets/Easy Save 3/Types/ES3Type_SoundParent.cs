using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("GNDConnect", "VCCConnect", "DigitalConnect", "Parent", "MouseClick")]
	public class ES3Type_SoundParent : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_SoundParent() : base(typeof(SoundParent))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (SoundParent)obj;
			
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("VCCConnect", instance.VCCConnect, ES3Type_bool.Instance);
			writer.WriteProperty("DigitalConnect", instance.DigitalConnect, ES3Type_bool.Instance);
			writer.WritePropertyByRef("Parent", instance.Parent);
			writer.WriteProperty("MouseClick", instance.MouseClick, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (SoundParent)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "GNDConnect":
						instance.GNDConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "VCCConnect":
						instance.VCCConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "DigitalConnect":
						instance.DigitalConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Parent":
						instance.Parent = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "MouseClick":
						instance.MouseClick = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_SoundParentArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_SoundParentArray() : base(typeof(SoundParent[]), ES3Type_SoundParent.Instance)
		{
			Instance = this;
		}
	}
}