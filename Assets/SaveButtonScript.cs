using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButtonScript : ButtonScript
{
    [SerializeField] InputField newPlayerNameInputField;
    [SerializeField] Text savedNameTextField;

    public override void HandleButtonClick()
    {
        savedNameTextField.text = "New profile create for: " + newPlayerNameInputField.text;
    }
}
