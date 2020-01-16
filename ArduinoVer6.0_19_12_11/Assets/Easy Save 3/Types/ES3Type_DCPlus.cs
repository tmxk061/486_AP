using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccPower", "Connect", "Electro", "Around", "Line", "POWER", "dcmanager", "l298nout")]
	public class ES3Type_DCPlus : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_DCPlus() : base(typeof(DCPlus))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (DCPlus)obj;
			
			writer.WriteProperty("VccPower", instance.VccPower, ES3Type_int.Instance);
			writer.WriteProperty("Connect", instance.Connect, ES3Type_bool.Instance);
			writer.WriteProperty("Electro", instance.Electro, ES3Type_float.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("Line", instance.Line);
			writer.WriteProperty("POWER", instance.POWER, ES3Type_int.Instance);
			writer.WritePropertyByRef("dcmanager", instance.dcmanager);
			writer.WritePropertyByRef("l298nout", instance.l298nout);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (DCPlus)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "VccPower":
						instance.VccPower = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "Connect":
						instance.Connect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Electro":
						instance.Electro = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Around":
						instance.Around = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Line":
						instance.Line = reader.Read<LineManager>();
						break;
					case "POWER":
						instance.POWER = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "dcmanager":
						instance.dcmanager = reader.Read<DC>();
						break;
					case "l298nout":
						instance.l298nout = reader.Read<L298NOUT4>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_DCPlusArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_DCPlusArray() : base(typeof(DCPlus[]), ES3Type_DCPlus.Instance)
		{
			Instance = this;
		}
	}
}