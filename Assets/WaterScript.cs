using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaterScript : MonoBehaviour
{
    private BoxCollider2D myBoxCollider;
    private Camera mainCamera;

    private Vector2 currentTouchPositionVector2InScreenPixels;
    private Vector3 currentTouchPositionVector3InWorldUnits;

    private Vector2 startingPositionVector2;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        myBoxCollider = GetComponent<BoxCollider2D>();
        startingPositionVector2 = gameObject.transform.position;

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpWaterEvent, HandleChefPicksMeUpEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, ResetMeAfterSubmission);

        if (GameManagerScript.currentLevel < 5)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Android)
        {
            HandleItchInput();
        }
        else if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Itch)
        {
            HandleAndroidInput();
        }
    }

    private void HandleAndroidInput()
    {
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Android)
        {
            return;
        }
        if (Touchscreen.current == null) return; // avoid errors when testing with a mouse

        currentTouchPositionVector2InScreenPixels = Touchscreen.current.primaryTouch.position.ReadValue();

        currentTouchPositionVector3InWorldUnits = mainCamera.ScreenToWorldPoint(currentTouchPositionVector2InScreenPixels);

        //prevent the z coordinate from making the chef disappear
        currentTouchPositionVector3InWorldUnits = new Vector3(currentTouchPositionVector3InWorldUnits.x, currentTouchPositionVector3InWorldUnits.y, 0);

        if (myBoxCollider.OverlapPoint(currentTouchPositionVector3InWorldUnits))
        {
            EventManagerScript.chefPicksUpWaterEvent.Invoke();
        }
    }
    private void HandleItchInput()
    {
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Itch)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (myBoxCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                EventManagerScript.chefPicksUpWaterEvent.Invoke();
            }
        }
    }
    private void HandleChefPicksMeUpEvent()
    {
        GameManagerScript.chefHasWater = true;
        GameObject drinkLocation = GameObject.FindGameObjectWithTag("DrinkLocation");
        gameObject.transform.position = new Vector3(drinkLocation.transform.position.x, drinkLocation.transform.position.y, 0);
    }

    private void ResetMeAfterSubmission()
    {
        gameObject.transform.position = startingPositionVector2;
        GameManagerScript.chefHasWater = false;
    }
}
