using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioInSequenceScript : ButtonScript
{

    public override void HandleButtonClick()
    {
        AudioController.instance.PlayAudioInSequence(GameSoundEnum.Albanian_Chicken_Doner, GameSoundEnum.Albanian_Hamburger);
    }
}
