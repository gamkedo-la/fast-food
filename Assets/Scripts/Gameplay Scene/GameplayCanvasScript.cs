using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayCanvasScript : MonoBehaviour
{
    private GameObject[] arrayOfCustomers;
    [SerializeField] Text correctOrdersTextbox;
    [SerializeField] Text incorrectOrdersTextbox;
    [SerializeField] Text accuracyTextbox;

    // Start is called before the first frame update
    void Start()
    {
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.correctOrderSubmissionEvent, HandleCorrectOrderSubmission);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.incorrectOrderSubmissionEvent, HandleIncorrectOrderSubmission);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.lostCustomerEvent, HandleLostCustomerEvent);
    }

    private void IncreaseNumberOfCorrectOrders()
    {
        GameManagerScript.numberOfCorrectOrders++;
    }

    private void IncreaseNumberOfTotalSubmittedOrders()
    {
        GameManagerScript.totalSubmittedOrders++;
    }

    private void IncreaseNumberOfIncorrectOrders()
    {
        GameManagerScript.numberOfIncorrectOrders++;
    }
    
    private void UpdateCorrectOrdersTextBox()
    {
        correctOrdersTextbox.text = "Correct Orders: " + GameManagerScript.numberOfCorrectOrders.ToString();
    }

    private void UpdateIncorrectOrdersTextBox()
    {
        incorrectOrdersTextbox.text = "Incorrect Orders: " + GameManagerScript.numberOfIncorrectOrders.ToString();
    }

    private void CalculateAccuracy()
    {
        GameManagerScript.accuracy = GameManagerScript.numberOfCorrectOrders / GameManagerScript.totalSubmittedOrders;
        GameManagerScript.accuracy = GameManagerScript.accuracy * 100;
    }

    private void UpdateAccuracyTextBox()
    {
        accuracyTextbox.text = "Accuracy: " + GameManagerScript.accuracy.ToString() + "%";
    }
    private void HandleCorrectOrderSubmission()
    {
        IncreaseNumberOfTotalSubmittedOrders();
        IncreaseNumberOfCorrectOrders();
        UpdateCorrectOrdersTextBox();
        CalculateAccuracy();
        UpdateAccuracyTextBox();
    }    

    private void HandleIncorrectOrderSubmission()
    {
        IncreaseNumberOfTotalSubmittedOrders();
        IncreaseNumberOfIncorrectOrders();
        UpdateIncorrectOrdersTextBox();
        CalculateAccuracy();
        UpdateAccuracyTextBox();
    }

    private void HandleLostCustomerEvent()
    {
        IncreaseNumberOfTotalSubmittedOrders();
        IncreaseNumberOfIncorrectOrders();
        UpdateIncorrectOrdersTextBox();
        CalculateAccuracy();
        UpdateAccuracyTextBox();
    }
}
