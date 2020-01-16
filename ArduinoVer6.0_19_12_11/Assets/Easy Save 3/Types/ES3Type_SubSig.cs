using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Connect", "Around", "VccPower", "Line", "sub")]
	public class ES3Type_SubSig : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_SubSig() : base(typeof(SubSig))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (SubSig)obj;
			
			writer.WriteProperty("Connect", instance.Connect, ES3Type_bool.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WriteProperty("VccPower", instance.VccPower, ES3Type_int.Instance);
			writer.WritePropertyByRef("Line", instance.Line);
			writer.WritePropertyByRef("sub", instance.sub);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (SubSig)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Connect":
						instance.Connect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Around":
						instance.Around = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "VccPower":
						instance.VccPower = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "Line":
						instance.Line = reader.Read<LineManager>();
						break;
					case "sub":
						instance.sub = reader.Read<ServoManager>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_SubSigArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_SubSigArray() : base(typeof(SubSig[]), ES3Type_SubSig.Instance)
		{
			Instance = this;
		}
	}
}