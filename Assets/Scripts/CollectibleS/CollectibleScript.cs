using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    [SerializeField]
    public ParticleSystem coinParticles;
    public ParticleSystem hpParticles;
    public ParticleSystem magnetParticles;
    public GameObject mesh;
    public int value;

    
    

    public void playCoinParticles()
    {
        coinParticles.Play();
    }

    public void playHpParticles()
    {
        hpParticles.Play();
    }

    public void playMagnetParticles()
    {
        magnetParticles.Play();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), 5f * Time.deltaTime);
        }
    }

}
