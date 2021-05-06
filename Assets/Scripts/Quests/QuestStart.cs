using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStart : MonoBehaviour
{
    private bool questStarted;
    public GameObject firstObjective;

    // Update is called once per frame
    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            Debug.Log("Quest Started");
            firstObjective.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
