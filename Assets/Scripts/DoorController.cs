using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public AudioClip clip;
    public GameObject UICard;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        UICard.SetActive(true);
        AudioSource.PlayClipAtPoint(clip, transform.position);
        this.gameObject.SetActive(false);
    }
}
