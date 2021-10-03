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
public class CustomerOrderingScript : MonoBehaviour
{
    #region Fields
    [SerializeField] private InputActionAsset inputMap;
    private InputAction customerClick;

    private GameObject myOrderingLocation;
    [SerializeField] Slider myPatienceTimerSlider;
    [SerializeField] GameObject myPatienceTimerSliderGameObject;
    [SerializeField] Text speedBonusPointsTextbox;
    [SerializeField] private GameObject customerOrderingLocationManager;

    private CustomerStateEnumerations myStateEnumeration = CustomerStateEnumerations.WaitingOutsideEntrance;
    private float myStartingX;
    private float myOrderingImageStartingX;
    private float myOrderingImageToggleButtonsStartingX;
    private float myPatienceSliderTimerStartingX;
    [SerializeField] GameObject exitLocation;

    [SerializeField] private float minimumAmountOfTimeToWaitBeforeOrdering = 1.0f;
    [SerializeField] private float maximumAmountOfTimeToWaitBeforeOrdering = 3.0f;
    private float myRandomTimeToWaitBeforeOrdering = 0.0f;

    private List<GameObject> listOfCustomerOrderingLocations = new List<GameObject>();
    [SerializeField] private GameObject customerOrderingLocation1;
    [SerializeField] private GameObject customerOrderingLocation2;
    [SerializeField] private GameObject customerOrderingLocation3;

    [SerializeField] private float minimumXSpeed = 0.05f;
    [SerializeField] private float maximumXSpeed = 0.125f;
    private float myRandomSpeed = 0.0f;

    private Vector2 currentTouchPositionVector2InScreenPixels;
    private Vector3 currentTouchPositionVector3InWorldUnits;
    private Camera mainCamera;

    private CircleCollider2D customers2DCircleCollider;

    private bool iWantLettuce = false;
    private bool iWantTomatoe = false;
    private bool iWantOnion = false;

    [SerializeField] GameObject customerOrderingCanvas;
    [SerializeField] Image customerOrderingCanvasImage;
    [SerializeField] GameObject customerOrderingCanvasImageGameObject;
    private Transform customerOrderingCanvasImageTransform;
    private Vector3 customerOrderingCanvasImageStartingPosition;
    
    [SerializeField] Text customerOrderingTextBoxObject;
    private string customersOrderString;
    [SerializeField] Button customerOrderingCanvasToggleButton;

    private string currentCustomerDialogueString;
    public AudioClip myCurrentOrdersAudioClip;

    private bool isProcessingOrder = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        myStartingX = gameObject.transform.position.x;

        Vector2 orderImageStartingVectorConverted = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        customerOrderingCanvasImage.transform.position = orderImageStartingVectorConverted;
        Vector2 orderImageToggleButtonStartingVectorConverted = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        customerOrderingCanvasToggleButton.transform.position = orderImageToggleButtonStartingVectorConverted;
        Vector2 patienceSliderStartingVectorConverted = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        myPatienceTimerSlider.transform.position = patienceSliderStartingVectorConverted;

        myRandomTimeToWaitBeforeOrdering = Random.Range(minimumAmountOfTimeToWaitBeforeOrdering, maximumAmountOfTimeToWaitBeforeOrdering);
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
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.customerEntersRestaurantEvent, HandleCustomerEntersRestaurantEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.customerExitsRestaurantEvent, HandleCustomerExitedRestaurantEvent);
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
                Vector2 newCustomerPosition = new Vector2(myX + myRandomSpeed, gameObject.transform.position.y);
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
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + myRandomSpeed, gameObject.transform.position.y);
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
    }

    void InitializeOrder()
    {
        iWantLettuce = false;
        iWantTomatoe = false;
        iWantOnion = false;
        #region HandleCoinFlipDesireForEachTopping
        float randomFloatForCoinFlip = Random.Range(0.0f, 1.0f);
        if (randomFloatForCoinFlip < 0.5f)
        {
            iWantLettuce = true;
        }

        randomFloatForCoinFlip = Random.Range(0.0f, 1.0f);
        if (randomFloatForCoinFlip < 0.5f)
        {
            iWantTomatoe = true;
        }

        randomFloatForCoinFlip = Random.Range(0.0f, 1.0f);
        if (randomFloatForCoinFlip < 0.5f)
        {
            iWantOnion = true;
        }
        #endregion

        #region HandleCustomerDialogBoxString
        customersOrderString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["I want a hamburger"];
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
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only tomatoe"];
        }
        else if (!iWantLettuce && !iWantTomatoe && iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["only onion"];
        }

        //two toppings
        else if (iWantLettuce && iWantTomatoe && !iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce and tomatoe"];
        }
        else if (iWantLettuce && !iWantTomatoe && iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce and onion"];
        }
        else if (!iWantLettuce && iWantTomatoe && iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["tomatoe and onion"];
        }

        //all three toppings
        else if (iWantLettuce && iWantTomatoe && iWantOnion)
        {
            customersOrderString += LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["lettuce, tomatoe, and onion"];
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
        Debug.Log("currentCustomerDialogueString: " + currentCustomerDialogueString);
        myCurrentOrdersAudioClip = LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage][currentCustomerDialogueString];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "customerCounterTop")
        {
            return;
        }

        if (collision.gameObject.name == "Chef" && GameManagerScript.chefHasBurger)
        {
            isProcessingOrder = true;

            #region Handle Player Submission 
            //customer wants all the toppings
            if (iWantLettuce && iWantOnion && iWantTomatoe)
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

            //customer only wants tomatoe
            else if  (!iWantLettuce && iWantTomatoe && !iWantOnion)
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

            //customer wants lettuce and tomatoe
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

            //customer wants tomatoe and onion
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
        EventManagerScript.anyBurgerSubmissionEvent.Invoke();

        isProcessingOrder = false;
    }

    
    private void HandleCorrectOrderSubmission()
    {
        //prevent duplicate event calls
        if (!isProcessingOrder)
        {
            return;
        }

        currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);
        myStateEnumeration = CustomerStateEnumerations.LeavingRestaurant;
        myOrderingLocation.GetComponent<CustomerOrderingLocationScript>().isSelected = false;
        myOrderingLocation = null;
        StartCoroutine(DelayedToggleOffDialogBox());
        GameManagerScript.speedBonus = myPatienceTimerSlider.GetComponent<PatienceTimerSliderScript>().PercentageOfTimerLeft() * 10;
        speedBonusPointsTextbox.text = "Speed Bonus Points: " + GameManagerScript.speedBonus.ToString();
        myPatienceTimerSliderGameObject.SetActive(false);
    }

    private void HandleIncorrectOrderSubmission()
    {
        //prevent duplicate event calls
        if (!isProcessingOrder)
        {
            return;
        }

        currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["That's not what I want!"];
        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
        StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
    }
    
    
    IEnumerator DelayedNewOrder()
    {
        yield return new WaitForSeconds(2);
        InitializeOrder();
    }

    IEnumerator RedisplayCustomersOrderAfterIncorrectDelivery()
    {
        yield return new WaitForSeconds(2);
        currentCustomerDialogueString = customersOrderString;
        customerOrderingTextBoxObject.text = currentCustomerDialogueString;
    }
}
