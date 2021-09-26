using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionOnBurgerScript : ToppingOnBurgerScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpOnionEvent, Appear);
    }
}
