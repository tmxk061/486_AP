using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccPower", "Speed", "OUT1", "OUT2", "OUT3", "OUT4", "direction", "parant", "power", "l298connect1", "l298connect2", "RunOn", "First", "MouseClick")]
	public class ES3Type_DC : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_DC() : base(typeof(DC))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (DC)obj;
			
			writer.WriteProperty("VccPower", instance.VccPower, ES3Type_int.Instance);
			writer.WriteProperty("Speed", instance.Speed, ES3Type_int.Instance);
			writer.WriteProperty("OUT1", instance.OUT1, ES3Type_bool.Instance);
			writer.WriteProperty("OUT2", instance.OUT2, ES3Type_bool.Instance);
			writer.WriteProperty("OUT3", instance.OUT3, ES3Type_bool.Instance);
			writer.WriteProperty("OUT4", instance.OUT4, ES3Type_bool.Instance);
			writer.WriteProperty("direction", instance.direction, ES3Type_bool.Instance);
			writer.WritePropertyByRef("parant", instance.parant);
			writer.WriteProperty("power", instance.power, ES3Type_int.Instance);
			writer.WriteProperty("l298connect1", instance.l298connect1, ES3Type_bool.Instance);
			writer.WriteProperty("l298connect2", instance.l298connect2, ES3Type_bool.Instance);
			writer.WriteProperty("RunOn", instance.RunOn, ES3Type_bool.Instance);
			writer.WriteProperty("First", instance.First, ES3Type_bool.Instance);
			writer.WriteProperty("MouseClick", instance.MouseClick, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (DC)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "VccPower":
						instance.VccPower = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "Speed":
						instance.Speed = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "OUT1":
						instance.OUT1 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "OUT2":
						instance.OUT2 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "OUT3":
						instance.OUT3 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "OUT4":
						instance.OUT4 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "direction":
						instance.direction = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "parant":
						instance.parant = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "power":
						instance.power = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "l298connect1":
						instance.l298connect1 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "l298connect2":
						instance.l298connect2 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "RunOn":
						instance.RunOn = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "First":
						instance.First = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "MouseClick":
						instance.MouseClick = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_DCArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_DCArray() : base(typeof(DC[]), ES3Type_DC.Instance)
		{
			Instance = this;
		}
	}
}