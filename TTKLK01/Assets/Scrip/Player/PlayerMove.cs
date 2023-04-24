using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{ 
    public static PlayerMove instance;
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField] protected LayerMask jumpAbleGround;
  

    public float ValSpeed;
    public float ValJump;
    private void Start()
    {
        instance = this;
        rb = GameObject.Find("Model").GetComponent<Rigidbody2D>();
        coll=rb.GetComponent<BoxCollider2D>();


    }
    private void Update()
    {
        
        float dirX = Manager_Input.DirX;      
        Moving(dirX);
        bool checkJump = Jumping();

        DoJump(checkJump);
    }

    public void DoJump(bool checkjump)
    {
        if (checkjump==true && (IsGroundDown()))
        {

            Sound_Manager.instance.PlayJump();
            rb.velocity = new Vector2(rb.velocity.x, ValJump);
        }
        if (checkjump == true && (IsGroundLeft() || IsGroundRight()))
        {

            Sound_Manager.instance.PlayJump();
            rb.velocity = new Vector2(rb.velocity.x, ValJump);
        }
    }
    protected virtual void Moving(float dirX)
    {
      
        rb.velocity = new Vector2(dirX * ValSpeed , rb.velocity.y);
     
        

    }

    protected virtual Boolean Jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
          
            return true;
        }
        return false;

    }

    public virtual bool IsGroundLeft()
    {
     //   Manager_Animation.instance.isSlidingWall = true;
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, 0.1f, jumpAbleGround);
        
    }
    public virtual bool IsGroundRight()
    {
        //Manager_Animation.instance.isSlidingWall = true;
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, 0.1f, jumpAbleGround);

    }
    public virtual bool IsGroundDown()
    {
     
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpAbleGround);

    }


}
