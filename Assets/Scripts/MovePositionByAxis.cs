using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionByAxis : MonoBehaviour
{
    public float speed = 9.0f;
    public bool useRawAxis = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = useRawAxis ? Input.GetAxisRaw("Horizontal") : Input.GetAxis("Horizontal");
        float zAxis = useRawAxis ? Input.GetAxisRaw("Vertical") : Input.GetAxis("Vertical");

        //Debug.Log("x : " + horizontalInputValue + " z: " + verticalInputValue);
        transform.position += new Vector3(xAxis, 0.0f, zAxis) * speed * Time.deltaTime;
    }
}
