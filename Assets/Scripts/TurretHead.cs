using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHead : MonoBehaviour
{
    private Quaternion rotation;
    float speed;
    public BunnyController target;
    private void Update()
    {
       
    }
    private void Awake()
    {

    }
    public Quaternion getRotation()
    {
        rotation = this.transform.rotation;
        return rotation;
    }

    public void turnTowardsPlayer(BunnyController target)
    {
        Vector3 diff = transform.position - target.transform.position;

        diff.Normalize();

        float rot_Z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rot_Z);
    }

    
}
