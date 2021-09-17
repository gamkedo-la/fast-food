using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuMainMenuButtonScript : MonoBehaviour
{
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandleMainMenuButtonClick()
    {
        GameManagerScript.numberOfCorrectOrders = 0;
        GameManagerScript.numberOfIncorrectOrders = 0;
        GameManagerScript.totalSubmittedOrders = 0;
        GameManagerScript.accuracy = 0;

        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);

        SceneManager.LoadScene("MainMenu");
    }
}
