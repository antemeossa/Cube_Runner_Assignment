using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorksScript : MonoBehaviour
{
    public ParticleSystem[] fireworks;
    void Start()
    {
        
    }

    public void shootFireworks()
    {
        for (int i = 0; i < fireworks.Length; i++)
        {
            fireworks[i].Play();
        }
    }
      
    
}
