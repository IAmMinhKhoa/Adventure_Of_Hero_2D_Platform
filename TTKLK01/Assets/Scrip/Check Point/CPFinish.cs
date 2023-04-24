using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CPFinish : MonoBehaviour
{
  
    protected int nextScenceLoad;

    private void Start()
    {
        nextScenceLoad = SceneManager.GetActiveScene().buildIndex + 1 ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string nameObject = gameObject.name;
        if (collision.gameObject.CompareTag("Player")&& nameObject=="Point Finish")
        {
            Sound_Manager.instance.PlayFinish();
            StartCoroutine(LoadMap(2f));
        }
        if (collision.gameObject.CompareTag("Player") && nameObject == "Point Start")
        {
            Sound_Manager.instance.PlayStart();
        }
    }
    IEnumerator LoadMap(float delayTime)
    {
        
     
        yield return new WaitForSeconds(delayTime);
        int total_score = PlayerPrefs.GetInt("score") + ItemCollector.instance.score;
        PlayerPrefs.SetInt("score", total_score);
        SceneManager.LoadScene(nextScenceLoad);
        if (nextScenceLoad > PlayerPrefs.GetInt("levelat"))
        {
            PlayerPrefs.SetInt("levelat", nextScenceLoad);
        }

    }
}
