using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_TrapFire : MonoBehaviour
{
     protected Animator animator;
   
    [SerializeField] protected BoxCollider2D boxFire;
    [Header("TimeFiring and TimeDelay")]
    public int timeFiring;
    public int timeDelay;
   
    void Start()
    {
        animator=GetComponent<Animator>();
       
        InvokeRepeating(nameof(PlayTrapFire), 0f,(timeDelay+timeFiring));
    }
  

  

    protected void SetOnTrapFire()
    {
        animator.SetBool("CheckFire", true);
    }
    protected void SetOffTrapFire()
    {
        animator.SetBool("CheckFire", false);
    }

    protected void PlayTrapFire()
    {
      //  Debug.Log("callham");
        StartCoroutine(IETrapFire(timeFiring));
       
    }

    IEnumerator IETrapFire(float delayTime)
    {
        SetOnTrapFire();
        boxFire.enabled = true;
      //  Debug.Log("bat");
        yield return new WaitForSeconds(delayTime);
        boxFire.enabled = false;
        SetOffTrapFire();
      //  Debug.Log("tat");


    }
}
