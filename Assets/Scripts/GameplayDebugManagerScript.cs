using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayDebugManagerScript : MonoBehaviour
{
    [SerializeField] GameObject levelStatsCanvas;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            EventManagerScript.levelCompletedEvent.Invoke();
            levelStatsCanvas.SetActive(true);
        }
    }
}
