using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHead : MonoBehaviour
{
    private Quaternion rotation;
    private void Update()
    {
        
    }

    public Quaternion getRotation()
    {
        rotation = transform.rotation;
        return rotation;
    }
}
