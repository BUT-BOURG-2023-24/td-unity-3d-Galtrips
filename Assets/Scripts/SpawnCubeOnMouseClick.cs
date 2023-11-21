using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCubeOnMouseClick : MonoBehaviour
{
    public InputActionReference clickInputRef = null;
    public LayerMask layerMask;
    public GameObject cubePrefab = null;

    private float spawnHeightOffset = 0.5f;

    private void OnEnable()
    {
        clickInputRef.action.performed += onClick;
    }

    private void OnDisable()
    {
        clickInputRef.action.performed -= onClick;
    }

    private void onClick(InputAction.CallbackContext obj)
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        
        //Debug.DrawRay(ray.origin, ray.direction, Color.blue, 100.0f);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1000f, layerMask))
        {
            Vector3 spawnpoint = hitInfo.point;
            spawnpoint.y += spawnHeightOffset;
            GameObject cube = GameObject.Instantiate(cubePrefab, spawnpoint, Quaternion.identity);

        }

    }
}
