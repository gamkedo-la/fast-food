using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenPlayButtonScript : MonoBehaviour
{
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandlePlayButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        SceneManager.LoadScene("PrepScene");
        GameManagerScript.gameIsPaused = false;
    }
}
