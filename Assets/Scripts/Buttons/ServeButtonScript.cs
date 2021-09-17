using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServeButtonScript : MonoBehaviour
{
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandleServeButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        SceneManager.LoadScene("Test");
    }
}
