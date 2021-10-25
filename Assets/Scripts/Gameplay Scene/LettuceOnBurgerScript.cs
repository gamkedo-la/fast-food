using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettuceOnBurgerScript : ToppingOnBurgerScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpLettuceEvent, Appear);
        EventManagerScript2.AddPlayerPicksUpLettuceEventHandler(Appear);
    }
}
