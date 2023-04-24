using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    [SerializeField] Boolean RotateY = false; 

    // Update is called once per frame
    void Update()
    {
        if(RotateY)
            transform.Rotate(0, 0, 360 * Time.deltaTime * speed);
        else
            transform.Rotate(0, 360 * Time.deltaTime * speed, 0);
    }
}
