using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public float forwardSpeed;
    public float defaultSpeed;
    public bool gameStartedBool;
    public bool gameOverBool;
    public int lvl;





    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        defaultSpeed = forwardSpeed + (PlayerPrefs.GetInt("level") * 0.01f);  //To make things interesting I add a value 1/10th of the level to the sped of the game.
        forwardSpeed = 0;

        
        

        if (PlayerPrefs.GetInt("level") == 0)
        {
            lvl = 1;
            PlayerPrefs.SetInt("level", lvl);
        }
        else
        {
            lvl = PlayerPrefs.GetInt("level");
        }
    }

    private void Update()
    {
    }
}
