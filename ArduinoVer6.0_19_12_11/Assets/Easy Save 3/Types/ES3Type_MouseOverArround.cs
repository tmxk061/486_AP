using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("MakeLine", "mousepoint", "mousepoint2", "tableMgr", "Parents")]
	public class ES3Type_MouseOverArround : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_MouseOverArround() : base(typeof(MouseOverArround))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (MouseOverArround)obj;
			
			writer.WritePropertyByRef("MakeLine", instance.MakeLine);
			writer.WritePropertyByRef("mousepoint", instance.mousepoint);
			writer.WritePropertyByRef("mousepoint2", instance.mousepoint2);
			writer.WritePropertyByRef("tableMgr", instance.tableMgr);
			writer.WritePropertyByRef("Parents", instance.Parents);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (MouseOverArround)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "MakeLine":
						instance.MakeLine = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "mousepoint":
						instance.mousepoint = reader.Read<Mousepoint>();
						break;
					case "mousepoint2":
						instance.mousepoint2 = reader.Read<Mousepoint>();
						break;
					case "tableMgr":
						instance.tableMgr = reader.Read<CraftTable_Mgr>();
						break;
					case "Parents":
						instance.Parents = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_MouseOverArroundArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_MouseOverArroundArray() : base(typeof(MouseOverArround[]), ES3Type_MouseOverArround.Instance)
		{
			Instance = this;
		}
	}
}