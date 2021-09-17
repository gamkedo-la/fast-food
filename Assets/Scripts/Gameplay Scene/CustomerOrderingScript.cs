using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


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

    private string myState = "waiting";
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
    private float customerOrderingCanvasImageStartingY;
    private float customerOrderingCanvasImageXOffset = 2000.0f;
    [SerializeField] Text customerOrderingTextBoxObject;
    private string customersOrderString;
    [SerializeField] Button customerOrderingCanvasToggleButton;

    private string currentCustomerDialogueString;

    [SerializeField] GameObject burger;

    [SerializeField] Text correctOrdersTextbox;
    [SerializeField] Text incorrectOrdersTextbox;
    [SerializeField] Text accuracyTextbox;

    [SerializeField] GameObject fullHeadOfLettuce;
    [SerializeField] GameObject fullTomatoe;
    [SerializeField] GameObject fullOnion;

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
        customerOrderingCanvasImageStartingY = customerOrderingCanvasImageStartingPosition.y;
    }

    
    IEnumerator SelectRandomOrderingLocationAfterARandomAmountOfTime()
    {
        yield return new WaitForSeconds(myRandomTimeToWaitBeforeOrdering);
        SelectAnAvailableOrderingLocation();
    }
    public void SelectAnAvailableOrderingLocation()
    {
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
    }

    private void MoveTowardsSelectedOrderingLocation()
    {
        if (myOrderingLocation != null && myState == "waiting")
        {
            float myX = gameObject.transform.position.x;
            float orderingLocationX = myOrderingLocation.transform.position.x;

            if (myX < orderingLocationX)
            {
                Vector2 newCustomerPosition = new Vector2(myX + myRandomSpeed, gameObject.transform.position.y);
                gameObject.transform.position = newCustomerPosition;

                Vector2 newUIPositionConvertedFromWorldToScreenPoint = Camera.main.WorldToScreenPoint(newCustomerPosition);

                float orderingImageXOffSet = 3.0f;
                float orderingImageYOffSet = 2.0f;
                Vector2 newOrderingImageVectorWithOffsets = new Vector2(newCustomerPosition.x + orderingImageXOffSet, newCustomerPosition.y - orderingImageYOffSet);
                customerOrderingCanvasImage.transform.position = newOrderingImageVectorWithOffsets;

                customerOrderingCanvasToggleButton.transform.position = newCustomerPosition;

                float patienceTimerSliderYCoordinateWithOffset = newCustomerPosition.y - 1.0f;
                Vector2 patienceTimerSliderVectorWithYOffset = new Vector2(newCustomerPosition.x, patienceTimerSliderYCoordinateWithOffset);
                myPatienceTimerSlider.transform.position = patienceTimerSliderVectorWithYOffset;
            }
        }
        else if (myState == "leaving" && gameObject.transform.position.x < exitLocation.transform.position.x)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + myRandomSpeed, gameObject.transform.position.y);
            customerOrderingCanvasImage.transform.localPosition = new Vector3(customerOrderingCanvasImage.transform.localPosition.x + myRandomSpeed * 50,
                    customerOrderingCanvasImage.transform.localPosition.y, 0.0f);
            customerOrderingCanvasToggleButton.transform.localPosition = new Vector3(customerOrderingCanvasToggleButton.transform.localPosition.x + myRandomSpeed * 51,
                customerOrderingCanvasToggleButton.transform.localPosition.y, 0.0f);
        }
        else if (myState == "leaving" && gameObject.transform.position.x > exitLocation.transform.position.x)
        {
            gameObject.transform.position = new Vector2(myStartingX, gameObject.transform.position.y);
            customerOrderingCanvasImage.transform.localPosition = new Vector3(myOrderingImageStartingX, customerOrderingCanvasImage.transform.localPosition.y, 0.0f);
            customerOrderingCanvasToggleButton.transform.localPosition = new Vector3(myOrderingImageToggleButtonsStartingX, customerOrderingCanvasToggleButton.transform.localPosition.y, 0.0f);
            myPatienceTimerSlider.transform.localPosition = new Vector3(myPatienceSliderTimerStartingX, myPatienceTimerSlider.transform.localPosition.y, 0.0f);
            myState = "waiting";
            StartCoroutine(DelayedNewOrder());
        }
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

        MoveTowardsSelectedOrderingLocation();
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
        Debug.Log("I want lettuce: " + iWantLettuce + ", I want tomatoe: " + iWantTomatoe + ", I want onion: " + iWantOnion);

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
        Debug.Log("reaching dialog textbox setting with current string string");
        Debug.Log("currentCustomerDialogueString: " + currentCustomerDialogueString);
        customerOrderingTextBoxObject.text = currentCustomerDialogueString;
        Debug.Log("customerOrderingTextBoxObject.text: " + customerOrderingTextBoxObject.text);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chef" && GameManagerScript.chefHasBurger)
        {
            #region Handle Player Submission 
            //customer wants all the toppings
            if (iWantLettuce && iWantOnion && iWantTomatoe)
                {
                    if (GameManagerScript.burgerHasLettuce && GameManagerScript.burgerHasTomatoe && GameManagerScript.burgerHasOnion)
                    {
                        currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
                        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);
                        HandleCorrectOrderSubmission();
                    }
                    else
                    {
                        currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["That's not what I want!"];
                        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
                        HandleIncorrectOrderSubmission();
                        StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
                    }
            }
                
            //customer wants no toppings
            else if (!iWantLettuce && !iWantTomatoe && !iWantOnion)
                {
                    if (!GameManagerScript.burgerHasLettuce && !GameManagerScript.burgerHasTomatoe && !GameManagerScript.burgerHasOnion)
                    {
                        currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
                        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);
                        HandleCorrectOrderSubmission();
                    }
                    else
                    {
                        currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["That's not what I want!"];
                        Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
                        HandleIncorrectOrderSubmission();
                        StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
                    }
            }
                        
            //customer only wants lettuce
            else if (iWantLettuce && !iWantTomatoe && !iWantOnion)
            {
                if (GameManagerScript.burgerHasLettuce && !GameManagerScript.burgerHasTomatoe && !GameManagerScript.burgerHasOnion)
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);
                    HandleCorrectOrderSubmission();
                }
                else
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["That's not what I want!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
                    HandleIncorrectOrderSubmission();
                    StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
                }
            }

            //customer only wants tomatoe
            else if  (!iWantLettuce && iWantTomatoe && !iWantOnion)
            {
                if (!GameManagerScript.burgerHasLettuce && GameManagerScript.burgerHasTomatoe && !GameManagerScript.burgerHasOnion)
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);
                    HandleCorrectOrderSubmission();
                }
                else
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["That's not what I want!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
                    HandleIncorrectOrderSubmission();
                    StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
                }
            }

            //customer only wants onion
            else if (!iWantLettuce && !iWantTomatoe && iWantOnion)
            {
                if (!GameManagerScript.burgerHasLettuce && !GameManagerScript.burgerHasTomatoe && GameManagerScript.burgerHasOnion)
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);
                    HandleCorrectOrderSubmission();
                }
                else
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["That's not what I want!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
                    HandleIncorrectOrderSubmission();
                    StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
                }
            }

            //customer wants lettuce and tomatoe
            else if (iWantLettuce && iWantTomatoe && !iWantOnion)
            {
                if (GameManagerScript.burgerHasLettuce && GameManagerScript.burgerHasTomatoe && !GameManagerScript.burgerHasOnion)
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);
                    HandleCorrectOrderSubmission();
                }
                else
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["That's not what I want!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
                    HandleIncorrectOrderSubmission();
                    StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
                }
            }

            //customer wants lettuce and onion
            else if (iWantLettuce && !iWantTomatoe && iWantOnion)
            {
                if (GameManagerScript.burgerHasLettuce && !GameManagerScript.burgerHasTomatoe && GameManagerScript.burgerHasOnion)
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);
                    HandleCorrectOrderSubmission();
                }
                else
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["That's not what I want!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
                    HandleIncorrectOrderSubmission();
                    StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
                }
            }

            //customer wants tomatoe and onion
            else if (!iWantLettuce && iWantTomatoe && iWantOnion)
            {
                if (!GameManagerScript.burgerHasLettuce && GameManagerScript.burgerHasTomatoe && GameManagerScript.burgerHasOnion)
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["Thank you!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["Thank You"]);
                    HandleCorrectOrderSubmission();
                }
                else
                {
                    currentCustomerDialogueString = LanguageDictionary.languageDictionary[GameManagerScript.currentLanguage]["That's not what I want!"];
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(LanguageDictionary.audioLanguageDictionary[GameManagerScript.currentLanguage]["No"]);
                    HandleIncorrectOrderSubmission();
                    StartCoroutine(RedisplayCustomersOrderAfterIncorrectDelivery());
                }
            }
            #endregion
            customerOrderingTextBoxObject.text = currentCustomerDialogueString;
        }

        fullHeadOfLettuce.GetComponent<SpriteRenderer>().enabled = true;
        fullTomatoe.GetComponent<SpriteRenderer>().enabled = true;
        fullOnion.GetComponent<SpriteRenderer>().enabled = true;
        burger.GetComponent<BurgerScript>().ResetBurger();
    }

    private void HandleCorrectOrderSubmission()
    {
        GameManagerScript.numberOfCorrectOrders++;
        GameManagerScript.totalSubmittedOrders++;
        correctOrdersTextbox.text = "Correct Orders: " + GameManagerScript.numberOfCorrectOrders.ToString();
        myState = "leaving";
        myOrderingLocation.GetComponent<CustomerOrderingLocationScript>().isSelected = false;
        myOrderingLocation = null;
        StartCoroutine(DelayedToggleOffDialogBox());
        Debug.Log("percentage of timer left: " + myPatienceTimerSlider.GetComponent<PatienceTimerSliderScript>().PercentageOfTimerLeft());
        speedBonusPointsTextbox.text = "Speed Bonus Points: " + (myPatienceTimerSlider.GetComponent<PatienceTimerSliderScript>().PercentageOfTimerLeft() * 10).ToString();
        myPatienceTimerSliderGameObject.SetActive(false);
        CalculateAccuracy();
    }

    private void HandleIncorrectOrderSubmission()
    {
        GameManagerScript.numberOfIncorrectOrders++;
        GameManagerScript.totalSubmittedOrders++;
        incorrectOrdersTextbox.text = "Incorrect Orders: " + GameManagerScript.numberOfIncorrectOrders.ToString();
        CalculateAccuracy();
    }
    
    private void CalculateAccuracy()
    {
        GameManagerScript.accuracy = GameManagerScript.numberOfCorrectOrders / GameManagerScript.totalSubmittedOrders;
        GameManagerScript.accuracy = GameManagerScript.accuracy * 100;
        accuracyTextbox.text = "Accuracy: " + GameManagerScript.accuracy.ToString() + "%";
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
