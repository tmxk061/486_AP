using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccPower", "Electro", "Around")]
	public class ES3Type_IllGND : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_IllGND() : base(typeof(IllGND))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (IllGND)obj;
			
			writer.WriteProperty("VccPower", instance.VccPower, ES3Type_int.Instance);
			writer.WriteProperty("Electro", instance.Electro, ES3Type_float.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (IllGND)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "VccPower":
						instance.VccPower = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "Electro":
						instance.Electro = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Around":
						instance.Around = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_IllGNDArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_IllGNDArray() : base(typeof(IllGND[]), ES3Type_IllGND.Instance)
		{
			Instance = this;
		}
	}
}