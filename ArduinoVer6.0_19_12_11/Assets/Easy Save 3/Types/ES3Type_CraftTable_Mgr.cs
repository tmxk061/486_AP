using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("instance", "CreateMode", "useGUILayout", "runInEditMode", "enabled", "hideFlags")]
	public class ES3Type_CraftTable_Mgr : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_CraftTable_Mgr() : base(typeof(CraftTable_Mgr))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (CraftTable_Mgr)obj;
			
			writer.WritePropertyByRef("instance", CraftTable_Mgr.instance);
			writer.WriteProperty("CreateMode", instance.CreateMode, ES3Type_bool.Instance);
			writer.WriteProperty("useGUILayout", instance.useGUILayout, ES3Type_bool.Instance);
			writer.WriteProperty("runInEditMode", instance.runInEditMode, ES3Type_bool.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("hideFlags", instance.hideFlags);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (CraftTable_Mgr)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "instance":
						CraftTable_Mgr.instance = reader.Read<CraftTable_Mgr>();
						break;
					case "CreateMode":
						instance.CreateMode = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "useGUILayout":
						instance.useGUILayout = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "runInEditMode":
						instance.runInEditMode = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "hideFlags":
						instance.hideFlags = reader.Read<UnityEngine.HideFlags>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_CraftTable_MgrArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_CraftTable_MgrArray() : base(typeof(CraftTable_Mgr[]), ES3Type_CraftTable_Mgr.Instance)
		{
			Instance = this;
		}
	}
}