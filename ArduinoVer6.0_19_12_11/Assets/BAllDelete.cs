using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAllDelete : MonoBehaviour
{
    GameObject[] UltBlcok;
    GameObject[] DigitalWrite;
    GameObject[] ifBlcok;
    GameObject[] WaitBlock;
    GameObject[] ServoBlock;
    GameObject[] WaterMachineBlock;
    GameObject[] AnalogRead;
    GameObject[] WhileBlock;

    public GameObject NewStart;

    public void DeleteBlock()
    { 
        try
        {
            UltBlcok = GameObject.FindGameObjectsWithTag("UltBlock");
            DigitalWrite = GameObject.FindGameObjectsWithTag("DigitalWrite");
            ifBlcok = GameObject.FindGameObjectsWithTag("ifBlock");
            WaitBlock = GameObject.FindGameObjectsWithTag("WaitBlock");
            ServoBlock = GameObject.FindGameObjectsWithTag("ServoBlock");
            WaterMachineBlock = GameObject.FindGameObjectsWithTag("WaterMachineBlock");
            AnalogRead = GameObject.FindGameObjectsWithTag("AnalogRead");
            WhileBlock = GameObject.FindGameObjectsWithTag("whileBlock");
           
            for (int i = 0; i < UltBlcok.Length; i++)
            {
                Destroy(UltBlcok[i]);
            }
           
            for (int i = 0; i < DigitalWrite.Length; i++)
            {
                Destroy(DigitalWrite[i]);
            }
           
            for (int i = 0; i < ifBlcok.Length; i++)
            {
                Destroy(ifBlcok[i]);
            }
           
            for (int i = 0; i < WaitBlock.Length; i++)
            {
                Destroy(WaitBlock[i]);
            }
           
            for (int i = 0; i < ServoBlock.Length; i++)
            {
                Destroy(ServoBlock[i]);
            }
           
            for (int i = 0; i < WaterMachineBlock.Length; i++)
            {
                Destroy(WaterMachineBlock[i]);
            }
           
            for (int i = 0; i < AnalogRead.Length; i++)
            {
                Destroy(AnalogRead[i]);
            }
           
            for (int i = 0; i < WhileBlock.Length; i++)
            {
                Destroy(WhileBlock[i]);
            }     
        }
        catch
        {

        }
    }
}
