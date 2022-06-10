using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Vector3 firstPos;
    private Vector3 lastPos;
    private Vector3 pos;

    

    private float distance;
    
    [SerializeField]
    private float playerSpeed;

    private void Start()
    {
        pos = transform.position;
        
    }

    void Update()
    {
        if (!GameManager.Instance.gameOverBool )
        {
            

            if (Input.GetMouseButtonDown(0)) //first input
            {
                firstPos = Input.mousePosition;
                

            }
            else if (Input.GetMouseButton(0))
            {

                lastPos = Input.mousePosition;
                distance = lastPos.x - firstPos.x;

                transform.Translate(distance * Time.deltaTime * playerSpeed, 0, 0);
            }

            if (Input.GetMouseButtonUp(0)) //when there is input
            {
                firstPos = Vector3.zero;
                lastPos = Vector3.zero;
            }

            pos = transform.position;
            pos.x = Mathf.Clamp(transform.position.x, -1.55f, 1.55f);
            transform.position = pos;
        }
        else
        {
            playerSpeed = 0;
        }
        
    }
}
