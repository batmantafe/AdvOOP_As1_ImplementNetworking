using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }

    public void Player1Button()
    {
        PlayerPrefs.SetInt("Player", 1);

        SceneManager.LoadScene("Game");
    }

    public void Player2Button()
    {
        PlayerPrefs.SetInt("Player", 2);

        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
