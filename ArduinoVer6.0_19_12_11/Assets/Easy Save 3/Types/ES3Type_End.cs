using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Firstmake", "Electro", "Manager", "mousepoint", "playerRaycast", "socket", "l298n", "l298n_gnd", "l298n_vcc12", "l298n_vcc5", "pm", "first", "resi", "l298ndigi", "LoadLine", "savepos")]
	public class ES3Type_End : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_End() : base(typeof(End))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (End)obj;
			
			writer.WriteProperty("Firstmake", instance.Firstmake, ES3Type_bool.Instance);
			writer.WriteProperty("Electro", instance.Electro, ES3Type_float.Instance);
			writer.WritePropertyByRef("Manager", instance.Manager);
			writer.WritePropertyByRef("mousepoint", instance.mousepoint);
			writer.WritePropertyByRef("playerRaycast", instance.playerRaycast);
			writer.WritePropertyByRef("socket", instance.socket);
			writer.WritePropertyByRef("l298n", instance.l298n);
			writer.WritePropertyByRef("l298n_gnd", instance.l298n_gnd);
			writer.WritePropertyByRef("l298n_vcc12", instance.l298n_vcc12);
			writer.WritePropertyByRef("l298n_vcc5", instance.l298n_vcc5);
			writer.WritePropertyByRef("pm", instance.pm);
			writer.WriteProperty("first", instance.first, ES3Type_bool.Instance);
			writer.WritePropertyByRef("resi", instance.resi);
			writer.WritePropertyByRef("l298ndigi", instance.l298ndigi);
			writer.WriteProperty("LoadLine", instance.LoadLine, ES3Type_bool.Instance);
			writer.WriteProperty("savepos", instance.savepos, ES3Type_floatArray.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (End)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Firstmake":
						instance.Firstmake = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Electro":
						instance.Electro = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Manager":
						instance.Manager = reader.Read<LineManager>(ES3Type_LineManager.Instance);
						break;
					case "mousepoint":
						instance.mousepoint = reader.Read<Mousepoint>();
						break;
					case "playerRaycast":
						instance.playerRaycast = reader.Read<PlayerRaycast>();
						break;
					case "socket":
						instance.socket = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "l298n":
						instance.l298n = reader.Read<L298NOUT4>();
						break;
					case "l298n_gnd":
						instance.l298n_gnd = reader.Read<L298N_GND>();
						break;
					case "l298n_vcc12":
						instance.l298n_vcc12 = reader.Read<L298N_VCC12v>();
						break;
					case "l298n_vcc5":
						instance.l298n_vcc5 = reader.Read<L298N_VCC5v>();
						break;
					case "pm":
						instance.pm = reader.Read<PlusMinus>();
						break;
					case "first":
						instance.first = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "resi":
						instance.resi = reader.Read<Resist>();
						break;
					case "l298ndigi":
						instance.l298ndigi = reader.Read<DIGITAL_PARENT>();
						break;
					case "LoadLine":
						instance.LoadLine = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "savepos":
						instance.savepos = reader.Read<System.Single[]>(ES3Type_floatArray.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_EndArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_EndArray() : base(typeof(End[]), ES3Type_End.Instance)
		{
			Instance = this;
		}
	}
}