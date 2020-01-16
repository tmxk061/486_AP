using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3Type_RotationBread : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_RotationBread() : base(typeof(RotationBread))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (RotationBread)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (RotationBread)obj;
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

	public class ES3Type_RotationBreadArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_RotationBreadArray() : base(typeof(RotationBread[]), ES3Type_RotationBread.Instance)
		{
			Instance = this;
		}
	}
}