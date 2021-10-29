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
        //Default for testing in the editor
        GameManagerScript.currentPlatformEnum = CurrentPlatformEnum.Itch;

        //***COMMENT OUT DEFAULT ABOVE HERE AND UNCOMMENT BELOW FOR BUILDS
        //if (Application.platform == RuntimePlatform.WebGLPlayer)
        //{
        //    GameManagerScript.currentPlatformEnum = CurrentPlatformEnum.Itch;
        //}
        //else if (Application.platform == RuntimePlatform.Android)
        //{
        //    GameManagerScript.currentPlatformEnum = CurrentPlatformEnum.Android;
        //}

        Debug.Log("GameManagerScript.currentPlatformEnum: " + GameManagerScript.currentPlatformEnum.ToString());

        if (!GameManagerScript.progressToNextLevelEventHasBeenAdded)
        {
            EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelCompletedEvent, ProgressToNextLevel);
            GameManagerScript.progressToNextLevelEventHasBeenAdded = true;
        }
        DontDestroyOnLoad(this.gameObject);
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
