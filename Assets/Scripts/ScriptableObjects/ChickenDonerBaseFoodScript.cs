using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChickenDonerBaseFoodScript : BaseFoodScript
{
    //[SerializeField] private BaseFoodScriptableObject baseFoodScriptableObject;

    //[SerializeField] private string englishWord;

    //[SerializeField] GameObject trayAndPlateLocation;

    //private Vector2 currentTouchPositionVector2InScreenPixels;
    //private Vector3 currentTouchPositionVector3InWorldUnits;

    //private Camera mainCamera;
    //private Vector2 startingPositionVector2;

    private CapsuleCollider2D baseFoodCapsuleCollider;

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
    public override void Start()
    {
        base.Start();
        
        baseFoodCapsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.playerSelectsChickenDonerEvent, HandlePlayerSelectsBaseFoodEvent);
    }

    public override void Update()
    {
        if (GameManagerScript.currentPlatformEnum != CurrentPlatformEnum.Android)
        {
            return;
        }

        currentTouchPositionVector2InScreenPixels = Touchscreen.current.primaryTouch.position.ReadValue();

        currentTouchPositionVector3InWorldUnits = mainCamera.ScreenToWorldPoint(currentTouchPositionVector2InScreenPixels);

        //prevent the z coordinate from making the chef disappear
        currentTouchPositionVector3InWorldUnits = new Vector3(currentTouchPositionVector3InWorldUnits.x, currentTouchPositionVector3InWorldUnits.y, 0);

        if (!GameManagerScript.chefHasChickenDoner && baseFoodCapsuleCollider.OverlapPoint(currentTouchPositionVector3InWorldUnits))
        {
            EventManagerScript.playerSelectsChickenDonerEvent.Invoke();
        }
    }

    public override void HandlePlayerSelectsBaseFoodEvent()
    {
        base.HandlePlayerSelectsBaseFoodEvent();
        AudioController.instance.PlayAudio(GameSoundEnum.SFX_Meat_Pickup);
        GameManagerScript.chefHasChickenDoner = true;
        baseFoodCapsuleCollider.enabled = false;
    }

    public override void ResetBaseFood()
    {
        base.ResetBaseFood();

        if (baseFoodCapsuleCollider)
        {
            baseFoodCapsuleCollider.enabled = true;
        }

        GameManagerScript.chefHasChickenDoner = false;
        GameManagerScript.chickenDonerHasLettuce = false;
        GameManagerScript.chickenDonerHasTomatoe = false;
        GameManagerScript.chickenDonerHasOnion = false;

        GameManagerScript.chefHasChickenDoner = false;
    }

    public override void MoveToTray()
    {
        GameObject trayAndPlate = GameObject.FindGameObjectWithTag("TrayAndPlate");
        gameObject.transform.position = trayAndPlate.transform.position;
    }

    public override void OnMouseUp()
    {
        base.OnMouseUp();
        AudioController.instance.PlayAudio(GameSoundEnum.SFX_Meat_Pickup);
        EventManagerScript.playerSelectsChickenDonerEvent.Invoke();
        GameManagerScript.chefHasChickenDoner = true;
    }
}
