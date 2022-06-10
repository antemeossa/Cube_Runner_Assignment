using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    public GameObject deathpanel;
    public GameObject startPanel;
    public GameObject detailsPanel;
    private static CanvasManager _instance;

    public static CanvasManager Instance
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
        setTexts();
        deathpanel.SetActive(false);
        startPanel.SetActive(false);
        nextLevelBtn.gameObject.SetActive(false);
        detailsPanel.SetActive(true);
        retryBtn.gameObject.SetActive(false);


    }


    public Button startBtn;
    public Button retryBtn;
    public Button nextLevelBtn;

    public TMP_Text liveText;
    public TMP_Text sessionScoreText;
    public TMP_Text totalScoreText;
    public TMP_Text lvlText;
    public TMP_Text gameLvlText;
    public TMP_Text gameSessionScore;
    public GameObject diamondIcon;
    public void startButton()
    {
        
        startBtn.gameObject.SetActive(false);
        GameManager.Instance.gameStartedBool = true;
        GameManager.Instance.forwardSpeed = GameManager.Instance.defaultSpeed;
        startPanel.SetActive(true);
        detailsPanel.SetActive(false);
        PlayerManager.Instance.animator.SetTrigger("GameStarted");

    }

    public void nextLevelButton()
    {
        nextLevelBtn.gameObject.SetActive(false);        
        detailsPanel.SetActive(false);

        SceneManager.LoadScene(0);
    }

    public void retryButton()
    {
        GameManager.Instance.gameStartedBool = true;
        deathpanel.SetActive(false);
        retryBtn.gameObject.SetActive(false);
        SceneManager.LoadScene(0);

    }

    public void setTexts()
    {
        liveText.text = PlayerManager.Instance.hpCount + "";
        sessionScoreText.text = PlayerManager.Instance.sessionGold + "";
        totalScoreText.text = PlayerPrefs.GetInt("totalGold") + "";
        lvlText.text = "LEVEL " + PlayerPrefs.GetInt("level") ;
        gameLvlText.text = lvlText.text;
        gameSessionScore.text = sessionScoreText.text;

    }

    public void onDeath()
    {
        deathpanel.SetActive(true);
        retryBtn.enabled = true;
        startPanel.SetActive(false);
        GameManager.Instance.forwardSpeed = 0;
        GameManager.Instance.gameOverBool = true;
        retryBtn.gameObject.SetActive(true);
    }

    public void onSuccess()
    {
        nextLevelBtn.gameObject.SetActive(true);
        startBtn.gameObject.SetActive(false);
        startPanel.SetActive(false);
        detailsPanel.SetActive(true);
        GameManager.Instance.forwardSpeed = 0;
        PlayerManager.Instance.animator.SetTrigger("Victory");
    }


    public IEnumerator shakeIcon(GameObject obj)
    {
        float t = 0;
        float desiredT = .25f;
        Transform pos = obj.transform;
        while (t < desiredT)
        {
            obj.transform.Rotate(new Vector3(0, 15, 0));
            t += Time.deltaTime;
            yield return null;
        }


        
    }
}
