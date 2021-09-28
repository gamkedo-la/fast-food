using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusButtonScript : MonoBehaviour
{
    [SerializeField] Text reviewLevelTextbox;

    public void IncreaseLevel()
    {
        GameManagerScript.currentLevel++;
        reviewLevelTextbox.text = "Level to Start from: " + GameManagerScript.currentLevel;
    }
}
