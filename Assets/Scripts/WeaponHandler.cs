using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public GameObject weapon;
    public int maxCombo;
    public float comboCooldown = 0.5f;
    public float lastComboTime;
    private Animator animator;
    private InputHandler _input;
    private TopDownMovment player;
    private Queue<int> combo;
    public int comboCount;
    
    
    void Start()
    {
        combo = new Queue<int>();
        animator = weapon.GetComponent<Animator>();
        _input = GetComponent<InputHandler>();
        player = GetComponent<TopDownMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        CaptureCombo();
        //AnimateCombo();
        
    }

    private int currentInCombo = 0;
    private float mousecd = 0.1f;
    void CaptureCombo()
    {
        if(player.isEquipped)
        {
            
            if(_input.LMB && (Time.time > lastComboTime + mousecd || lastComboTime ==0) && comboCount < maxCombo)
            {
                Debug.Log("AAddToCombo");
                
                    currentInCombo++;
                    int attackType = 1;
                    string animString = "combo" + currentInCombo;
                    animator.SetInteger(animString, attackType);
                lastComboTime = Time.time;
                comboCount++;
            } 
            else if(_input.RMB && Time.time < lastComboTime + comboCooldown && comboCount < maxCombo)
            {
                currentInCombo++;
                    int attackType = 2;
                    string animString = "combo" + currentInCombo;
                    animator.SetInteger(animString, attackType);
                lastComboTime = Time.time;
                comboCount++;
            } 
            
            
            
            Debug.Log("Printing");
            
            
            
        }

    }
    public void ResetCooldowns()
    {
        animator.SetInteger("combo1", 0);
        animator.SetInteger("combo2", 0);
        comboCount = 0;
        currentInCombo = 0;
    }
    
    
    // void AnimateCombo()
    // {
    //     if(combo.Count != 0 && currentInCombo < maxCombo && Time.time < lastComboTime + comboCooldown)
    //     {
            
    //         currentInCombo++;
    //         int attackType = combo.Dequeue();
    //         string animString = "combo" + currentInCombo;
    //         animator.SetInteger(animString, attackType);
            

    //     }
    //     else if(combo.Count == 0 && Time.time > lastComboTime + comboCooldown)
    //     {
    //         comboCount = 0;
    //         //currentInCombo = 0;
    //         animator.SetInteger("combo1", 0);
    //         animator.SetInteger("combo2", 0);
            
            
    //     }
    //}
}
