using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsCanvasScript : MonoBehaviour
{
    public void Appear()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
