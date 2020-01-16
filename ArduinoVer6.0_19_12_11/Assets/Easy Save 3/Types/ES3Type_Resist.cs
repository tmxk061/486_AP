using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Connect1", "Connect2", "VccConnect", "GNDConnect", "Power", "LineParent", "plusgroup")]
	public class ES3Type_Resist : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_Resist() : base(typeof(Resist))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Resist)obj;
			
			writer.WriteProperty("Connect1", instance.Connect1, ES3Type_bool.Instance);
			writer.WriteProperty("Connect2", instance.Connect2, ES3Type_bool.Instance);
			writer.WriteProperty("VccConnect", instance.VccConnect, ES3Type_bool.Instance);
			writer.WriteProperty("GNDConnect", instance.GNDConnect, ES3Type_bool.Instance);
			writer.WriteProperty("Power", instance.Power, ES3Type_int.Instance);
			writer.WritePropertyByRef("LineParent", instance.LineParent);
			writer.WritePropertyByRef("plusgroup", instance.plusgroup);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Resist)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Connect1":
						instance.Connect1 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Connect2":
						instance.Connect2 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "VccConnect":
						instance.VccConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "GNDConnect":
						instance.GNDConnect = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Power":
						instance.Power = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "LineParent":
						instance.LineParent = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "plusgroup":
						instance.plusgroup = reader.Read<PlusGroup>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_ResistArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_ResistArray() : base(typeof(Resist[]), ES3Type_Resist.Instance)
		{
			Instance = this;
		}
	}
}