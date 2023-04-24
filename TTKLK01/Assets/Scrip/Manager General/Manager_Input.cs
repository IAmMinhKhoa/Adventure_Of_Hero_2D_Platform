using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Input : MonoBehaviour
{
    protected static float dirX;
    protected static Manager_Input instance;
    public static Manager_Input Instance { get=>instance;}
    public static float DirX
    {
        set { dirX = value; }
        get => dirX; }   
    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        //if use verison mobie, you should turn off function "getinput", because it cause error class "mobiesMoves"
        GetInput();
    }

    protected void GetInput()
    {
        Manager_Input.DirX = Input.GetAxisRaw("Horizontal");
    }



}
