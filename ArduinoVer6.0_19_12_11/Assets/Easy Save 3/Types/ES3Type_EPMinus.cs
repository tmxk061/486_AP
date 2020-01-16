using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Connect", "Electro", "Around", "circuitManager", "Line")]
	public class ES3Type_EPMinus : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_EPMinus() : base(typeof(EPMinus))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (EPMinus)obj;
			
			writer.WriteProperty("Connect", instance.Connect, ES3Type_bool.Instance);
			writer.WriteProperty("Electro", instance.Electro, ES3Type_float.Instance);
			writer.WritePropertyByRef("Around", instance.Around);
			writer.WritePropertyByRef("circuitManager", instance.circuitManager);
			writer.WritePropertyByRef("Line", instance.Line);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (EPMinus)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Connect":
						instance.Connect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Electro":
						instance.Electro = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Around":
						instance.Around = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "circuitManager":
						instance.circuitManager = reader.Read<CircuitManager>();
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

	public class ES3Type_EPMinusArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_EPMinusArray() : base(typeof(EPMinus[]), ES3Type_EPMinus.Instance)
		{
			Instance = this;
		}
	}
}