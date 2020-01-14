using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3Type_TextMesh : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_TextMesh() : base(typeof(UnityEngine.TextMesh))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.TextMesh)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.TextMesh)obj;
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

	public class ES3Type_TextMeshArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_TextMeshArray() : base(typeof(UnityEngine.TextMesh[]), ES3Type_TextMesh.Instance)
		{
			Instance = this;
		}
	}
}