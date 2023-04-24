using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TouchToDo : MonoBehaviour
{
    int checkBox = 0;
   
    

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("box")|| collision.gameObject.CompareTag("trap"))
        {
           
            checkBox = 1;
            //DO SOMETHING
            ToDo();

        }
        if ( collision.gameObject.CompareTag("Player"))
        {
           
            //DO SOMETHING
            ToDo();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(checkBox!=0)//box trong area
        {
            if (collision.gameObject.CompareTag("box"))
            {

               
                checkBox = 0;
                    NoneToDo();

            }
        }
        else //box khong trong area
        {
            if (collision.gameObject.CompareTag("Player"))
            {

              
                NoneToDo();

            }
        }
       
      
    }

    protected abstract void ToDo();
    protected abstract void NoneToDo();

}
