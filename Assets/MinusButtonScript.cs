using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinusButtonScript : MonoBehaviour
{
    [SerializeField] Text currentLevelText;
    [SerializeField] TextMeshProUGUI currentLevelTextMeshPro;
    public void DecreaseLevel()
    {
        GameManagerScript.currentLevel--;
        if (GameManagerScript.currentLevel == 0)
        {
            GameManagerScript.currentLevel = 1;
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
