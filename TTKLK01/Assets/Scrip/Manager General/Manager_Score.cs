using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager_Score : MonoBehaviour
{
    [SerializeField] public int score;
    public static Manager_Score Instance;

    private void Awake()
    {
        score = PlayerPrefs.GetInt("score");
    }
    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        Instance = this;
    }
   
}
