using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepSceneAudioButtonScript : ButtonScript
{
    [SerializeField] string languageDictionaryKeyString;

    public void PlayMyAudio()
    {
        switch (GameManagerScript.currentLanguage)
        {
            case Language.English:
                AudioController.instance.PlayAudio(GameSoundEnum.English_I_Would_Like_A);
                break;

            case Language.Albanian:
                AudioController.instance.PlayAudio(GameSoundEnum.Albanian_I_Would_Like_A);
                break;

            case Language.Georgian:
                AudioController.instance.PlayAudio(GameSoundEnum.Georgian_I_Would_Like_A);
                    break;

            case Language.Turkish:
                //AudioController.instance.PlayAudio(GameSoundEnum.Turkish_I_Would_Like_A);
                break;
        }
    }

    public override void HandleButtonClick()
    {
        PlayMyAudio();
    }
}
