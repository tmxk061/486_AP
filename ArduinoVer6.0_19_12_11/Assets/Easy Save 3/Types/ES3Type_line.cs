using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Manager", "EndPoint", "lr", "distance", "rayHit", "ray", "Connect")]
	public class ES3Type_line : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_line() : base(typeof(line))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (line)obj;
			
			writer.WritePropertyByRef("Manager", instance.Manager);
			writer.WritePropertyByRef("EndPoint", instance.EndPoint);
			writer.WritePrivateFieldByRef("lr", instance);
			writer.WritePrivateField("distance", instance);
			writer.WritePrivateField("rayHit", instance);
			writer.WritePrivateField("ray", instance);
			writer.WriteProperty("Connect", instance.Connect, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (line)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Manager":
						instance.Manager = reader.Read<LineManager>(ES3Type_LineManager.Instance);
						break;
					case "EndPoint":
						instance.EndPoint = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "lr":
					reader.SetPrivateField("lr", reader.Read<UnityEngine.LineRenderer>(), instance);
					break;
					case "distance":
					reader.SetPrivateField("distance", reader.Read<UnityEngine.Vector3>(), instance);
					break;
					case "rayHit":
					reader.SetPrivateField("rayHit", reader.Read<UnityEngine.RaycastHit>(), instance);
					break;
					case "ray":
					reader.SetPrivateField("ray", reader.Read<UnityEngine.Ray>(), instance);
					break;
					case "Connect":
						instance.Connect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_lineArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_lineArray() : base(typeof(line[]), ES3Type_line.Instance)
		{
			Instance = this;
		}
	}
}