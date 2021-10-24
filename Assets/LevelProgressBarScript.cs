using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBarScript : MonoBehaviour
{
    [SerializeField] Image levelProgressBarMaskImage;

    // Start is called before the first frame update
    void Start()
    {
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, HandleAnyOrderSubmissionEvent);
    }

    private void HandleAnyOrderSubmissionEvent()
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
