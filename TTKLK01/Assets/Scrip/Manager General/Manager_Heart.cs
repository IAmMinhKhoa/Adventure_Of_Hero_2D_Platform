using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager_Heart : MonoBehaviour
{
    [Header("max heart of player")]
    [SerializeField] protected int maxHeart = 3;
    [Header("current heart of player")]
    [SerializeField] protected int heart ;
    [Header("Prefab icon Heart")]
    [SerializeField] protected GameObject prefabHeart;
    [Header("List current heart of player")]
    [SerializeField] protected List<Transform> ListHeart;
    public int Heart { get => heart; }
    public int MaxHeart { get => maxHeart; }
    public static Manager_Heart instance;

 
    private void Awake()
    {
        instance = this;
       // heart = maxHeart;
       
       
    }
    private void Start()
    {
        //c?n ph?i kh?i t?o 1 heart tr??c
       
        AddHeartMax();  
    }
    protected void LoadHeartInList()
    {
        ListHeart.Clear();
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
         
            ListHeart.Add(gameObject.transform.GetChild(i));
        }
      
    }
  

    protected void InitHeart()
    {
        GameObject FirstHeart = Instantiate(prefabHeart, new Vector2(transform.position.x+31,transform.position.y+31), Quaternion.identity);
        FirstHeart.transform.SetParent(transform);
        LoadHeartInList();
    }
    public void AddHeartMax()
    {
        InitHeart();
        heart = 1;
        for (int i = 1; i < maxHeart; i++)
        {

            AddHeart();
        }
    }
    public void AddHeart()
    {
        heart++;
        GameObject lastHeart= ListHeart.Last().gameObject;  
        Vector2 nextHeart = new Vector2(lastHeart.transform.position.x - 55f, lastHeart.transform.position.y);
        GameObject newHeart= Instantiate(prefabHeart, nextHeart, Quaternion.identity);  
        newHeart.transform.SetParent(transform);
        LoadHeartInList();


    }

    public void MinusHeart()
    {
        heart--;
        if(heart < 0) return;   
        
        GameObject lastHeart = ListHeart.Last().gameObject;
     
        Destroy(lastHeart);
         ListHeart.Remove(ListHeart.Last());      
        
    }
}
