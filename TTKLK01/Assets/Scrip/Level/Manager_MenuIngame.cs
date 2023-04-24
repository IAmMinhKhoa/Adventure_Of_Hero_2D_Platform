using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_MenuIngame : MonoBehaviour
{
    [SerializeField] protected GameObject BtnStop;
    [SerializeField] protected GameObject BoardControlMenu;


    public void OpenBtnStop()
    {
        
        BtnStop.SetActive(true);
    }
    
    public void CloseBtnStop()
    {
        BtnStop.SetActive(false);
    }

    public void OpenBoardControl()
    {
        PlayClickBtn();
        CloseBtnStop();
        PauseGame();
        BoardControlMenu.SetActive(true);
    }
    public void CloseBoardControl()
    {
        PlayClickBtn();
        ResumeGame();
        OpenBtnStop();
        BoardControlMenu.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void PlayAgain()
    {
        PlayClickBtn();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }
    public void Exits()
    {
        PlayClickBtn();
        ResumeGame();   
        SceneManager.LoadScene("Menu");
    }
    void PlayClickBtn()
    {
        Sound_Manager.instance.PlayCickButton();
    }
}

