using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class TrayAndPlateScript : MonoBehaviour
{

    private Camera mainCamera;
    private BoxCollider2D trayAndPlateBoxCollider;

    private Vector2 currentTouchPositionVector2InScreenPixels;
    private Vector3 currentTouchPositionVector3InWorldUnits;

    public Vector3 startingPositionVector3;

    [SerializeField] GameObject burgerScriptablePrefab;
    [SerializeField] GameObject chickenDonerScriptablePrefab;
    [SerializeField] GameObject beer;
    [SerializeField] GameObject redWine;
    [SerializeField] GameObject whiteWine;
    [SerializeField] GameObject water;

    [SerializeField] GameObject drinkLocation;

    [SerializeField] GameObject trayAndPlateStartingLocationGameObject;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        trayAndPlateBoxCollider = gameObject.GetComponent<BoxCollider2D>();

        burgerScriptablePrefab = GameObject.FindGameObjectWithTag("BurgerPrefab");
        chickenDonerScriptablePrefab = GameObject.FindGameObjectWithTag("ChickenDonerScriptablePrefab");
        beer = GameObject.FindGameObjectWithTag("Beer");
        redWine = GameObject.FindGameObjectWithTag("RedWine");
        whiteWine = GameObject.FindGameObjectWithTag("WhiteWine");
        water = GameObject.FindGameObjectWithTag("Water");

        startingPositionVector3 = gameObject.transform.position;

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, HandleAnyOrderSubmissionEvent);
    }

    //Update is called once per frame
    void Update()
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

            if (GameManagerScript.chefHasBeer)
            {
                beer.transform.position = new Vector3(drinkLocation.transform.position.x, drinkLocation.transform.position.y, 0);
            }
            else if (GameManagerScript.chefHasRedWine)
            {
                redWine.transform.position = new Vector3(drinkLocation.transform.position.x, drinkLocation.transform.position.y, 0);
            }
            else if (GameManagerScript.chefHasWhiteWine)
            {
                whiteWine.transform.position = new Vector3(drinkLocation.transform.position.x, drinkLocation.transform.position.y, 0);
            }
            else if (GameManagerScript.chefHasWater)
            {
                water.transform.position = new Vector3(drinkLocation.transform.position.x, drinkLocation.transform.position.y, 0);
            }
        }
    }

    private void HandleAnyOrderSubmissionEvent()
    {
        GameManagerScript.chefHasBaseFood = true;
        Destroy(gameObject);
    }
    //Itch
    private void OnMouseDrag()
    {
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Itch)
        {
            return;
        }

        Vector2 mousePositionInScreenPixels = Input.mousePosition;
        Vector2 mousePositionConvertedToWorldUnits = mainCamera.ScreenToWorldPoint(mousePositionInScreenPixels);

        //if (GameManagerScript.playerIsTouchingChef)
        //{
        //if ( customerCounterTop.GetComponent<BoxCollider2D>().OverlapPoint(mousePositionConvertedToWorldUnits) )
        //{
        //    return;
        //}
        gameObject.transform.position = mousePositionConvertedToWorldUnits;


        if (GameManagerScript.chefHasBurger)
        {
            float burgerYPositionWithOffset = gameObject.transform.position.y + GameManagerScript.burgerBeingHeldYOffset;
            //burger.transform.position = new Vector3(burgerXPositionWithOffset, gameObject.transform.position.y, 0);
            burgerScriptablePrefab.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.0f, 0);
        }
        else if (GameManagerScript.chefHasChickenDoner)
        {
            chickenDonerScriptablePrefab.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        }

        if (GameManagerScript.chefHasBeer)
        {
            beer.transform.position = new Vector3(drinkLocation.transform.position.x, drinkLocation.transform.position.y, 0);
        }
        else if (GameManagerScript.chefHasRedWine)
        {
            redWine.transform.position = new Vector3(drinkLocation.transform.position.x, drinkLocation.transform.position.y, 0);
        }
        else if (GameManagerScript.chefHasWhiteWine)
        {
            whiteWine.transform.position = new Vector3(drinkLocation.transform.position.x, drinkLocation.transform.position.y, 0);
        }
        else if (GameManagerScript.chefHasWater)
        {
            water.transform.position = new Vector3(drinkLocation.transform.position.x, drinkLocation.transform.position.y, 0);
        }
    }
}
