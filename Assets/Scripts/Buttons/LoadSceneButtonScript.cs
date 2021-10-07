using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScenesToLoadEnumerations
{
    MainMenu,
    NewPlayerPrepScene,
    ReturningPlayerPrepScene,
    Gameplay,
}
public class LoadSceneButtonScript : ButtonScript
{
    [SerializeField] ScenesToLoadEnumerations mySceneToLoadEnumeration;

    public override void HandleButtonClick()
    {
        //AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
       
        SceneManager.LoadScene(mySceneToLoadEnumeration.ToString());

        switch (mySceneToLoadEnumeration)
        {
            case ScenesToLoadEnumerations.MainMenu:
                AudioController.instance.PlayAudio(GameSoundEnum.Music_Main_Menu);
                break;
            case ScenesToLoadEnumerations.Gameplay:
                AudioController.instance.PlayAudio(GameSoundEnum.Music_Level);
                break;
            default:
                break;    
        }
    }
}
