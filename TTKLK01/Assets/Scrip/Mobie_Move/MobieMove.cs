using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobieMove : MonoBehaviour
{
    protected float dirX;
    bool moveForward;
    //0 la dung im
    //1 la phai
    //-1 la trai
    int checkmove = 0;
    bool checkJump = false;

  
    void Update()
    {
       // GetInput();
        
        if (moveForward )
        {
            if(checkmove==1)
                 Manager_Input.DirX = 1;
            else 
                Manager_Input.DirX = -1;
        }
        else
             Manager_Input.DirX = 0;

        PlayerMove.instance.DoJump(checkJump);
        checkJump=false;
    }
    public void Jumping()
    {
        checkJump = true;
    }
    public void MoveButtonPressed()
    {
        moveForward = true;
    }
    public void MoveButtonReleased()
    {
        moveForward = false;
    }
    public void moveLeft()
    {

        checkmove = -1;
    }
    public void moveRight()
    {
        checkmove = 1;
    }
   
}
