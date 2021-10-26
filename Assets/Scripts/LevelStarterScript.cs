using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class LevelStarterScript : MonoBehaviour
{
    [SerializeField] Text numberOfCorrectOrdersTextbox;
    [SerializeField] Text numberOfIncorrectOrdersTextbox;
    [SerializeField] Text accuracyTextbox;
    [SerializeField] Text speedBonusTextbox;

    [SerializeField] GameObject fullTomatoe;
    [SerializeField] GameObject fullOnion;
    [SerializeField] GameObject chickenDoner;

    [SerializeField] GameObject statsCanvas;
    [SerializeField] TMP_Text statsCanvasLoadLevelButtonText;
    [SerializeField] Text feedbackMessageTextbox;

    InitializeLevelEvent initializeLevelEvent = new InitializeLevelEvent();
    LevelInitializationFinishedEvent levelInitializationFinishedEvent = new LevelInitializationFinishedEvent();

    // Start is called before the first frame update
    void Start()
    {
        if (!GameManagerScript.levelStarterFirstTimeStarted)
        {
            //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.initializeLevel, HandleStartOfLevelEvent);
            EventManagerScript2.AddLevelInitializationEventInvoker(this);
            EventManagerScript2.AddLevelInitialzationEventHandler(HandleStartOfLevelEvent);

            EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.timerRanOutOfTimeEvent, HandleTimerRanOutOfTimeEvent);
            EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelCompletedEvent, HandleLevelCompletedEvent);

            //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelInitializationFinishedEvent, HandleInitalizationOfLevelFinishedEvent);
            EventManagerScript2.AddLevelInitializationFinishedEventInvoker(this);
            EventManagerScript2.AddLevelInitialzationFinishedFinishedEventHandler(HandleInitalizationOfLevelFinishedEvent);
        }
        initializeLevelEvent.Invoke();
    }

    public void AddLevelInitializationEventHandler(UnityAction handler)
    {
        initializeLevelEvent.AddListener(handler);
    }

    public void AddLevelInitializationFinishedEventHandler(UnityAction handler)
    {
        levelInitializationFinishedEvent.AddListener(handler);
    }

    private void HandleStartOfLevelEvent()
    {
        GameManagerScript.numberOfCorrectOrders = 0;
        GameManagerScript.numberOfIncorrectOrders = 0;
        GameManagerScript.totalSubmittedOrders = 0;
        GameManagerScript.accuracy = 0;
        GameManagerScript.speedBonus = 0;

        numberOfCorrectOrdersTextbox.text = "Correct Orders: ";
        numberOfIncorrectOrdersTextbox.text = "Incorrect Orders: ";
        accuracyTextbox.text = "Accuracy: ";
        speedBonusTextbox.text = "Speed Bonus Points: ";

        switch (GameManagerScript.currentLevel)
        {
            case 1:
                GameManagerScript.minimumSubmittedOrdersToCompleteCurrentLevel = GameManagerScript.minimumSubmittedOrdersToCompleteLevel1;               
                break;
            case 2:
                GameManagerScript.minimumSubmittedOrdersToCompleteCurrentLevel = GameManagerScript.minimumSubmittedOrdersToCompleteLevel2;
                break;
            case 3:
                GameManagerScript.minimumSubmittedOrdersToCompleteCurrentLevel = GameManagerScript.minimumSubmittedOrdersToCompleteLevel3;
                break;
            case 4:
                GameManagerScript.minimumSubmittedOrdersToCompleteCurrentLevel = GameManagerScript.minimumSubmittedOrdersToCompleteLevel4;
                break;
        }


        if (GameManagerScript.currentLevel >= 2)
        {
            fullTomatoe.SetActive(true);
        }
        if (GameManagerScript.currentLevel >= 3)
        {
            chickenDoner.SetActive(true);
        }
        if (GameManagerScript.currentLevel >= 4)
        {
            fullOnion.SetActive(true);
        }

        levelInitializationFinishedEvent.Invoke();
    }

    private void HandleInitalizationOfLevelFinishedEvent()
    {
        if (GameManagerScript.currentLevel < 3)
        {
            chickenDoner.SetActive(false);
        }
    }

    private void HandleTimerRanOutOfTimeEvent()
    {
        Debug.Log("calling ran out of time event");
        statsCanvas.SetActive(true);
        statsCanvasLoadLevelButtonText.text = "Try Again";
        feedbackMessageTextbox.text = "You ran out of time! Please try again.";
    }

    private void HandleLevelCompletedEvent()
    {
        Debug.Log("calling level completed event");
        statsCanvas.SetActive(true);
        statsCanvasLoadLevelButtonText.text = "Next Level";
        feedbackMessageTextbox.text = "Congratulations! You're ready for the next level.";
    }
}
