using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentPlatformEnum
{
    Android,
    Itch
}

public class GameManagerObjectScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

        HandleCurrentPlatform();

        if (!GameManagerScript.progressToNextLevelEventHasBeenAdded)
        {
            EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelCompletedEvent, ProgressToNextLevel);
            GameManagerScript.progressToNextLevelEventHasBeenAdded = true;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Use the first line to test in the editor, use the if/else if when building to Android/Itch
    /// </summary>
    private void HandleCurrentPlatform()
    {
        //GameManagerScript.currentPlatformEnum = CurrentPlatformEnum.Itch;

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            GameManagerScript.currentPlatformEnum = CurrentPlatformEnum.Itch;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            GameManagerScript.currentPlatformEnum = CurrentPlatformEnum.Android;
        }
    }    

    public static void ProgressToNextLevel()
    {
        GameManagerScript.currentLevel++;
        AudioController.instance.StopAudio(GameSoundEnum.SFX_Customer_Impatience);
        
        if (GameManagerScript.currentProfile != null) {
            GameManagerScript.currentProfile.currentLevel = GameManagerScript.currentLevel;
        } else {
            Debug.Log("ERROR - missing player profile");
        }

        SaveSystem.SaveListOfProfilesData();
    }
}
