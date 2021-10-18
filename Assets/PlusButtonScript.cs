using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusButtonScript : MonoBehaviour
{
    [SerializeField] Text currentLevelTextbox;
    public void IncreaseLevel()
    {
        GameManagerScript.currentLevel++;
        if (GameManagerScript.currentLevel == 4)
        {
            GameManagerScript.currentLevel = 3;
        }
        GameManagerScript.currentProfile.currentLevel = GameManagerScript.currentLevel;
        for (int i = 0; i < ProfileManagerScript.listOfProfiles.Count; i++)
        {
            if (GameManagerScript.currentProfile.userName == ProfileManagerScript.listOfProfiles[i].userName)
            {
                ProfileManagerScript.listOfProfiles[i].currentLevel = GameManagerScript.currentLevel;
            }
        }
        SaveSystem.SaveListOfProfilesData();
        currentLevelTextbox.text = GameManagerScript.currentLevel.ToString();
    }
}
