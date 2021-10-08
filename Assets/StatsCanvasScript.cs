using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsCanvasScript : MonoBehaviour
{
    public void Appear()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
