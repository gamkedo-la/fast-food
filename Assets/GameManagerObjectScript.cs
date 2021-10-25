using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelCompletedEvent, ProgressToNextLevel);
        DontDestroyOnLoad(this.gameObject);
    }

    public static void ProgressToNextLevel()
    {
        GameManagerScript.currentLevel++;
        
        if (GameManagerScript.currentProfile != null) {
            GameManagerScript.currentProfile.currentLevel = GameManagerScript.currentLevel;
        } else {
            Debug.Log("ERROR - missing player profile");
        }

        SaveSystem.SaveListOfProfilesData();
    }
}
