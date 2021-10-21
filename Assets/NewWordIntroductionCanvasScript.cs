using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWordIntroductionCanvasScript : MonoBehaviour
{
    [SerializeField] GameObject tomatoScriptableObjectStudyCard;
    [SerializeField] GameObject chickenDonerScriptableObjectStudyCard;
    [SerializeField] GameObject onionScriptableObjectStudyCard;

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
        }
    }
}
