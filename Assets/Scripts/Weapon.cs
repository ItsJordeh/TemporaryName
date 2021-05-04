using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    private WeaponHandler handler;
    
    void Start()
    {
        
        handler = GetComponentInParent<WeaponHandler>();
    }
    public void ResetCooldowns()
    {
        handler.ResetCooldowns();
    }
    public void PlaySlashSound()
    {
        FindObjectOfType<AudioManager>().Play("swing" + Random.Range(1,2));
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Prop")
        {
            ObjectProperties prop = collision.gameObject.GetComponent<ObjectProperties>();
            prop.MakeHitSound();
            Debug.Log("HitSound");
        }
        else
        {
            Physics.IgnoreCollision(collision.transform.GetComponent<Collider>(), GetComponent<Collider>());
        }

    }
    
}
