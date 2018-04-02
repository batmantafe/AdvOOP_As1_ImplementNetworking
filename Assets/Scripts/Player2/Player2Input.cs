using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Player2Input : NetworkBehaviour
{
    public GameObject body;

    private MouseLook player2MouseLook;
    private Movement player2Movement;
    private Vector3 spawn1;

    private Player1Input player1Input;

    void Start()
    {
        LocalPlayerStartSetup();
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

    #region Local Player's Start Setup
    void LocalPlayerStartSetup()
    {
        Cursor.visible = false;

        AudioListener audioListener = GetComponentInChildren<AudioListener>();
        Camera camera = GetComponentInChildren<Camera>();

        player2MouseLook = GetComponent<MouseLook>();
        player2Movement = GetComponent<Movement>();

        spawn1 = new Vector3(5,2,0);

        if (isLocalPlayer)
        {
            camera.enabled = true;
            audioListener.enabled = true;

            
        }

        if (!isLocalPlayer)
        {
            camera.enabled = false;
            audioListener.enabled = false;
        }

        // IF this Player starts at Player 1's position
        if (transform.position == spawn1)
        {
            Cursor.visible = true;

            player2MouseLook.enabled = false;
            player2Movement.enabled = false;

            body.GetComponent<MeshRenderer>().enabled = false;
            body.GetComponent<SphereCollider>().enabled = false;

            CharacterController charCont = GetComponent<CharacterController>();
            charCont.enabled = false;

            transform.position = new Vector3(8,300,0);
            transform.Rotate(90,0,180);

            camera.orthographic = true;
            camera.orthographicSize = 91;

            player1Input = GetComponent<Player1Input>();
            player1Input.enabled = true;
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
