using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseFoodScript : MonoBehaviour
{
    #region Fields

    [SerializeField] private BaseFoodScriptableObject baseFoodScriptableObject;

    [SerializeField] private string englishWord;

    private Vector2 startingPositionVector2;

    [SerializeField] private Sprite baseFoodImage;
    private SpriteRenderer baseFoodSpriteRenderer;
    [SerializeField] private Sprite baseFoodImage2;
    private SpriteRenderer baseFoodSpriteRenderer2;
    [SerializeField] private Sprite topping1Image;
    private SpriteRenderer topping1SpriteRenderer;
    [SerializeField] private Sprite topping2Image;
    private SpriteRenderer topping2SpriteRenderer;
    [SerializeField] private Sprite topping3Image;
    private SpriteRenderer topping3SpriteRenderer;

    [SerializeField] private GameObject trayAndPlateLocation;

    private Camera mainCamera;
    private CircleCollider2D baseFoodCircleCollider;
    private CapsuleCollider2D baseFoodCapsuleCollider;

    private Vector2 currentTouchPositionVector2InScreenPixels;
    private Vector3 currentTouchPositionVector3InWorldUnits;
    #endregion

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

    // Start is called before the first frame update
    public virtual void Start()
    {
        mainCamera = Camera.main;

        if (gameObject.name == "BurgerScriptablePrefab")
        {
            baseFoodCircleCollider = gameObject.GetComponent<CircleCollider2D>();
        }
        else if (gameObject.name == "ChickenDonerScriptablePrefab")
        {
            baseFoodCapsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
        }

        startingPositionVector2 = gameObject.transform.position;

        gameObject.GetComponent<SpriteRenderer>().sprite = baseFoodImage;

        //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpHamburgerEvent, HandleChefPicksUpBurgerEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, ResetBaseFood);
    }

    //Android
    private void Update()
    {
        currentTouchPositionVector2InScreenPixels = Touchscreen.current.primaryTouch.position.ReadValue();

        currentTouchPositionVector3InWorldUnits = mainCamera.ScreenToWorldPoint(currentTouchPositionVector2InScreenPixels);

        //prevent the z coordinate from making the chef disappear
        currentTouchPositionVector3InWorldUnits = new Vector3(currentTouchPositionVector3InWorldUnits.x, currentTouchPositionVector3InWorldUnits.y, 0);

        if (gameObject.name == "BurgerScriptablePrefab" && baseFoodCircleCollider.OverlapPoint(currentTouchPositionVector3InWorldUnits))
        {
            HandlePlayerSelectsBaseFoodEvent();
        }
        else if (gameObject.name == "ChickenDonerScriptablePrefab" && baseFoodCapsuleCollider.OverlapPoint(currentTouchPositionVector3InWorldUnits))
        {
            HandlePlayerSelectsBaseFoodEvent();
        }
    }

    //Itch
    //private void OnMouseUp()
    //{
    //    EventManagerScript.playerSelectsBurgerEvent.Invoke();
    //}

    public virtual void HandlePlayerSelectsBaseFoodEvent()
    {
        MoveToTray();
        if (!GameManagerScript.chefHasBaseFood)
        {
            GameManagerScript.chefHasBaseFood = true;
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage][englishWord]);
        }
    }
    private void MoveToTray()
    {
        gameObject.transform.position = trayAndPlateLocation.transform.position;
    }
    public virtual void ResetBaseFood()
    {
        gameObject.transform.position = startingPositionVector2;

        baseFoodSpriteRenderer.enabled = false;
        topping1SpriteRenderer.enabled = false;
        topping2SpriteRenderer.enabled = false;
        topping3SpriteRenderer.enabled = false;

        GameManagerScript.chefHasBaseFood = false;
    }
}
