using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccPower", "Data", "Connect", "Around", "Line")]
	public class ES3Type_UltSig : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_UltSig() : base(typeof(UltSig))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UltSig)obj;
			
			writer.WriteProperty("VccPower", instance.VccPower, ES3Type_float.Instance);
			writer.WriteProperty("Data", instance.Data, ES3Type_float.Instance);
			writer.WriteProperty("Connect", instance.Connect, ES3Type_bool.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UltSig)obj;
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
					case "Connect":
						instance.Connect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
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

	public class ES3Type_UltSigArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_UltSigArray() : base(typeof(UltSig[]), ES3Type_UltSig.Instance)
		{
			Instance = this;
		}
	}
}