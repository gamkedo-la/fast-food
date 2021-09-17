using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsCanvasBackButtonScript : MonoBehaviour
{
    [SerializeField] GameObject instructionsCanvas;
    [SerializeField] GameObject mainMenuCanvas;

    public void HandleInstructionsCanvasBackButtonClick()
    {
        instructionsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}
