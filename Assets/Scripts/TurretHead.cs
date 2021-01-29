using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHead : MonoBehaviour
{
    private Quaternion rotation;
    private void Awake()
    {
    }

    public Quaternion getRotation()
    {
        rotation = this.transform.rotation;
        return rotation;
    }

    public void setRotation(float input)
    {
        transform.Rotate(0, 0, input, Space.Self);
    }
}
