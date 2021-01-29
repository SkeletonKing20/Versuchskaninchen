using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHead : MonoBehaviour
{
    private Quaternion rotation;
    float speed;
    public Transform target;
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

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("yep");
        var step = speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yep");
        var step = speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
    }
}
