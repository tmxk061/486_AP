using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccPower", "Data", "Around", "Line")]
	public class ES3Type_IllOUT : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_IllOUT() : base(typeof(IllOUT))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (IllOUT)obj;
			
			writer.WriteProperty("VccPower", instance.VccPower, ES3Type_float.Instance);
			writer.WriteProperty("Data", instance.Data, ES3Type_float.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (IllOUT)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "VccPower":
						instance.VccPower = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Data":
						instance.Data = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Around":
						instance.Around = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Line":
						instance.Line = reader.Read<LineManager>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_IllOUTArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_IllOUTArray() : base(typeof(IllOUT[]), ES3Type_IllOUT.Instance)
		{
			Instance = this;
		}
	}
}