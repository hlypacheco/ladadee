using UnityEngine;

public class CharacterAnimationScript : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleAnimations();
    }
    
    private void HandleAnimations()
    {
        //handle running and idling
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("RunTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }
        
        // handle jumping
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("JumpTrigger");
        }
		else
		{
			animator.SetTrigger("IdleTrigger");
		}
        
        //Triggers the Double Jump Animation
        //if (Input.GetButtonDown("Jump"))
        //{
            //animator.SetTrigger("Jump");
        //}
        //else
        //{
            //animator.SetTrigger("Idle");
        //}
        
        // handle wall jumping
        if (Input.GetKeyDown(KeyCode.W))
        {
           animator.SetTrigger("WallJumpTrigger");
        } 
		else
		{
			animator.SetTrigger("IdleTrigger");
		}        
        //Triggers the Hit Animation
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("HitTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }
        
        //Triggers the *Fall? Animation
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("FallTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }
    }
}
