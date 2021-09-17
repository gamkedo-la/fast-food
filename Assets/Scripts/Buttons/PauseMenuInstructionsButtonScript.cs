using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuInstructionsButtonScript : MonoBehaviour
{
    [SerializeField] GameObject instructionsCanvasPrefab;
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandlePauseMenuInstructionsButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);

        instructionsCanvasPrefab.SetActive(true);
        pauseMenuCanvas.SetActive(false);
    }
}
