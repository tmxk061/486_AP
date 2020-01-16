using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Electro", "Manager", "mousepoint", "l298n_gnd", "l298n_vcc12", "l298n_vcc5", "socket", "l298n", "sensor", "pm", "resi", "l298ndigi")]
	public class ES3Type_StartLine : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_StartLine() : base(typeof(StartLine))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (StartLine)obj;
			
			writer.WriteProperty("Electro", instance.Electro, ES3Type_float.Instance);
			writer.WritePropertyByRef("Manager", instance.Manager);
			writer.WritePropertyByRef("mousepoint", instance.mousepoint);
			writer.WritePropertyByRef("l298n_gnd", instance.l298n_gnd);
			writer.WritePropertyByRef("l298n_vcc12", instance.l298n_vcc12);
			writer.WritePropertyByRef("l298n_vcc5", instance.l298n_vcc5);
			writer.WritePropertyByRef("socket", instance.socket);
			writer.WritePropertyByRef("l298n", instance.l298n);
			writer.WritePropertyByRef("sensor", instance.sensor);
			writer.WritePropertyByRef("pm", instance.pm);
			writer.WritePropertyByRef("resi", instance.resi);
			writer.WritePropertyByRef("l298ndigi", instance.l298ndigi);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (StartLine)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Electro":
						instance.Electro = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Manager":
						instance.Manager = reader.Read<LineManager>(ES3Type_LineManager.Instance);
						break;
					case "mousepoint":
						instance.mousepoint = reader.Read<Mousepoint>();
						break;
					case "l298n_gnd":
						instance.l298n_gnd = reader.Read<L298N_GND>(ES3Type_L298N_GND.Instance);
						break;
					case "l298n_vcc12":
						instance.l298n_vcc12 = reader.Read<L298N_VCC12v>(ES3Type_L298N_VCC12v.Instance);
						break;
					case "l298n_vcc5":
						instance.l298n_vcc5 = reader.Read<L298N_VCC5v>(ES3Type_L298N_VCC5v.Instance);
						break;
					case "socket":
						instance.socket = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "l298n":
						instance.l298n = reader.Read<L298NOUT4>(ES3Type_L298NOUT4.Instance);
						break;
					case "sensor":
						instance.sensor = reader.Read<Sensor>();
						break;
					case "pm":
						instance.pm = reader.Read<PlusMinus>();
						break;
					case "resi":
						instance.resi = reader.Read<Resist>(ES3Type_Resist.Instance);
						break;
					case "l298ndigi":
						instance.l298ndigi = reader.Read<DIGITAL_PARENT>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_StartLineArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_StartLineArray() : base(typeof(StartLine[]), ES3Type_StartLine.Instance)
		{
			Instance = this;
		}
	}
}