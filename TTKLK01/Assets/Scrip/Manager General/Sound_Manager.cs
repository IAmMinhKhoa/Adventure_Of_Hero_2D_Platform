using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    [Header("---------Source Audio PLAYER--------")]
    [SerializeField] protected AudioSource eatFruit;
    [SerializeField] protected AudioSource jump;
    [SerializeField] protected AudioSource die;
    [Header("---------Source Audio CHECK POINT--------")]
    [SerializeField] protected AudioSource start;
    [SerializeField] protected AudioSource finish;
    [Header("---------Source Audio TRAP--------")]
    [SerializeField] protected AudioSource trampoline;
    [Header("---------Source Audio BUTTON--------")]
    [SerializeField] protected AudioSource clickButton;
    [Header("---------Source Audio SOUND TRACK--------")]
    [SerializeField] protected AudioSource STmenu;
    [SerializeField] protected AudioSource STplaying;
    public static Sound_Manager instance;

    private void Awake()
    {
        instance = this;

    }

    public void PlayEatFruit()
    {
        eatFruit.Play();
    }
    public void PlayJump()
    {
        jump.Play();
    }
    public void PlayFinish()
    {
        finish.Play();
    }
    public void PlayDie()
    {
        die.Play();
    }
    public void PlayStart()
    {
        start.Play();
    }
 
    public void PlayTrampoline()
    {
        trampoline.Play();
    }
    public void PlayCickButton()
    {
        clickButton.Play();
    }
    public void PlaySTmenu()
    {
        if(STmenu != null)
          STmenu.Play();
    }
    public void PlaySTplaying()
    {
        STplaying.Play();
    }
}
