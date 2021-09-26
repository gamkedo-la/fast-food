using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScenesToLoadEnumerations
{
    MainMenu,
    PrepScene,
    Gameplay
}
public class LoadSceneButtonScript : ButtonScript
{
    [SerializeField] ScenesToLoadEnumerations mySceneToLoadEnumeration;

    public override void HandleButtonClick()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        SceneManager.LoadScene(mySceneToLoadEnumeration.ToString());
    }
}
