using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MoveByVelocity : MonoBehaviour
{
    public float speed = 9.0f;
    public InputActionReference moveInputRef = null;
    public Rigidbody rigidbody = null; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputMouvement = moveInputRef.action.ReadValue<Vector2>();

        rigidbody.velocity = new Vector3(inputMouvement.x * speed, rigidbody.velocity.y, inputMouvement.y * speed);
    }
}
