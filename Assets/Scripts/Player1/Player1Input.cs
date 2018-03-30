using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Input : MonoBehaviour
{
    public Camera player1Camera;

    public GameObject enemy1Target;

    public Transform moveTo;

    void Start()
    {
        Cursor.visible = true;
    }


    void Update()
    {
        MouseLeftClick();
    }

    void MouseLeftClick()
    {
        RaycastHit clickedOn; // to identify what our raycast hits

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Player1 Clicks!");

            Ray ray = player1Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out clickedOn))
            {
                Transform otherObject = clickedOn.transform;

                if (otherObject.gameObject.name == "Street")
                {
                    Debug.Log(clickedOn.point);

                    enemy1Target.transform.position = clickedOn.point;
                }
            }
        }
    }
}
