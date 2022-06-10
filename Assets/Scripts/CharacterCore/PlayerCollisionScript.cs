using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{

    public Magnet magnet;
    public FireWorksScript fireWorksScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if(PlayerManager.Instance.hpCount > 0)
            {
                PlayerManager.Instance.hpCount--;
                CamManager.Instance.shake = true;
                PlayerManager.Instance.animator.SetTrigger("Stumble");
                CanvasManager.Instance.setTexts();

            }
            else
            {
                PlayerManager.Instance.totalGold += PlayerManager.Instance.sessionGold;
                GameManager.Instance.gameOverBool = true;
                CamManager.Instance.shakeDuration = 1f;
                CamManager.Instance.shake = true;
                PlayerManager.Instance.animator.SetTrigger("Defeat");
                PlayerManager.Instance.playerCol.SetActive(false);
                CanvasManager.Instance.detailsPanel.SetActive(true);
                CanvasManager.Instance.setTexts();
                CanvasManager.Instance.onDeath();

            }
        }

        if (other.CompareTag("Coin"))
        {
            PlayerManager.Instance.sessionGold += other.GetComponent<CollectibleScript>().value;
            
            if (other.GetComponent<CollectibleScript>() != null)
            {
                other.GetComponent<CollectibleScript>().mesh.SetActive(false);
                other.GetComponent<CollectibleScript>().playCoinParticles();
                CanvasManager.Instance.setTexts();
                StartCoroutine(CanvasManager.Instance.shakeIcon(CanvasManager.Instance.diamondIcon));
                
            }
            
        }

        if (other.CompareTag("HP"))
        {
            PlayerManager.Instance.hpCount++;
            other.GetComponent<CollectibleScript>().mesh.SetActive(false);
            other.GetComponent<CollectibleScript>().playHpParticles();
            CanvasManager.Instance.setTexts();
            StartCoroutine(CanvasManager.Instance.shakeIcon(CanvasManager.Instance.hpIcon));
        }

        if (other.CompareTag("Magnet"))
        {
            StartCoroutine(magnet.countdown());
        }

        if (other.CompareTag("FinishLine"))
        {
            PlayerManager.Instance.setScore();
            GameManager.Instance.lvl = PlayerPrefs.GetInt("level") + 1;
            PlayerPrefs.SetInt("level", GameManager.Instance.lvl);
            CanvasManager.Instance.onSuccess();
            StartCoroutine(CamManager.Instance.moveToEndPos());


        }

        if (other.CompareTag("FireWork"))
        {
            fireWorksScript.shootFireworks();       

            

        }
    }

    
}
