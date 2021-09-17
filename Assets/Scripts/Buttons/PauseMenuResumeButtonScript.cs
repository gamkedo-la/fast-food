using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuResumeButtonScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandleResumeButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);

        pauseMenuCanvas.SetActive(false);
        GameManagerScript.gameIsPaused = false;
    }
}
