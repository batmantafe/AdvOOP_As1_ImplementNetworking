using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private int playerChosen;

    // Use this for initialization
    void Start()
    {
        GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetPlayer()
    {
        playerChosen = PlayerPrefs.GetInt("Player");

        switch (playerChosen)
        {
            case 1:
                player2.SetActive(false);
                break;

            case 2:
                player1.SetActive(false);
                break;
        }
    }
}
