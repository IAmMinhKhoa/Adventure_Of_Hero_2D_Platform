using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
  

   public void selecLV()
    {
        Sound_Manager.instance.PlayCickButton();
        SceneManager.LoadScene("level_"+level);
    }
}
