using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platform : MonoBehaviour
{
    [Header("Moving with List Point ")]
    [SerializeField] protected List<GameObject> listWayPoint;
   
    protected int currentWayPoint = 0;
    [Header("Speed moving of object")]
    [SerializeField] protected float speed=10f;

 
   
    void Update()
    {
        Moving();
    }

    protected void Moving()
    {
        if (Vector2.Distance(listWayPoint[currentWayPoint].transform.position, transform.position) < 0.1f)
        {
            currentWayPoint++;
            if (currentWayPoint >= listWayPoint.Count)
            {
                currentWayPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, listWayPoint[currentWayPoint].transform.position, speed * Time.deltaTime);
    }
}
