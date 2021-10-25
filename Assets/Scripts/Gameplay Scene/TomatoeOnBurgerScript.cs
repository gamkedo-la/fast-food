using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoeOnBurgerScript : ToppingOnBurgerScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        //EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.chefPicksUpTomatoeEvent, Appear);
        EventManagerScript2.AddPlayerPicksUpTomatoEventHandler(Appear);
    }
}
