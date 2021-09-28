using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusButtonScript : MonoBehaviour
{
    [SerializeField] Text currentLevelTextbox;
    [SerializeField] AudioClip buttonClickAudioClip;
    public void IncreaseLevel()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        GameManagerScript.currentLevel++;
        if (GameManagerScript.currentLevel == 5)
        {
            GameManagerScript.currentLevel = 4;
        }
        currentLevelTextbox.text = GameManagerScript.currentLevel.ToString();
    }
}
