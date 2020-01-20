using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("WaterMachine", "MachineRun")]
	public class ES3Type_WaterMachineBlock : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_WaterMachineBlock() : base(typeof(WaterMachineBlock))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WaterMachineBlock)obj;
			
			writer.WritePrivateFieldByRef("WaterMachine", instance);
			writer.WritePrivateFieldByRef("MachineRun", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WaterMachineBlock)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "WaterMachine":
					reader.SetPrivateField("WaterMachine", reader.Read<water_machin>(), instance);
					break;
					case "MachineRun":
					reader.SetPrivateField("MachineRun", reader.Read<UnityEngine.UI.Dropdown>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_WaterMachineBlockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_WaterMachineBlockArray() : base(typeof(WaterMachineBlock[]), ES3Type_WaterMachineBlock.Instance)
		{
			Instance = this;
		}
	}
}