using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveByJoystik : MonoBehaviour
{
    public Joystick joystik = null;
    public float speed = 9.0f;
    public Rigidbody rigidbody = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputMouvement = joystik.Direction;

        rigidbody.velocity = new Vector3(inputMouvement.x * speed, rigidbody.velocity.y, inputMouvement.y * speed);
    }


}
