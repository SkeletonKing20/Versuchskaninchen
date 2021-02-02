using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    float yCoordinate;
    void Awake()
    {
        yCoordinate = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (transform.position.y != yCoordinate - 1.68)
        {
          //  transform.position *= Vector3.
        }
    }
}
