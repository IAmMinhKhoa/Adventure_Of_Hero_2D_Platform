using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [Header("Transform of model Player")]
    [SerializeField] public Transform Player;

    [SerializeField] float val = 0.5f;

    private void Start()
    {
        Sound_Manager.instance.PlaySTplaying();
    }

    private void Update()
    {
        //turn off for dev

        if (StartCam())
        {
            MoveCamFlCharacter();
        }

        // MoveCamFlCharacter();


    }
    protected Boolean StartCam()
    {
     
        transform.position = Vector3.MoveTowards(transform.position, Player.position, val * Time.deltaTime * 2);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
       
        if ( transform.position.x-0.5f <=  Player.position.x)
        {
           
            Manager_Animation.instance.UnFreezePlayer();
            return true;    
        }
        return false;
     
    }
    protected void MoveCamFlCharacter()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y,transform.position.z);
    }

}
