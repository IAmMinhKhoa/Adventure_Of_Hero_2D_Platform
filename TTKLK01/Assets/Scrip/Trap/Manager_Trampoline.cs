using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Trampoline : MonoBehaviour
{
    [Header("variable of Hight")]
    [SerializeField] protected int valTrampoline;
    private Rigidbody2D rb;
    private Animator animator;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GameObject.Find("Model").GetComponent<Rigidbody2D>();
    }
 

    protected void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.gameObject.CompareTag("Player") && PlayerMove.instance.IsGroundDown() == false)
        {
            animator.SetBool("Jump", true);
            Sound_Manager.instance.PlayTrampoline();
            StartCoroutine(delayBooleanTrampoline(.1f));
            rb.velocity = Vector2.up * valTrampoline;
        }

    }
    IEnumerator delayBooleanTrampoline(float delayTime)
    { 
        yield return new WaitForSeconds(delayTime);
        animator.SetBool("Jump", false);
    }
}
