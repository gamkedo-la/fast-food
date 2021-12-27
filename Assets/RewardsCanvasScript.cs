using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardsCanvasScript : MonoBehaviour
{
    [SerializeField] GameObject chefsHatImage;
    [SerializeField] GameObject chefsCoatImage;
    [SerializeField] GameObject chefsApronImage;
    [SerializeField] GameObject chefsKnifeImage;
    [SerializeField] GameObject chefsPanImage;
    [SerializeField] GameObject chefsSpatulaImage;
    [SerializeField] GameObject contractImage;

    [SerializeField] TextMeshProUGUI feedbackTextGameObject;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManagerScript.currentLevel: " + GameManagerScript.currentLevel);
        switch (GameManagerScript.currentLevel)
        {
            case 2:
                chefsHatImage.gameObject.SetActive(true);
                feedbackTextGameObject.text = "You've earned a chef's hat!";
                break;
            case 3:
                chefsHatImage.gameObject.SetActive(true);
                chefsCoatImage.gameObject.SetActive(true);
                feedbackTextGameObject.text = "You've earned a chef's jacket!";
                break;
            case 4:
                chefsHatImage.gameObject.SetActive(true);
                chefsCoatImage.gameObject.SetActive(true);
                chefsApronImage.gameObject.SetActive(true);
                feedbackTextGameObject.text = "You've earned a chef's apron!";
                break;
            case 5:
                chefsHatImage.gameObject.SetActive(true);
                chefsCoatImage.gameObject.SetActive(true);
                chefsApronImage.gameObject.SetActive(true);
                chefsKnifeImage.gameObject.SetActive(true);
                feedbackTextGameObject.text = "You've earned a chef's knife!";
                break;
            case 6:
                chefsHatImage.gameObject.SetActive(true);
                chefsCoatImage.gameObject.SetActive(true);
                chefsApronImage.gameObject.SetActive(true);
                chefsKnifeImage.gameObject.SetActive(true);
                chefsPanImage.gameObject.SetActive(true);
                feedbackTextGameObject.text = "You've earned a chef's pan!";
                break;
            case 7:
                chefsHatImage.gameObject.SetActive(true);
                chefsCoatImage.gameObject.SetActive(true);
                chefsApronImage.gameObject.SetActive(true);
                chefsKnifeImage.gameObject.SetActive(true);
                chefsPanImage.gameObject.SetActive(true);
                chefsSpatulaImage.gameObject.SetActive(true);
                feedbackTextGameObject.text = "You've earned a chef's spatula!";
                break;
            case 8:
                contractImage.gameObject.SetActive(true);
                feedbackTextGameObject.text = "You've earned a job contract!";
                break;
        }
    }
}
