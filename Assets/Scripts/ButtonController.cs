using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    bool isPressed;
    SpriteRenderer spriteR;
    public Sprite Button;
    public Sprite ButtonPressed;
    public GameObject door;
    public void SetPressed(bool press)
    {
        Debug.Log("worked");
        isPressed = press;
    }
    private void Start()
    {
        spriteR = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if(isPressed)
        {
            spriteR.sprite = ButtonPressed;
            door.gameObject.SetActive(false);
        }
        else
        {
            spriteR.sprite = Button;
            door.gameObject.SetActive(true);
        }
    }
}
