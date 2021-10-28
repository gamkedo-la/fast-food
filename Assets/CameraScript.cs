using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject statsCanvas;
    [SerializeField] GameObject suggestReviewCanvas;
    [SerializeField] GameObject newWordIntroductionCanvas;

    // Start is called before the first frame update
    void Start()
    {    
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelCompletedEvent, HandleLevelCompletedEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.suggestReviewToPlayerEvent, HandleSuggestReviewToStudentEvent);

        if (GameManagerScript.shouldIntroduceNewLevel)
        {
            newWordIntroductionCanvas.SetActive(true);
        }
    }

    
    private void HandleSuggestReviewToStudentEvent()
    {
        suggestReviewCanvas.SetActive(true);
    }

    private bool CheckIfLevelIntroductionIsAppropriate()
    {
        if (GameManagerScript.currentLevel == 2 && !GameManagerScript.hasIntroducedLevel2)
        {
            return true;
        }
        else if (GameManagerScript.currentLevel == 3 && !GameManagerScript.hasIntroducedLevel3)
        {
            return true;
        }
        else if (GameManagerScript.currentLevel == 4 && !GameManagerScript.hasIntroducedLevel4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void HandleLevelCompletedEvent()
    {
        statsCanvas.GetComponent<StatsCanvasScript>().Appear();

        if (CheckIfLevelIntroductionIsAppropriate())
        {
            GameManagerScript.shouldIntroduceNewLevel = true;
        }
    }
}
