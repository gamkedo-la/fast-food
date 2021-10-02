using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePromptModeButtonScript : ButtonScript
{
    [SerializeField] Text currentModeTextbox;
    public override void HandleButtonClick()
    {
        Debug.Log("anything");
        if (GameManagerScript.currentCustomerPromptType == CustomerPromptTypeEnumerables.Text)
        {
            GameManagerScript.currentCustomerPromptType = CustomerPromptTypeEnumerables.Audio;
        }
        else
        {
            GameManagerScript.currentCustomerPromptType = CustomerPromptTypeEnumerables.Text;
        }
        Debug.Log("GameManagerScript.currentCustomerPromptType.ToString();" + GameManagerScript.currentCustomerPromptType.ToString());
        currentModeTextbox.text = GameManagerScript.currentCustomerPromptType.ToString();
    }
}
