using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour
{
    public AudioController audioController;
#region Unity Functions
#if UNITY_EDITOR
    private void Update() {
        //To test playback, stop, restart of soundtrack
        if (Input.GetKeyUp(KeyCode.T)){
            audioController.PlayAudio(AudioType.Music_Main_Menu);
        }
        if (Input.GetKeyUp(KeyCode.G)){
            audioController.StopAudio(AudioType.Music_Main_Menu);
        }
        if (Input.GetKeyUp(KeyCode.B)){
            audioController.RestartAudio(AudioType.Music_Main_Menu);
        }
        //To test playback, stop, restart of a sound effect
        if (Input.GetKeyUp(KeyCode.Y)){
            audioController.PlayAudio(AudioType.UI_Button);
        }
        if (Input.GetKeyUp(KeyCode.H)){
            audioController.StopAudio(AudioType.UI_Button);
        }
        if (Input.GetKeyUp(KeyCode.N)){
            audioController.RestartAudio(AudioType.UI_Button);
        }

        //workaround test for direct audio playing
        if (Input.GetKeyUp(KeyCode.P))
        {
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }
    #endif
#endregion
}
