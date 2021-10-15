using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProfileDataScript
{
    public string userName;
    public int currentLevel;

    public ProfileDataScript (string newUserName)
    {
        userName = newUserName;
        currentLevel = 1;
        GameManagerScript.listOfProfiles.Add(this);
    }
}
