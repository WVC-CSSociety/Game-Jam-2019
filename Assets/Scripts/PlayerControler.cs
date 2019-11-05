﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public CharacterController myController;

    public float rotationSpeed = 1;

    public float speed = 1;
    public float jumpIntensity = 1;
    public float gravity = 50;

    [HideInInspector]
    public float verticalVelocity;

    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        if (myController == null) myController = gameObject.GetComponent<CharacterController>();
        if (myController == null) myController = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        var xValue = Input.GetAxis("Horizontal");
        var zValue = Input.GetAxis("Vertical");

        var rotateValue = Input.GetAxis("Strafe");

        var jumping = Input.GetAxis("Jump");

        if(jumping > 0)
        {
            if (myController.isGrounded)
            {
                verticalVelocity = 0;
                verticalVelocity += jumping * jumpIntensity;
            }
        }

        myController.Move(new Vector3(xValue * speed * deltaTime, verticalVelocity, zValue * speed * deltaTime));

        Debug.Log("rotateValue: " + rotateValue);
        myController.transform.Rotate(new Vector3(0, rotateValue * rotationSpeed, 0));

        //if (verticalVelocity > 0)
        {
            verticalVelocity -= gravity * deltaTime;
            //if (verticalVelocity < 0) verticalVelocity = 0;
        }

        //Ground detection
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, groundMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}