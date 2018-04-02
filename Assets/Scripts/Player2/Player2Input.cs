using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Player2Input : NetworkBehaviour
{
    void Start()
    {
        Cursor.visible = false;

        AudioListener audioListener = GetComponentInChildren<AudioListener>();
        Camera camera = GetComponentInChildren<Camera>();

        if (isLocalPlayer)
        {
            camera.enabled = true;
            audioListener.enabled = true;
        }
        else
        {
            camera.enabled = false;
            audioListener.enabled = false;
        }

    }

    void Update()
    {
        if (isLocalPlayer)
        {
            Shortcuts();


        }
    }

    #region Shortcuts
    void Shortcuts()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Game");
        }
    }
    #endregion

    #region OnTrigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.transform.parent.gameObject.SetActive(false);
        }
    }
    #endregion
}
