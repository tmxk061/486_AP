using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("center", "size", "enabled", "isTrigger", "contactOffset", "sharedMaterial", "material")]
	public class ES3Type_BoxCollider : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_BoxCollider() : base(typeof(UnityEngine.BoxCollider))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.BoxCollider)obj;
			
			writer.WriteProperty("center", instance.center, ES3Type_Vector3.Instance);
			writer.WriteProperty("size", instance.size, ES3Type_Vector3.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
			writer.WriteProperty("isTrigger", instance.isTrigger, ES3Type_bool.Instance);
			writer.WriteProperty("contactOffset", instance.contactOffset, ES3Type_float.Instance);
			writer.WritePropertyByRef("sharedMaterial", instance.sharedMaterial);
			writer.WritePropertyByRef("material", instance.material);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.BoxCollider)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "center":
						instance.center = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "size":
						instance.size = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isTrigger":
						instance.isTrigger = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "contactOffset":
						instance.contactOffset = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "sharedMaterial":
						instance.sharedMaterial = reader.Read<UnityEngine.PhysicMaterial>(ES3Type_PhysicMaterial.Instance);
						break;
					case "material":
						instance.material = reader.Read<UnityEngine.PhysicMaterial>(ES3Type_PhysicMaterial.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_BoxColliderArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_BoxColliderArray() : base(typeof(UnityEngine.BoxCollider[]), ES3Type_BoxCollider.Instance)
		{
			Instance = this;
		}
	}
}