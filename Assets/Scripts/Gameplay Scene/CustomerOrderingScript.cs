using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using TMPro;

public enum CustomerStateEnumerations
{
    WaitingOutsideEntrance,
    PickingAnOrderingLocation,
    EnteringRestaurant,
    WaitingForMyOrder,
    LeavingRestaurant,
    ExitingRestaurant
}
public class CustomerOrderingScript : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject myAccessoriesPrefab;

    [SerializeField] private GameObject audioController;

    [SerializeField] private InputActionAsset inputMap;
    private InputAction customerClick;

    private GameObject myOrderingLocation;
    [SerializeField] Slider myPatienceTimerSlider;
    [SerializeField] GameObject myPatienceTimerSliderGameObject;
    [SerializeField] Text speedBonusPointsTextbox;
    [SerializeField] TextMeshProUGUI speedBonusPointsTextMeshPro;
    [SerializeField] private GameObject customerOrderingLocationManager;

    public CustomerStateEnumerations myStateEnumeration = CustomerStateEnumerations.WaitingOutsideEntrance;
    private float myStartingX;
    private float myOrderingImageStartingX;
    private float myOrderingImageToggleButtonsStartingX;
    private float myPatienceSliderTimerStartingX;
    [SerializeField] GameObject exitLocation;

    [SerializeField] private float minimumAmountOfTimeToWaitBeforeOrdering = 0.1f;
    [SerializeField] private float maximumAmountOfTimeToWaitBeforeOrdering = 0.5f;
    private float myRandomTimeToWaitBeforeOrdering = 0.0f;

    private List<GameObject> listOfCustomerOrderingLocations = new List<GameObject>();
    [SerializeField] private GameObject customerOrderingLocation1;
    [SerializeField] private GameObject customerOrderingLocation2;
    [SerializeField] private GameObject customerOrderingLocation3;

    [SerializeField] private float minimumXSpeed = 0.3f;
    [SerializeField] private float maximumXSpeed = 0.5f;
    private float myRandomSpeed = 0.0f;

    private Vector2 currentTouchPositionVector2InScreenPixels;
    private Vector3 currentTouchPositionVector3InWorldUnits;
    private Camera mainCamera;

    private CircleCollider2D customers2DCircleCollider;

    private bool iWantAHamburger = false;
    private bool iWantAChickenDoner = false;
    private bool iWantLettuce = false;
    private bool iWantTomatoe = false;
    private bool iWantOnion = false;

    private bool iWantWater = false;
    private bool iWantBeer = false;
    private bool iWantRedWine = false;
    private bool iWantWhiteWine = false;

    [SerializeField] GameObject customerOrderingCanvas;
    [SerializeField] Image customerOrderingCanvasImage;
    [SerializeField] GameObject customerOrderingCanvasImageGameObject;
    private Transform customerOrderingCanvasImageTransform;
    private Vector3 customerOrderingCanvasImageStartingPosition;
    
    [SerializeField] Text customerOrderingTextBoxObject;
    [SerializeField] TextMeshProUGUI orderTextBoxTextMeshPro;
    public string customersOrderString;
    [SerializeField] Button customerOrderingCanvasToggleButton;

    public string currentCustomerDialogueString;
    public string currentCustomerFoodOrderString;
    public string currentCustomerDrinkOrderString;
    public string currentCustomerOrderDisplayString;
    public string currentCustomerOrderStringInEnglish; //for debugging
    public AudioClip myCurrentOrdersAudioClip;

    public bool isProcessingOrder = false;

    public bool losingPatience = false;
    [SerializeField] private ParticleSystem particleSystem1;
    [SerializeField] private ParticleSystem particleSystem2;
    [SerializeField] private ParticleSystem lostCustomerParticleSystem;

    [SerializeField] GameObject customerManagerObject;

    [SerializeField] GameObject myThumbsUpImage;
    [SerializeField] GameObject myThumbsDownImage;

    [SerializeField] GameObject burgerScriptablePrefab;
    [SerializeField] GameObject chickenDonerScriptablePrefab;

    [SerializeField] GameObject parentAccessoriesGameObject;
    private CustomerAccessories customerAccessoriesScript;

    [SerializeField] GameObject separateGameObjectForDoorCollider;
    private float doorForColliderXOffset = -0.55f;
    private float doorForColliderYOffset = 0.75f;

    private SpriteFlipper mySpriteFlipperScript;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("AudioController");
        customerAccessoriesScript = parentAccessoriesGameObject.GetComponent<CustomerAccessories>();

        Time.timeScale = 1;
        myStateEnumeration = CustomerStateEnumerations.WaitingOutsideEntrance;
        myStartingX = gameObject.transform.position.x;

        Vector2 orderImageStartingVectorConverted = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        customerOrderingCanvasImage.transform.position = orderImageStartingVectorConverted;
        Vector2 orderImageToggleButtonStartingVectorConverted = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        customerOrderingCanvasToggleButton.transform.position = orderImageToggleButtonStartingVectorConverted;
        Vector2 patienceSliderStartingVectorConverted = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        myPatienceTimerSlider.transform.position = patienceSliderStartingVectorConverted;

        myRandomTimeToWaitBeforeOrdering = Random.Range(minimumAmountOfTimeToWaitBeforeOrdering, maximumAmountOfTimeToWaitBeforeOrdering);
        myRandomTimeToWaitBeforeOrdering = myRandomTimeToWaitBeforeOrdering / 10;
        myRandomSpeed = Random.Range(minimumXSpeed, maximumXSpeed);

        listOfCustomerOrderingLocations.Add(customerOrderingLocation1);
        listOfCustomerOrderingLocations.Add(customerOrderingLocation2);
        listOfCustomerOrderingLocations.Add(customerOrderingLocation3);

        mainCamera = Camera.main;

        customers2DCircleCollider = gameObject.GetComponent<CircleCollider2D>();

        InitializeOrder();
        customerOrderingCanvasImageTransform = customerOrderingCanvasImage.transform;
        customerOrderingCanvasImageStartingPosition = customerOrderingCanvasImageTransform.position;

        mySpriteFlipperScript = gameObject.GetComponent<SpriteFlipper>();

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.correctOrderSubmissionEvent, HandleCorrectOrderSubmission);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.incorrectOrderSubmissionEvent, HandleIncorrectOrderSubmission);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, HandleAnyOrderSubmissionEvent);

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.customerEntersRestaurantEvent, HandleCustomerEntersRestaurantEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.customerExitsRestaurantEvent, HandleCustomerExitedRestaurantEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.customerReachedOrderingLocationEvent, HandleCustomerReachedOrderingLocationEvent);

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.customerLosingPatienceEvent, HandleLosingPatienceEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.lostCustomerEvent, HandleLostCustomerEvent);
    }

    
    private void HandleAnyOrderSubmissionEvent()
    {
        if (!isProcessingOrder)
        {
            return;
        }
        burgerScriptablePrefab.GetComponent<HamburgerBaseFoodScript>().ResetBaseFood();
        chickenDonerScriptablePrefab.GetComponent<ChickenDonerBaseFoodScript>().ResetBaseFood();
        isProcessingOrder = false;
    }
    private void HandleLosingPatienceEvent()
    {
        if (!losingPatience)
        {
            return;
        }
        if (!GameManagerScript.impatienceSoundIsPlaying){
            AudioController.instance.PlayAudio(GameSoundEnum.SFX_Customer_Impatience);
        }

        mySpriteFlipperScript.spriteIndex = 0;
        mySpriteFlipperScript.currentArrayOfSprites = mySpriteFlipperScript.impatientSprites;
        mySpriteFlipperScript.longDurationOfSpriteFlip = Random.Range(mySpriteFlipperScript.minFrametime, mySpriteFlipperScript.maxFrametime);

        GameManagerScript.impatienceSoundIsPlaying = true;
        particleSystem1.gameObject.SetActive(true);
        particleSystem2.gameObject.SetActive(true);
        StartCoroutine(SlowDownImpatienceSmokeAfterInitialBurst());
    }

    IEnumerator SlowDownImpatienceSmokeAfterInitialBurst()
    {
        yield return new WaitForSeconds(1);
        ParticleSystem.MainModule psMain1 = particleSystem1.main;
        ParticleSystem.MainModule psMain2 = particleSystem2.main;

        psMain1.startLifetime = 1.0f;
        psMain2.startLifetime = 1.0f;
        psMain1.startSpeed = 3.0f;
        psMain2.startSpeed = 3.0f;
        var particleSystem1Emitter = particleSystem1.emission;
        particleSystem1Emitter.rateOverTime = 5.0f;
        var particleSystem2Emitter = particleSystem2.emission;
        particleSystem2Emitter.rateOverTime = 5.0f;
    }
    IEnumerator SelectRandomOrderingLocationAfterARandomAmountOfTime()
    {
        yield return new WaitForSeconds(myRandomTimeToWaitBeforeOrdering);
        SelectAnAvailableOrderingLocation();
    }
    public void SelectAnAvailableOrderingLocation()
    {
        myStateEnumeration = CustomerStateEnumerations.PickingAnOrderingLocation;
        GameObject randomlyPickedAvailableOrderingLocation = null;
        int numberOfOrderingLocations = listOfCustomerOrderingLocations.Count;
        int randomOrderingLocationListIndex = Random.Range(0, numberOfOrderingLocations);
        randomlyPickedAvailableOrderingLocation = listOfCustomerOrderingLocations[randomOrderingLocationListIndex];
        while (randomlyPickedAvailableOrderingLocation.GetComponent<CustomerOrderingLocationScript>().isSelected == true)
        {
            randomOrderingLocationListIndex = Random.Range(0, numberOfOrderingLocations);
            randomlyPickedAvailableOrderingLocation = listOfCustomerOrderingLocations[randomOrderingLocationListIndex];
        }
        randomlyPickedAvailableOrderingLocation.GetComponent<CustomerOrderingLocationScript>().isSelected = true;
        myOrderingLocation = randomlyPickedAvailableOrderingLocation;
        myPatienceTimerSlider.GetComponent<PatienceTimerSliderScript>().isActive = true;
        EventManagerScript.customerEntersRestaurantEvent.Invoke();
    }

    private void HandleCustomerEntersRestaurantEvent()
    {
        //prevent duplicate event calls
        if (myStateEnumeration != CustomerStateEnumerations.PickingAnOrderingLocation)
        {
            return;
        }

        myStateEnumeration = CustomerStateEnumerations.EnteringRestaurant;
        AudioController.instance.PlayAudio(GameSoundEnum.SFX_Customer_Enter);
    }

    private void MoveTowardsSelectedOrderingLocation()
    {
        if (GameManagerScript.extraPauseForTransitions)
        {
            return;
        }
        if (myOrderingLocation != null && myStateEnumeration == CustomerStateEnumerations.EnteringRestaurant)
        {
            float myX = gameObject.transform.position.x;
            float orderingLocationX = myOrderingLocation.transform.position.x;

            if (myX < orderingLocationX)
            {
                Vector2 newCustomerPosition = new Vector2(myX + myRandomSpeed * 2, gameObject.transform.position.y);
                gameObject.transform.position = newCustomerPosition;

                float newDoorForColliderXPosition = newCustomerPosition.x - doorForColliderXOffset;
                float newDoorForColliderYPosition = newCustomerPosition.y + doorForColliderYOffset;
                separateGameObjectForDoorCollider.transform.position = new Vector2(newDoorForColliderXPosition, newDoorForColliderYPosition);
                
                float orderingImageYOffSet = 2.0f;
                Vector2 newOrderingImageVectorWithOffsets = new Vector2(newCustomerPosition.x, newCustomerPosition.y - orderingImageYOffSet);
                customerOrderingCanvasImage.transform.position = newOrderingImageVectorWithOffsets;

                customerOrderingCanvasToggleButton.transform.position = newCustomerPosition;

                float patienceTimerSliderYCoordinateWithOffset = newCustomerPosition.y - 0.5f;
                float patienceTimerSliderXCoordinateWithOffset = newCustomerPosition.x + 2.25f;
                Vector2 patienceTimerSliderVectorWithYOffset = new Vector2(patienceTimerSliderXCoordinateWithOffset, patienceTimerSliderYCoordinateWithOffset);
                myPatienceTimerSlider.transform.position = patienceTimerSliderVectorWithYOffset;
            }
            else
            {
                myStateEnumeration = CustomerStateEnumerations.WaitingForMyOrder;
                EventManagerScript.customerReachedOrderingLocationEvent.Invoke();
            }
        }
    }

    private void HandleCustomerReachedOrderingLocationEvent()
    {
        if (myStateEnumeration != CustomerStateEnumerations.WaitingForMyOrder)
        {
            return;
        }

        mySpriteFlipperScript.spriteIndex = 0;
        mySpriteFlipperScript.currentArrayOfSprites = mySpriteFlipperScript.mySprites;
        mySpriteFlipperScript.longDurationOfSpriteFlip = Random.Range(mySpriteFlipperScript.minFrametime, mySpriteFlipperScript.maxFrametime);

        List<Transform> listOfActiveAccessories = customerAccessoriesScript.ReturnAListOfActiveAccessoryTransforms();
        for (int i = 0; i < listOfActiveAccessories.Count; i++)
        {
            listOfActiveAccessories[i].GetComponent<AccessorieScript>().transform.rotation = Quaternion.Euler(Vector3.forward * 0);

            float newX = gameObject.transform.position.x + listOfActiveAccessories[i].GetComponent<AccessorieScript>().myXPositionWhenWaiting;
            float newY = gameObject.transform.position.y + listOfActiveAccessories[i].GetComponent<AccessorieScript>().myYPositionWhenWaiting;

            listOfActiveAccessories[i].GetComponent<AccessorieScript>().transform.position = new Vector2(newX, newY);
        }
    }

    private void MoveTowardsExit()
    {
        if (GameManagerScript.extraPauseForTransitions)
        {
            return;
        }
        if (myStateEnumeration == CustomerStateEnumerations.LeavingRestaurant && gameObject.transform.position.x < exitLocation.transform.position.x)
        {
            Vector2 newCustomerPosition = new Vector2(gameObject.transform.position.x + myRandomSpeed * 2, gameObject.transform.position.y);
            gameObject.transform.position = newCustomerPosition;

            float orderingImageYOffSet = 2.0f;
            Vector2 newOrderingImageVectorWithOffsets = new Vector2(newCustomerPosition.x, newCustomerPosition.y - orderingImageYOffSet);
            customerOrderingCanvasImage.transform.position = newOrderingImageVectorWithOffsets;

            separateGameObjectForDoorCollider.transform.position = new Vector2(
                gameObject.transform.position.x - doorForColliderXOffset + myRandomSpeed * 2, 
                gameObject.transform.position.y + doorForColliderYOffset);
        }

        if (myStateEnumeration == CustomerStateEnumerations.LeavingRestaurant && gameObject.transform.position.x > exitLocation.transform.position.x)
        {
            myStateEnumeration = CustomerStateEnumerations.ExitingRestaurant;
            EventManagerScript.customerExitsRestaurantEvent.Invoke();
        }
    }

    private void HandleCustomerExitedRestaurantEvent()
    {
        //preventing duplicate calls in event
        if (myStateEnumeration != CustomerStateEnumerations.ExitingRestaurant)
        {
            return;
        }

        //AudioController.instance.PlayAudio(GameSoundEnum.SFX_Customer_Leave);

        myAccessoriesPrefab.GetComponent<CustomerAccessories>().RandomizeAccesories();

        gameObject.transform.position = new Vector2(myStartingX, gameObject.transform.position.y);
        separateGameObjectForDoorCollider.transform.position = new Vector2(
            myStartingX - doorForColliderXOffset, 
            gameObject.transform.position.y + doorForColliderYOffset);

        customerOrderingCanvasImage.transform.localPosition = new Vector3(myOrderingImageStartingX, customerOrderingCanvasImage.transform.localPosition.y, 0.0f);
        customerOrderingCanvasToggleButton.transform.localPosition = new Vector3(myOrderingImageToggleButtonsStartingX, customerOrderingCanvasToggleButton.transform.localPosition.y, 0.0f);
        myPatienceTimerSlider.transform.localPosition = new Vector3(myPatienceSliderTimerStartingX, myPatienceTimerSlider.transform.localPosition.y, 0.0f);
        myStateEnumeration = CustomerStateEnumerations.WaitingOutsideEntrance;
        StartCoroutine(DelayedNewOrder());
        lostCustomerParticleSystem.gameObject.SetActive(false);
    }

    IEnumerator DelayedToggleOffDialogBox()
    {
        yield return new WaitForSeconds(1);
        ToggleOffDialogBox();
    }
    private void ToggleOffDialogBox()
    {
        customerOrderingCanvasImageGameObject.SetActive(false);
    }

    private void Update()
    {
        //gameIsPaused stops Time.deltaTime, extraPauseForTransitions does not stop Time.deltaTime
        if (GameManagerScript.gameIsPaused || GameManagerScript.extraPauseForTransitions)
        {
            return;
        }

        if (myStateEnumeration == CustomerStateEnumerations.EnteringRestaurant)
        {
            MoveTowardsSelectedOrderingLocation();
        }
        else if (myStateEnumeration == CustomerStateEnumerations.LeavingRestaurant)
        {
            MoveTowardsExit();
        }

        //if (losingPatience)
        //{
        //    ParticleSystem.MainModule psMain1 = particleSystem1.main;
        //    ParticleSystem.MainModule psMain2 = particleSystem2.main;

        //    psMain1.startLifetime = 1.0f - (myPatienceTimerSlider.value/10);
        //    psMain2.startLifetime = 1.0f - (myPatienceTimerSlider.value/10);
        //    psMain1.startSpeed = 3.0f - (myPatienceTimerSlider.value / 10);
        //    psMain2.startSpeed = 3.0f - (myPatienceTimerSlider.value / 10);
        //    //psMain1.startSpeed += Time.deltaTime;
        //    //particleLauncher.Emit(1);

        //}
    }

    void InitializeOrder()
    {
        iWantAHamburger = false;
        iWantAChickenDoner = false;
        iWantLettuce = false;
        iWantTomatoe = false;
        iWantOnion = false;
        iWantWater = false;
        iWantBeer = false;
        iWantRedWine = false;
        iWantWhiteWine = false;

        #region HandleCoinFlipDesireForEachTopping
        if (GameManagerScript.currentLevel < 3)
        {
            iWantAHamburger = true;//chicken doner doesn't get introduced until level 3
        }
        float randomFloatForCoinFlip = Random.Range(0.0f, 1.0f);
        if (randomFloatForCoinFlip < 0.5f)
        {
            iWantLettuce = true;
        }

        if (GameManagerScript.currentLevel >= 2)
        {
            randomFloatForCoinFlip = Random.Range(0.0f, 1.0f);
            if (randomFloatForCoinFlip < 0.5f)
            {
                iWantTomatoe = true;
            }
        }
        
        if (GameManagerScript.currentLevel >= 3)
        {
            randomFloatForCoinFlip = Random.Range(0.0f, 1.0f);
            if (randomFloatForCoinFlip < 0.5f)
            {
                iWantAHamburger = true;
            }
            else
            {
                iWantAChickenDoner = true;
            }
        }

        if (GameManagerScript.currentLevel >= 4)
        {
            randomFloatForCoinFlip = Random.Range(0.0f, 1.0f);
            if (randomFloatForCoinFlip < 0.5f)
            {
                iWantOnion = true;
            }
        }

        if (GameManagerScript.currentLevel == 5)
        {
            randomFloatForCoinFlip = Random.Range(0.0f, 1.0f);
            if (randomFloatForCoinFlip < 0.5f)
            {
                iWantWater = true;
            }
            else
            {
                iWantBeer = true;
            }
        }

        if (GameManagerScript.currentLevel == 6)
        {
            randomFloatForCoinFlip = Random.Range(0.0f, 1.0f);
            if (randomFloatForCoinFlip < 0.33f)
            {
                iWantWater = true;
            }
            else if (randomFloatForCoinFlip > 0.66f)
            {
                iWantBeer = true;
            }
            else
            {
                iWantRedWine = true;
            }
        }

        if (GameManagerScript.currentLevel == 7)
        {
            randomFloatForCoinFlip = Random.Range(0.0f, 1.0f);
            if (randomFloatForCoinFlip > 0.75f)
            {
                iWantWater = true;
            }
            else if (randomFloatForCoinFlip < 0.25f)
            {
                iWantBeer = true;
            }
            else if (randomFloatForCoinFlip >= 0.25f && randomFloatForCoinFlip < 0.5f)
            {
                iWantRedWine = true;
            }
            else if (randomFloatForCoinFlip >= 0.5f && randomFloatForCoinFlip <= 0.75f)
            {
                iWantWhiteWine = true;
            }
        }
        #endregion

        #region HandleCustomerDialogBoxString

        if (GameManagerScript.currentLanguage == Language.Turkish)
        {
            customersOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["a"];
            currentCustomerOrderDisplayString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["a"];

            //one topping
            if (iWantLettuce && !iWantTomatoe && !iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with only lettuce"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with only lettuce"];
            }
            else if (!iWantLettuce && iWantTomatoe && !iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with only tomato"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with only tomato"];
            }
            else if (!iWantLettuce && !iWantTomatoe && iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with only onion"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with only onion"];
            }

            //two toppings
            else if (iWantLettuce && iWantTomatoe && !iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with lettuce and tomato"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with lettuce and tomato"];
            }
            else if (iWantLettuce && !iWantTomatoe && iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with lettuce and onion"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with lettuce and onion"];
            }
            else if (!iWantLettuce && iWantTomatoe && iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with tomato and onion"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with tomato and onion"];
            }

            //all three toppings
            else if (iWantLettuce && iWantTomatoe && iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with lettuce, tomato, and onion"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with lettuce, tomato, and onion"];
            }

            currentCustomerOrderDisplayString += "\n";

            if (iWantAHamburger)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["hamburger"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["hamburger"];
            }
            else
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["chicken doner"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["chicken doner"];

            }
            currentCustomerFoodOrderString = customersOrderString;

            if (iWantWater)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["water"];
                currentCustomerDrinkOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["water"];
                currentCustomerOrderDisplayString += "\n";
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["water"];
            }
            else if (iWantBeer)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["beer"];
                currentCustomerDrinkOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["beer"];
                currentCustomerOrderDisplayString += "\n";
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["beer"];
            }
            else if (iWantRedWine)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["red wine"];
                currentCustomerDrinkOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["red wine"];
                currentCustomerOrderDisplayString += "\n";
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["red wine"];
            }
            else if (iWantWhiteWine)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["white wine"];
                currentCustomerDrinkOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["white wine"];
                currentCustomerOrderDisplayString += "\n";
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["white wine"];
            }


            currentCustomerFoodOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want"];
            currentCustomerDrinkOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want"];
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want"];
            currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want"];
        }
        else
        {

            if (iWantAHamburger)
            {
                customersOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want a hamburger"];
                currentCustomerOrderDisplayString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want a hamburger"];
                currentCustomerOrderStringInEnglish = LanguageDictionary.languageDictionary[Language.English]["I want a hamburger"];
            }
            else
            {
                customersOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want a chicken doner"];
                currentCustomerOrderDisplayString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want a chicken doner"];
                currentCustomerOrderStringInEnglish = LanguageDictionary.languageDictionary[Language.English]["I want a chicken doner"];

            }

            if (iWantLettuce || iWantTomatoe || iWantOnion)
            {
                currentCustomerOrderDisplayString += "\n" + LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with"];
                //Debug.Log("LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]['with']: " + LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with"]);
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["with"];
            }

            //one topping
            if (iWantLettuce && !iWantTomatoe && !iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only lettuce"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only lettuce"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["only lettuce"];
            }
            else if (!iWantLettuce && iWantTomatoe && !iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only tomato"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only tomato"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["only tomato"];
            }
            else if (!iWantLettuce && !iWantTomatoe && iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only onion"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only onion"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["only onion"];
            }

            //two toppings
            else if (iWantLettuce && iWantTomatoe && !iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce and tomato"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce and tomato"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["lettuce and tomato"];
            }
            else if (iWantLettuce && !iWantTomatoe && iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce and onion"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce and onion"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["lettuce and onion"];
            }
            else if (!iWantLettuce && iWantTomatoe && iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["tomato and onion"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["tomato and onion"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["tomato and onion"];
            }

            //all three toppings
            else if (iWantLettuce && iWantTomatoe && iWantOnion)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce, tomato, and onion"];
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce, tomato, and onion"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["lettuce, tomato, and onion"];
            }
            currentCustomerFoodOrderString = customersOrderString;


            if (iWantWater)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["water"];
                currentCustomerDrinkOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["water"];
                currentCustomerOrderDisplayString += "\n";
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["water"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["water"];
            }
            else if (iWantBeer)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["beer"];
                currentCustomerDrinkOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["beer"];
                currentCustomerOrderDisplayString += "\n";
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["beer"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["beer"];
            }
            else if (iWantRedWine)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["red wine"];
                currentCustomerDrinkOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["red wine"];
                currentCustomerOrderDisplayString += "\n";
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["red wine"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["red wine"];
            }
            else if (iWantWhiteWine)
            {
                customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["white wine"];
                currentCustomerDrinkOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["white wine"];
                currentCustomerOrderDisplayString += "\n";
                currentCustomerOrderDisplayString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["white wine"];
                currentCustomerOrderStringInEnglish += LanguageDictionary.languageDictionary[Language.English]["white wine"];
            }

            
            if (GameManagerScript.currentLanguage == Language.Georgian)
            {
                if (GameManagerScript.currentLevel >= 5)
                {
                    currentCustomerOrderDisplayString += " თუ შეიძლება.";
                }
                else
                {
                    currentCustomerOrderDisplayString += "\nთუ შეიძლება.";
                }
            }

        }
        //Debug.Log("currentCustomerOrderDisplayString: " + currentCustomerOrderDisplayString);
        //Debug.Log("currentCustomerOrderStringInEnglish: " + currentCustomerOrderStringInEnglish);

        //if it is turkish, we would still have to do the english way in order to make currentCustomerOrderStringInEnglish variable correctly.
        //So we first do the english stuff and if it is turkish we overwrite it with turkish for other variables.

        #endregion

        StartCoroutine(SelectRandomOrderingLocationAfterARandomAmountOfTime());
        myPatienceTimerSlider.GetComponent<PatienceTimerSliderScript>().InitializeTimer();
        float patienceTimerSliderYCoordinateWithOffset = gameObject.transform.position.y;
        Vector2 patienceTimerSliderVectorWithYOffset = new Vector2(gameObject.transform.position.x, patienceTimerSliderYCoordinateWithOffset);
        myPatienceTimerSlider.transform.position = patienceTimerSliderVectorWithYOffset;
        myPatienceTimerSliderGameObject.SetActive(true);
        currentCustomerDialogueString = customersOrderString;
        
        //customerOrderingTextBoxObject.text = currentCustomerDialogueString;
        orderTextBoxTextMeshPro.text = currentCustomerOrderDisplayString;

        //Remove if statement when Georgian audio clips are implemented
        //if (GameManagerScript.currentLanguage != Language.Georgian)
        //{
        //    myCurrentOrdersAudioClip = LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage][currentCustomerDialogueString];
        //}
    }

    private void ProcessDrinkSubmission()
    {
        if (iWantWater && !GameManagerScript.chefHasWater)
        {
            EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
            isProcessingOrder = false;
            return;
        }
        else if (iWantBeer && !GameManagerScript.chefHasBeer)
        {
            EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
            isProcessingOrder = false;
            return;
        }
        else if (iWantRedWine && !GameManagerScript.chefHasRedWine)
        {
            EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
            isProcessingOrder = false;
            return;
        }
        else if (iWantWhiteWine && !GameManagerScript.chefHasWhiteWine)
        {
            EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
            isProcessingOrder = false;
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "customerCounterTop" || collision.gameObject.name == "BurgerScriptablePrefab" || 
            collision.gameObject.name == "ChickenDonerScriptablePrefab" || collision.gameObject.name == "Beer" || 
            collision.gameObject.name == "RedWine" || collision.gameObject.name == "WhiteWine" || collision.gameObject.name == "Water" ||
            collision.gameObject.name == "EntranceDoor" || collision.gameObject.name == "ExitDoor")
        {
            return;
        }

        if (collision.gameObject.name == "TrayAndPlate(Clone)" && GameManagerScript.chefHasBaseFood)
        {
            isProcessingOrder = true;

            #region Handle Player Submission 
            ProcessDrinkSubmission();

            if (iWantAHamburger)
            {
                if (GameManagerScript.chefHasChickenDoner)
                {
                    EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                }

                //customer wants all the toppings
                else if (iWantLettuce && iWantOnion && iWantTomatoe)
                {
                    if (GameManagerScript.burgerHasLettuce && GameManagerScript.burgerHasTomatoe && GameManagerScript.burgerHasOnion)
                    {
                        EventManagerScript.correctOrderSubmissionEvent.Invoke();
                    }
                    else
                    {
                        EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                    }
                }

                //customer wants no toppings
                else if (!iWantLettuce && !iWantTomatoe && !iWantOnion)
                {
                    if (!GameManagerScript.burgerHasLettuce && !GameManagerScript.burgerHasTomatoe && !GameManagerScript.burgerHasOnion)
                    {
                        EventManagerScript.correctOrderSubmissionEvent.Invoke();
                    }
                    else
                    {
                        EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                    }
                }

                //customer only wants lettuce
                else if (iWantLettuce && !iWantTomatoe && !iWantOnion)
                {
                    if (GameManagerScript.burgerHasLettuce && !GameManagerScript.burgerHasTomatoe && !GameManagerScript.burgerHasOnion)
                    {
                        EventManagerScript.correctOrderSubmissionEvent.Invoke();
                    }
                    else
                    {
                        EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                    }
                }

                //customer only wants tomato
                else if (!iWantLettuce && iWantTomatoe && !iWantOnion)
                {
                    if (!GameManagerScript.burgerHasLettuce && GameManagerScript.burgerHasTomatoe && !GameManagerScript.burgerHasOnion)
                    {
                        EventManagerScript.correctOrderSubmissionEvent.Invoke();
                    }
                    else
                    {
                        EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                    }
                }

                //customer only wants onion
                else if (!iWantLettuce && !iWantTomatoe && iWantOnion)
                {
                    if (!GameManagerScript.burgerHasLettuce && !GameManagerScript.burgerHasTomatoe && GameManagerScript.burgerHasOnion)
                    {
                        EventManagerScript.correctOrderSubmissionEvent.Invoke();
                    }
                    else
                    {
                        EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                    }
                }

                //customer wants lettuce and tomato
                else if (iWantLettuce && iWantTomatoe && !iWantOnion)
                {
                    if (GameManagerScript.burgerHasLettuce && GameManagerScript.burgerHasTomatoe && !GameManagerScript.burgerHasOnion)
                    {
                        EventManagerScript.correctOrderSubmissionEvent.Invoke();
                    }
                    else
                    {
                        EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                    }
                }

                //customer wants lettuce and onion
                else if (iWantLettuce && !iWantTomatoe && iWantOnion)
                {
                    if (GameManagerScript.burgerHasLettuce && !GameManagerScript.burgerHasTomatoe && GameManagerScript.burgerHasOnion)
                    {
                        EventManagerScript.correctOrderSubmissionEvent.Invoke();
                    }
                    else
                    {
                        EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                    }
                }

                //customer wants tomato and onion
                else if (!iWantLettuce && iWantTomatoe && iWantOnion)
                {
                    if (!GameManagerScript.burgerHasLettuce && GameManagerScript.burgerHasTomatoe && GameManagerScript.burgerHasOnion)
                    {
                        EventManagerScript.correctOrderSubmissionEvent.Invoke();
                    }
                    else
                    {
                        EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                    }
                }
                #endregion
                //customerOrderingTextBoxObject.text = currentCustomerDialogueString;
                orderTextBoxTextMeshPro.text = currentCustomerDialogueString;
        }
        else if (iWantAChickenDoner)
        {
            if (GameManagerScript.chefHasBurger)
            {
                EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
            }
            //customer wants all the toppings
            else if (iWantLettuce && iWantOnion && iWantTomatoe)
            {
                if (GameManagerScript.chickenDonerHasLettuce && GameManagerScript.chickenDonerHasTomatoe && GameManagerScript.chickenDonerHasOnion)
                {
                    EventManagerScript.correctOrderSubmissionEvent.Invoke();
                }
                else
                {
                    EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                }
            }

            //customer wants no toppings
            else if (!iWantLettuce && !iWantTomatoe && !iWantOnion)
            {
                if (!GameManagerScript.chickenDonerHasLettuce && !GameManagerScript.chickenDonerHasTomatoe && !GameManagerScript.chickenDonerHasOnion)
                {
                    EventManagerScript.correctOrderSubmissionEvent.Invoke();
                }
                else
                {
                    EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                }
            }

            //customer only wants lettuce
            else if (iWantLettuce && !iWantTomatoe && !iWantOnion)
            {
                if (GameManagerScript.chickenDonerHasLettuce && !GameManagerScript.chickenDonerHasTomatoe && !GameManagerScript.chickenDonerHasOnion)
                {
                    EventManagerScript.correctOrderSubmissionEvent.Invoke();
                }
                else
                {
                    EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                }
            }

            //customer only wants tomato
            else if (!iWantLettuce && iWantTomatoe && !iWantOnion)
            {
                if (!GameManagerScript.chickenDonerHasLettuce && GameManagerScript.chickenDonerHasTomatoe && !GameManagerScript.chickenDonerHasOnion)
                {
                    EventManagerScript.correctOrderSubmissionEvent.Invoke();
                }
                else
                {
                    EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                }
            }

            //customer only wants onion
            else if (!iWantLettuce && !iWantTomatoe && iWantOnion)
            {
                if (!GameManagerScript.chickenDonerHasLettuce && !GameManagerScript.chickenDonerHasTomatoe && GameManagerScript.chickenDonerHasOnion)
                {
                    EventManagerScript.correctOrderSubmissionEvent.Invoke();
                }
                else
                {
                    EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                }
            }

            //customer wants lettuce and tomato
            else if (iWantLettuce && iWantTomatoe && !iWantOnion)
            {
                if (GameManagerScript.chickenDonerHasLettuce && GameManagerScript.chickenDonerHasTomatoe && !GameManagerScript.chickenDonerHasOnion)
                {
                    EventManagerScript.correctOrderSubmissionEvent.Invoke();
                }
                else
                {
                    EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                }
            }

            //customer wants lettuce and onion
            else if (iWantLettuce && !iWantTomatoe && iWantOnion)
            {
                if (GameManagerScript.chickenDonerHasLettuce && !GameManagerScript.chickenDonerHasTomatoe && GameManagerScript.chickenDonerHasOnion)
                {
                    EventManagerScript.correctOrderSubmissionEvent.Invoke();
                }
                else
                {
                    EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                }
            }

            //customer wants tomato and onion
            else if (!iWantLettuce && iWantTomatoe && iWantOnion)
            {
                if (!GameManagerScript.chickenDonerHasLettuce && GameManagerScript.chickenDonerHasTomatoe && GameManagerScript.chickenDonerHasOnion)
                {
                    EventManagerScript.correctOrderSubmissionEvent.Invoke();
                }
                else
                {
                    EventManagerScript.incorrectOrderSubmissionEvent.Invoke();
                }
            }
            //customerOrderingTextBoxObject.text = currentCustomerDialogueString;
            orderTextBoxTextMeshPro.text = currentCustomerDialogueString;
        }
        }
            
        EventManagerScript.anyOrderSubmissionEvent.Invoke();

        isProcessingOrder = false;
    }

    
    private void HandleCorrectOrderSubmission()
    {
        //prevent duplicate event calls
        if (!isProcessingOrder)
        {
            return;
        }

        mySpriteFlipperScript.spriteIndex = 0;
        mySpriteFlipperScript.currentArrayOfSprites = mySpriteFlipperScript.walkingSprites;
        mySpriteFlipperScript.longDurationOfSpriteFlip = mySpriteFlipperScript.walkingTimeFrame;
        mySpriteFlipperScript.iAmBlinking = false;

        losingPatience = false;
        currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);

        switch (GameManagerScript.currentLanguage)
        {
            case Language.English:
            AudioController.instance.PlayAudio(GameSoundEnum.English_Thank_You);
            break;

            case Language.Albanian:
            AudioController.instance.PlayAudio(GameSoundEnum.Albanian_Thank_You);
            break;
            case Language.Turkish:
            AudioController.instance.PlayAudio(GameSoundEnum.Turkish_Thank_You);
            break;
        }
        AudioController.instance.OneShot(GameSoundEnum.SFX_Correct_Order);
        if (!customerManagerObject.GetComponent<CustomerManagerScript>().AreAnyCustomersLosingPatience()){ //if no customers are losing patience when a correct order is delivered, the customer impatience sound should stop
            AudioController.instance.StopAudio(GameSoundEnum.SFX_Customer_Impatience);
            GameManagerScript.impatienceSoundIsPlaying = false; //the public bool that says whether the impatience sound is playing needs to be set to false since we just stopped the sound
        }
        myStateEnumeration = CustomerStateEnumerations.LeavingRestaurant;
        myOrderingLocation.GetComponent<CustomerOrderingLocationScript>().isSelected = false;
        myOrderingLocation = null;
        StartCoroutine(DelayedToggleOffDialogBox());
        GameManagerScript.speedBonus = myPatienceTimerSlider.GetComponent<PatienceTimerSliderScript>().PercentageOfTimerLeft() * 10;
        speedBonusPointsTextMeshPro.text = "Speed Points: " + GameManagerScript.speedBonus.ToString();
        myPatienceTimerSliderGameObject.SetActive(false);
        
        CheckForLevelCompletion();
        CheckForReviewNotification();


        ParticleSystem.MainModule psMain1 = particleSystem1.main;
        ParticleSystem.MainModule psMain2 = particleSystem2.main;
        psMain1.startSpeed = 1.0f;
        psMain2.startSpeed = 1.0f;
        psMain1.startLifetime = 0.75f;
        psMain2.startLifetime = 0.75f;
        particleSystem1.gameObject.SetActive(false);
        particleSystem2.gameObject.SetActive(false);

        ShowThumbsUp();
        isProcessingOrder = false;

        List<Transform> listOfCurrentActiveAccesories = customerAccessoriesScript.ReturnAListOfActiveAccessoryTransforms();
        for (int i = 0; i < listOfCurrentActiveAccesories.Count; i++)
        {
            float xOffset = gameObject.transform.position.x + listOfCurrentActiveAccesories[i].GetComponent<AccessorieScript>().myXPositionWhenRotated;
            float yOffset = gameObject.transform.position.y + listOfCurrentActiveAccesories[i].GetComponent<AccessorieScript>().myYPositionWhenRotated; ;
            listOfCurrentActiveAccesories[i].transform.position = new Vector2(xOffset, yOffset);
            listOfCurrentActiveAccesories[i].transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        }
    }

    private void ShowThumbsUp()
    {
        myThumbsUpImage.SetActive(true);
        StartCoroutine(TurnOffThumbsUp());
    }
    IEnumerator TurnOffThumbsUp()
    {
        yield return new WaitForSeconds(1);
        myThumbsUpImage.SetActive(false);
    }

    private void ShowThumbsDown()
    {
        myThumbsDownImage.SetActive(true);
        StartCoroutine(TurnOffThumbsDown());
    }
    IEnumerator TurnOffThumbsDown()
    {
        yield return new WaitForSeconds(1);
        myThumbsDownImage.SetActive(false);
    }

    private void CheckForLevelCompletion()
    {
        if (GameManagerScript.totalSubmittedOrders >= GameManagerScript.minimumSubmittedOrdersToCompleteCurrentLevel &&
            GameManagerScript.accuracy >= GameManagerScript.minimumAccuracyToCompleteLevel)
        {
            EventManagerScript.levelCompletedEvent.Invoke();
        }
    }

    private void CheckForReviewNotification()
    {
        if (GameManagerScript.totalSubmittedOrders >= GameManagerScript.minimumSubmittedOrdersToCompleteCurrentLevel &&
            GameManagerScript.accuracy < GameManagerScript.minimumAccuracyToCompleteLevel)
        {
            EventManagerScript.suggestReviewToPlayerEvent.Invoke();
        }
    }

    private void HandleIncorrectOrderSubmission()
    {
        //prevent duplicate event calls
        if (!isProcessingOrder)
        {
            return;
        }

        CheckForReviewNotification();
        currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["That's not what I want!"];
        
        //remove 'if' after georgian audio clips are implemented
        if (GameManagerScript.currentLanguage != Language.Georgian)
        {
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
        }
        
        AudioController.instance.OneShot(GameSoundEnum.SFX_Incorrect_Order);
        StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
        ShowThumbsDown();
        isProcessingOrder = false;
    }
    
    private void HandleLostCustomerEvent()
    {
        if (myPatienceTimerSlider.value != 0)
        {
            return;
        }
        losingPatience = false;

        mySpriteFlipperScript.spriteIndex = 0;
        mySpriteFlipperScript.currentArrayOfSprites = mySpriteFlipperScript.walkingSprites;
        mySpriteFlipperScript.longDurationOfSpriteFlip = mySpriteFlipperScript.walkingTimeFrame;
        mySpriteFlipperScript.timeRemainingUntilNextSpriteFlip = mySpriteFlipperScript.longDurationOfSpriteFlip;
        mySpriteFlipperScript.iAmBlinking = false;

        myStateEnumeration = CustomerStateEnumerations.LeavingRestaurant;
        if (!customerManagerObject.GetComponent<CustomerManagerScript>().AreAnyCustomersLosingPatience())
        { //if no customers are losing patience when a correct order is delivered, the customer impatience sound should stop
            AudioController.instance.StopAudio(GameSoundEnum.SFX_Customer_Impatience);
            GameManagerScript.impatienceSoundIsPlaying = false; //the public bool that says whether the impatience sound is playing needs to be set to false since we just stopped the sound
        }
        myOrderingLocation.GetComponent<CustomerOrderingLocationScript>().isSelected = false;
        myOrderingLocation = null;
        myPatienceTimerSliderGameObject.SetActive(false);

        ToggleOffDialogBox();

        ParticleSystem.MainModule psMain1 = particleSystem1.main;
        ParticleSystem.MainModule psMain2 = particleSystem2.main;

        psMain1.startSpeed = 1.0f;
        psMain2.startSpeed = 1.0f;
        psMain1.startLifetime = 0.75f;
        psMain2.startLifetime = 0.75f;
        particleSystem1.gameObject.SetActive(false);
        particleSystem2.gameObject.SetActive(false);

        
        lostCustomerParticleSystem.gameObject.SetActive(true);
        AudioController.instance.PlayAudio(GameSoundEnum.SFX_Lose_Customer);

        List<Transform> listOfCurrentActiveAccesories = customerAccessoriesScript.ReturnAListOfActiveAccessoryTransforms();
        for (int i = 0; i < listOfCurrentActiveAccesories.Count; i++)
        {
            float xOffset = gameObject.transform.position.x + listOfCurrentActiveAccesories[i].GetComponent<AccessorieScript>().myXPositionWhenRotated;
            float yOffset = gameObject.transform.position.y + listOfCurrentActiveAccesories[i].GetComponent<AccessorieScript>().myYPositionWhenRotated; ;
            listOfCurrentActiveAccesories[i].transform.position = new Vector2(xOffset, yOffset);

            listOfCurrentActiveAccesories[i].transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        }
    }
    IEnumerator DelayedNewOrder()
    {
        yield return new WaitForSeconds(0.1f);
        InitializeOrder();
    }

    IEnumerator RedisplayCustomersOrderAfterIncorrectDelivery()
    {
        yield return new WaitForSeconds(2);
        currentCustomerDialogueString = customersOrderString;
        //customerOrderingTextBoxObject.text = currentCustomerDialogueString;
        orderTextBoxTextMeshPro.text = currentCustomerDialogueString;
    }
}
