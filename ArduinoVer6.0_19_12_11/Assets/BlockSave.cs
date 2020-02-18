using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSave : MonoBehaviour
{
    public static BlockSave instance;

    StartBlock StartBlock;
    GameObject BlockCodingZone;
    [SerializeField] GameObject[] BlockPrefab;

    // BlockData[i][0] = 이름, Block[i][1~] 값
    // public static string[][] BlockData    
    public static List<List<string>> BlockData = new List<List<string>>();
    public static List<GameObject> LoadBlocks = new List<GameObject>();


    void Awake()
    {
        instance = this;
        StartBlock = GameObject.Find("StartBlock").GetComponent<StartBlock>();
        BlockCodingZone = GameObject.Find("BlockCordingZone");
        BlockData.Clear();
        LoadBlocks.Clear();
    }

    public void ClickSave()
    {
        BlockData.Clear();
        StartBlock.Save();


        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////


        // 경로 받기


        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////


        string path = "C:\\AAA\\aaa" + ".es";

        ES3.Save<List<List<string>>>("aaa", BlockData, path);

        Debug.Log("저장된 정보");
        int i = 0;
        foreach (List<string> list in BlockData)
        {
            int j = 0;
            foreach (string aa in list)
            {
                Debug.Log("BlockData[" + i + "] [" + j + "] = " + aa);

                j++;
            }
            i++;
        }
        BlockData.Clear();
    }

    public void ClickLoad()
    {
        BlockLoad();
    }


    public static void SaveData(Block CurrentBlock)
    {
        // Start
        if (CurrentBlock.tag == "Block")
            return;

        // Input
        //if (CurrentBlock.tag == "DigitalWrite")
        //{
        //    BlockData[SaveNum][0] = "InPutBlock1";
        //    BlockData[SaveNum][1] = CurrentBlock.GetComponentInChildren<Dropdown>().value.ToString();
        //}
        // else if

        if (CurrentBlock.tag == "AnalogRead")
        {
            List<string> temp = new List<string>();
            temp.Add("InPutBlock2");
            temp.Add(CurrentBlock.transform.Find("Dropdown").GetComponent<Dropdown>().value.ToString());
            BlockData.Add(temp);
        }
        else if (CurrentBlock.tag == "UltBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("InPutBlock3");
            temp.Add(CurrentBlock.transform.Find("Dropdown (2)").GetComponent<Dropdown>().value.ToString());
            temp.Add(CurrentBlock.transform.Find("Dropdown (3)").GetComponent<Dropdown>().value.ToString());
            BlockData.Add(temp);
        }
        // OutPut
        else if (CurrentBlock.tag == "DigitalWrite")
        {
            List<string> temp = new List<string>();
            temp.Add("OutPutBlock1");
            temp.Add(CurrentBlock.transform.Find("Dropdown").GetComponent<Dropdown>().value.ToString());
            temp.Add(CurrentBlock.transform.Find("Dropdown (1)").GetComponent<Dropdown>().value.ToString());
            BlockData.Add(temp);
        }
        else if (CurrentBlock.tag == "ServoBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("OutPutBlock2");
            temp.Add(CurrentBlock.transform.Find("Dropdown").GetComponent<Dropdown>().value.ToString());
            temp.Add(CurrentBlock.transform.Find("InputField").GetComponent<InputField>().text);
            BlockData.Add(temp);
        }
        // Condition
        else if (CurrentBlock.tag == "ifBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("ifBlcok");
            temp.Add(CurrentBlock.transform.Find("Dropdown").GetComponent<Dropdown>().value.ToString());
            temp.Add(CurrentBlock.transform.Find("Dropdown (1)").GetComponent<Dropdown>().value.ToString());
            temp.Add(CurrentBlock.transform.Find("InputField").GetComponent<InputField>().text);
            BlockData.Add(temp);
        }
        else if (CurrentBlock.tag == "whileBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("WhileBlock1");
            temp.Add(CurrentBlock.transform.Find("InputField").GetComponent<InputField>().text);
            BlockData.Add(temp);
        }
        else if (CurrentBlock.tag == "ifBar")
        {
            List<string> temp = new List<string>();
            temp.Add("ifBar");
            BlockData.Add(temp);
            //
        }
        else if (CurrentBlock.tag == "whileBar")
        {
            List<string> temp = new List<string>();
            temp.Add("whileBar");
            BlockData.Add(temp);
            // 
        }
        // Control
        else if (CurrentBlock.tag == "WaitBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("ControlBlock1");
            temp.Add(CurrentBlock.transform.Find("InputField").GetComponent<InputField>().text);
            BlockData.Add(temp);
        }
        // Etc
        else if (CurrentBlock.tag == "WaterMachineBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("WaterBlock");
            BlockData.Add(temp);
            //
        }
        else if (CurrentBlock.tag == "LanternBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("LanternBlock");
            temp.Add(CurrentBlock.transform.Find("Dropdown (1)").GetComponent<Dropdown>().value.ToString());
            BlockData.Add(temp);
        }
        else if (CurrentBlock.tag == "ToiletBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("ToiletBlock");
            BlockData.Add(temp);
            //
        }
        else if (CurrentBlock.tag == "ClockBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("ClockBlock");
            BlockData.Add(temp);
            //
        }
        else if (CurrentBlock.tag == "HeaterBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("HeaterBlock");
            BlockData.Add(temp);
            //
        }
        //else if (CurrentBlock.tag == "추가할 블록")
        //{
        //    BlockData[SaveNum][0] = "블록 이름";
        //    BlockData[SaveNum][1~] = 프리팹보면서 가져올 값 찾기
        //}
    }

    void BlockLoad()
    {
        //try
        //{

        // 블록코딩 지우기
        foreach (Transform child in StartBlock.transform)
        {
            if (child.name != "Text")
                Destroy(child.gameObject);  //Destroy가 Update가 끝날때 적용된다는데
                                            //StartCoroutine(Destroy);
                                            //Destroyimmediate();
                                            //child.gameObject.SetActive(false);
        }
        // 블록코딩 지우기
        foreach (Transform child in BlockCodingZone.transform)
        {
            if (child.name == "TrashCan" || child.name == "StartBlock" || child.name == "spawn")
            {

            }
            else
            {
                Destroy(child.gameObject);
            }
        }
        LoadBlocks.Clear();
        BlockData.Clear();



        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////

        // 파일 고르기

        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////

        string path = "C:\\AAA\\aaa" + ".es";
        if (ES3.KeyExists("aaa", path))
        {
            BlockData = ES3.Load<List<List<string>>>("aaa", path);


            Debug.Log("로드한 정보");
            int i = 0;
            foreach (List<string> data in BlockData)
            {
                int j = 0;
                foreach (string ddata in data)
                {
                    Debug.Log("BlockData[" + i + "][" + j + "] = " + ddata);
                    j++;
                }
                i++;
            }
        }
        else
        {
            return;
        }

        // 0부터 블록개수만큼
        for (int i = 0; i < BlockData.Count; i++)
        {
            for (int j = 0; j < BlockPrefab.Length; j++)
            {
                // ifBar와 whileBar는 Bar위의 블록이 부모가 아니고 if while이 부모
                //Debug.Log("BlockData[" + i + "][0] = " + BlockData[i][0]);
                if (BlockData[i][0] == "ifBar" || BlockData[i][0] == "whileBar")
                {
                    //Debug.Log(LoadBlocks.Count);
                    if (LoadBlocks.Count < i+1)
                    {
                        //Debug.Log(BlockData[i][0] + "@@@@@@");

                        int UnderBarCheck = 1;
                        int k = 0;
                        for (k = i - 1; UnderBarCheck > 0; k--)
                        {
                            //Debug.Log("i : " + i + ", k : " + k + ", check : " + UnderBarCheck);
                            if (BlockData[k][0] == "ifBar" || BlockData[k][0] == "whileBar")
                            {
                                UnderBarCheck = UnderBarCheck + 1;
                                //Debug.Log("UnderBarCheck +1 = " + UnderBarCheck);
                            }
                            if (BlockData[k][0] == "ifBlcok" || BlockData[k][0] == "WhileBlock1")
                            {
                                UnderBarCheck = UnderBarCheck - 1;
                                //Debug.Log("UnderBarCheck -1 = " + UnderBarCheck);
                            }
                            //Debug.Log(k);
                        }
                        k++;
                        //Debug.Log("@@@@@ count : " + LoadBlocks.Count +", k : " + k);
                        LoadBlocks.Add(LoadBlocks[k].transform.Find("UnderBar").gameObject);
                        LoadBlocks[i].transform.position = LoadBlocks[i - 1].transform.position + new Vector3(0, -35, 0);
                        LoadBlocks[i].transform.SetParent(LoadBlocks[k].transform);
                        LoadBlocks[i].transform.SetAsLastSibling();
                    }
                }





                // Load한 BlockData의 이름과 프리팹블록 이름 비교
                else if (BlockPrefab[j].name == BlockData[i][0])
                {
                    //Debug.Log("일치");
                    // 해당 블록 생성, 사이즈 조절
                    GameObject obj = new GameObject();
                    obj = Instantiate(BlockPrefab[j]);
                    obj.transform.SetParent(BlockCodingZone.transform);
                    obj.transform.localScale = StartBlock.transform.localScale;

                    // 
                    //Debug.Log("블록데이터 개수 : " + BlockData.Count);
                    //Debug.Log(LoadBlocks.Count + " & " + i);
                    LoadBlocks.Add(obj);
                    //Debug.Log(LoadBlocks.Count + " & " + i);
                    // 블록에 로드한 값들 넣기
                    LoadingBlock(LoadBlocks[i], i);

                    // 모양, 부모자식 관계 잡기
                    if (LoadBlocks.Count > 0)
                    {
                        // 첫번째는 StartBlock의 자식
                        if (i == 0)
                        {
                            LoadBlocks[i].transform.position = StartBlock.transform.position + new Vector3(0, -35, 0);
                            LoadBlocks[i].transform.SetParent(StartBlock.transform);
                            LoadBlocks[i].transform.SetAsFirstSibling();
                        }

                        // 보통블록
                        else
                        {
                            LoadBlocks[i].transform.position = LoadBlocks[i - 1].transform.position + new Vector3(0, -35, 0);
                            LoadBlocks[i].transform.SetParent(LoadBlocks[i - 1].transform);
                            LoadBlocks[i].transform.SetAsFirstSibling();
                        }

                        if (LoadBlocks[i].name == "ifBlcok" || LoadBlocks[i].name == "WhileBlock1")
                        {
                            LoadBlocks[i].transform.Find("UnderBar").position = LoadBlocks[i].transform.position + new Vector3(100, -35, 0);
                        }
                    }
                }

            }
        }
        //}
        //catch
        //{

        //}
    }

    // 불러온값 블록에 넣는 함수
    // void SaveData(Block CurrentBlock) 참고
    void LoadingBlock(GameObject loadingBlock, int i)
    {
        Debug.Log(i + "번째");
        //if (CurrentBlock.tag == "DigitalWrite")   // InputBlock1
        //{
        //    loadingBlock.GetComponentInChildren<Dropdown>().value = int.Parse(BlockData[i][1]);
        //}
        // else if
        if (loadingBlock.tag == "AnalogRead")
        {
            //loadingBlock.GetComponentInChildren<Dropdown>().value = int.Parse(BlockData[i][1]);
            loadingBlock.transform.Find("Dropdown").GetComponent<Dropdown>().value = int.Parse(BlockData[i][1]);
        }
        else if (loadingBlock.tag == "UltBlock")
        {
            loadingBlock.transform.Find("Dropdown (2)").GetComponent<Dropdown>().value = int.Parse(BlockData[i][1]);
            loadingBlock.transform.Find("Dropdown (3)").GetComponent<Dropdown>().value = int.Parse(BlockData[i][2]);
            //Dropdown[] dropdowns = loadingBlock.GetComponentsInChildren<Dropdown>();
            //dropdowns[0].value = int.Parse(BlockData[i][1]);
            //dropdowns[1].value = int.Parse(BlockData[i][2]);
        }
        // OutPut
        else if (loadingBlock.tag == "DigitalWrite")
        {
            loadingBlock.transform.Find("Dropdown").GetComponent<Dropdown>().value = int.Parse(BlockData[i][1]);
            loadingBlock.transform.Find("Dropdown (1)").GetComponent<Dropdown>().value = int.Parse(BlockData[i][2]);
            //Dropdown[] dropdowns = loadingBlock.GetComponentsInChildren<Dropdown>();
            //dropdowns[0].value = int.Parse(BlockData[i][1]);
            //dropdowns[1].value = int.Parse(BlockData[i][2]);
        }
        else if (loadingBlock.tag == "ServoBlock")
        {
            loadingBlock.transform.Find("Dropdown").GetComponent<Dropdown>().value = int.Parse(BlockData[i][1]);
            loadingBlock.transform.Find("InputField").GetComponent<InputField>().text = BlockData[i][2];
            //loadingBlock.GetComponentInChildren<Dropdown>().value = int.Parse(BlockData[i][1]);
            //loadingBlock.GetComponentInChildren<InputField>().text = BlockData[i][2];
        }
        // Condition
        else if (loadingBlock.tag == "ifBlock")
        {
            loadingBlock.transform.Find("Dropdown").GetComponent<Dropdown>().value = int.Parse(BlockData[i][1]);
            loadingBlock.transform.Find("Dropdown (1)").GetComponent<Dropdown>().value = int.Parse(BlockData[i][2]);
            loadingBlock.transform.Find("InputField").GetComponent<InputField>().text = BlockData[i][3];
            //Dropdown[] dropdowns = loadingBlock.GetComponentsInChildren<Dropdown>();
            //dropdowns[0].value = int.Parse(BlockData[i][1]);
            //dropdowns[1].value = int.Parse(BlockData[i][2]);
            //loadingBlock.GetComponentInChildren<InputField>().text = BlockData[i][3];
        }
        else if (loadingBlock.tag == "whileBlock")
        {
            loadingBlock.transform.Find("InputField").GetComponent<InputField>().text = BlockData[i][1];
            //loadingBlock.GetComponentInChildren<InputField>().text = BlockData[i][1];
        }
        else if (loadingBlock.tag == "ifBar")
        {
            // x
        }
        else if (loadingBlock.tag == "whileBar")
        {
            // x
        }
        // Control
        else if (loadingBlock.tag == "WaitBlock")
        {
            loadingBlock.transform.Find("InputField").GetComponent<InputField>().text = BlockData[i][1];
            //loadingBlock.GetComponentInChildren<InputField>().text = BlockData[i][1];
        }
        // Etc
        else if (loadingBlock.tag == "WaterMachineBlock")
        {
            // x
        }
        else if (loadingBlock.tag == "LanternBlock")
        {
            loadingBlock.transform.Find("Dropdown (1)").GetComponent<Dropdown>().value = int.Parse(BlockData[i][1]);
            //loadingBlock.GetComponentInChildren<Dropdown>().value = int.Parse(BlockData[i][1]);
        }
        else if (loadingBlock.tag == "ToiletBlock")
        {
            // x
        }
        else if (loadingBlock.tag == "ClockBlock")
        {
            // x
        }
        else if (loadingBlock.tag == "HeaterBlock")
        {
            // x
        }
        //else if (loadingBlock.tag == "추가할 블록")
        //{
        //    // void SaveData(Block CurrentBlock) 이랑 맞추기
        //}
    }
}
