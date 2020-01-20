using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3Type_StartBlock : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_StartBlock() : base(typeof(StartBlock))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (StartBlock)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (StartBlock)obj;
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

	public class ES3Type_StartBlockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_StartBlockArray() : base(typeof(StartBlock[]), ES3Type_StartBlock.Instance)
		{
			Instance = this;
		}
	}
}