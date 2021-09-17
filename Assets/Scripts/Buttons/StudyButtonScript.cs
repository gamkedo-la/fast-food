using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyButtonScript : MonoBehaviour
{
    [SerializeField] GameObject prepSceneCanvas;
    [SerializeField] GameObject studyCanvas;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandlePrepSceneStudyButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        studyCanvas.SetActive(true);
        prepSceneCanvas.SetActive(false);
    }
}
