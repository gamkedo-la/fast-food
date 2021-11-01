using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlusButtonScript : MonoBehaviour
{
    [SerializeField] Text currentLevelTextbox;
    [SerializeField] TextMeshProUGUI currentLevelTextMeshPro;

    public void IncreaseLevel()
    {
        GameManagerScript.currentLevel++;
        if (GameManagerScript.currentLevel == 5)
        {
            GameManagerScript.currentLevel = 4;
        }

        if (GameManagerScript.currentProfile != null)
        {
            GameManagerScript.currentProfile.currentLevel = GameManagerScript.currentLevel;
        }

        for (int i = 0; i < ProfileManagerScript.listOfProfiles.Count; i++)
        {
            if (GameManagerScript.currentProfile.userName == ProfileManagerScript.listOfProfiles[i].userName)
            {
                ProfileManagerScript.listOfProfiles[i].currentLevel = GameManagerScript.currentLevel;
            }
        }
        SaveSystem.SaveListOfProfilesData();
        currentLevelTextMeshPro.text = GameManagerScript.currentLevel.ToString();
    }
}
