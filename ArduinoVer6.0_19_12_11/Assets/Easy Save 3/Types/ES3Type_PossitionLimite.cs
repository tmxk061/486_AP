using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Desk", "Modules")]
	public class ES3Type_PossitionLimite : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_PossitionLimite() : base(typeof(PossitionLimite))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PossitionLimite)obj;
			
			writer.WritePropertyByRef("Desk", instance.Desk);
			writer.WritePropertyByRef("Modules", instance.Modules);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PossitionLimite)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Desk":
						instance.Desk = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Modules":
						instance.Modules = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_PossitionLimiteArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_PossitionLimiteArray() : base(typeof(PossitionLimite[]), ES3Type_PossitionLimite.Instance)
		{
			Instance = this;
		}
	}
}