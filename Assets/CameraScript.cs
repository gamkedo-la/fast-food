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
        if (GameManagerScript.shouldIntroduceNewWord)
        {
            newWordIntroductionCanvas.SetActive(true);
            GameManagerScript.shouldIntroduceNewWord = false;
        }
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelCompletedEvent, statsCanvas.GetComponent<StatsCanvasScript>().Appear);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.suggestReviewToPlayerEvent, HandleSuggestReviewToStudentEvent);
    }

    
    private void HandleSuggestReviewToStudentEvent()
    {
        Debug.Log("should be invoking review event");
        suggestReviewCanvas.SetActive(true);
    }
}
