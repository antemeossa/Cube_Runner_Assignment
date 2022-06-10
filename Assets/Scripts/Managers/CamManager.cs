using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{

    public float shakeDuration = 1f;

    public bool shake = false;

    public AnimationCurve shakeCurve;


    private static CamManager _instance;

    public static CamManager Instance
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



    private void Update()
    {
        if (shake)
        {
            shake = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPos = transform.position;
        float t = 0f;

        while (t < shakeDuration)
        {
            t += Time.deltaTime;
            float strength = shakeCurve.Evaluate(t / shakeDuration);
            transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPos;
    }


    public Transform endPos;
    

    public IEnumerator moveToEndPos()
    {
        float t=0;
        float desiredT = 3f;
        Transform startPos = transform;
        float y = 0;
        while (t < desiredT)
        {
            transform.position = Vector3.Lerp(startPos.position, endPos.position, t / desiredT);
            transform.rotation = Quaternion.Slerp(transform.rotation, endPos.rotation, t / desiredT);
            t += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos.position;

    }


}
