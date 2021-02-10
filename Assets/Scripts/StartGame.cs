using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene(0);
    }
    public void creditsStart()
    {
        SceneManager.LoadScene(3);
    }
}
