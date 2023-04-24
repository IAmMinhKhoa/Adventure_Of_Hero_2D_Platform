using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager_Animation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private BoxCollider2D box;

    public static Manager_Animation instance;
    /* state =0 : idel
     * state =1 : Running
     * state =2 : Jump
     * State =3 : Falling*/
    private enum MovementState { idle, running, jumping, falling,slidejunmp };
    float dirX;


        
    void Start()
    {
        
        instance = this;

        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //turn off for dev
        FreezePlayer();
    }


    void Update()
    {
         dirX = Manager_Input.DirX;
      /*  dirX = Manager_Input.DirX = 99;
        Debug.Log(dirX);*/
        CtrlAnimation(dirX);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap")) {
            Die();
        }
       
    }

  
    protected virtual void CtrlAnimation(float dirX)
    {
    
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }

        else if (dirX < 0f)
        {
            spriteRenderer.flipX = true;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
   
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
   
        animator.SetInteger("state", (int)state);
        
    }
 
    protected void Die()
    {
     
        Manager_Heart.instance.MinusHeart();
        Sound_Manager.instance.PlayDie();
       
        //khi cham trap thi jump len 4f
        rb.velocity = new Vector2(rb.velocity.x,3f);
    
        StartCoroutine(TouchTrap(0.2f));
       // Debug.Log(Manager_Heart.instance.Heart);
        if (Manager_Heart.instance.Heart <= 0)
        {
            
            FreezePlayer();
            animator.SetTrigger("death");
            StartCoroutine(RestartLevel(1f));
            
            box.enabled = false;
        }
    }
    public void FreezePlayer()
    {
      
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void UnFreezePlayer()
    {
  
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    protected int FlexPlayer()
    {
        if (spriteRenderer.flipX) return 1;
        return -1;
    }
    

    IEnumerator RestartLevel(float delayTime)
    {
        //Wait for the specified delay time before continuing.

        yield return new WaitForSeconds(delayTime);
  
        //Do the action after the delay time has finished.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator TouchTrap(float delayTime)
    {
        spriteRenderer.color= Color.red;
        yield return new WaitForSeconds(delayTime);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(delayTime);
     

    }


}
