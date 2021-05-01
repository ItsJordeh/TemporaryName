using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovment : MonoBehaviour
{
    // Start is called before the first frame update
    private InputHandler _input;
     public float turnSmoothing = 15f; // A smoothing value for turning the player.
     public float speedDampTime = 0.1f; // The damping for the speed parameter

    
    private Vector3 movement;

    private Rigidbody rb;

    private Transform mainPlayer;
   
    Vector3 x, z;

    public float speed = 10f;
    void Start()
    {
        mainPlayer = GetComponentInParent<Transform>();
        _input = GetComponent<InputHandler>();
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        x = transform.right * _input.InputVector.x;
        z = transform.forward * _input.InputVector.y;
        
        


    }
    void FixedUpdate()
    {
        ProcessMovement(_input.InputVector.x, _input.InputVector.y);
    }

    private void ProcessMovement(float horizontal, float vertical)
    {
        // Vector3 targetDirection = new Vector3(_input.InputVector.x, 0f, _input.InputVector.y);
        // targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        // targetDirection.y = 0.0f;
        // 

        // 

        if(horizontal != 0f || vertical != 0f)
         {
             // ... set the players rotation and set the speed parameter to 5.3f.
             Rotating(horizontal, vertical);
             rb.AddForce(transform.forward * speed);
         }

             // Otherwise set the speed parameter to 0.
             
              
     
    }
    
    void Rotating (float horizontal, float vertical)
     {
         // Create a new vector of the horizontal and vertical inputs. 
         Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
         targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
         
         // Create a rotation based on this new vector assuming that up is the global y axis.
         Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
         
         // Create a rotation that is an increment closer to the target rotation from the player's rotation.
         Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);
         
         // Change the players rotation to this new rotation.
         transform.rotation = (newRotation);
     }
}
