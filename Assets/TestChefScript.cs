using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestChefScript : MonoBehaviour
{
    #region Fields

    private Vector2 touchInputCoordinatesInScreenPixels;
    private Vector2 touchInputCoordinatesInWorldUnits;
    [SerializeField] private Camera mainCamera;

    #endregion
    

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current.primaryTouch.IsPressed())
        {
            touchInputCoordinatesInScreenPixels = Touchscreen.current.primaryTouch.position.ReadValue();
            touchInputCoordinatesInWorldUnits = mainCamera.ScreenToWorldPoint(touchInputCoordinatesInScreenPixels);
            Debug.Log("touchInputCoordinatesInWorldUnits: " + touchInputCoordinatesInWorldUnits);
            gameObject.transform.position = touchInputCoordinatesInWorldUnits;
        }
    }
}
