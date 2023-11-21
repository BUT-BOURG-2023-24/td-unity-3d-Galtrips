using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionByKeys : MonoBehaviour

{

    public float speed = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputMouvement = Vector3.zero;
        if(Input.GetKey(KeyCode.UpArrow)) {
            inputMouvement.z = 1.0f;
        } 
        if (Input.GetKey(KeyCode.DownArrow)) {
            inputMouvement.z = -1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            inputMouvement.x = -1.0f;
        } 
        if (Input.GetKey(KeyCode.RightArrow)) {
            inputMouvement.x = 1.0f;
        }

        transform.position += inputMouvement * speed * Time.deltaTime;
    }
}
