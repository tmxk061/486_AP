﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ifbarRegion : MonoBehaviour
{
    #region 변수
    ifBlock ifblock;
    whileBlock whileBlock;

    public int count = 0;
    
    Vector3 Firstlocation;
    Vector3 FirstScale;
   
    List<GameObject> objlist = new List<GameObject>();

    RectTransform thisrect;

    Vector2 Firstpos;
    BoxCollider2D box;
    Vector2 Firstbox;
    #endregion 변수


    private void Awake()
    {
        //if (this.gameObject.GetComponentInParent<ifBlock>() != null)
        //    ifblock = this.gameObject.GetComponentInParent<ifBlock>();
        //else if (this.gameObject.GetComponentInParent<whileBlock>() != null)
        //    whileBlock = this.gameObject.GetComponentInParent<whileBlock>();
        //Debug.Log(ifblock);
        //Debug.Log(whileBlock);

        //Firstlocation = this.transform.localPosition;
       
        //FirstScale = this.gameObject.transform.localScale;

        //thisrect = this.gameObject.GetComponent<RectTransform>();

        //Firstpos = thisrect.sizeDelta;
        //box = this.GetComponent<BoxCollider2D>();
        //Firstbox = box.size;
    }


    public Vector3 GetLocalScale()
    {

        return this.transform.localScale;
    }

    public Vector3 GetLocalPosition()
    {
        return this.transform.localPosition;
    } 

    /*
     * 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "ifBlock" && collision.tag != "whileBlock" && collision.tag != "ifBar" && collision.tag != "Block")
        {
            for (int i = 0; i < objlist.Count; i++)
            {
                if (objlist[i] == collision.gameObject)
                    return;
            }

            count += 1;

            // this.transform.localPosition = Firstlocation - count*new Vector3(0, 1, 0); //위치 변경
            if (count >= 1)
            {
                box.size = new Vector2(Firstbox.x, Firstbox.y + (49 * (count - 1)));// 컬라이더 사이즈 증가/감소
                box.offset = new Vector2(0, 4 + (-24.5f * (count - 1)));
            }
            else if (count == 0)
            {
                box.size = new Vector2(Firstbox.x, 75);// 컬라이더 사이즈 증가/감소
                box.offset = new Vector2(0, 4);
            }

            //thisrect.sizeDelta = new Vector2(this.thisrect.sizeDelta.x, Firstpos.y + count * 300);

            if (count >= 1)
            {
                if (ifblock != null)
                    ifblock.ChangeBar(-(count - 1) * 51);
                else if (whileBlock != null)
                    whileBlock.ChangeBar(-(count - 1) * 51);
            }
            else if(count ==0)
            {
                if (ifblock != null)
                    ifblock.ChangeBar(-(count) * 51);
                else if (whileBlock != null)
                    whileBlock.ChangeBar(-(count) * 51);
            }
            objlist.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "ifBlock" && collision.tag != "whileBlock" && collision.tag != "ifBar" && collision.tag != "Block")
        {
            for (int i = 0; i < objlist.Count; i++)
            {
                if (objlist[i] == collision.gameObject)
                {
                    objlist.Remove(objlist[i]);
                    count -= 1;
                }
            }

            // this.transform.localPosition = Firstlocation - new Vector3(0, 0.3f, 0);
            if (count >= 1)
            {
                box.size = new Vector2(Firstbox.x, Firstbox.y + (49 * (count - 1)));// 컬라이더 사이즈 증가/감소
                box.offset = new Vector2(0, 4 + (-24.5f * (count - 1)));
            }
            else if(count == 0)
            {
                box.size = new Vector2(Firstbox.x, 75);// 컬라이더 사이즈 증가/감소
                box.offset = new Vector2(0, 4);
            }

            // thisrect.sizeDelta = new Vector2(this.thisrect.sizeDelta.x, Firstpos.y + count * 300);

            if (count >= 1)
            {
                if (ifblock != null)
                    ifblock.ChangeBar(-(count - 1) * 51);
                else if (whileBlock != null)
                    whileBlock.ChangeBar(-(count - 1) * 51);
            }
            else if (count == 0)
            {
                if (ifblock != null)
                    ifblock.ChangeBar(-(count) * 51);
                else if (whileBlock != null)
                    whileBlock.ChangeBar(-(count) * 51);
            }
        }
    }
    */

}
