using UnityEngine;

public class BlockManager : MonoBehaviour
{
    #region 싱글턴

    public static BlockManager instance;

    public void Awake()
    {
        BlockManager.instance = this;
    }

    #endregion 싱글턴

    //다음블록 컴포넌트를 넘겨주는 코드들

    public Block BlockIdentity(Transform trans)
    {
        Block block = null;
        foreach (Transform child in trans)
        {
            block = identityCheck(child.tag, "T", child,null, null);

            if (block != null)
                return block;
        }

        return null;
    }

    public Block BlockIdentity(Collider2D collision)
    {
        Block block = null;
        block = identityCheck(collision.tag, "C", null, collision, null);
        return block;
    }

    public Block BlockIdentity(GameObject UpObj)
    {
        Block block = null;
        block = identityCheck(UpObj.tag, "G", null, null, UpObj);
        return block;
    }


    private Block identityCheck(string str, string type, Transform trans, Collider2D collision, GameObject UpObj)
    {
        Block block = null;

        switch (str)
        {
            case "DigitalWrite":
                if (type == "T")
                {
                    block = trans.GetComponent<DragImage>();
                    return block;
                }
                else if(type == "C")
                {
                    block = collision.GetComponent<DragImage>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<DragImage>();
                    return block;
                }
                break;

            case "ifBlock":
                if (type == "T")
                {
                    block = trans.GetComponent<ifBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<ifBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<ifBlock>();
                    return block;
                }
                break;

            case "AnalogRead":
                if (type == "T")
                {
                    block = trans.GetComponent<AnalogRead>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<AnalogRead>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<AnalogRead>();
                    return block;
                }
                break;

            case "WaitBlock":
                if (type == "T")
                {
                    Debug.Log("웨이트블록");

                    block = trans.GetComponent<WaitBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<WaitBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<WaitBlock>();
                    return block;
                }
                break;

            case "ServoBlock":
                if (type == "T")
                {
                    block = trans.GetComponent<ServoBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<ServoBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<ServoBlock>();
                    return block;
                }
                break;

            case "UltBlock":
                if (type == "T")
                {
                    block = trans.GetComponent<UltBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<UltBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<UltBlock>();
                    return block;
                }
                break;
            case "Block":
                if (type == "T")
                {
                    block = trans.GetComponent<StartBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<StartBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<StartBlock>();
                    return block;
                }
                break;
            case "ifBar":
                if (type == "T")
                {
                    block = trans.GetComponent<ifBar>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<ifBar>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<ifBar>();
                    return block;
                }
                break;
            case "whileBlock":
                if (type == "T")
                {
                    block = trans.GetComponent<whileBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<whileBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<whileBlock>();
                    return block;
                }
                break;
            case "whileBar":
                if (type == "T")
                {
                    block = trans.GetComponent<whileBar>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<whileBar>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<whileBar>();
                    return block;
                }
                break;

            case "WaterMachineBlock":
                if (type == "T")
                {
                    block = trans.GetComponent<WaterMachineBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<WaterMachineBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<WaterMachineBlock>();
                    return block;
                }
                break;

            case "LanternBlock":
                if (type == "T")
                {
                    block = trans.GetComponent<LanternBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<LanternBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<LanternBlock>();
                    return block;
                }
                break;

            case "ToiletBlock":
                if (type == "T")
                {
                    block = trans.GetComponent<ToiletBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<ToiletBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<ToiletBlock>();
                    return block;
                }
                break;

            case "ClockBlock":
                if (type == "T")
                {
                    block = trans.GetComponent<ClockBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<ClockBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<ClockBlock>();
                    return block;
                }
                break;

            case "HeaterBlock":
                if (type == "T")
                {
                    block = trans.GetComponent<HeaterBlock>();
                    return block;
                }
                else if (type == "C")
                {
                    block = collision.GetComponent<HeaterBlock>();
                    return block;
                }
                else if (type == "G")
                {
                    block = UpObj.GetComponent<HeaterBlock>();
                    return block;
                }
                break;
        }

        return null;
    }

    #region 옛날코드
    //public Block NextBlcok(Transform trans)
    //{
    //    Block block = null;
    //    foreach (Transform child in trans)
    //    {
    //        switch (child.tag)
    //        {
    //            case "DigitalWrite":
    //                block = child.GetComponent<DragImage>();
    //                return block;

    //            case "ifBlock":
    //                block = child.GetComponent<ifBlock>();
    //                return block;

    //            case "AnalogRead":
    //                block = child.GetComponent<AnalogRead>();
    //                return block;

    //            case "WaitBlock":
    //                block = child.GetComponent<WaitBlock>();
    //                return block;

    //            case "ServoBlock":
    //                block = child.GetComponent<ServoBlock>();
    //                return block;

    //            case "UltBlock":
    //                block = child.GetComponent<UltBlock>();
    //                return block;
    //        }
    //    }

    //    return null;
    //}

    //public Block ConnectBlock(Collider2D collision)
    //{
    //    Block sample = null;

    //    switch (collision.tag)
    //    {
    //        case "DigitalWrite":
    //            sample = collision.GetComponent<DragImage>();

    //            return sample;

    //        case "AnalogRead":
    //            sample = collision.GetComponent<AnalogRead>();

    //            return sample;

    //        case "ifBlock":
    //            sample = collision.GetComponent<ifBlock>();

    //            return sample;

    //        case "ifBar":
    //            sample = collision.GetComponent<ifBar>();

    //            return sample;

    //        case "Block":
    //            sample = collision.GetComponent<StartBlock>();

    //            return sample;

    //        case "WaitBlock":
    //            sample = collision.GetComponent<WaitBlock>();

    //            return sample;

    //        case "ServoBlock":
    //            sample = collision.GetComponent<ServoBlock>();

    //            return sample;

    //        case "UltBlock":
    //            sample = collision.GetComponent<UltBlock>();

    //            return sample;
    //    }

    //    return null;
    //}

    //public Block CutBlock(GameObject UpObj)
    //{
    //    Block block;
    //    switch (UpObj.tag)
    //    {
    //        case "DigitalWrite":
    //            block = UpObj.GetComponent<DragImage>();

    //            return block;

    //        case "Block":
    //            block = UpObj.GetComponent<StartBlock>();

    //            return block;

    //        case "ifBlock":
    //            block = UpObj.GetComponent<ifBlock>();

    //            return block;

    //        case "ifBar":
    //            block = UpObj.GetComponent<ifBar>();

    //            return block;

    //        case "AnalogRead":
    //            block = UpObj.GetComponent<AnalogRead>();

    //            return block;

    //        case "WaitBlock":
    //            block = UpObj.GetComponent<WaitBlock>();

    //            return block;

    //        case "ServoBlock":
    //            block = UpObj.GetComponent<ServoBlock>();

    //            return block;

    //        case "UltBlock":
    //            block = UpObj.GetComponent<UltBlock>();

    //            return block;
    //    }
    //    return null;
    //}
    #endregion
}