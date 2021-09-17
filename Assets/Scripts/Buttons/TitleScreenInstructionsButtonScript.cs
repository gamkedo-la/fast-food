using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenInstructionsButtonScript : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject instructionsCanvas;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandleTitleScreenInstructionsButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        mainMenuCanvas.SetActive(false);
        instructionsCanvas.SetActive(true);
    }
}
