using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelStarterScript : MonoBehaviour
{
    [SerializeField] Text numberOfCorrectOrdersTextbox;
    [SerializeField] Text numberOfIncorrectOrdersTextbox;
    [SerializeField] Text accuracyTextbox;
    [SerializeField] Text speedBonusTextbox;

    [SerializeField] TextMeshProUGUI numberOfCorrectOrdersTextMeshPro;
    [SerializeField] TextMeshProUGUI numberOfIncorrectOrdersTextMeshPro;
    [SerializeField] TextMeshProUGUI accuracyTextMeshPro;
    [SerializeField] TextMeshProUGUI speedBonusTextMeshPro;


    [SerializeField] GameObject fullTomatoe;
    [SerializeField] GameObject fullOnion;
    [SerializeField] GameObject chickenDoner;

    [SerializeField] GameObject statsCanvas;
    [SerializeField] TMP_Text statsCanvasLoadLevelButtonText;
    [SerializeField] Text feedbackMessageTextbox;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerScript.NewPlayerHasntPlayedMainGameYet == true)
        {
            GameManagerScript.NewPlayerHasntPlayedMainGameYet = false;
        }

        if (!GameManagerScript.levelStarterFirstTimeStarted)
        {
            EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.initializeLevel, HandleStartOfLevelEvent);
            EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.timerRanOutOfTimeEvent, HandleTimerRanOutOfTimeEvent);
            EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelCompletedEvent, HandleLevelCompletedEvent);
            EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelInitializationFinishedEvent, HandleInitalizationOfLevelFinishedEvent);
        }
        EventManagerScript.initializeLevel.Invoke();
    }

    private void HandleStartOfLevelEvent()
    {
        GameManagerScript.numberOfCorrectOrders = 0;
        GameManagerScript.numberOfIncorrectOrders = 0;
        GameManagerScript.totalSubmittedOrders = 0;
        GameManagerScript.accuracy = 0;
        GameManagerScript.speedBonus = 0;

        //numberOfCorrectOrdersTextbox.text = "Correct Orders: ";
        //numberOfIncorrectOrdersTextbox.text = "Incorrect Orders: ";
        //accuracyTextbox.text = "Accuracy: ";
        //speedBonusTextbox.text = "Speed Bonus Points: ";

        numberOfCorrectOrdersTextMeshPro.text = "Correct Orders: ";
        numberOfIncorrectOrdersTextMeshPro.text = "Incorrect Orders: ";
        accuracyTextMeshPro.text = "Accuracy: ";
        speedBonusTextMeshPro.text = "Speed Bonus Points: ";

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

        EventManagerScript.levelInitializationFinishedEvent.Invoke();
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
        statsCanvas.SetActive(true);
        statsCanvasLoadLevelButtonText.text = "Try Again";
        feedbackMessageTextbox.text = "You ran out of time! Please try again.";
    }

    private void HandleLevelCompletedEvent()
    {
        //statsCanvas.SetActive(true);
        statsCanvasLoadLevelButtonText.text = "Next Level";
        feedbackMessageTextbox.text = "Congratulations! You're ready for the next level.";
    }
}
