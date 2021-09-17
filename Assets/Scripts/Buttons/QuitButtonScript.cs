using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    [SerializeField] AudioClip buttonClickAudioClip;
    public void HandleQuitButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        Application.Quit();
    }
}
