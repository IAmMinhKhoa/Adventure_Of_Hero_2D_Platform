using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : TouchToDo
{
    SpriteRenderer spriteRenderer;
    public GameObject objectWantDo;
    public Boolean nowActive ;
    // Start is called before the first frame update
    Color temp;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        temp=spriteRenderer.color;
    }
      
    protected override void NoneToDo()
    {
        spriteRenderer.color = temp;
        objectWantDo.SetActive(nowActive);    
    }
    protected override void ToDo()
    {
        spriteRenderer.color = Color.black;
        objectWantDo.SetActive(!nowActive);
    }
}
