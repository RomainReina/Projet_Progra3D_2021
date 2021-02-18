using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Rigidbody playerRigidbody;
    
    [SerializeField] private float movementSpeed = 0.5f;
    [SerializeField] private float cameraSensibility = 10;
    private float yawn;
    private float pitch;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MoveCamera();
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        if (horizontalAxis > 0.05f || verticalAxis > 0.05f )
        {
            // cache calcule des vecteurs avant et Droit
            Vector3 cameraRight = cameraTransform.right;
            Vector3 cameraForward = cameraTransform.forward;

            // Calcul du deplacement du joueur
            Vector3 deltaPosition =
                new Vector3(cameraRight.x, 0f, cameraRight.z) * horizontalAxis
                + new Vector3(cameraForward.x, 0f, cameraForward.z) * verticalAxis;

            // deplacement du joueur
            deltaPosition.Normalize();
            playerRigidbody.MovePosition(playerRigidbody.position + deltaPosition * movementSpeed);
        }
    }

    private void MoveCamera()
    {
        // Calcul du rotation de la camera
        yawn += Input.GetAxis("Mouse X") * cameraSensibility;
        pitch -= Input.GetAxis("Mouse Y") * cameraSensibility;
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        //rotation de la camera
        cameraTransform.localEulerAngles = new Vector3(
            pitch,
            yawn,
            0f);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            Debug.Log("Bullet Hit");
        }
    }
}