using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("VccConnect", "GNDConnect", "DigitalConnect", "EchoPinConnet", "VccPower", "other", "closeDistance", "ForwardDirection", "RunLaser", "sqrLen", "ultrasonic", "MouseClick", "CustomDis", "CustomWil")]
	public class ES3Type_UltValue : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_UltValue() : base(typeof(UltValue))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UltValue)obj;
			
			writer.WriteProperty("VccConnect", instance.VccConnect, ES3Type_bool.Instance);
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("DigitalConnect", instance.DigitalConnect, ES3Type_bool.Instance);
			writer.WriteProperty("EchoPinConnet", instance.EchoPinConnet, ES3Type_bool.Instance);
			writer.WriteProperty("VccPower", instance.VccPower, ES3Type_int.Instance);
			writer.WritePropertyByRef("other", instance.other);
			writer.WriteProperty("closeDistance", instance.closeDistance, ES3Type_float.Instance);
			writer.WriteProperty("ForwardDirection", instance.ForwardDirection, ES3Type_Vector3.Instance);
			writer.WriteProperty("RunLaser", instance.RunLaser, ES3Type_bool.Instance);
			writer.WriteProperty("sqrLen", instance.sqrLen, ES3Type_float.Instance);
			writer.WriteProperty("ultrasonic", instance.ultrasonic);
			writer.WriteProperty("MouseClick", instance.MouseClick, ES3Type_bool.Instance);
			writer.WriteProperty("CustomDis", instance.CustomDis, ES3Type_float.Instance);
			writer.WriteProperty("CustomWil", instance.CustomWil, ES3Type_float.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UltValue)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "VccConnect":
						instance.VccConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "GNDConnect":
						instance.GNDConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "DigitalConnect":
						instance.DigitalConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "EchoPinConnet":
						instance.EchoPinConnet = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "VccPower":
						instance.VccPower = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "other":
						instance.other = reader.Read<UnityEngine.Transform>(ES3Type_Transform.Instance);
						break;
					case "closeDistance":
						instance.closeDistance = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "ForwardDirection":
						instance.ForwardDirection = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "RunLaser":
						instance.RunLaser = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "sqrLen":
						instance.sqrLen = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "ultrasonic":
						instance.ultrasonic = reader.Read<Ultrasonic>();
						break;
					case "MouseClick":
						instance.MouseClick = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "CustomDis":
						instance.CustomDis = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "CustomWil":
						instance.CustomWil = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_UltValueArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_UltValueArray() : base(typeof(UltValue[]), ES3Type_UltValue.Instance)
		{
			Instance = this;
		}
	}
}