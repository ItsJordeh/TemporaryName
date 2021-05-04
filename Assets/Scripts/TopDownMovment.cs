using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovment : MonoBehaviour
{
    // Start is called before the first frame update
    private InputHandler _input;
    public GameObject weapon;

    public float eqippedMoveSpeed = 10f, dequippedMoveSpeed = 30f;

    private Animator swordAnimator;
    public Vector3 mouseWorldPosition;
     public float turnSmoothing = 15f; // A smoothing value for turning the player.
     public float speedDampTime = 0.1f; // The damping for the speed parameter

    public float maxSpeed = 30f;
    
    private Vector3 movement;
    public float dashImpulse;

    private Rigidbody rb;

    private Transform mainPlayer;
    public bool isEquipped;
   
    Vector3 x, z;

    private float speed = 10f;
    void Start()
    {
        swordAnimator = weapon.GetComponent<Animator>();
        swordAnimator.SetFloat("equipSpeed", equipTime);
        swordAnimator.SetFloat("dequipSpeed", dequipTime);


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
        ProcessInput();
        ProcessCooldowns();
        LimitMovement();
    }
    void LimitMovement()
    {
         if(rb.velocity.magnitude > maxSpeed)
         {
                rb.velocity = rb.velocity.normalized * maxSpeed;
         }
    }
    private Vector3 newDir;
    private Vector3 direction;
    private Quaternion rot;
    private void ProcessMovement(float horizontal, float vertical)
    {
        if(isEquipped || equipping || dequipping)   speed = eqippedMoveSpeed;
        else if(!isEquipped)    speed = dequippedMoveSpeed;

        
        

        if((horizontal != 0f || vertical != 0f) && !isEquipped)
         {
             Rotating(horizontal, vertical);
             rb.AddForce(transform.forward * speed);
             
             
             
             
         }
         if(isEquipped || equipping)
         {
             RotateTowardCursor(horizontal, vertical);

             
            
            if(horizontal!= 0f || vertical!=0f)
            {
                Vector3 targetDirection = new Vector3(horizontal, 0, vertical);
                targetDirection = Camera.main.transform.TransformDirection(targetDirection);
                
                targetDirection.y = 0.0f;
                rb.AddForce(targetDirection.normalized*speed);
                
                
            }
             
         }
             
        
        
        
     
    }
    void RotateTowardCursor(float horizontal, float vertical)
    {
        Plane plane = new Plane(Vector3.up, transform.position.y);

            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(plane.Raycast(ray, out distance))
            {
                mouseWorldPosition = ray.GetPoint(distance);
                mouseWorldPosition = new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z);
            }
            direction = new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z) - transform.position;
            
            rot = Quaternion.LookRotation(direction);
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
         
            // Create a rotation that is an increment closer to the target rotation from the player's rotation.
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);
            
            transform.rotation = newRotation;

            if(horizontal != 0f && vertical != 0f)
            {
                Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
                targetDirection = Camera.main.transform.TransformDirection(targetDirection);
                targetDirection.y = 0.0f;
                
            }
    }
    
    private Vector3 targetDirection;
    void ProcessInput()
    {
        if(_input.RKey)
        {
            Equip();
        }
        if(_input.doubleTapW || _input.doubleTapA || _input.doubleTapS || _input.doubleTapD)
        {
            Dash();
        }
    }
    
    public float equipTime = 2f;
    private float equipStart;
    private bool equipping;

    public float dequipTime = 1f;
    private float dequipStart;
    private bool dequipping;
    
    void ProcessCooldowns()
    {
        if(equipping || dequipping)
        {
            if(Time.time > equipStart + equipTime && !isEquipped && equipping)
            {
                swordAnimator.SetBool("equipping", false);
                equipping = false;
                isEquipped = true;
                Debug.Log("Equipped");
            }    
            if(Time.time > dequipStart + dequipTime && isEquipped && dequipping)
            {
                swordAnimator.SetBool("dequipping", false);
                dequipping = false;
                isEquipped = false;
                Debug.Log("Dequipped");
            }
        }
        
    }
    void Dash()
    {
        if(isEquipped)
        {
            if(_input.doubleTapW)
            {
                targetDirection = new Vector3(0, 0, 1);
                
            }
            if(_input.doubleTapA)
            {
                targetDirection = new Vector3(-1, 0, 0);
                
            }
            if(_input.doubleTapS)
            {
                targetDirection = new Vector3(0, 0, -1);
                
            }
            if(_input.doubleTapD)
            {
                targetDirection = new Vector3(1, 0, 0);
                
            }
            Debug.Log("dash");
            _input.ResetDoubleTaps();
            
            targetDirection = Camera.main.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            Debug.Log(targetDirection*dashImpulse);
            rb.AddForce(targetDirection*dashImpulse, ForceMode.Impulse);
        }
    }
    void Equip()
    {
        if(!equipping || !dequipping)
        {
            if(isEquipped && !dequipping)
            {
                swordAnimator.SetBool("dequipping", true);
                dequipping = true;
                dequipStart = Time.time;
            }
            else if(!isEquipped && !equipping)
            {
                swordAnimator.SetBool("equipping", true);
                equipping = true;
                equipStart = Time.time;
            }
        }
        
    }
    
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(mouseWorldPosition, 1);
        Gizmos.DrawSphere(direction, 1);
        //Gizmos.DrawSphere(newDir, 1);
        Gizmos.DrawLine(transform.position, mouseWorldPosition);
        
        
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
