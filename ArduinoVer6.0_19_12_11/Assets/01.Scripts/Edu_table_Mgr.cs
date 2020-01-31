using System.Collections.Generic;
using UnityEngine;

public class Edu_table_Mgr : MonoBehaviour
{
    private void Start()
    {
       
    }

    public static List<string[]> GetMainTable()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("Edu_Main");

        List<string[]> Maindata = new List<string[]>();

        for (int i = 0; i < data.Count; i++)
        {
            string[] da = new string[2];
            da[0] = data[i]["ID"].ToString();
            da[1] = data[i]["NAME"].ToString();

            Maindata.Add(da);
        }

        return Maindata;

    }

    public static int[] GetModulTable(int number)
    {
        number -= 1;
        List<Dictionary<string, object>> data = CSVReader.Read("Edu_Modul");

        int[] Tabledata = new int[10];

        Tabledata[0] = (int)data[number]["ID"];
        Tabledata[1] = (int)data[number]["SLOT_1"];
        Tabledata[2] = (int)data[number]["SLOT_2"];
        Tabledata[3] = (int)data[number]["SLOT_3"];
        Tabledata[4] = (int)data[number]["SLOT_4"];
        Tabledata[5] = (int)data[number]["SLOT_5"];
        Tabledata[6] = (int)data[number]["SLOT_6"];
        Tabledata[7] = (int)data[number]["SLOT_7"];
        Tabledata[8] = (int)data[number]["SLOT_8"];
        Tabledata[9] = (int)data[number]["SLOT_9"];

        return Tabledata;
    }

    public static string[,] GetModulOrder(int number)
    {
        string fileName = "Edu_order_" + number.ToString();
        List<Dictionary<string, object>> data = CSVReader.Read(fileName);
        
        string[,] Tabledata = new string[data.Count, 6];

        for (int i = 0; i < data.Count; i++)
        {
            Tabledata[i,0] = data[i]["NUM"].ToString();
            Tabledata[i, 1] = data[i]["TARGET_1"].ToString();
            Tabledata[i, 2] = data[i]["NUM_1"].ToString();
            Tabledata[i, 3] = data[i]["TARGET_2"].ToString();
            Tabledata[i, 4] = data[i]["NUM_2"].ToString();
            Tabledata[i, 5] = data[i]["TEXT"].ToString();
        }
        return Tabledata;
    }

}