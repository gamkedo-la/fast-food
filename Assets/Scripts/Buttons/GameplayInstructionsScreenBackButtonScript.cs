using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInstructionsScreenBackButtonScript : MonoBehaviour
{
    [SerializeField] GameObject instructionsScreenPrefab;
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandleGameplayInstructionsScreenBackButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        pauseMenuCanvas.SetActive(true);
        instructionsScreenPrefab.SetActive(false);
    }
}
