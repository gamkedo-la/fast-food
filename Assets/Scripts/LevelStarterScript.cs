using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStarterScript : MonoBehaviour
{
    [SerializeField] Text numberOfCorrectOrdersTextbox;
    [SerializeField] Text numberOfIncorrectOrdersTextbox;
    [SerializeField] Text accuracyTextbox;
    [SerializeField] Text speedBonusTextbox;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerScript.numberOfCorrectOrders = 0;
        GameManagerScript.numberOfIncorrectOrders = 0;
        GameManagerScript.accuracy = 0;
        GameManagerScript.speedBonus = 0;

        numberOfCorrectOrdersTextbox.text = "Correct Orders: ";
        numberOfIncorrectOrdersTextbox.text = "Incorrect Orders: ";
        accuracyTextbox.text = "Accuracy: ";
        speedBonusTextbox.text = "Speed Bonus Points: ";
    }
}
