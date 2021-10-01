using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToppingOnBurgerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyBurgerSubmissionEvent, Disappear);
    }

    protected void Appear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    protected void Disappear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
