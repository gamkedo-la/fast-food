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
            Debug.Log("anything");
            Time.timeScale = 0;
            levelStatsCanvas.SetActive(true);
        }
    }
}
