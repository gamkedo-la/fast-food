using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class ChefMovement : MonoBehaviour
{
    /// <summary>
    /// Define how the chef will move
    /// </summary>

    #region Fields
    private Vector2 currentTouchPositionVector2InScreenPixels;
    private Vector3 currentTouchPositionVector3InWorldUnits;
    private Vector3 previousFramesTouchPositionVector3InWorldUnits;

    private Vector3 previousFrameTouchInputPosition;
    private Vector3 currentFrameTouchInputPosition;
    private float negligibleDeltaXRangeFromTouchInputForCameraFollow = 0.1f;
    private float negligibleDeltaXRangeFromTouchInputForTriggeringChefDrag = 0.1f;

    private float currentDeltaXFromTouchInput;

    private BoxCollider2D chefs2DBoxCollider;
    private Camera mainCamera;
    [SerializeField] GameObject burger;
    [SerializeField] GameObject burgerScriptablePrefab;

    [SerializeField] GameObject foodCounterTop;
    [SerializeField] GameObject customerCounterTop;

    #endregion

    #region Methods
    private void Start()
    {
        mainCamera = Camera.main;
        chefs2DBoxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        //for mobile build, turn on simulated touch input in Window -> Analysis -> Input Debugger
        #region Mobile Build
        Debug.Log("Touchscreen.current.primaryTouch.IsPressed()" + Touchscreen.current.primaryTouch.IsPressed());
        if (!Touchscreen.current.primaryTouch.IsPressed())
        {
            GameManagerScript.playerIsTouchingScreenBool = true;
            return;
        }
        if (Touchscreen.current.primaryTouch.IsPressed())
        {

            GameManagerScript.playerIsTouchingScreenBool = true;
        }
        else
        {
            GameManagerScript.playerIsTouchingScreenBool = false;
        }

        if (GameManagerScript.gameIsPaused)
        {
            return;
        }
        if (!GameManagerScript.playerIsTouchingScreenBool)
        {
            Debug.Log("player isn't touching screen");
            GameManagerScript.playerIsTouchingChef = false;
            GameManagerScript.playerIsDraggingChef = false;
            //currentTouchPositionVector3InWorldUnits = Vector3.zero;
            return;
        }


        currentTouchPositionVector2InScreenPixels = Touchscreen.current.primaryTouch.position.ReadValue();

        currentTouchPositionVector3InWorldUnits = mainCamera.ScreenToWorldPoint(currentTouchPositionVector2InScreenPixels);

        //prevent the z coordinate from making the chef disappear
        currentTouchPositionVector3InWorldUnits = new Vector3(currentTouchPositionVector3InWorldUnits.x, currentTouchPositionVector3InWorldUnits.y, 0);

        if (chefs2DBoxCollider.OverlapPoint(currentTouchPositionVector3InWorldUnits))
        {
            GameManagerScript.playerIsTouchingChef = true;
        }
        else
        {
            GameManagerScript.playerIsTouchingChef = false;
            GameManagerScript.playerIsDraggingChef = false;
            GameManagerScript.cameraShouldFollowChef = false;
        }

        if (GameManagerScript.playerIsTouchingChef)
        {
            if (foodCounterTop.GetComponent<BoxCollider2D>().OverlapPoint(currentTouchPositionVector3InWorldUnits) ||
                customerCounterTop.GetComponent<BoxCollider2D>().OverlapPoint(currentTouchPositionVector3InWorldUnits))
            {
                return;
            }

            gameObject.transform.position = currentTouchPositionVector3InWorldUnits;
            if (GameManagerScript.chefHasBurger)
            {
                float burgerXPositionWithOffset = gameObject.transform.position.x + GameManagerScript.burgerBeingHeldXOffset;
                burger.transform.position = new Vector3(burgerXPositionWithOffset, gameObject.transform.position.y, 0);
                burgerScriptablePrefab.transform.position = new Vector3(burgerXPositionWithOffset, gameObject.transform.position.y, 0);
            }
        }
        #endregion

        //    currentDeltaXFromTouchInput = Mathf.Abs(currentTouchPositionVector3InWorldUnits.x - previousFramesTouchPositionVector3InWorldUnits.x);
        //    if (GameManagerScript.playerIsTouchingChef && currentDeltaXFromTouchInput > negligibleDeltaXRangeFromTouchInputForTriggeringChefDrag)
        //    {
        //        Debug.Log("inside touching and dragging check");
        //        GameManagerScript.playerIsDraggingChef = true;
        //    }
        //    if (GameManagerScript.playerIsTouchingChef && GameManagerScript.playerIsDraggingChef)
        //    {
        //        gameObject.transform.position = currentTouchPositionVector3InWorldUnits;
        //        if (GameManagerScript.chefHasBurger)
        //        {
        //            float burgerXPositionWithOffset = gameObject.transform.position.x + GameManagerScript.burgerBeingHeldXOffset;
        //            burger.transform.position = new Vector3(burgerXPositionWithOffset, gameObject.transform.position.y, 0);
        //        }
        //    }

        //    if (GameManagerScript.playerIsDraggingChef = true && currentDeltaXFromTouchInput > negligibleDeltaXRangeFromTouchInputForCameraFollow)
        //    {
        //        GameManagerScript.cameraShouldFollowChef = true;
        //    }
        //    else
        //    {
        //        GameManagerScript.cameraShouldFollowChef = false;
        //    }
        //}

    }//end of update

    #region Itch Build
    private void OnMouseDrag()
    {
        //Vector2 mousePositionInScreenPixels = Input.mousePosition;
        //Vector2 mousePositionConvertedToWorldUnits = mainCamera.ScreenToWorldPoint(mousePositionInScreenPixels);

        ////if (GameManagerScript.playerIsTouchingChef)
        ////{
        //    if (foodCounterTop.GetComponent<BoxCollider2D>().OverlapPoint(mousePositionConvertedToWorldUnits) ||
        //        customerCounterTop.GetComponent<BoxCollider2D>().OverlapPoint(mousePositionConvertedToWorldUnits))
        //    {
        //        return;
        //    }
        //    gameObject.transform.position = mousePositionConvertedToWorldUnits;

        //    if (GameManagerScript.chefHasBurger)
        //    {
        //        float burgerXPositionWithOffset = gameObject.transform.position.x + GameManagerScript.burgerBeingHeldXOffset;
        //        burger.transform.position = new Vector3(burgerXPositionWithOffset, gameObject.transform.position.y, 0);
        //    }
            //}
    }
    #endregion //Itch build
    #endregion //Methods
}
