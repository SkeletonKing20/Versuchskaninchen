using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHead : MonoBehaviour
{
    private Quaternion rotation;
    public BunnyController target;
    public float offset;
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 diff = transform.position - target.getPosition();

            diff.Normalize();

            float rot_Z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rot_Z - offset);
        }
    }

    public Quaternion getRotation()
    {
        rotation = transform.rotation;
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
