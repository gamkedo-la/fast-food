using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDonerBaseFoodScript : BaseFoodScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        EventManagerScript.AddEventHandlerToTargetEvent(EventManagerScript.playerSelectsChickenDonerEvent, HandlePlayerSelectsBaseFoodEvent);
    }

    public override void HandlePlayerSelectsBaseFoodEvent()
    {
        base.HandlePlayerSelectsBaseFoodEvent();

        GameManagerScript.chefHasChickenDoner = true;
    }

    public override void ResetBaseFood()
    {
        base.ResetBaseFood();
        GameManagerScript.chefHasChickenDoner = false;
        GameManagerScript.chickenDonerHasLettuce = false;
        GameManagerScript.chickenDonerHasTomatoe = false;
        GameManagerScript.chickenDonerHasOnion = false;
    }
}
