using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject rewardsCanvas;
    [SerializeField] GameObject suggestReviewCanvas;
    [SerializeField] GameObject newWordIntroductionCanvas;
    [SerializeField] GameObject trayAndPlatePrefab;

    public GameObject fadeTransitioner;
    public Color tempColor;

    // Start is called before the first frame update
    void Start()
    {
        fadeTransitioner = GameObject.FindGameObjectWithTag("FadeTransitioner");
        fadeTransitioner.GetComponent<FadeTransitionerScript>().firstFrameAfterSceneLoadHasPassed = false;

        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelCompletedEvent, HandleLevelCompletedEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.suggestReviewToPlayerEvent, HandleSuggestReviewToStudentEvent);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, HandleAnyOrderSubmissionEvent);

        Instantiate(trayAndPlatePrefab);

        if (GameManagerScript.shouldIntroduceNewLevel)
        {
            newWordIntroductionCanvas.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            fadeTransitioner.GetComponent<FadeTransitionerScript>().isFadingIn = true;
        }
    }

    private void HandleAnyOrderSubmissionEvent()
    {
        Instantiate(trayAndPlatePrefab);
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
        rewardsCanvas.SetActive(true);
        
        Time.timeScale = 0;
        AudioController.instance.StopAudio(GameSoundEnum.SFX_Customer_Impatience);
        GameManagerScript.impatienceSoundIsPlaying = false;

        if (CheckIfLevelIntroductionIsAppropriate())
        {
            GameManagerScript.shouldIntroduceNewLevel = true;
        }
    }
}
