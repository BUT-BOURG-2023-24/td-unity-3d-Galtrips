using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class SpawnCubeOnMouseClick : MonoBehaviour
{
    public InputActionReference clickInputRef = null;
    public LayerMask layerMask;
    public GameObject cubePrefab = null;
    public Joystick joystik = null;

    private float spawnHeightOffset = 0.5f;

    private void OnEnable()
    {
        clickInputRef.action.performed += onClick;

        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();

        EnhancedTouch.Touch.onFingerDown += OnFingerDown;
    }

    private void OnDisable()
    {
        clickInputRef.action.performed -= onClick;
        //EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.TouchSimulation.Disable();

        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
    }

    private void onClick(InputAction.CallbackContext obj)
    {
        //spawnCube(Input.mousePosition);
    }

    private void OnFingerDown(EnhancedTouch.Finger finger)
    {
        RectTransform joystikCoord = (joystik.transform as RectTransform);

        if (finger.screenPosition.x > joystikCoord.offsetMin.x && finger.screenPosition.x < joystikCoord.offsetMax.x
                       && finger.screenPosition.y > joystikCoord.offsetMin.y && finger.screenPosition.y < joystikCoord.offsetMax.y)
        {
            return;
        }

        spawnCube(finger.screenPosition);
    }

    private void spawnCube(Vector2 screenPosition)
    {
        Vector3 mousePosition = screenPosition;
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
