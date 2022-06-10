using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetMovement : MonoBehaviour
{
    void Update()
    {
            moveRoad(GameManager.Instance.forwardSpeed);
        
    }

    private void moveRoad(float movementSpeed)
    {

        transform.position -= new Vector3(0, 0, movementSpeed);
    }
}
