using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3Type_Rigidbody2D : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_Rigidbody2D() : base(typeof(UnityEngine.Rigidbody2D))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.Rigidbody2D)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.Rigidbody2D)obj;
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

	public class ES3Type_Rigidbody2DArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_Rigidbody2DArray() : base(typeof(UnityEngine.Rigidbody2D[]), ES3Type_Rigidbody2D.Instance)
		{
			Instance = this;
		}
	}
}