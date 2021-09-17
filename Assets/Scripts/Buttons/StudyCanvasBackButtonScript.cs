using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyCanvasBackButtonScript : MonoBehaviour
{
    [SerializeField] GameObject prepSceneCanvas;
    [SerializeField] GameObject studyCanvas;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandleStudyCanvasBackButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        prepSceneCanvas.SetActive(true);
        studyCanvas.SetActive(false);
    }
}
