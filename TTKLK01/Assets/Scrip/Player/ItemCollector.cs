using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    [Header("Count Fruit")]
    [SerializeField] protected int kiwi = 0;
    [SerializeField] protected int banana = 0;
    [SerializeField] protected int melon = 0;
    [SerializeField] protected int Score = 0;
    [Header("Text Score")]
    [SerializeField] public int score;
    [SerializeField] protected Text txtScore;
    public static ItemCollector instance;
    private void Start()
    {
        instance = this;   
    }


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("kiwi"))
        {
            Sound_Manager.instance.PlayEatFruit();  
            Destroy(collision.gameObject);
            kiwi++;
            score += 100;
            Manager_Score.Instance.score += (int)score;
        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            Sound_Manager.instance.PlayEatFruit();
            Destroy(collision.gameObject);
            banana++;
            score += 200;
            Manager_Score.Instance.score += (int)score;

        }
        if (collision.gameObject.CompareTag("Melon"))
        {
            Sound_Manager.instance.PlayEatFruit();
            Destroy(collision.gameObject);
            melon++;
            score += 300;
            Manager_Score.Instance.score += (int)score;
        }
        if (collision.gameObject.CompareTag("heart"))
        {
            Sound_Manager.instance.PlayEatFruit();
            Manager_Heart.instance.AddHeart();
            Destroy(collision.gameObject);
            Manager_Score.Instance.score += (int)score;

        }
       
        txtScore.text ="Score : "+ score.ToString();
      
    }

    


}
