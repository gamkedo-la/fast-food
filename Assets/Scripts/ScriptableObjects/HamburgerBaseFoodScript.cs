using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerBaseFoodScript : BaseFoodScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.playerSelectsBurgerEvent, HandlePlayerSelectsBaseFoodEvent);
    }

    public override void HandlePlayerSelectsBaseFoodEvent()
    {
        base.HandlePlayerSelectsBaseFoodEvent();

        GameManagerScript.chefHasBurger = true;
    }

    public override void ResetBaseFood()
    {
        base.ResetBaseFood();
        GameManagerScript.chefHasBurger = false;
        GameManagerScript.burgerHasLettuce = false;
        GameManagerScript.burgerHasTomatoe = false;
        GameManagerScript.burgerHasOnion = false;
    }
}
