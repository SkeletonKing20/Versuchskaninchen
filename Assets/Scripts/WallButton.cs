using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    SpriteRenderer spriteR;
    public Sprite pressedWallButton;
    Sprite initialButton;
    public bool isPressed;
    float coolDown;
    public static GameObject button1;
    private void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        initialButton = spriteR.sprite;
        isPressed = false;
        button1 = GameObject.Find("WallButton");
    }

    private void Update()
    {
        if(isPressed)
        {
            spriteR.sprite = pressedWallButton;
        }
        else
        {
            spriteR.sprite = initialButton;
        }
    }

    public Sprite getSprite()
    {
        return spriteR.sprite;
    }

    public void setSprite(Sprite spriteN)
    {
        spriteR.sprite = spriteN;
    }

    public static void setPressed()
    {
        if (button1.gameObject.GetComponent<WallButton>().isPressed == true)
        {
            button1.gameObject.GetComponent<WallButton>().isPressed = false;
        }
        else
        {
            button1.gameObject.GetComponent<WallButton>().isPressed = true;
        }
    }
}
