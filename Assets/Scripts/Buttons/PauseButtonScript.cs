using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandlePauseButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        pauseMenuCanvas.SetActive(true);
        GameManagerScript.gameIsPaused = true;
    }
}
