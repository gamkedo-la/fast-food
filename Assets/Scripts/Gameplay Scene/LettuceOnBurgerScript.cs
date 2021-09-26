using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettuceOnBurgerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpLettuceEvent, Appear);
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyBurgerSubmissionEvent, Disappear);
    }

    private void Appear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void Disappear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
