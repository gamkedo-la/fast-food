using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsPopupOkButtonScript : MonoBehaviour
{
    [SerializeField] GameObject controlsPopup;
    [SerializeField] AudioClip buttonClickAudioClip;

    public void HandleControlsPopupOkButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        controlsPopup.SetActive(false);
    }
}
