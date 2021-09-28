using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinusButtonScript : MonoBehaviour
{
    [SerializeField] Text currentLevelText;
    [SerializeField] AudioClip buttonClickAudioClip;
    public void DecreaseLevel()
    {
        AudioManagerScript.audioManagerScript.PlayOneShot(buttonClickAudioClip);
        GameManagerScript.currentLevel--;
        if (GameManagerScript.currentLevel == 0)
        {
            GameManagerScript.currentLevel = 1;
        }
        currentLevelText.text = GameManagerScript.currentLevel.ToString();
    }
}
