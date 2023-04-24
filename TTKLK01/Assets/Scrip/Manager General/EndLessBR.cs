using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EndLessBR : MonoBehaviour
{
    public float scrollSpeed;
    public float maximunY;
    Vector2 startPositon;

    private void Start()
    {
        startPositon = transform.position;
    }
    void Update()
    {
        float y = Time.deltaTime*scrollSpeed;
        
           transform.position = new Vector2(0, transform.position.y-y);
        if (transform.position.y< maximunY)
        {
            transform.position = startPositon;
        }
     
    }
}
