using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSave : MonoBehaviour
{
    public static BlockSave instance;

    StartBlock StartBlock;
    [SerializeField] GameObject[] BlockPrefab;

    //public static string[][] BlockData
    // Block[i][0] = 이름, Block[i][1~] 값
    public static List<List<string>> BlockData = new List<List<string>>();
    public static int SaveNum;

    public static List<GameObject> LoadBlocks = new List<GameObject>();

    void Awake()
    {
        instance = this;
        StartBlock = GameObject.Find("StartBlock").GetComponent<StartBlock>();
        BlockData.Clear();
        SaveNum = 0;
        LoadBlocks.Clear();
    }

    public void ClickSave()
    {
        SaveNum = 0;
        StartBlock.Save();


        /////////////////////////////////////////////////////////////////////////

        // 경로,이름
        // ES3 이용
        // BlockSave.BlockData 저장

        // 경로 받기w

        string path = "C:\\AAA\\aaa" + ".es";

        ES3.Save<List<List<string>>>("aaa", BlockData, path);

        int i = 0;
        foreach (List<string> list in BlockData)
        {
            int j = 0;
            foreach (string aa in list)
            {
                Debug.Log("[" + i + "] [" + j + "] = " + aa);

                j++;
            }
            i++;
        }
        BlockData.Clear();

        /////////////////////////////////////////////////////////////////////////

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
        //    BlockData[SaveNum][0] = "InputBlock1";
        //    BlockData[SaveNum][1] = CurrentBlock.GetComponentInChildren<Dropdown>().value.ToString();
        //}
        // else if

        if (CurrentBlock.tag == "AnalogRead")
        {
            List<string> temp = new List<string>();
            temp.Add("InputBlock2");
            temp.Add(CurrentBlock.transform.Find("Dropdown").GetComponent<Dropdown>().value.ToString());
            BlockData.Add(temp);
        }
        else if (CurrentBlock.tag == "UltBlock")
        {
            List<string> temp = new List<string>();
            temp.Add("InputBlock3");
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
            temp.Add("UnderBar");
            BlockData.Add(temp);
            //
        }
        else if (CurrentBlock.tag == "whileBar")
        {
            List<string> temp = new List<string>();
            temp.Add("UnderBar");
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

        SaveNum += 1;
    }

    void NameData(string blockName)
    {
        //BlockData[SaveNum][0] = blockName;
    }



    void BlockLoad()
    {
        // 블록코딩 지우기
        foreach(Transform child in StartBlock.transform)
        {
            if (child.name != "Text")
                Destroy(child.gameObject);  //Destroy가 Update가 끝날때 적용된다는데
                //StartCoroutine(Destroy);
                //Destroyimmediate();
                //child.gameObject.SetActive(false);
        }
        LoadBlocks.Clear();
        BlockData.Clear();



        /////////////////////////////////////////////////////////////////////////

        // 탐색기에서 ES3로 저장한 파일 골라
        // BlockData 로드하기
        string path = "C:\\AAA\\aaa" + ".es";
        if (ES3.KeyExists("aaa", path))
        {
            //ES3.LoadInto<List<List<string>>>("aaa", path, BlockData);
            //List<List<string>> temp = ES3.Load<List<List<string>>>("aaa", path);
            //Debug.Log(temp.Count + "_+_+_+");
            //foreach (List<string> list in temp)
            //{
            //    BlockData.Add(list);
            //}

            Debug.Log(BlockData.Count + "+++++-----");
            BlockData = ES3.Load<List<List<string>>>("aaa", path);

            Debug.Log(BlockData.Count + "_____+++++");
        }
        else
        {


        }

        // 0부터 LoadNum 개수만큼
        for (int i = 0; i < BlockData.Count; i++)
        {
            for (int j = 0; j < BlockPrefab.Length; j++)
            {

                Debug.Log(BlockPrefab[j].name + "Prefab  i:"+i+"  j:"+j);
                Debug.Log(BlockData[i][0].ToString() + "Data  i:" + i + "  j:" + j);

                // Load한 BlockData의 이름과 프리팹블록 이름 비교
                if (BlockPrefab[j].name == BlockData[i][0].ToString())
                {
                    Debug.Log("이름비교 같음");

                    // 일치하는 블록 생성
                    LoadBlocks.Add(Instantiate(BlockPrefab[j]));
                    // 사이즈 조정
                    LoadBlocks[i].transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1));

                    // 불러온 값들 블록에 넣기
                    LoadingBlock(LoadBlocks[i], i);

                    // 모양, 부모자식 관계 잡기
                    // 첫번째는 StartBlock의 자식
                    if (LoadBlocks.Count > 0)
                    {
                        Debug.Log("LoadBlocks.Count > 0");
                        if (i == 0)
                        {
                            LoadBlocks[i].transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1));
                            LoadBlocks[i].transform.position = StartBlock.transform.position + new Vector3(0, -35, 0);
                            LoadBlocks[i].transform.SetParent(StartBlock.transform);
                            LoadBlocks[i].transform.SetAsFirstSibling();
                        }
                        
                        // 보통블록
                        else
                        {
                            LoadBlocks[i].transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1));
                            LoadBlocks[i].transform.position = LoadBlocks[i - 1].transform.position + new Vector3(0, -35, 0);
                            LoadBlocks[i].transform.SetParent(LoadBlocks[i - 1].transform);
                            LoadBlocks[i].transform.SetAsFirstSibling();
                        }
                        
                        // ifBar와 whileBar는 부모자식 관계가 다름
                        // Bar위의 블록이 부모가 아니고 if while이 부모
                        if (BlockData[i][0] == "ifBar" || BlockData[i][0] == "whileBar")
                        {
                            List<string> bar = new List<string>();
                            if (BlockData[i][0] == "ifBar")
                            {
                                GameObject UnderBar = new GameObject();
                                UnderBar.tag = "ifBar";
                                LoadBlocks.Add(UnderBar);
                            }
                            else if (BlockData[i][0] == "whileBar")
                            {
                                GameObject UnderBar = new GameObject();
                                UnderBar.tag = "whileBar";
                                LoadBlocks.Add(UnderBar);
                            }
                            Debug.Log("Bar들어옴");

                            int UnderBarCheck = 1;
                            int k = 0;
                            for (k = i - 1; UnderBarCheck > 0; k--)
                            {
                                if (LoadBlocks[i].tag == "ifBar" || LoadBlocks[i].tag == "whileBar")
                                {
                                    UnderBarCheck++;
                                }
                                if (LoadBlocks[i].tag == "ifBlock" || LoadBlocks[i].tag == "whileBlock")
                                {
                                    UnderBarCheck--;
                                }
                            }
                            if (LoadBlocks[i].tag == "ifBar")
                                LoadBlocks[i] = LoadBlocks[k].GetComponentInChildren<ifBar>().gameObject;
                            else if (LoadBlocks[i].tag == "whileBar")
                                LoadBlocks[i] = LoadBlocks[k].GetComponentInChildren<whileBar>().gameObject;

                            LoadBlocks[i].transform.position = LoadBlocks[i - 1].transform.position + new Vector3(0, -35, 0);
                            //LoadBlocks[i].transform.SetParent(LoadBlocks[k].transform);
                            LoadBlocks[i].transform.SetAsLastSibling();
                        }
                    }
                }
            }
        }
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
        Debug.Log("void LoadingBlock");
        if (loadingBlock.tag == "AnalogRead")
        {
            loadingBlock.GetComponentInChildren<Dropdown>().value = int.Parse(BlockData[i][1]);
        }
        else if (loadingBlock.tag == "UltBlock")
        {
            Dropdown[] dropdowns = loadingBlock.GetComponentsInChildren<Dropdown>();
            dropdowns[0].value = int.Parse(BlockData[i][1]);
            dropdowns[1].value = int.Parse(BlockData[i][2]);
        }
        // OutPut
        else if (loadingBlock.tag == "DigitalWrite")
        {
            Dropdown[] dropdowns = loadingBlock.GetComponentsInChildren<Dropdown>();
            dropdowns[0].value = int.Parse(BlockData[i][1]);
            dropdowns[1].value = int.Parse(BlockData[i][2]);
        }
        else if (loadingBlock.tag == "ServoBlock")
        {
            loadingBlock.GetComponentInChildren<Dropdown>().value = int.Parse(BlockData[i][1]);
            loadingBlock.GetComponentInChildren<InputField>().text = BlockData[i][2];
        }
        // Condition
        else if (loadingBlock.tag == "ifBlock")
        {
            Dropdown[] dropdowns = loadingBlock.GetComponentsInChildren<Dropdown>();
            dropdowns[0].value = int.Parse(BlockData[i][1]);
            dropdowns[1].value = int.Parse(BlockData[i][2]);
            loadingBlock.GetComponentInChildren<InputField>().text = BlockData[i][3];
        }
        else if (loadingBlock.tag == "whileBlock")
        {
            loadingBlock.GetComponentInChildren<InputField>().text = BlockData[i][1];
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
            loadingBlock.GetComponentInChildren<InputField>().text = BlockData[i][1];
        }
        // Etc
        else if (loadingBlock.tag == "WaterMachineBlock")
        {
            // x
        }
        else if (loadingBlock.tag == "LanternBlock")
        {
            loadingBlock.GetComponentInChildren<Dropdown>().value = int.Parse(BlockData[i][1]);
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
