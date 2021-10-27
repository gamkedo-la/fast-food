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
}
public class LoadSceneButtonScript : ButtonScript
{
    [SerializeField] ScenesToLoadEnumerations mySceneToLoadEnumeration;

    public override void HandleButtonClick()
    {  
        SceneManager.LoadScene(mySceneToLoadEnumeration.ToString());

        //Play UI button sound
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);

        if (gameObject.name == "SkipToRestaurantButton" && GameManagerScript.currentLanguage == "")
        {
            GameManagerScript.currentLanguage = "English";
        }
        if (gameObject.name == "MainMenuSceneLoadButton")
        {
            Debug.Log("GameManagerScript.currentProfile.currentLevel: " + GameManagerScript.currentProfile.currentLevel);
            SaveSystem.SaveListOfProfilesData();
        }
        //Play the correct music based on scene
        switch (mySceneToLoadEnumeration)
        {
            case ScenesToLoadEnumerations.MainMenu1:
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
