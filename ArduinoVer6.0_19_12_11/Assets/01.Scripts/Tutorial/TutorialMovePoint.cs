using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovePoint : MonoBehaviour
{
    [SerializeField]
    private TutorialTrigger trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            trigger.OnTutorialTriggerOn();
            transform.parent.gameObject.SetActive(false);
        }
    }
}
