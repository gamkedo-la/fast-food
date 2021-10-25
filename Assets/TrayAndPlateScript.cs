using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrayAndPlateScript : MonoBehaviour
{

    private Camera mainCamera;
    private BoxCollider2D trayAndPlateBoxCollider;

    private Vector2 currentTouchPositionVector2InScreenPixels;
    private Vector3 currentTouchPositionVector3InWorldUnits;

    private Vector2 startingPositionVector2;

    [SerializeField] GameObject burgerScriptablePrefab;
    [SerializeField] GameObject chickenDonerScriptablePrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        trayAndPlateBoxCollider = gameObject.GetComponent<BoxCollider2D>();

        startingPositionVector2 = gameObject.transform.position;

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, HandleAnyOrderSubmissionEvent);
    }

    //Update is called once per frame
    void Update()
    {
        if (Touchscreen.current == null) return; // avoid errors when testing with a mouse
        
        currentTouchPositionVector2InScreenPixels = Touchscreen.current.primaryTouch.position.ReadValue();

        currentTouchPositionVector3InWorldUnits = mainCamera.ScreenToWorldPoint(currentTouchPositionVector2InScreenPixels);

        //prevent the z coordinate from making the chef disappear
        currentTouchPositionVector3InWorldUnits = new Vector3(currentTouchPositionVector3InWorldUnits.x, currentTouchPositionVector3InWorldUnits.y, 0);

        if (trayAndPlateBoxCollider.OverlapPoint(currentTouchPositionVector3InWorldUnits))
        {
            gameObject.transform.position = currentTouchPositionVector3InWorldUnits;

            if (GameManagerScript.chefHasBurger)
            {
                float burgerYPositionWithOffset = gameObject.transform.position.y + GameManagerScript.burgerBeingHeldYOffset;
                //burger.transform.position = new Vector3(burgerXPositionWithOffset, gameObject.transform.position.y, 0);
                burgerScriptablePrefab.transform.position = new Vector3(gameObject.transform.position.x, burgerYPositionWithOffset, 0);
            }
            else if (GameManagerScript.chefHasChickenDoner)
            {
                float chickenDonerYPositionWithOffset = gameObject.transform.position.y + GameManagerScript.chickenDonerBeingHeldYOffset;
                chickenDonerScriptablePrefab.transform.position = new Vector3(gameObject.transform.position.x, chickenDonerYPositionWithOffset, 0);
            }
        }
    }

    private void HandleAnyOrderSubmissionEvent()
    {
        gameObject.transform.position = startingPositionVector2;
    }
    //Itch
    //private void OnMouseDrag()
    //{
    //    Vector2 mousePositionInScreenPixels = Input.mousePosition;
    //    Vector2 mousePositionConvertedToWorldUnits = mainCamera.ScreenToWorldPoint(mousePositionInScreenPixels);

    //    //if (GameManagerScript.playerIsTouchingChef)
    //    //{
    //    //if ( customerCounterTop.GetComponent<BoxCollider2D>().OverlapPoint(mousePositionConvertedToWorldUnits) )
    //    //{
    //    //    return;
    //    //}
    //    gameObject.transform.position = mousePositionConvertedToWorldUnits;

    //    if (GameManagerScript.chefHasBurger)
    //    {
    //        float burgerXPositionWithOffset = gameObject.transform.position.x + GameManagerScript.burgerBeingHeldXOffset;
    //        //burger.transform.position = new Vector3(burgerXPositionWithOffset, gameObject.transform.position.y, 0);
    //        burgerScriptablePrefab.transform.position = new Vector3(burgerXPositionWithOffset, gameObject.transform.position.y, 0);
    //    }
    //}
}
