using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusButtonScript : MonoBehaviour
{
    [SerializeField] Text currentLevelTextbox;
    public void IncreaseLevel()
    {
        GameManagerScript.currentLevel++;
        if (GameManagerScript.currentLevel == 4)
        {
            GameManagerScript.currentLevel = 3;
        }
        currentLevelTextbox.text = GameManagerScript.currentLevel.ToString();
    }
}
