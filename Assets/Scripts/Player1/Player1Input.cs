using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Input : MonoBehaviour
{
    public Camera player1Camera;

    public GameObject[] enemyTargets;

    private int enemySelection;

    void Start()
    {
        Cursor.visible = true;

        enemySelection = 0;
    }


    void Update()
    {
        Shortcuts();

        EnemySelect();
        MouseLeftClick();
    }

    #region Shortcuts
    void Shortcuts()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Game");
        }
    }
    #endregion

    void MouseLeftClick()
    {
        RaycastHit clickedOn; // to identify what our raycast hits

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = player1Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out clickedOn))
            {
                Transform otherObject = clickedOn.transform;

                if (otherObject.gameObject.name == "Street")
                {
                    Debug.Log(clickedOn.point);

                    enemyTargets[enemySelection].transform.position = clickedOn.point;
                }
            }
        }
    }

    void EnemySelect()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            enemySelection = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            enemySelection = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            enemySelection = 2;
        }
    }
}
