using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    bool isPressed;
    SpriteRenderer spriteR;
    public Sprite Button;
    public Sprite ButtonPressed;
    public Sprite ButtonPress1;
    public Sprite ButtonPress2;
    public GameObject door;
    public int pressWeight;
    public void SetPressed(int weight)
    {
        pressWeight += weight;
    }
    public int getWeight()
    {
        return pressWeight;
    }
    private void Start()
    {
        spriteR = GetComponentInChildren<SpriteRenderer>();
        pressWeight = 0;
    }
    private void Update()
    {
            switch (pressWeight)
            {
                case 0:
                        spriteR.sprite = Button;
                        door.gameObject.SetActive(true);
                    break;
                case 1:
                        spriteR.sprite = ButtonPress1;
                    break;
                case 2:
                        spriteR.sprite = ButtonPress2;
                    break;
                case 3:
                        spriteR.sprite = ButtonPressed;
                        door.gameObject.SetActive(false);
                    break;
                case 4:
                    spriteR.sprite = ButtonPressed;
                    door.gameObject.SetActive(false);
                    break;
                default:
                        spriteR.sprite = Button;
                        door.gameObject.SetActive(true);
                    break;
            }
    }
}
