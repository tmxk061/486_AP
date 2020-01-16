using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edu_Menu_Mgr : MonoBehaviour
{
    public List<string[]> Main_Data;

    [SerializeField]
    private GameObject Btn; //생성할 버튼

    [SerializeField]
    private Transform parent; //버튼 생성될부모


    // Start is called before the first frame update
    void Start()
    {
        Main_Data = Edu_table_Mgr.GetMainTable();

        for (int i = 0; i < Main_Data.Count; i++)
        {
            GameObject newbtn = Instantiate(Btn);
            newbtn.SetActive(true);
            newbtn.transform.parent = parent;
            newbtn.transform.position = parent.position;
            newbtn.transform.localScale = Btn.transform.localScale;

            newbtn.GetComponent<StudyBtn>().ID = int.Parse(Main_Data[i][0]);
            newbtn.GetComponentInChildren<Text>().text = Main_Data[i][1];
        }

        //Debug.Log("asd"+Main_Data[0][1]);
    }

}
