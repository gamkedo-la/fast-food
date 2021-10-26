using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToppingOnBurgerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.anyOrderSubmissionEvent, Disappear);
    }

    protected void Appear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    protected void Disappear()
    {
        Debug.Log("inside disappear of parent class ToppingOnBurgerScript.cs");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
