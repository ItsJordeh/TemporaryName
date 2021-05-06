using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePoint : MonoBehaviour
{
    public bool isFinalObjective;
    public GameObject nextObjectivePoint;
    public Event objectiveEvent;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            if(objectiveEvent != null)
            {
                objectiveEvent.PlayEvent();
            }
            
            if(isFinalObjective)
            {
                Debug.Log("Quest Completed");
                this.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Objective Reached");
                this.gameObject.SetActive(false);
                nextObjectivePoint.SetActive(true);
            }
            
        }
    }
}
