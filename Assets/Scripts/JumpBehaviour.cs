using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpBehaviour : MonoBehaviour
{
    public float jumpForce = 50.0f;
    public InputActionReference jumpInputRef = null;
    public Rigidbody rigidbody = null;
    public GameObject groundObject = null;

    public bool isGrounded { get; private set; } = true;

    private void OnEnable()
    {
        jumpInputRef.action.performed += onJumpInputPressed;
    }

    private void OnDisable()
    {
        jumpInputRef.action.performed -= onJumpInputPressed;
    }
    private void Update()
    {
    }

    private void onJumpInputPressed(InputAction.CallbackContext obj)
    {
        Jump();
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject == groundObject)
        //{
            //GameObject de Terrain
            isGrounded = true;

            //Ou Ajouter layer dans Project Settings -> Physics -> Layer Collision Matrix et ajouter le layer dans le gameObject
            //Va Trigger seulement si le gameObject est dans le layer
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //Tags dans Terrain
        //if (other.gameObject.CompareTag("Ground"))
        //{
            isGrounded = false;
        //}
    }
}
