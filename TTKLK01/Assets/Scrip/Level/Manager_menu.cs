using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] lvlButton;
    protected int level;
    public GameObject menuLevel;
    public GameObject MenuMain;
    public Text Total_Score;
    public Text textCoding;
    void Start()
    {
       
        Sound_Manager.instance.PlaySTmenu();
        //PlayerPrefs.SetInt("score", 0);
       // PlayerPrefs.SetInt("levelat", 1);
        int levelAt = PlayerPrefs.GetInt("levelat", 1);
        for(int i = 0; i < lvlButton.Length; i++)
        {
            if(i+1>levelAt )
                lvlButton[i].interactable = false;
        }
        if(Total_Score != null)
            Total_Score.text = "Total :"+PlayerPrefs.GetInt("score").ToString();
    }
   
    public void selectLV()
    {

        SceneManager.LoadScene("level_1");
    }
    public void Open_menuLevel()
    {
        Sound_Manager.instance.PlayCickButton();
        Close_menuMain();
        menuLevel.SetActive(true);
       
    }
    public void Close_menuLevel()
    {
        Sound_Manager.instance.PlayCickButton();
        menuLevel.SetActive(false);
        Open_menuMain();
        
    }
    public void Open_menuMain()
    {
        MenuMain.SetActive(true);
    }
    public void Close_menuMain()
    {
        MenuMain.SetActive(false);
    }
    public void NextScenceInformation()
    {
        SceneManager.LoadScene("Information");
    }
    public void NextScenceMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void coding()
    {
        textCoding.enabled= true;
        StartCoroutine(changeColorText(0.2f));
    }
    IEnumerator changeColorText(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
       textCoding.color= Color.red;
        yield return new WaitForSeconds(delayTime);
        textCoding.color = Color.black;
        yield return new WaitForSeconds(delayTime);
        textCoding.color = Color.red;
        yield return new WaitForSeconds(delayTime);
        textCoding.color = Color.black;
        yield return new WaitForSeconds(delayTime);
        textCoding.color = Color.red;
        yield return new WaitForSeconds(delayTime);
        textCoding.color = Color.black;



        textCoding.enabled = false;
    }
}
