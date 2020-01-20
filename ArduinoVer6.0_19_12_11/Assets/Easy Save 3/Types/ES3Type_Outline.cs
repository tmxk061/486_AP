using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3Type_Outline : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_Outline() : base(typeof(UnityEngine.UI.Outline))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Outline)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Outline)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_OutlineArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_OutlineArray() : base(typeof(UnityEngine.UI.Outline[]), ES3Type_Outline.Instance)
		{
			Instance = this;
		}
	}
}