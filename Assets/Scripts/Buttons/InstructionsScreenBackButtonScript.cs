using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScreenBackButtonScript : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject instructionsCanvas;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandleInstructionsScreenBackButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        mainMenuCanvas.SetActive(true);
        instructionsCanvas.SetActive(false);
    }
}
