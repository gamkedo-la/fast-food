using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
