using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWordIntroductionCanvasScript : MonoBehaviour
{
    [SerializeField] GameObject tomatoScriptableObjectStudyCard;
    [SerializeField] GameObject chickenDonerScriptableObjectStudyCard;
    [SerializeField] GameObject onionScriptableObjectStudyCard;
    [SerializeField] GameObject beerScriptableObjectStudyCard;
    [SerializeField] GameObject waterScriptableObjectStudyCard;
    [SerializeField] GameObject redWineScriptableObjectStudyCard;
    [SerializeField] GameObject whiteWineScriptableObjectStudyCard;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        switch (GameManagerScript.currentLevel)
        {
            case 2:
                if (!GameManagerScript.hasIntroducedLevel2)
                {
                    tomatoScriptableObjectStudyCard.SetActive(true);
                    GameManagerScript.hasIntroducedLevel2 = true;
                }
                break;
            case 3:
                if (!GameManagerScript.hasIntroducedLevel3)
                {
                    chickenDonerScriptableObjectStudyCard.SetActive(true);
                    GameManagerScript.hasIntroducedLevel3 = true;
                }
                break;
            case 4:
                if (!GameManagerScript.hasIntroducedLevel4)
                {
                    onionScriptableObjectStudyCard.SetActive(true);
                    GameManagerScript.hasIntroducedLevel4 = true;
                }
                break;
            case 5:
                if (!GameManagerScript.hasIntroducedLevel5)
                {
                    beerScriptableObjectStudyCard.SetActive(true);
                    waterScriptableObjectStudyCard.SetActive(true);
                    GameManagerScript.hasIntroducedLevel5 = true;
                }
                break;
            case 6:
                if (!GameManagerScript.hasIntroducedLevel6)
                {
                    redWineScriptableObjectStudyCard.SetActive(true);
                    GameManagerScript.hasIntroducedLevel6 = true;
                }
                break;
            case 7:
                if (!GameManagerScript.hasIntroducedLevel7)
                {
                    whiteWineScriptableObjectStudyCard.SetActive(true);
                    GameManagerScript.hasIntroducedLevel7 = true;
                }
                break;
        }
    }
}
