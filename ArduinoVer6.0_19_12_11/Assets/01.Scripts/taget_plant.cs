using UnityEngine;

public class taget_plant : MonoBehaviour
{
    public GameObject roomMgr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mug")
        {
            try
            {
                other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                roomMgr.GetComponent<ChallengeRommMgr>().Lock = false;

            }
            catch
            {

            }
        }
    }
}