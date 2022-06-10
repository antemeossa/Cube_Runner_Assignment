using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int hpCount = 3;
    public int totalGold;
    public int sessionGold;

    public Animator animator;
    public GameObject playerCol;
    public int tmpScore;

    private static PlayerManager _instance;

    public static PlayerManager Instance
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
       
    }

    private void Update()
    {
        
    }

    public void setScore()
    {
        tmpScore = sessionGold;
        PlayerPrefs.SetInt("totalGold", PlayerPrefs.GetInt("totalGold") + tmpScore);
        totalGold = PlayerPrefs.GetInt("totalGold");
        CanvasManager.Instance.setTexts();
    }


}
