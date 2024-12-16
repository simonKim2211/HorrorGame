using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 4f;

    // Update is called once per frame
    void Update()
    {   
        //Grabbing input from the keyboard
        //***NOTE UNITY HAS INBUILT VALUES FOR HORIZONTAL AND VERTICAL I.E. -1 AND 1
        // VERTICAL = 1 INDICATES W IS PRESSED, -1 INDICATES S
        // HORIZONTAL = 1 INDICATES D IS PRESSED, -1 INDICATES A

        float x = Input.GetAxis("Horizontal"); //left/right
        float z = Input.GetAxis("Vertical"); //forward/backward

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
