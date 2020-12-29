using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))] 
public class PlayerController : MonoBehaviour
{
    Camera cam;

    // to avoid walking on non-walkable objects

    public LayerMask movementMask;

    PlayerMotor motor;



    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                Debug.Log("Left mouse hit:  " + hit.collider.name + " " + hit.point);

                motor.MoveToPoint(hit.point);
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("Right mouse hit:  " + hit.collider.name + " " + hit.point);

                // check if we hit an interactive object. Set as focus.
            }
        }
    }
}
