using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    public string[] soundsWhenHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeHitSound()
    {
        int count = soundsWhenHit.Length;
        int randomIndex = Random.Range(0,count);
        FindObjectOfType<AudioManager>().Play(soundsWhenHit[randomIndex]);
    }
}
