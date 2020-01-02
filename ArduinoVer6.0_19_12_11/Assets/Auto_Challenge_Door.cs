using UnityEngine;

public class Auto_Challenge_Door : MonoBehaviour
{
    //public GameObject door;
    private Animator animator;

    public GameObject ChanllengeRoomMgr;
    // bool autodoor;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (ChanllengeRoomMgr.GetComponent<ChallengeRommMgr>().Lock == false)
                animator.SetBool("AutoDoor", true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        animator.SetBool("AutoDoor", false);
    }
}