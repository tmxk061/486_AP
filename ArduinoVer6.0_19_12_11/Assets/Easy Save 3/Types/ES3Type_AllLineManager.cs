using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("MakeLine")]
	public class ES3Type_AllLineManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_AllLineManager() : base(typeof(AllLineManager))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (AllLineManager)obj;
			
			writer.WritePropertyByRef("MakeLine", instance.MakeLine);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (AllLineManager)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "MakeLine":
						instance.MakeLine = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_AllLineManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_AllLineManagerArray() : base(typeof(AllLineManager[]), ES3Type_AllLineManager.Instance)
		{
			Instance = this;
		}
	}
}