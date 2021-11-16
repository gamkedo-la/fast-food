using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScenesToLoadEnumerations
{
    MainMenu1,
    NewPlayerPrepScene,
    ReturningPlayerPrepScene,
    Gameplay,
    Spelling,
    Sentences,
    Numbers,
    Colors,
    Phonics,
}
public class LoadSceneButtonScript : ButtonScript
{
    [SerializeField] ScenesToLoadEnumerations mySceneToLoadEnumeration;

    public override void HandleButtonClick()
    {  
        SceneManager.LoadScene(mySceneToLoadEnumeration.ToString());

        //Play UI button sound
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);

        if (gameObject.name == "SkipToRestaurantButton" && GameManagerScript.currentLanguage == Language.Undefined)
        {
            GameManagerScript.currentLanguage = Language.English;
        }
        if (gameObject.name == "MainMenuSceneLoadButton")
        {
            SaveSystem.SaveListOfProfilesData();
        }
        //Play the correct music based on scene
        switch (mySceneToLoadEnumeration)
        {
            case ScenesToLoadEnumerations.MainMenu1:
                AudioController.instance.PlayAudio(GameSoundEnum.Music_Main_Menu);
                break;
            case ScenesToLoadEnumerations.Gameplay:
                switch (GameManagerScript.currentLanguage)
                {
                    case Language.Georgian:
                        AudioController.instance.PlayAudio(GameSoundEnum.Music_Level_Georgian);
                        break;
                    default:
                        AudioController.instance.PlayAudio(GameSoundEnum.Music_Level);
                        break;
                }        
                break;
            default:
                break;    
        }
    }
}
