using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelectionScreenBackButtonScript : MonoBehaviour
{
    [SerializeField] GameObject languageSelectionScreenCanvas;
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandleLanguageSelectionScreenBackButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        mainMenuCanvas.SetActive(true);
        languageSelectionScreenCanvas.SetActive(true);
    }
}
