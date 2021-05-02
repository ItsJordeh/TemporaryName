using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovment : MonoBehaviour
{
    // Start is called before the first frame update
    private InputHandler _input;
    public Vector3 mouseWorldPosition;
     public float turnSmoothing = 15f; // A smoothing value for turning the player.
     public float speedDampTime = 0.1f; // The damping for the speed parameter

    
    private Vector3 movement;

    private Rigidbody rb;

    private Transform mainPlayer;
    public bool isEquipped;
   
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
    private Vector3 newDir;
    private Vector3 direction;
    private Quaternion rot;
    private void ProcessMovement(float horizontal, float vertical)
    {
        // Vector3 targetDirection = new Vector3(_input.InputVector.x, 0f, _input.InputVector.y);
        // targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        // targetDirection.y = 0.0f;
        // 

        // 

        if(horizontal != 0f || vertical != 0f && !isEquipped)
         {
             // ... set the players rotation and set the speed parameter to 5.3f.
             Rotating(horizontal, vertical);
             rb.AddForce(transform.forward * speed);
         }
         else if (isEquipped)
         {
            //  Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

            //  Vector2 mouseOnScreen =(Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

            // 

            // 

            Plane plane = new Plane(Vector3.up, transform.position.y);

            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(plane.Raycast(ray, out distance))
            {
                mouseWorldPosition = ray.GetPoint(distance);
                mouseWorldPosition = new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z);
            }
            direction = new Vector3(mouseWorldPosition.x, 0f, mouseWorldPosition.z);
            
            rot = Quaternion.LookRotation(transform.InverseTransformPoint(direction));
            
            transform.rotation = rot;

            //  float angle = AngleBetweenTwoPoints(transform.position, mouseWorldPosition);

            //   transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
         }

             // Otherwise set the speed parameter to 0.
             
        
        
        
     
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(mouseWorldPosition, 1);
        Gizmos.DrawSphere(direction, 1);
        Gizmos.DrawSphere(newDir, 1);
        Gizmos.DrawLine(transform.position, mouseWorldPosition);
        Debug.Log(Vector3.Angle(transform.position, mouseWorldPosition));
        
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
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
