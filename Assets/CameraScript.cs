using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject statsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.levelCompletedEvent, statsCanvas.GetComponent<StatsCanvasScript>().Appear);
    }
}
