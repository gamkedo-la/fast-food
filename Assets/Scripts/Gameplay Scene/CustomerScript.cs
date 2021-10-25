using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public enum CustomerStateEnumerations
{
    WaitingOutsideEntrance,
    PickingAnOrderingLocation,
    EnteringRestaurant,
    WaitingForMyOrder,
    LeavingRestaurant,
    ExitingRestaurant
}
public class CustomerScript : MonoBehaviour
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

    [SerializeField] GameObject customerOrderingCanvas;
    [SerializeField] Image customerOrderingCanvasImage;
    [SerializeField] GameObject customerOrderingCanvasImageGameObject;
    private Transform customerOrderingCanvasImageTransform;
    private Vector3 customerOrderingCanvasImageStartingPosition;
    
    [SerializeField] Text customerOrderingTextBoxObject;
    public string customersOrderString;
    [SerializeField] Button customerOrderingCanvasToggleButton;

    public string currentCustomerDialogueString;
    public AudioClip myCurrentOrdersAudioClip;

    public bool isProcessingOrder = false;

    public bool losingPatience = false;
    [SerializeField] private ParticleSystem particleSystem1;
    [SerializeField] private ParticleSystem particleSystem2;

    [SerializeField] GameObject customerManagerObject;

    [SerializeField] GameObject myThumbsUpImage;
    [SerializeField] GameObject myThumbsDownImage;

    [SerializeField] GameObject burgerScriptablePrefab;
    [SerializeField] GameObject chickenDonerScriptablePrefab;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("AudioController");

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

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.correctOrderSubmissionEvent, HandleCorrectOrderSubmission);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.incorrectOrderSubmissionEvent, HandleIncorrectOrderSubmission);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, HandleAnyOrderSubmissionEvent);

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.customerEntersRestaurantEvent, HandleCustomerEntersRestaurantEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.customerExitsRestaurantEvent, HandleCustomerExitedRestaurantEvent);

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.customerLosingPatienceEvent, HandleLosingPatienceEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.lostCustomerEvent, HandleLostCustomerEvent);
    }

    private void HandleAnyOrderSubmissionEvent()
    {
        Debug.Log("inside handle any order submission event");
        burgerScriptablePrefab.GetComponent<HamburgerBaseFoodScript>().ResetFood();
        chickenDonerScriptablePrefab.GetComponent<ChickenDonerBaseFoodScript>().ResetFood();
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
    }

    private void MoveTowardsSelectedOrderingLocation()
    {
        if (myOrderingLocation != null && myStateEnumeration == CustomerStateEnumerations.EnteringRestaurant)
        {
            float myX = gameObject.transform.position.x;
            float orderingLocationX = myOrderingLocation.transform.position.x;

            if (myX < orderingLocationX)
            {
                Vector2 newCustomerPosition = new Vector2(myX + myRandomSpeed * 2, gameObject.transform.position.y);
                gameObject.transform.position = newCustomerPosition;
                
                float orderingImageYOffSet = 2.0f;
                Vector2 newOrderingImageVectorWithOffsets = new Vector2(newCustomerPosition.x, newCustomerPosition.y - orderingImageYOffSet);
                customerOrderingCanvasImage.transform.position = newOrderingImageVectorWithOffsets;

                customerOrderingCanvasToggleButton.transform.position = newCustomerPosition;

                float patienceTimerSliderYCoordinateWithOffset = newCustomerPosition.y - 1.0f;
                Vector2 patienceTimerSliderVectorWithYOffset = new Vector2(newCustomerPosition.x, patienceTimerSliderYCoordinateWithOffset);
                myPatienceTimerSlider.transform.position = patienceTimerSliderVectorWithYOffset;
            }
        }
    }

    private void MoveTowardsExit()
    {
        if (myStateEnumeration == CustomerStateEnumerations.LeavingRestaurant && gameObject.transform.position.x < exitLocation.transform.position.x)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + myRandomSpeed * 2, gameObject.transform.position.y);
            customerOrderingCanvasImage.transform.localPosition = new Vector3(customerOrderingCanvasImage.transform.localPosition.x + myRandomSpeed * 50,
                    customerOrderingCanvasImage.transform.localPosition.y, 0.0f);
            customerOrderingCanvasToggleButton.transform.localPosition = new Vector3(customerOrderingCanvasToggleButton.transform.localPosition.x + myRandomSpeed * 51,
                customerOrderingCanvasToggleButton.transform.localPosition.y, 0.0f);
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

        myAccessoriesPrefab.GetComponent<CustomerAccessories>().RandomizeAccesories();
        gameObject.transform.position = new Vector2(myStartingX, gameObject.transform.position.y);
        customerOrderingCanvasImage.transform.localPosition = new Vector3(myOrderingImageStartingX, customerOrderingCanvasImage.transform.localPosition.y, 0.0f);
        customerOrderingCanvasToggleButton.transform.localPosition = new Vector3(myOrderingImageToggleButtonsStartingX, customerOrderingCanvasToggleButton.transform.localPosition.y, 0.0f);
        myPatienceTimerSlider.transform.localPosition = new Vector3(myPatienceSliderTimerStartingX, myPatienceTimerSlider.transform.localPosition.y, 0.0f);
        myStateEnumeration = CustomerStateEnumerations.WaitingOutsideEntrance;
        StartCoroutine(DelayedNewOrder());
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
        if (GameManagerScript.gameIsPaused)
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
        #endregion

        #region HandleCustomerDialogBoxString
        if (iWantAHamburger)
        {
            customersOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want a hamburger"];
        }
        else
        {
            customersOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want a chicken doner"];
        }

        if (iWantLettuce || iWantTomatoe || iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["with"];
        }

        //one topping
        if (iWantLettuce && !iWantTomatoe && !iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only lettuce"];
        }
        else if (!iWantLettuce && iWantTomatoe && !iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only tomato"];
        }
        else if (!iWantLettuce && !iWantTomatoe && iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only onion"];
        }

        //two toppings
        else if (iWantLettuce && iWantTomatoe && !iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce and tomato"];
        }
        else if (iWantLettuce && !iWantTomatoe && iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce and onion"];
        }
        else if (!iWantLettuce && iWantTomatoe && iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["tomato and onion"];
        }

        //all three toppings
        else if (iWantLettuce && iWantTomatoe && iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce, tomato, and onion"];
        }
        #endregion

        StartCoroutine(SelectRandomOrderingLocationAfterARandomAmountOfTime());
        myPatienceTimerSlider.GetComponent<PatienceTimerSliderScript>().InitializeTimer();
        float patienceTimerSliderYCoordinateWithOffset = gameObject.transform.position.y - 1.0f;
        Vector2 patienceTimerSliderVectorWithYOffset = new Vector2(gameObject.transform.position.x, patienceTimerSliderYCoordinateWithOffset);
        myPatienceTimerSlider.transform.position = patienceTimerSliderVectorWithYOffset;
        myPatienceTimerSliderGameObject.SetActive(true);
        currentCustomerDialogueString = customersOrderString;
        customerOrderingTextBoxObject.text = currentCustomerDialogueString;
        myCurrentOrdersAudioClip = LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage][currentCustomerDialogueString];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "customerCounterTop" || collision.gameObject.name == "BurgerScriptablePrefab" || 
            collision.gameObject.name == "ChickenDonerScriptablePrefab")
        {
            return;
        }

        if (collision.gameObject.name == "TrayAndPlate" && GameManagerScript.chefHasBaseFood)
        {
            isProcessingOrder = true;

            #region Handle Player Submission 
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
                customerOrderingTextBoxObject.text = currentCustomerDialogueString;
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
                customerOrderingTextBoxObject.text = currentCustomerDialogueString;
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

        losingPatience = false;
        currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);
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
        speedBonusPointsTextbox.text = "Speed Bonus Points: " + GameManagerScript.speedBonus.ToString();
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
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
        AudioController.instance.OneShot(GameSoundEnum.SFX_Incorrect_Order);
        StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
        ShowThumbsDown();
    }
    
    private void HandleLostCustomerEvent()
    {
        if (myPatienceTimerSlider.value != 0)
        {
            return;
        }
        losingPatience = false;
        myStateEnumeration = CustomerStateEnumerations.LeavingRestaurant;
        if (!customerManagerObject.GetComponent<CustomerManagerScript>().AreAnyCustomersLosingPatience())
        { //if no customers are losing patience when a correct order is delivered, the customer impatience sound should stop
            AudioController.instance.StopAudio(GameSoundEnum.SFX_Customer_Impatience);
            GameManagerScript.impatienceSoundIsPlaying = false; //the public bool that says whether the impatience sound is playing needs to be set to false since we just stopped the sound
        }
        myOrderingLocation.GetComponent<CustomerOrderingLocationScript>().isSelected = false;
        myOrderingLocation = null;
        myPatienceTimerSliderGameObject.SetActive(false);

        ParticleSystem.MainModule psMain1 = particleSystem1.main;
        ParticleSystem.MainModule psMain2 = particleSystem2.main;
        psMain1.startSpeed = 1.0f;
        psMain2.startSpeed = 1.0f;
        psMain1.startLifetime = 0.75f;
        psMain2.startLifetime = 0.75f;
        particleSystem1.gameObject.SetActive(false);
        particleSystem2.gameObject.SetActive(false);
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
        customerOrderingTextBoxObject.text = currentCustomerDialogueString;
    }
}