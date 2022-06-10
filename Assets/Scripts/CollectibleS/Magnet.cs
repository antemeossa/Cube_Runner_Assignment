using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

    public IEnumerator countdown()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
