using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("plusElectric", "minusElectric", "ConnectBattery", "ConnectSuccese", "Connect1", "Connect2", "type", "L298N_OUTCONNECT", "VccConnect", "GNDConnect", "DigitalConnect", "child", "Electro", "parent", "start", "plusGroup", "Power")]
	public class ES3Type_LineManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_LineManager() : base(typeof(LineManager))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (LineManager)obj;
			
			writer.WriteProperty("plusElectric", instance.plusElectric, ES3Type_float.Instance);
			writer.WriteProperty("minusElectric", instance.minusElectric, ES3Type_float.Instance);
			writer.WriteProperty("ConnectBattery", instance.ConnectBattery, ES3Type_bool.Instance);
			writer.WriteProperty("ConnectSuccese", instance.ConnectSuccese, ES3Type_int.Instance);
			writer.WriteProperty("Connect1", instance.Connect1, ES3Type_int.Instance);
			writer.WriteProperty("Connect2", instance.Connect2, ES3Type_int.Instance);
			writer.WriteProperty("type", instance.type);
			writer.WriteProperty("L298N_OUTCONNECT", instance.L298N_OUTCONNECT, ES3Type_bool.Instance);
			writer.WriteProperty("VccConnect", instance.VccConnect, ES3Type_bool.Instance);
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("DigitalConnect", instance.DigitalConnect, ES3Type_bool.Instance);
			writer.WritePropertyByRef("child", instance.child);
			writer.WriteProperty("Electro", instance.Electro, ES3Type_float.Instance);
			writer.WritePropertyByRef("parent", instance.parent);
			writer.WritePropertyByRef("start", instance.start);
			writer.WritePropertyByRef("plusGroup", instance.plusGroup);
			writer.WriteProperty("Power", instance.Power, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (LineManager)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "plusElectric":
						instance.plusElectric = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "minusElectric":
						instance.minusElectric = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "ConnectBattery":
						instance.ConnectBattery = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "ConnectSuccese":
						instance.ConnectSuccese = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "Connect1":
						instance.Connect1 = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "Connect2":
						instance.Connect2 = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "type":
						instance.type = reader.Read<GameManager.SensorType>();
						break;
					case "L298N_OUTCONNECT":
						instance.L298N_OUTCONNECT = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "VccConnect":
						instance.VccConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "GNDConnect":
						instance.GNDConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "DigitalConnect":
						instance.DigitalConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "child":
						instance.child = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Electro":
						instance.Electro = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "parent":
						instance.parent = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "start":
						instance.start = reader.Read<StartLine>();
						break;
					case "plusGroup":
						instance.plusGroup = reader.Read<PlusGroup>();
						break;
					case "Power":
						instance.Power = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_LineManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_LineManagerArray() : base(typeof(LineManager[]), ES3Type_LineManager.Instance)
		{
			Instance = this;
		}
	}
}