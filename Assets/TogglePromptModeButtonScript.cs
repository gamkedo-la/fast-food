using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePromptModeButtonScript : ButtonScript
{
    [SerializeField] Text currentModeTextbox;

    private void Start()
    {
        currentModeTextbox.text = GameManagerScript.currentCustomerPromptType.ToString();
    }
    public override void HandleButtonClick()
    {
        if (GameManagerScript.currentCustomerPromptType == CustomerPromptTypeEnumerables.Text)
        {
            GameManagerScript.currentCustomerPromptType = CustomerPromptTypeEnumerables.Audio;
        }
        else
        {
            GameManagerScript.currentCustomerPromptType = CustomerPromptTypeEnumerables.Text;
        }
        currentModeTextbox.text = GameManagerScript.currentCustomerPromptType.ToString();

        //Play button sound
        AudioController.instance.PlayAudio(GameSoundEnum.UI_Button);
    }
}
