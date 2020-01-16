using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3Type_L298NOUT4 : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_L298NOUT4() : base(typeof(L298NOUT4))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (L298NOUT4)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (L298NOUT4)obj;
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

	public class ES3Type_L298NOUT4Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_L298NOUT4Array() : base(typeof(L298NOUT4[]), ES3Type_L298NOUT4.Instance)
		{
			Instance = this;
		}
	}
}