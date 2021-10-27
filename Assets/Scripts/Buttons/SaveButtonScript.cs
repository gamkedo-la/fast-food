using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveButtonScript : ButtonScript
{
    [SerializeField] TMP_InputField newPlayerNameInputField;
    [SerializeField] TextMeshProUGUI savedNameTextField;

    public override void HandleButtonClick()
    {
        Debug.Log("anything");
        if (newPlayerNameInputField.text == "")
        {
            newPlayerNameInputField.text = "You didn't enter a name";
            return;
        }
        
        savedNameTextField.text = "New profile create for: " + newPlayerNameInputField.text;
        GameManagerScript.currentProfile = new ProfileDataScript(newPlayerNameInputField.text);
        
        ProfileManagerScript.listOfProfiles.Add(GameManagerScript.currentProfile);
        
        SaveSystem.SaveListOfProfilesData();
     
        GameManagerScript.currentLevel = 1;
    }
}
