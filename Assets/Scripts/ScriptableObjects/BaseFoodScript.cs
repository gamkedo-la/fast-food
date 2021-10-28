using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseFoodScript : MonoBehaviour
{
    #region Fields

    [SerializeField] protected BaseFoodScriptableObject baseFoodScriptableObject;

    [SerializeField] protected string englishWord;

    protected Vector2 startingPositionVector2;

    [SerializeField] protected Sprite baseFoodImage;
    protected SpriteRenderer baseFoodSpriteRenderer;
    [SerializeField] protected Sprite baseFoodImage2;
    protected SpriteRenderer baseFoodSpriteRenderer2;
    [SerializeField] protected Sprite topping1Image;
    protected SpriteRenderer topping1SpriteRenderer;
    [SerializeField] protected Sprite topping2Image;
    protected SpriteRenderer topping2SpriteRenderer;
    [SerializeField] protected Sprite topping3Image;
    protected SpriteRenderer topping3SpriteRenderer;

    [SerializeField] protected GameObject trayAndPlateLocation;

    protected Camera mainCamera;

    protected Vector2 currentTouchPositionVector2InScreenPixels;
    protected Vector3 currentTouchPositionVector3InWorldUnits;
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

        startingPositionVector2 = gameObject.transform.position;

        gameObject.GetComponent<SpriteRenderer>().sprite = baseFoodImage;

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
        //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpHamburgerEvent, HandleChefPicksUpBurgerEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, ResetBaseFood);
        //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.playerSelectsBurgerEvent, HandlePlayerSelectsBaseFoodEvent);
        //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.playerSelectsChickenDonerEvent, HandlePlayerSelectsBaseFoodEvent);
        //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.playerSelectsBaseFoodEvent, HandlePlayerSelectsBaseFoodEvent);
    }

    //Android
    public virtual void Update()
    {
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Itch)
        {
            return;
        }
    }

    //Itch
    private void OnMouseUp()
    {
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Itch)
        {
            return;
        }
        EventManagerScript.playerSelectsBurgerEvent.Invoke();
    }

    public virtual void HandlePlayerSelectsBaseFoodEvent()
    {
        MoveToTray();
        if (!GameManagerScript.chefHasBaseFood)
        {
            GameManagerScript.chefHasBaseFood = true;
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage][englishWord]);
        }
    }
    public virtual void MoveToTray()
    {
    }
    public virtual void ResetBaseFood()
    {
        gameObject.transform.position = startingPositionVector2;        

        topping1SpriteRenderer.enabled = false;
        topping2SpriteRenderer.enabled = false;
        topping3SpriteRenderer.enabled = false;

        GameManagerScript.chefHasBaseFood = false;
    }
}
