using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HamburgerBaseFoodScript : BaseFoodScript
{
    //[SerializeField] private BaseFoodScriptableObject baseFoodScriptableObject;

    //[SerializeField] private string englishWord;

    //[SerializeField] GameObject trayAndPlateLocation;
    private CircleCollider2D baseFoodCircleCollider;

    //private Vector2 currentTouchPositionVector2InScreenPixels;
    //private Vector3 currentTouchPositionVector3InWorldUnits;

    //private Camera mainCamera;

    //private Vector2 startingPositionVector2;

    //[SerializeField] private Sprite baseFoodImage;
    //private SpriteRenderer baseFoodSpriteRenderer;
    //[SerializeField] private Sprite baseFoodImage2;
    //private SpriteRenderer baseFoodSpriteRenderer2;
    //[SerializeField] private Sprite topping1Image;
    //private SpriteRenderer topping1SpriteRenderer;
    //[SerializeField] private Sprite topping2Image;
    //private SpriteRenderer topping2SpriteRenderer;
    //[SerializeField] private Sprite topping3Image;
    //private SpriteRenderer topping3SpriteRenderer;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        
        baseFoodCircleCollider = gameObject.GetComponent<CircleCollider2D>();
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.playerSelectsBurgerEvent, HandlePlayerSelectsBaseFoodEvent);
    }

    private void OnValidate()
    {
        if (baseFoodScriptableObject != null)
        {
            englishWord = baseFoodScriptableObject.englishWord;

            baseFoodSpriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
            baseFoodSpriteRenderer2 = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
            topping1SpriteRenderer = gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>();
            topping2SpriteRenderer = gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>();
            topping3SpriteRenderer = gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>();

            baseFoodImage = baseFoodScriptableObject.baseFoodImage;
            baseFoodImage2 = baseFoodScriptableObject.baseFoodImage2;
            topping1Image = baseFoodScriptableObject.topping1Image;
            topping2Image = baseFoodScriptableObject.topping2Image;
            topping3Image = baseFoodScriptableObject.topping3Image;

            baseFoodSpriteRenderer.sprite = baseFoodImage;
            topping1SpriteRenderer.sprite = topping1Image;
            topping2SpriteRenderer.sprite = topping2Image;
            topping3SpriteRenderer.sprite = topping3Image;
        }
    }
    public override void Update()
    {
        
        if (Touchscreen.current == null) return; // avoid errors when testing with a mouse

        currentTouchPositionVector2InScreenPixels = Touchscreen.current.primaryTouch.position.ReadValue();

        currentTouchPositionVector3InWorldUnits = mainCamera.ScreenToWorldPoint(currentTouchPositionVector2InScreenPixels);

        //prevent the z coordinate from making the chef disappear
        currentTouchPositionVector3InWorldUnits = new Vector3(currentTouchPositionVector3InWorldUnits.x, currentTouchPositionVector3InWorldUnits.y, 0);

        if (!GameManagerScript.chefHasBurger && baseFoodCircleCollider.OverlapPoint(currentTouchPositionVector3InWorldUnits))
        {
            Debug.Log("should be calling player selects burger event");
            EventManagerScript.playerSelectsBurgerEvent.Invoke();
        }
    }

    public override void HandlePlayerSelectsBaseFoodEvent()
    {
        base.HandlePlayerSelectsBaseFoodEvent();
        GameManagerScript.chefHasBurger = true;
    }

    public override void ResetBaseFood()
    {
        base.ResetBaseFood();

        GameManagerScript.chefHasBurger = false;
        GameManagerScript.burgerHasLettuce = false;
        GameManagerScript.burgerHasTomatoe = false;
        GameManagerScript.burgerHasOnion = false;
    }

    public override void MoveToTray()
    {
        float burgerYPositionWithOffset = trayAndPlateLocation.transform.position.y + GameManagerScript.burgerBeingHeldYOffset;
        //burger.transform.position = new Vector3(burgerXPositionWithOffset, gameObject.transform.position.y, 0);
        gameObject.transform.position = new Vector3(trayAndPlateLocation.transform.position.x, burgerYPositionWithOffset, 0);     
    }
}
