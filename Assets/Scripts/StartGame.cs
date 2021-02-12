using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    Vector3 initialPosition;
    public Vector3 targetPosition;
    bool start;
    bool credits;
    private void Start()
    {
        initialPosition = transform.position;
        start = true;
        credits = false;
    }

    private void Update()
    {
        switch (Input.GetAxisRaw("Vertical"))
        {
            case 1:
                transform.position = initialPosition;
                start = true;
                credits = false;
                break;
            case -1:
                transform.position = targetPosition;
                credits = true;
                start = false;
                break;
            default:
                transform.position = transform.position;
                break;
        }

        if (start && (Input.GetButtonDown("Jump")|| Input.GetKeyDown(KeyCode.Return)))
        {
            gameStart();
        }
        else if (credits && (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Return)))
        {
            creditsStart();
        }
    }
    public void gameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void creditsStart()
    {
        SceneManager.LoadScene(3);
    }
}
