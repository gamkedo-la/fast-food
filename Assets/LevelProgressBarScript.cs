using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBarScript : MonoBehaviour
{
    [SerializeField] Image levelProgressBarMaskImage;
    private float currentProgressAmount = 0.0f;
    private float numberOfBurgersSubmitted = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyBurgerSubmissionEvent, HandleBurgerSubmissionEvent);
    }

    private void HandleBurgerSubmissionEvent()
    {
        float currentMaxFillAmount;
        float percentOfCurrentMaxFillAmountToFill;
        if ( (GameManagerScript.totalSubmittedOrders < GameManagerScript.minimumSubmittedOrdersToCompleteCurrentLevel))
        {
            currentMaxFillAmount = GameManagerScript.totalSubmittedOrders / GameManagerScript.minimumSubmittedOrdersToCompleteCurrentLevel;
        }
        else
        {
            currentMaxFillAmount = 1.0f;
        }
        double accuracyConvertedForCalculations = GameManagerScript.accuracy * 0.01;
        percentOfCurrentMaxFillAmountToFill = currentMaxFillAmount * (float)accuracyConvertedForCalculations;
        levelProgressBarMaskImage.fillAmount = percentOfCurrentMaxFillAmountToFill;
    }
}