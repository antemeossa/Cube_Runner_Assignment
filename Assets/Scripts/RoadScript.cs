using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private GameObject collectible1;
    [SerializeField]
    private GameObject collectible2;
    [SerializeField]
    private GameObject hpCollectible;
    [SerializeField]
    private GameObject magnet;

    [SerializeField]
    private Transform[] collectiblePos1;
    [SerializeField]
    private Transform[] collectiblePos2;
    [SerializeField]
    private Transform[] obstaclePos;

    public List<GameObject> spawnedCollectibles1;
    public List<GameObject> spawnedCollectibles2;
    private List<GameObject> spawnedObstacles;


    private void Start()
    {
        

        spawnedCollectibles1 = new List<GameObject>();
        spawnedCollectibles2 = new List<GameObject>();
        spawnedObstacles = new List<GameObject>();

        setCollectibles();
        obstacleSpawner();
    }
    

    private void setCollectibles()
    {
        int random = Random.Range(0, 3);
        int hpRnd = Random.Range(0, 9);
        if(random == 0)
        {
            for (int i = 0; i < collectiblePos1.Length; i++)
            {
                if(hpRnd == 8)
                {
                    objectSpawner(hpCollectible, collectiblePos1, spawnedCollectibles1);
                }
                else
                {
                    objectSpawner(collectible1, collectiblePos1, spawnedCollectibles1);
                }
                
                
            }
            for (int i = 0; i < collectiblePos2.Length; i++)
            {                                
                objectSpawner(collectible2, collectiblePos2, spawnedCollectibles2);
            }
        }
        else if (random > 0)
        {

            for (int i = 0; i < collectiblePos2.Length; i++)
            {
                if (hpRnd == 8)
                {
                    objectSpawner(hpCollectible, collectiblePos2, spawnedCollectibles1);
                }
                else
                {
                    objectSpawner(collectible1, collectiblePos2, spawnedCollectibles1);
                }
            }
            for (int i = 0; i < collectiblePos1.Length; i++)
            {
                objectSpawner(collectible2, collectiblePos1, spawnedCollectibles2);
            }
        }
        
    }


    private void objectSpawner(GameObject obj, Transform[] transformArr, List<GameObject> objList)
    {
        for (int i = 0; i < transformArr.Length; i++)
        {
            GameObject spawnedObj = Instantiate(obj, transformArr[i].position, Quaternion.identity);
            spawnedObj.transform.SetParent(gameObject.transform);
            objList.Add(spawnedObj);
            spawnedObj.SetActive(false);
        }

        int random = Random.Range(0, 4);
        //Debug.Log(random);
        if (random == 0)
        {
            objList[0].SetActive(true);
            objList[1].SetActive(false);
            objList[2].SetActive(false);

        }
        else if (random == 1)
        {
            objList[0].SetActive(false);
            objList[1].SetActive(true);
            objList[2].SetActive(false);

        }
        else if(random == 2)
        {
            objList[0].SetActive(false);
            objList[1].SetActive(false);
            objList[2].SetActive(true);

        }
        else
        {
            objList[0].SetActive(false);
            objList[1].SetActive(false);
            objList[2].SetActive(false);

        }
    }
    private void obstacleSpawner()
    {

        
            objectSpawner(obstacle, obstaclePos, spawnedObstacles);
        
       

    }

    private void collectibleSpawner()
    {
        int random = Random.Range(0, 2);

        
    }
}
