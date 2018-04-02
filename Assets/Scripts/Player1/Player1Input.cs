using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Input : MonoBehaviour
{
    public Camera player1Camera;

    public GameObject[] enemyTargets;
    public GameObject[] enemySelectHighlight;

    public GameObject beam;

    private int enemySelection;

    void Start()
    {
        Cursor.visible = true;

        FindEnemies();

        enemySelection = 0;

        enemySelectHighlight[enemySelection].GetComponent<MeshRenderer>().enabled = true;

        ForLoopEnemyHighlight();
    }


    void Update()
    {
        Shortcuts();

        EnemySelect();
        MouseLeftClick();

        Shoot();
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

    #region Networking: Finding Enemy Targets and Enemy Godrays
    void FindEnemies()
    {
        enemyTargets[0] = GameObject.Find("Target (Enemy 1)");
        enemyTargets[1] = GameObject.Find("Target (Enemy 2)");
        enemyTargets[2] = GameObject.Find("Target (Enemy 3)");

        enemySelectHighlight[0] = GameObject.Find("Godray 1");
        enemySelectHighlight[1] = GameObject.Find("Godray 2");
        enemySelectHighlight[2] = GameObject.Find("Godray 3");
    }
    #endregion

    #region Moving Enemies
    void MouseLeftClick()
    {
        RaycastHit clickedOn;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = player1Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out clickedOn))
            {
                Transform otherObject = clickedOn.transform;

                Debug.Log(clickedOn.point);

                if (otherObject.gameObject.name == "Street")
                {
                    enemyTargets[enemySelection].transform.position = clickedOn.point;
                }

                if (otherObject.gameObject.name == "Radar")
                {
                    enemyTargets[enemySelection].transform.position = new Vector3(clickedOn.point.x, 0.5f, clickedOn.point.z);
                }
            }
        }
    }
    #endregion

    #region Selecting the Enemy with Numbers
    void EnemySelect()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            enemySelection = 0;

            ForLoopEnemyHighlight();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            enemySelection = 1;

            ForLoopEnemyHighlight();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            enemySelection = 2;

            ForLoopEnemyHighlight();
        }
    }

    void ForLoopEnemyHighlight()
    {
        for (int i = 0; i < enemySelectHighlight.Length; i++)
        {
            enemySelectHighlight[i].GetComponent<MeshRenderer>().enabled = false;

            if (i == enemySelection)
            {
                enemySelectHighlight[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
    #endregion

    #region OrbitalStrike!
    void Shoot()
    {
        RaycastHit shotAt;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Ray ray = player1Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out shotAt))
            {
                //Transform shotWhere = shotAt.transform;

                Vector3 shotSpot = new Vector3(shotAt.point.x, 150.5f,shotAt.point.z);

                //Debug.Log(shotAt.point);

                Instantiate(beam, shotSpot, Quaternion.identity);

                /*if (otherObject.gameObject.name == "Street")
                {
                    enemyTargets[enemySelection].transform.position = clickedOn.point;
                }

                if (otherObject.gameObject.name == "Radar")
                {
                    enemyTargets[enemySelection].transform.position = new Vector3(clickedOn.point.x, 0.5f, clickedOn.point.z);
                }*/
            }
        }
    }
    #endregion
}
