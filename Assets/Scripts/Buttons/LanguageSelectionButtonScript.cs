using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelectionButtonScript : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject languageSelectionCanvas;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandleLanguageSelectionButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        languageSelectionCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }
}

